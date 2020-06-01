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
using System.ComponentModel;

namespace video_launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string MovieDirectory = video_launcher.Properties.Settings.Default.MovieDirectory;
        public ObservableCollection<Movie> Movies = new ObservableCollection<Movie>();
        public Movie MovieToShow = null;
        public List<Genre> MovieGenres = new List<Genre>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            this.InitializeComponent();

            this.Loaded += MainWindow_Loaded;

            DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationFrame.NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }

        public void OptionsUpdated()
        {
            if(video_launcher.Properties.Settings.Default.MovieDirectory != MovieDirectory)
            {
                Movies = new ObservableCollection<Movie>();
                MovieDirectory = video_launcher.Properties.Settings.Default.MovieDirectory;
                NotifyPropertyChanged("MovieDirectory");
            }

            NotifyPropertyChanged("BackgroundTopColor");
            NotifyPropertyChanged("BackgroundBottomColor");
            NotifyPropertyChanged("ButtonColor");
            NotifyPropertyChanged("ButtonHoverColor");
            NotifyPropertyChanged("TextColor");

        }

        public void ShowMovie(Movie movie)
        {
            Console.WriteLine("showing " + movie.Name);
            MovieToShow = movie;
            NavigationFrame.NavigationService.Navigate(new Uri("MovieDetails.xaml", UriKind.Relative));
        }

        public void ResetBrowseVariables()
        {
            MovieToShow = null;
            Genre.UncheckGenres(MovieGenres);
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

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

}
