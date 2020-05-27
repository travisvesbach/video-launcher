using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MovieIndex : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

        public Movie MovieDetails = null;

        public List<Genre> Genres = new List<Genre>();
        public List<string> CheckedGenres = new List<string>();
        public string SearchText = "";

        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;


        public MovieIndex()
        {
            InitializeComponent();

            movies = wnd.movies;
            Genres = wnd.MovieGenres;
            CheckedGenres = Genre.CheckedGenres(Genres);

            DataContext = this;
            
            if (wnd.MovieToShow != null)
            {
                lvMovies.ScrollIntoView(wnd.MovieToShow);
            }

            if(CheckedGenres.Count > 0)
            {
                exFilters.IsExpanded = true;
                exGenres.IsExpanded = true;
            }
        }

        public ObservableCollection<Movie> Movies
        {
            get
            {
                return FilteredMovies();
            }
        }

        public List<Genre> MovieGenres
        {
            get { return Genres; }
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

        public ObservableCollection<Movie> FilteredMovies()
        {
            ObservableCollection<Movie> filtered = new ObservableCollection<Movie>();

            foreach (Movie movie in movies)
            {
                if (CheckedGenres.Count > 0)
                {
                    if (CheckedGenres.All(x => movie.Genres.Any(y => x == y)) && movie.Name.ToLower().Contains(SearchText.ToLower()))
                    {
                        filtered.Add(movie);
                    }
                }
                else
                {
                    if (movie.Name.ToLower().Contains(SearchText.ToLower()))
                    {
                        filtered.Add(movie);
                    }
                }
            }
            
            return filtered;
        }

        public void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchText = tbSearch.Text;
            NotifyPropertyChanged("Movies");
        }

        public void ClickCheckBox(object sender, RoutedEventArgs e)
        {
            CheckedGenres = Genre.CheckedGenres(Genres);
            NotifyPropertyChanged("Movies");
        }

        public void ClickResetFilters(object sender, RoutedEventArgs e)
        {
            Genres = Genre.UncheckGenres(Genres);
            CheckedGenres = new List<string>();
            SearchText = "";
            tbSearch.Text = "";
            NotifyPropertyChanged("MovieGenres");
            NotifyPropertyChanged("Movies");
        }

        public void ClickHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
