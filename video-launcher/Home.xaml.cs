using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page, INotifyPropertyChanged
    {
        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        public Home()
        {
            InitializeComponent();

            wnd.ResetBrowseVariables();

            DataContext = this;
        }

        private void ClickAnimeIndex(object sender, RoutedEventArgs e)
        {
            wnd.ShowType = "Anime";
            NavigationService.Navigate(new Uri("ShowIndex.xaml", UriKind.Relative));
        }

        private void ClickMovieIndex(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("MovieIndex.xaml", UriKind.Relative));
        }

        private void ClickTVIndex(object sender, RoutedEventArgs e)
        {
            wnd.ShowType = "TV";
            NavigationService.Navigate(new Uri("ShowIndex.xaml", UriKind.Relative));
        }

        public void ClickOptions(object sender, RoutedEventArgs e)
        {
            var options = new Options();
            options.FormClosed += OptionsClosed;
            options.Show();
        }

        public void OptionsClosed(object sender, System.EventArgs e)
        {
            wnd.OptionsUpdated();
            NotifyPropertyChanged("AnimeDirectory");
            NotifyPropertyChanged("MovieDirectory");
            NotifyPropertyChanged("TVShowDirectory");
        }

        public MainWindow Window
        {
            get { return wnd; }
        }

        public string AnimeDirectory
        {
            get { return video_launcher.Properties.Settings.Default.AnimeDirectory; }
        }

        public string MovieDirectory
        {
            get { return video_launcher.Properties.Settings.Default.MovieDirectory; }
        }

        public string TVShowDirectory
        {
            get { return video_launcher.Properties.Settings.Default.TVShowDirectory; }
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
