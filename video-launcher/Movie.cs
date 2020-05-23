using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace video_launcher
{
    public class Movie
    {
        // directory class
        public DirectoryInfo directory { get; set; }

        public string Name { get; set; }
        public string Video_type { get; set; }

        //files in directory
        public string File_video { get; set; }
        public string File_nfo { get; set; }
        public string Img_banner { get; set; }
        public string Img_clearart { get; set; }
        public string Img_clearlogo { get; set; }
        public string Img_disc { get; set; }
        public string Img_fanart { get; set; }
        public string Img_keyart { get; set; }
        public string Img_logo { get; set; }
        public BitmapImage Img_poster { get; set; }
        public string Img_thumb { get; set; }
        public List<string> Subtitles = new List<string>();


        public Movie(DirectoryInfo dir)
        {
            directory = dir;
            Name = directory.Name;
            ProcessDirectory();
            Console.WriteLine(Name);
            Console.WriteLine(Img_poster);
        }

        // Process all files in the directory passed in, recurse on any directories
        // that are found, and process the files they contain.
        public void ProcessDirectory()
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(directory.FullName);
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
                case "banner":
                    Img_banner = path;
                    break;
                case "clearart":
                    Img_clearart = path;
                    break;
                case "clearlogo":
                    Img_clearlogo = path;
                    break;
                case "disc":
                    Img_disc = path;
                    break;
                case "fanart":
                    Img_fanart = path;
                    break;
                case "keyart":
                    Img_keyart = path;
                    break;
                case "logo":
                    Img_logo = path;
                    break;
                case "poster":
                    Img_poster = new BitmapImage(new Uri(path, UriKind.Absolute));
                    Img_poster.DecodePixelWidth = 100;
                    Img_poster.DecodePixelHeight = 100;
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

    }
}
