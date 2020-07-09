using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;

namespace video_launcher
{
    public class Episode : INotifyPropertyChanged
    {

        public string Name { get; set; }
        public string Video_type { get; set; }
        public Show Parent { get; set; }

        //files in directory
        public string File_video { get; set; }
        public string File_nfo { get; set; }
        public BitmapImage Img_poster { get; set; }
        public string Img_thumb { get; set; }
        public List<string> Subtitles = new List<string>();
        public string SubtitlesString { get; set; }

        //from nfo file
        public string Title { get; set; }
        public string ShowTitle { get; set; }
        public string Season { get; set; }
        public string EpisodeNumber { get; set; }
        public string Plot { get; set; }
        public string Aired { get; set; }
        public string Watched { get; set; }
        public DateTime? LastWatched { get; set; }
        public string LastWatchedString { get; set; }

        public string DisplayName { get; set; }


        private ICommand _play;
        private ICommand _toggleWatched;

        public event PropertyChangedEventHandler PropertyChanged;

        public Episode(string videoPath, int seasonNum, int episodeNum, Show parent)
        {
            Parent = parent;
            ProcessVideoPath(videoPath);
            if (Season == null)
            {
                Season = seasonNum.ToString();
            }
            if (EpisodeNumber == null)
            {
                EpisodeNumber = episodeNum.ToString();
            }
        }

        
        public void ProcessVideoPath(string videoPath)
        {
            string fileName = Path.GetFileNameWithoutExtension(videoPath);
            string fileExtension = Path.GetExtension(videoPath);
            File_video = videoPath;
            Name = fileName;
            Video_type = fileExtension.TrimStart('.');

            string filePathWithoutExtension = Path.GetDirectoryName(videoPath) + "\\" + fileName;
            string tempNFOPath = filePathWithoutExtension + ".nfo";
            if (File.Exists(tempNFOPath))
            {
                File_nfo = tempNFOPath;
                ReadNFO();
            }
            else
            {
                CreateNFO();
            }
            
            DisplayName = (Title != null ? Title : Name);

            if (File.Exists(filePathWithoutExtension + ".jpg"))
            {
                Img_thumb = filePathWithoutExtension + ".jpg";
            }
            else if (File.Exists(filePathWithoutExtension + ".png"))
            {
                Img_thumb = filePathWithoutExtension + ".png";
            }
            else if (File.Exists(filePathWithoutExtension + ".gif"))
            {
                Img_thumb = filePathWithoutExtension + ".gif";
            }
            
        }

        // Set image path based on path file name
        public void SetImage(string path)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            switch (fileName)
            {
                case "poster":
                    Img_poster = new BitmapImage(new Uri(path, UriKind.Absolute));
                    Img_poster.Freeze();
                    break;
                case "thumb":
                    Img_thumb = path;
                    break;
            }
        }

        // Add subtitle language to list
        public void SetSubtitles(string path)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            if (fileName.Contains(".en"))
            {
                Subtitles.Add("English");
            }
            else if (fileName.Contains(".ja"))
            {
                Subtitles.Add("Japanese");
            }
        }

        public void ReadNFO()
        {
            XmlDocument nfo = new XmlDocument();
            try
            {
                nfo.Load(File_nfo);
            }
            catch(Exception ex)
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
                    case "showtitle":
                        ShowTitle = node.InnerText;
                        break;
                    case "season":
                        Season = node.InnerText;
                        break;
                    case "episode":
                        EpisodeNumber = node.InnerText;
                        break;
                    case "plot":
                        Plot = node.InnerText;
                        break;
                    case "aired":
                        Aired = DateTime.Parse(node.InnerText).ToString("d");
                        break;
                    case "watched":
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
            string directory = Path.GetDirectoryName(File_video);
            File_nfo = directory + "\\" + Name + ".nfo";
            XmlDocument nfo = new XmlDocument();
            nfo.AppendChild(nfo.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlNode episodedetailsNode = nfo.CreateElement("episodedetails");
            nfo.AppendChild(episodedetailsNode);

            Plot = ".nfo file not found. This simple one was created to track watched and last watched variables.  If you create a .nfo file later, it might overwrite these values.";
            Watched = "false";

            NotifyPropertyChanged(Plot);
            NotifyPropertyChanged(Watched);

            XmlNode plotNode = episodedetailsNode.AppendChild(nfo.CreateElement("plot"));
            plotNode.InnerText = Plot;
            XmlNode watchedNode = episodedetailsNode.AppendChild(nfo.CreateElement("watched"));
            watchedNode.InnerText = Watched;

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
            get { return (Img_thumb != null) ? new BitmapImage(new Uri(Img_thumb, UriKind.Absolute)) : null; }
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
                else
                {
                    return "Unwatched";
                }
            }
        }

        public string EpisodeNumberString
        {
            get
            {
                string numString = EpisodeNumber.ToString() + ".";
                if (numString.Length == 2)
                {
                    numString = "0" + numString;
                }
                return numString;
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

        public ICommand CommandPlay
        {
            get { return _play ?? (_play = new CommandHandler(() => Play(), () => CanExecute)); }
        }

        private void Play()
        {
            System.Diagnostics.Process.Start(@File_video);
            ToggleWatched("watched");
        }

        public ICommand CommandToggleWatched
        {
            get { return _toggleWatched ?? (_toggleWatched = new CommandHandler(() => ToggleWatched(), () => CanExecuteEditNFO)); }
        }

        public void ToggleWatched(string target = null, bool fromParent = false)
        {
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

            // create watched node if it doesn't exist; save new watched status
            XmlNode nfoWatched = nfo.SelectSingleNode("//episodedetails/watched");
            if (nfoWatched == null)
            {
                nfoWatched = nfo.SelectSingleNode("//episodedetails").AppendChild(nfo.CreateElement("watched"));
            }
            nfoWatched.InnerText = Watched.ToString().ToLower();

            // if watched == true: create, set, and add lastwatched node; else remove node
            LastWatched = DateTime.Now;
            XmlNode nfoLastWatched = nfo.SelectSingleNode("//episodedetails/lastwatched");
            if (Watched == "true")
            {
                if (nfoLastWatched == null)
                {
                    nfoLastWatched = nfo.SelectSingleNode("//episodedetails").AppendChild(nfo.CreateElement("lastwatched"));

                }
                LastWatchedString = LastWatched.Value.ToString("d");
                nfoLastWatched.InnerText = LastWatchedString;
            }
            else
            {
                if (nfoLastWatched != null)
                {
                    nfo.SelectSingleNode("//episodedetails").RemoveChild(nfoLastWatched);
                }
                LastWatched = null;
                LastWatchedString = null;
            }

            nfo.Save(File_nfo);

            if (!fromParent)
            {
                Parent.EpisodeWatched();
            }

            NotifyPropertyChanged("Watched");
            NotifyPropertyChanged("LastWatched");
            NotifyPropertyChanged("LastWatchedString");
            NotifyPropertyChanged("WatchedToggleText");
            NotifyPropertyChanged("WatchedIcon");
            NotifyPropertyChanged("WatchedButton");
            NotifyPropertyChanged("WatchedContextIcon");
        }
    }
}
