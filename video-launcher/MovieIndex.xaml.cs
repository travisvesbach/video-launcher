using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace video_launcher
{
    /// <summary>
    /// Interaction logic for MovieIndex.xaml
    /// </summary>
    public partial class MovieIndex : Page
    {
        public ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

        public Movie MovieDetails = null;

        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;


        public MovieIndex()
        {
            InitializeComponent();

            movies = wnd.movies;

            DataContext = this;

            //var container = icMovies.ItemContainerGenerator.ContainerFromItem(icMovies.SelectedItem) as FrameworkElement;
            //if (container != null)
                //container.BringIntoView();

            if (wnd.MovieToShow != null)
            {
                lbMovies.ScrollIntoView(wnd.MovieToShow);
            }


        }


        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
        }

        
        public void ProcessDirectory(string targetDirectory)
        {
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                movies.Add(new Movie(new DirectoryInfo(subdirectory)));
            }

        }
    }
}
