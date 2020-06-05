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
        public ObservableCollection<Movie> Movies = new ObservableCollection<Movie>();

        public Movie MovieDetails = null;

        public List<Genre> Genres = new List<Genre>();
        public List<string> CheckedGenres = new List<string>();
        public string WatchedFilter = "All";
        public string SearchText = "";

        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;


        public MovieIndex()
        {
            InitializeComponent();
            Movies = wnd.Movies;
            Genres = wnd.MovieGenres;
            WatchedFilter = wnd.WatchedFilter;


            DataContext = this;

            LoadMovies();
            CheckedGenres = Genre.CheckedGenres(Genres);

            if (wnd.MovieToShow != null)
            {
                lvMovies.ScrollIntoView(wnd.MovieToShow);
            }

            SetCurrentFilters();
        }

        public ObservableCollection<Movie> FilteredMovies
        {
            get
            {
                ObservableCollection<Movie> filtered = new ObservableCollection<Movie>();
                foreach (Movie movie in Movies)
                {
                    if (CheckedGenres.Count > 0 && movie.Genres != null)
                    {
                        if (CheckedGenres.All(x => movie.Genres.Any(y => x == y)) && movie.DisplayName.ToLower().Contains(SearchText.ToLower()))
                        {

                            if ((WatchedFilter == "Watched" && movie.Watched == true) || (WatchedFilter == "Unwatched" && movie.Watched == false) || (WatchedFilter == "All"))
                            {
                                filtered.Add(movie);
                            }
                        }
                    }
                    else
                    {
                        if (movie.DisplayName.ToLower().Contains(SearchText.ToLower()))
                        {
                            if ((WatchedFilter == "Watched" && movie.Watched == true) || (WatchedFilter == "Unwatched" && movie.Watched == false) || (WatchedFilter == "All"))
                            {
                                filtered.Add(movie);
                            }
                        }
                    }
                }

                return filtered;
            }
        }

        public List<Genre> MovieGenres
        {
            get { return Genres; }
        }

        public MainWindow Window
        {
            get { return wnd; }
        }

        public void LoadMovies()
        {
            if (wnd.MovieDirectory.Length > 0 && Movies.Count == 0)
            {
                btRefresh.IsEnabled = false;
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += (obj, e) => ProcessDirectory(wnd.MovieDirectory);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MoviesImported);
                worker.RunWorkerAsync();
            }
        }

        public void ProcessDirectory(string targetDirectory)
        {
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            ObservableCollection<Movie> imported = new ObservableCollection<Movie>();
            int counter = 0;
            foreach (string subdirectory in subdirectoryEntries)
            {
                Movie movie = new Movie(new DirectoryInfo(subdirectory));
                if (movie.Genres != null && movie.Genres.Count > 0)
                {
                    foreach (string genre in movie.Genres)
                    {
                        AddGenre(genre);
                    }

                }
                imported.Add(movie);
                counter++;

                if (counter % 25 == 0)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Movies = imported;
                        NotifyPropertyChanged("FilteredMovies");
                        NotifyPropertyChanged("Genres");
                    });
                }
                
            }
            this.Dispatcher.Invoke(() =>
            {
                Movies = imported;
            });
        }

        public void AddGenre(string genre)
        {
            if (!Genres.Any(x => x.Name == genre))
            {
                Genres.Add(new Genre()
                {
                    Name = genre,
                    IsChecked = false
                });
                Genres.Sort((x, y) => string.Compare(x.Name, y.Name));
            }
        }

        public void MoviesImported(object sender, RunWorkerCompletedEventArgs e)
        {
            NotifyPropertyChanged("FilteredMovies");
            NotifyPropertyChanged("Genres");
            wnd.Movies = Movies;
            wnd.MovieGenres = Genres;
            btRefresh.IsEnabled = true;
        }

        public void SetCurrentFilters()
        {
            if (CheckedGenres.Count > 0)
            {
                exFilters.IsExpanded = true;
                exGenres.IsExpanded = true;
            }

            if (WatchedFilter != "All")
            {
                if (WatchedFilter == "Watched")
                {
                    rbWatched.IsChecked = true;
                }
                else
                {
                    rbUnwatched.IsChecked = true;
                }
                exFilters.IsExpanded = true;
                exWatched.IsExpanded = true;
            }
        }

        public void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchText = tbSearch.Text;
            NotifyPropertyChanged("FilteredMovies");
        }

        public void ClickCheckBox(object sender, RoutedEventArgs e)
        {
            CheckedGenres = Genre.CheckedGenres(Genres);
            NotifyPropertyChanged("FilteredMovies");
        }

        public void ClickWatchedRadio(object sender, RoutedEventArgs e)
        {
            WatchedFilter = (sender as RadioButton).Content.ToString();
            wnd.WatchedFilter = WatchedFilter;
            NotifyPropertyChanged("FilteredMovies");
        }

        public void ClickResetFilters(object sender, RoutedEventArgs e)
        {
            Genres = Genre.UncheckGenres(Genres);
            CheckedGenres = new List<string>();
            SearchText = "";
            tbSearch.Text = "";
            NotifyPropertyChanged("MovieGenres");
            NotifyPropertyChanged("FilteredMovies");
        }

        public void ClickHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }

        public void ClickRefresh(object sender, RoutedEventArgs e)
        {
            Movies = new ObservableCollection<Movie>();
            NotifyPropertyChanged("FilteredMovies");
            LoadMovies();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void ShowMovie(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Movie dataObject = btn.DataContext as Movie;
            wnd.ShowMovie(dataObject);
        }
    }
}
