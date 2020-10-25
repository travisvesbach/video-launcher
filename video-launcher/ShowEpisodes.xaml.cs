using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ShowEpisodes.xaml
    /// </summary>
    public partial class ShowEpisodes : Page, INotifyPropertyChanged
    {
        public Show ShowData { get; set; }
        public int CurrentSeason = 1;
        public Episode SelectedEpisode { get; set; }

        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        public ShowEpisodes()
        {
            InitializeComponent();
            ShowData = wnd.ShowToShow;
            DataContext = this;
        }

        public ObservableCollection<Episode> FilteredEpisodes
        {
            get
            {
                ObservableCollection<Episode> filtered = new ObservableCollection<Episode>();
                foreach (Episode episode in ShowData.Episodes)
                {
                    if (Int32.Parse(episode.Season) == CurrentSeason)
                    {
                        filtered.Add(episode);
                    }
                }

                return filtered;
            }
        }

        public MainWindow Window
        {
            get { return wnd; }
        }

        private void ClickShowShow(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("ShowDetails.xaml", UriKind.Relative));
        }

        private void ClickSetSeason(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Season dataObject = btn.DataContext as Season;
            CurrentSeason = dataObject.Number;
            NotifyPropertyChanged("FilteredEpisodes");
        }

        private void ClickSetEpisode(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            SelectedEpisode = btn.DataContext as Episode;
            NotifyPropertyChanged("SelectedEpisode");
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
