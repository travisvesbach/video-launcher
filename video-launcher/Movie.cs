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
        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;

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


        private ICommand _showDetails;


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
        }

        // Process all files in the directory passed in, recurse on any directories
        // that are found, and process the files they contain.
        public void ProcessDirectory()
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(MovieDirectory.FullName);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

        }

        // Insert logic for processing found files here.
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


        // commands
        public bool CanExecute
        {
            get
            {
                return true;
            }
        }

        public ICommand ShowDetails
        {
            get
            {
                return _showDetails ?? (_showDetails = new CommandHandler(() => ShowMovie(), () => CanExecute));
            }
        }

        public void ShowMovie()
        {
            wnd.ShowMovie(this);

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
                        OriginalTitle = node.InnerText;
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
                        Trailer = node.InnerText;
                        break;
                    case "genre":
                        if (Genres == null)
                        {
                            Genres = new List<string>();
                        }
                        Genres.Add(node.InnerText);
                        wnd.AddMovieGenre(node.InnerText);
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


        public MainWindow Window
        {
            get { return wnd; }
        }
    }
}
