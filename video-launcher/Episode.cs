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
        // directory class
        public DirectoryInfo MovieDirectory { get; set; }

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
        public bool Watched { get; set; }
        public DateTime? LastWatched { get; set; }
        public string LastWatchedString { get; set; }

        public string DisplayName { get; set; }


        private ICommand _play;
        private ICommand _toggleWatched;

        public event PropertyChangedEventHandler PropertyChanged;

        public Episode(string videoPath)
        {
            Console.WriteLine(videoPath);
            ProcessVideoPath(videoPath);
        }

        
        public void ProcessVideoPath(string videoPath)
        {
            string fileName = Path.GetFileNameWithoutExtension(videoPath);
            string fileExtension = Path.GetExtension(videoPath);
            File_video = videoPath;
            Name = fileName;
            Video_type = fileExtension.TrimStart('.');

            string filePathWithoutExtension = Path.GetDirectoryName(videoPath) + "fileName";
            string tempNFOPath = filePathWithoutExtension + ".nfo";
            if (File.Exists(tempNFOPath))
            {
                File_nfo = tempNFOPath;
                ReadNFO();
            }
            else
            {
                Plot = "No .nfo file found for this episode";
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
            nfo.Load(File_nfo);

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
                        Aired = node.InnerText;
                        break;
                    case "watched":
                        Watched = (node.InnerText == "false" ? false : true);
                        break;
                    case "lastwatched":
                        LastWatched = DateTime.Parse(node.InnerText);
                        LastWatchedString = LastWatched.Value.ToString("MMMM dd, yyyy");
                        break;
                }
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
                return (Watched ? "Mark unwateched" : "Mark watched");
            }
        }

        public string WatchedIcon
        {
            get { return (Watched ? "Solid_CheckCircle" : "Solid_TimesCircle"); }
        }

        public string WatchedContextIcon
        {
            get { return (Watched ? "Solid_TimesCircle" : "Solid_CheckCircle"); }
        }

        public string WatchedButton
        {
            get { return (Watched ? "Watched" : "Unwatched"); }
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

        public void ToggleWatched(string target = null)
        {
            if (target != null)
            {
                Watched = (target == "watched" ? true : false);
            }
            else
            {
                Watched = (Watched == true ? false : true);
            }

            // load nfo file
            XmlDocument nfo = new XmlDocument();
            nfo.Load(File_nfo);

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
            if (Watched)
            {
                if (nfoLastWatched == null)
                {
                    nfoLastWatched = nfo.SelectSingleNode("//episodedetails").AppendChild(nfo.CreateElement("lastwatched"));

                }
                LastWatchedString = LastWatched.Value.ToString("MMMM dd, yyyy");
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
