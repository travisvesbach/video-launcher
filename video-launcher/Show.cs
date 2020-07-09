using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;

namespace video_launcher
{
    public class Show : INotifyPropertyChanged
    {
        // directory class
        public DirectoryInfo ShowDirectory { get; set; }

        public string Name { get; set; }
        public int SeasonCount { get; set; }
        public string SeasonCountString { get; set; }
        public int EpisodeCount { get; set; }
        public string EpisodeCountString { get; set; }
        public ObservableCollection<Episode> Episodes { get; set; }
        public bool Specials { get; set; }

        //files in directory
        public string File_video { get; set; }
        public string File_nfo { get; set; }
        public BitmapImage Img_poster { get; set; }
        public string Img_thumb { get; set; }
        public string Img_fanart { get; set; }

        //from nfo file
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public string Tagline { get; set; }
        public string Runtime { get; set; }
        public string Trailer { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public string Studio { get; set; }
        public List<string> Genres { get; set; }
        public string GenreString { get; set; }
        public string Watched { get; set; }
        public DateTime? LastWatched { get; set; }
        public string LastWatchedString { get; set; }

        public string DisplayName { get; set; }


        private ICommand _openTrailer;
        private ICommand _toggleWatched;

        public event PropertyChangedEventHandler PropertyChanged;

        public Show(DirectoryInfo dir)
        {
            ShowDirectory = dir;
            Name = ShowDirectory.Name;
            ProcessDirectory();
            Console.WriteLine(Name);
        }


        // Process the list of files found in the directory and set defaults if missing files
        public void ProcessDirectory()
        {
            string[] fileEntries = Directory.GetFiles(ShowDirectory.FullName);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

            if (Img_poster == null)
            {
                Img_poster = new BitmapImage(new Uri("images/filmstrip.png", UriKind.Relative));
                Img_poster.Freeze();
            }
            if (File_nfo == null)
            {
                CreateNFO();
            }
            DisplayName = ((Title != null && Year != null) ? Title + " (" + Year + ")" : Name);

        }

        // Insert logic for processing found file here.
        public void ProcessFile(string path)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExtension = Path.GetExtension(path);

            if (fileExtension == ".png" || fileExtension == ".jpg")
            {
                SetImage(path);
            }
            else if (fileExtension == ".nfo")
            {
                File_nfo = path;
                ReadNFO();
                if (Genres != null)
                {
                    GenreString = string.Join(" / ", Genres);
                }
            }
        }

        // Use background worker to call ProcessSeasons
        public void ProcessSeasonsWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (obj, e) => ProcessSeasons();
            worker.RunWorkerAsync();
        }

        // Process all the season directories and create a ObservableCollection of episodes
        public void ProcessSeasons()
        {
            string[] subdirectoryEntries = Directory.GetDirectories(ShowDirectory.FullName);
            int seasonCounter = 0;
            int episodeCounter = 0;
            Episodes = new ObservableCollection<Episode>();
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo dir = new DirectoryInfo(subdirectory);
                if (dir.Name.Contains("Season"))
                {
                    seasonCounter++;
                    int seasonEpisodeCounter = 0;
                    string[] SeasonFiles = Directory.GetFiles(dir.FullName);
                    foreach (string fileName in SeasonFiles)
                    {
                        string fileExtension = Path.GetExtension(fileName);
                        if (fileExtension != ".nfo" && fileExtension != ".jpg" && fileExtension != ".png" && fileExtension != ".gif")
                        {
                            episodeCounter++;
                            seasonEpisodeCounter++;
                            Episodes.Add(new Episode(fileName, seasonCounter, seasonEpisodeCounter, this));
                        }
                    }
                }
                if (dir.Name.Contains("Special"))
                {
                    Specials = true;
                    int specialEpisodeCounter = 0;
                    string[] SeasonFiles = Directory.GetFiles(dir.FullName);
                    foreach (string fileName in SeasonFiles)
                    {
                        string fileExtension = Path.GetExtension(fileName);
                        if (fileExtension != ".nfo" && fileExtension != ".jpg" && fileExtension != ".png" && fileExtension != ".gif")
                        {
                            episodeCounter++;
                            specialEpisodeCounter++;
                            Episodes.Add(new Episode(fileName, 0, specialEpisodeCounter, this));
                        }
                    }
                }
            }
            SeasonCount = seasonCounter;
            SeasonCountString = seasonCounter.ToString();
            EpisodeCount = episodeCounter;
            EpisodeCountString = episodeCounter.ToString();
            NotifyPropertyChanged("SeasonCountString");
            NotifyPropertyChanged("EpisodeCountString");

        }

        // Set image path based on path file name
        public void SetImage(string path)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            switch (fileName)
            {
                case "poster":
                    Img_poster = new BitmapImage();
                    Img_poster.BeginInit();
                    Img_poster.UriSource = new Uri(path, UriKind.Absolute);
                    Img_poster.CreateOptions = BitmapCreateOptions.DelayCreation;
                    Img_poster.CacheOption = BitmapCacheOption.None;
                    Img_poster.DecodePixelWidth = 185;
                    Img_poster.DecodePixelHeight = 278;
                    Img_poster.EndInit();
                    Img_poster.Freeze();
                    break;
                case "thumb":
                    Img_thumb = path;
                    break;
                case "fanart":
                    Img_fanart = path;
                    break;
            }
        }


        public void ReadNFO()
        {
            XmlDocument nfo = new XmlDocument();
            try
            {
                nfo.Load(File_nfo);
            }
            catch (Exception ex)
            {
                Plot = "Could not load nfo file. Exception message: " + ex.Message;
                return;
            }

            foreach (XmlNode node in nfo.DocumentElement.ChildNodes)
            {
                string text = node.InnerText; //or loop through its children as well
                switch (node.Name)
                {
                    case "title":
                        Title = node.InnerText;
                        break;
                    case "originaltitle":
                        if (node.InnerText != Title)
                        {
                            OriginalTitle = node.InnerText;
                        }
                        break;
                    case "year":
                        Year = node.InnerText;
                        break;
                    case "plot":
                        Plot = node.InnerText;
                        break;
                    case "tagline":
                        Tagline = node.InnerText;
                        break;
                    case "runtime":
                        Runtime = node.InnerText;
                        break;
                    case "trailer":
                        if (IsValidUri(node.InnerText))
                        {
                            Trailer = node.InnerText;
                        }
                        break;
                    case "genre":
                        if (Genres == null)
                        {
                            Genres = new List<string>();
                        }
                        Genres.Add(node.InnerText);
                        break;
                    case "director":
                        Director = node.InnerText;
                        break;
                    case "country":
                        Country = node.InnerText;
                        break;
                    case "studio":
                        Studio = node.InnerText;
                        break;
                    case "iswatched":
                        Watched = node.InnerText;
                        break;
                    case "lastwatched":
                        LastWatched = DateTime.Parse(node.InnerText);
                        LastWatchedString = LastWatched.Value.ToString("d");
                        break;
                }
            }
        }

        // Create nfo file with explanation plot and watched status
        public void CreateNFO()
        {
            File_nfo = ShowDirectory.FullName + "\\tvshow.nfo";
            XmlDocument nfo = new XmlDocument();
            nfo.AppendChild(nfo.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlNode tvshowNode = nfo.CreateElement("tvshow");
            nfo.AppendChild(tvshowNode);
            
            Plot = ".nfo file not found. This simple one was created to track iswatched and lastwatched variables.  If you create a .nfo file later, it might overwrite these values.";
            Watched = "false";

            XmlNode plotNode = tvshowNode.AppendChild(nfo.CreateElement("plot"));
            plotNode.InnerText = Plot;
            XmlNode iswatchedNode = tvshowNode.AppendChild(nfo.CreateElement("iswatched"));
            iswatchedNode.InnerText = Watched;

            try
            {
                nfo.Save(File_nfo);
            }
            catch (Exception ex)
            {
                Plot = "nfo file not found and could not create a new one" + ex.Message;
                return;
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public BitmapImage Thumb
        {
            get
            {
                if (Img_thumb != null)
                {
                    return new BitmapImage(new Uri(Img_thumb, UriKind.Absolute));
                }
                else if (Img_fanart != null)
                {
                    return new BitmapImage(new Uri(Img_fanart, UriKind.Absolute));
                }
                return null;
            }
        }

        public string WatchedToggleText
        {
            get
            {
                if (File_nfo == null)
                {
                    return "No nfo file";
                }
                return (Watched == "false" ? "Mark wateched" : "Mark unwatched");
            }
        }

        public string WatchedIcon
        {
            get
            {
                if (Watched == "true")
                {
                    return "Solid_CheckCircle";
                }
                else if (Watched == "in-progress")
                {
                    return "Solid_Eye";
                }
                else
                {
                    return "Solid_TimesCircle";
                }
            }
        }

        public string WatchedContextIcon
        {
            get { return (Watched == "false" ? "Solid_CheckCircle" : "Solid_TimesCircle"); }
        }

        public string WatchedButton
        {
            get
            {
                if (Watched == "true")
                {
                    return "Watched";
                }
                else if (Watched == "in-progress")
                {
                    return "In Progress";
                }
                else
                {
                    return "Unwatched";
                }
            }
        }


        // commands
        public bool CanExecute
        {
            get { return true; }
        }

        public bool CanExecuteEditNFO
        {
            get
            {
                if (File_nfo != null)
                {
                    return true;
                }
                return false;
            }
        }


        public ICommand CommandOpenTrailer
        {
            get { return _openTrailer ?? (_openTrailer = new CommandHandler(() => OpenTrailer(), () => CanExecute)); }
        }

        private void OpenTrailer()
        {
            OpenUri(Trailer);
        }

        public ICommand CommandToggleWatched
        {
            get { return _toggleWatched ?? (_toggleWatched = new CommandHandler(() => ToggleWatched(), () => CanExecuteEditNFO)); }
        }

        public void ToggleWatched(string target = null)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("This will update all its episodes too. Continue?", DisplayName + "'s watched status change", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.No)
            {
                return;
            }

            if (target != null)
            {
                Watched = (target == "watched" ? "true" : "false");
            }
            else
            {
                Watched = (Watched == "true" ? "false" : "true");
            }

            // load nfo file
            XmlDocument nfo = new XmlDocument();
            try
            {
                nfo.Load(File_nfo);
            }
            catch (Exception)
            {
                return;
            }

            // create iswatched node if it doesn't exist; save new watched status
            XmlNode nfoIsWatched = nfo.SelectSingleNode("//tvshow/iswatched");
            if (nfoIsWatched == null)
            {
                nfoIsWatched = nfo.SelectSingleNode("//tvshow").AppendChild(nfo.CreateElement("iswatched"));
            }
            nfoIsWatched.InnerText = Watched;

            // if watched == true: create, set, and add lastwatched node; else remove node
            LastWatched = DateTime.Now;
            XmlNode nfoLastWatched = nfo.SelectSingleNode("//tvshow/lastwatched");
            if (Watched == "true")
            {
                if (nfoLastWatched == null)
                {
                    nfoLastWatched = nfo.SelectSingleNode("//tvshow").AppendChild(nfo.CreateElement("lastwatched"));

                }
                LastWatchedString = LastWatched.Value.ToString("d");
                nfoLastWatched.InnerText = LastWatchedString;
            }
            else
            {
                if (nfoLastWatched != null)
                {
                    nfo.SelectSingleNode("//tvshow").RemoveChild(nfoLastWatched);
                }
                LastWatched = null;
                LastWatchedString = null;
            }
            nfo.Save(File_nfo);

            // use background worker to edit watched status in all episodes
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (obj, e) => ToggleEpisodesWatched();
            worker.RunWorkerAsync();

            NotifyPropertyChanged("Watched");
            NotifyPropertyChanged("LastWatched");
            NotifyPropertyChanged("LastWatchedString");
            NotifyPropertyChanged("WatchedToggleText");
            NotifyPropertyChanged("WatchedIcon");
            NotifyPropertyChanged("WatchedButton");
            NotifyPropertyChanged("WatchedContextIcon");
        }

        //edit watched status in all episodes
        public void ToggleEpisodesWatched()
        {
            if (Episodes == null)
            {
                ProcessSeasons();
            }
            string episodeTarget = (Watched == "true" ? "watched" : "unwatched");
            foreach (Episode episode in Episodes)
            {
                episode.ToggleWatched(episodeTarget, true);
            }
        }

        //called from episode when an episode watched status is changed
        public void EpisodeWatched()
        {

            int watchedCount = 0;
            foreach (Episode episode in Episodes)
            {
                if (episode.Watched == "true")
                {
                    watchedCount++;
                }
            }

            Console.WriteLine("watched count: " + watchedCount.ToString() + "    episode count:" + EpisodeCount.ToString());

            if (watchedCount == 0)
            {
                Watched = "false";
            }
            else if (watchedCount == EpisodeCount)
            {
                Watched = "true";
            }
            else
            {
                Watched = "in-progress";
            }

            // load nfo file
            XmlDocument nfo = new XmlDocument();
            try
            {
                nfo.Load(File_nfo);
            }
            catch (Exception)
            {
                return;
            }

            // create iswatched node if it doesn't exist; save new watched status
            XmlNode nfoWatched = nfo.SelectSingleNode("//tvshow/iswatched");
            if (nfoWatched == null)
            {
                nfoWatched = nfo.SelectSingleNode("//tvshow").AppendChild(nfo.CreateElement("iswatched"));
            }
            nfoWatched.InnerText = Watched;

            // if watched == true: create, set, and add lastwatched node; else remove node
            LastWatched = DateTime.Now;
            XmlNode nfoLastWatched = nfo.SelectSingleNode("//tvshow/lastwatched");
            if (Watched == "true" || Watched == "in-progress")
            {
                if (nfoLastWatched == null)
                {
                    nfoLastWatched = nfo.SelectSingleNode("//tvshow").AppendChild(nfo.CreateElement("lastwatched"));

                }
                LastWatchedString = LastWatched.Value.ToString("d");
                nfoLastWatched.InnerText = LastWatchedString;
            }
            else
            {
                if (nfoLastWatched != null)
                {
                    nfo.SelectSingleNode("//tvshow").RemoveChild(nfoLastWatched);
                }
                LastWatched = null;
                LastWatchedString = null;
            }
            nfo.Save(File_nfo);

            NotifyPropertyChanged("Watched");
            NotifyPropertyChanged("LastWatched");
            NotifyPropertyChanged("LastWatchedString");
            NotifyPropertyChanged("WatchedToggleText");
            NotifyPropertyChanged("WatchedIcon");
            NotifyPropertyChanged("WatchedButton");
            NotifyPropertyChanged("WatchedContextIcon");
        }

        //static functions
        public static bool OpenUri(string uri)
        {
            if (!IsValidUri(uri))
            {
                return false;
            }
            System.Diagnostics.Process.Start(uri);
            return true;
        }

        public static bool IsValidUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                return false;
            }
            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp))
            {
                return false;
            }
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }
    }
}
