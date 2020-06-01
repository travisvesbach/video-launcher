using System;
using System.Collections.Generic;
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
    public class Movie
    {
        // directory class
        public DirectoryInfo MovieDirectory { get; set; }

        public string Name { get; set; }
        public string Video_type { get; set; }

        //files in directory
        public string File_video { get; set; }
        public string File_nfo { get; set; }
        public BitmapImage Img_poster { get; set; }
        public string Img_thumb { get; set; }
        public List<string> Subtitles = new List<string>();

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
        public string Set { get; set; }
        public List<string> Genres { get; set; }
        public string GenreString { get; set; }
        public List<string> Tags { get; set; }
        public string TagString { get; set; }

        public string DisplayName { get; set; }

        
        private ICommand _play;
        private ICommand _openTrailer;


        public Movie(DirectoryInfo dir)
        {
            MovieDirectory = dir;
            Name = MovieDirectory.Name;
            ProcessDirectory();
            Console.WriteLine(Name);
            if (File_nfo != null)
            {
                ReadNFO();
                if (Genres != null)
                {
                    GenreString = string.Join(" / ", Genres);
                }
                if (Tags != null)
                {
                    TagString = string.Join(" / ", Tags);
                }
            }
            DisplayName = ((Title != null && Year != null) ? Title + " (" + Year + ")" : Name);
        }


        // Process the list of files found in the directory.
        public void ProcessDirectory()
        {
            string[] fileEntries = Directory.GetFiles(MovieDirectory.FullName);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

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
            }
            else if (fileExtension == ".srt")
            {
                SetSubtitles(path);
            }
            else
            {
                File_video = path;
                Video_type = fileExtension.TrimStart('.');
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
            else if (fileName.Contains(".jp"))
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
                    case "tag":
                        if (Tags == null)
                        {
                            Tags = new List<string>();
                        }
                        Tags.Add(node.InnerText);
                        break;
                    case "director":
                        Director = node.InnerText;
                        break;
                    case "set":
                        Set = node.InnerText;
                        break;
                    case "country":
                        Country = node.InnerText;
                        break;
                    case "studio":
                        Studio = node.InnerText;
                        break;
                }
            }
        }

        public BitmapImage Thumb
        {
            get { return (Img_thumb != null) ? new BitmapImage(new Uri(Img_thumb, UriKind.Absolute)) : null; }
        }

        // commands
        public bool CanExecute
        {
            get { return true; }
        }

        public ICommand CommandPlay
        {
            get { return _play ?? (_play = new CommandHandler(() => Play(), () => CanExecute)); }
        }

        private void Play()
        {
            System.Diagnostics.Process.Start(@File_video);
        }

        public ICommand CommandOpenTrailer
        {
            get { return _openTrailer ?? (_openTrailer = new CommandHandler(() => OpenTrailer(), () => CanExecute)); }
        }

        private void OpenTrailer()
        {
            OpenUri(Trailer);
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
