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

namespace video_launcher
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public string Img_projector = "/video_launcher;component/Images/projector_aqua.png";
        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;

        public Home()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void ClickMovieIndex(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("MovieIndex.xaml", UriKind.Relative));
        }

        public void ClickOptions(object sender, RoutedEventArgs e)
        {
            var options = new Options();
            options.Show();
        }

        public BitmapImage Projector
        {
            get { return new BitmapImage(new Uri(Img_projector, UriKind.Relative)); }
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

    }
}
