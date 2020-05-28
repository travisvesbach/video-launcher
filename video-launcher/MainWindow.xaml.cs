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
        public string MovieDirectory = video_launcher.Properties.Settings.Default.MovieDirectory;
        public ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        public Movie MovieToShow = null;
        public List<Genre> MovieGenres = new List<Genre>();

        public MainWindow()
        {
            this.InitializeComponent();

            if (MovieDirectory.Length > 0)
            {
                ProcessDirectory(MovieDirectory);
            }

            this.Loaded += MainWindow_Loaded;

            DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationFrame.NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }

        public void ShowMovie(Movie movie)
        {
            Console.WriteLine("showing " + movie.Name);
            MovieToShow = movie;
            NavigationFrame.NavigationService.Navigate(new Uri("MovieDetails.xaml", UriKind.Relative));
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

        public void AddMovieGenre(string genre)
        {
            if (!MovieGenres.Any(x => x.Name == genre))
            {
                MovieGenres.Add(new Genre(){
                    Name = genre,
                    IsChecked = false
                });
                MovieGenres.Sort((x, y) => string.Compare(x.Name, y.Name));
            }
        }

        public Color BackgroundTopColor
        {
            get { return (Color)ColorConverter.ConvertFromString(video_launcher.Properties.Settings.Default.BackgroundTopColor);  }
        }

        public Color BackgroundBottomColor
        {
            get { return (Color)ColorConverter.ConvertFromString(video_launcher.Properties.Settings.Default.BackgroundBottomColor);  }
        }

        public SolidColorBrush ButtonColor
        {
            get { return (SolidColorBrush)(new BrushConverter().ConvertFrom(video_launcher.Properties.Settings.Default.ButtonColor)); }
        }

        public SolidColorBrush ButtonHoverColor
        {
            get { return (SolidColorBrush)(new BrushConverter().ConvertFrom(video_launcher.Properties.Settings.Default.ButtonHoverColor)); }
        }

        public SolidColorBrush TextColor
        {
            get { return (SolidColorBrush)(new BrushConverter().ConvertFrom(video_launcher.Properties.Settings.Default.TextColor)); }
        }
    }

}
