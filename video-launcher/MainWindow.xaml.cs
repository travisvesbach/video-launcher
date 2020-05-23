using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;

namespace video_launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

        public string movieDirectory = "";

        public MainWindow()
        {
            InitializeComponent();

            ProcessDirectory(movieDirectory);

            DataContext = this;
        }

        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
        }

        // Process all files in the directory passed in, recurse on any directories
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                //ProcessFile(fileName);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                //Console.WriteLine("Processed file '{0}'.", subdirectory);
                //ProcessDirectory(subdirectory);
                movies.Add(new Movie(new DirectoryInfo(subdirectory)));
            }

        }

        // Insert logic for processing found files here.
        public void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }
    }

}
