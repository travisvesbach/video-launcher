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
    /// Interaction logic for ShowIndex.xaml
    /// </summary>
    public partial class ShowIndex : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Show> Shows = new ObservableCollection<Show>();

        public Show showDetails = null;

        public List<Genre> Genres = new List<Genre>();
        public List<string> CheckedGenres = new List<string>();
        public string WatchedFilter = "All";
        public string Sort = "Alphabetical";
        public string AiringFilter = "All";
        public string SearchText = "";
        public string ShowType { get; set; }

        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;


        public ShowIndex()
        {
            InitializeComponent();
            ShowType = (wnd.ShowType == "TV" ? "TV Shows" : "Anime");
            Shows = (wnd.ShowType == "TV" ? wnd.TV : wnd.Anime);
            Genres = (wnd.ShowType == "TV" ? wnd.TVGenres : wnd.AnimeGenres);
            WatchedFilter = wnd.WatchedFilter;
            Sort = wnd.Sort;
            AiringFilter = wnd.AiringFilter;
            

            DataContext = this;
            
            LoadShows();
            CheckedGenres = Genre.CheckedGenres(Genres);

            if (wnd.ShowToShow != null)
            {
                lvShows.ScrollIntoView(wnd.ShowToShow);
            }

            SetCurrentFilters();
        }

        public ObservableCollection<Show> FilteredShows
        {
            get
            {
                ObservableCollection<Show> filtered = new ObservableCollection<Show>();
                foreach (Show show in Shows)
                {
                    if (CheckedGenres.Count > 0 && show.Genres != null)
                    {
                        if (CheckedGenres.All(x => show.Genres.Any(y => x == y)) && show.DisplayName.ToLower().Contains(SearchText.ToLower()))
                        {
                            if ((WatchedFilter == "Watched" && show.Watched == "true") || (WatchedFilter == "Unwatched" && show.Watched == "false") || (WatchedFilter == "In Progress" && show.Watched == "in-progress") || (WatchedFilter == "All"))
                            {
                                filtered.Add(show);
                            }
                        }
                    }
                    else
                    {
                        if (show.DisplayName.ToLower().Contains(SearchText.ToLower()))
                        {
                            if ((WatchedFilter == "Watched" && show.Watched == "true") || (WatchedFilter == "Unwatched" && (show.Watched == "false" || show.Watched == null)) || (WatchedFilter == "In Progress" && show.Watched == "in-progress") || (WatchedFilter == "All"))
                            {
                                filtered.Add(show);
                            }
                        }
                    }
                }

                ObservableCollection<Show> filteredAiring = new ObservableCollection<Show>();
                foreach (Show show in filtered) {
                    if (AiringFilter == "All" || (AiringFilter == "Airing Now" && show.Airing == "airing") || (AiringFilter == "Waiting" && show.Airing == "on-hold") || (AiringFilter == "Completed" && (show.Airing == "completed" || show.Airing == null))) {
                        filteredAiring.Add(show);
                    }
                }
                filtered = filteredAiring;
                

                filtered = new ObservableCollection<Show>(filtered.OrderBy(x => x.DisplayName).ToList());
                if (Sort == "Year")
                {
                    filtered = new ObservableCollection<Show>(filtered.OrderBy(x => x.Year).ToList());
                }
                else if (Sort == "Last Watched")
                {
                    filtered = new ObservableCollection<Show>(filtered.Reverse().ToList());
                    filtered = new ObservableCollection<Show>(filtered.OrderBy(x => x.LastWatched).ToList());
                    filtered = new ObservableCollection<Show>(filtered.Reverse().ToList());
                }

                return filtered;
            }
        }

        public List<Genre> ShowGenres
        {
            get { return Genres; }
        }

        public MainWindow Window
        {
            get { return wnd; }
        }

        public void LoadShows()
        {
            if (wnd.ShowDirectory.Length > 0 && Shows.Count == 0)
            {
                btRefresh.IsEnabled = false;
                tbRefresh.Text = "Loading";
                btRefresh.Background = new SolidColorBrush(Colors.Gray);
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += (obj, e) => ProcessDirectory(wnd.ShowDirectory);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ShowsImported);
                worker.RunWorkerAsync();
            }
        }

        public void ProcessDirectory(string targetDirectory)
        {
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            ObservableCollection<Show> imported = new ObservableCollection<Show>();
            int counter = 0;
            int total = subdirectoryEntries.Length;
            foreach (string subdirectory in subdirectoryEntries)
            {
                Show show = new Show(new DirectoryInfo(subdirectory));
                int percent = (int)Math.Round((double)(100 * counter) / total);
                this.Dispatcher.Invoke(() =>
                {
                    tbRefresh.Text = "Loading ... " + percent + "%";
                });
                if (show.Genres != null && show.Genres.Count > 0)
                {
                    foreach (string genre in show.Genres)
                    {
                        AddGenre(genre);
                    }
                }
                imported.Add(show);
                counter++;

                if (counter % 25 == 0)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Shows = imported;
                        NotifyPropertyChanged("FilteredShows");
                        NotifyPropertyChanged("Genres");
                    });
                }

            }
            this.Dispatcher.Invoke(() =>
            {
                Shows = imported;
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

        public void ShowsImported(object sender, RunWorkerCompletedEventArgs e)
        {
            NotifyPropertyChanged("FilteredShows");
            NotifyPropertyChanged("Genres");
            if (wnd.ShowType == "TV")
            {
                wnd.TV = Shows;
                wnd.TVGenres = Genres;
            }
            else
            {
                wnd.Anime = Shows;
                wnd.AnimeGenres = Genres;
            }
            btRefresh.IsEnabled = true;
            tbRefresh.Text = "Reload";
            btRefresh.Background = wnd.ButtonColor;
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
            NotifyPropertyChanged("FilteredShows");
        }

        public void ClickCheckBox(object sender, RoutedEventArgs e)
        {
            CheckedGenres = Genre.CheckedGenres(Genres);
            NotifyPropertyChanged("FilteredShows");
        }

        public void ClickWatchedRadio(object sender, RoutedEventArgs e)
        {
            WatchedFilter = (sender as RadioButton).Content.ToString();
            wnd.WatchedFilter = WatchedFilter;
            NotifyPropertyChanged("FilteredShows");
        }

        public void ClickSortRadio(object sender, RoutedEventArgs e)
        {
            Sort = (sender as RadioButton).Content.ToString();
            wnd.Sort = Sort;
            NotifyPropertyChanged("FilteredShows");
        }

        public void ClickAiringRadio(object sender, RoutedEventArgs e)
        {
            AiringFilter = (sender as RadioButton).Content.ToString();
            wnd.AiringFilter = AiringFilter;
            NotifyPropertyChanged("FilteredShows");
        }

        public void ClickResetFilters(object sender, RoutedEventArgs e)
        {
            Genres = Genre.UncheckGenres(Genres);
            CheckedGenres = new List<string>();
            SearchText = "";
            tbSearch.Text = "";
            WatchedFilter = "All";
            wnd.WatchedFilter = WatchedFilter;
            rbAllWatched.IsChecked = true;
            Sort = "Alphabetical";
            wnd.Sort = Sort;
            rbAlphabetical.IsChecked = true;
            AiringFilter = "All";
            wnd.AiringFilter = AiringFilter;
            rbAllAiring.IsChecked = true;
            NotifyPropertyChanged("showGenres");
            NotifyPropertyChanged("FilteredShows");
        }

        public void ClickHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }

        public void ClickRefresh(object sender, RoutedEventArgs e)
        {
            Shows = new ObservableCollection<Show>();
            NotifyPropertyChanged("FilteredShows");
            LoadShows();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void ShowShow(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Show dataObject = btn.DataContext as Show;
            wnd.ShowShow(dataObject);
        }
    }
}
