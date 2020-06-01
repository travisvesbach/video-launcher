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
    /// Interaction logic for MovieDetailsPage.xaml
    /// </summary>
    public partial class MovieDetails : Page
    {
        public Movie MovieData { get; set; }

        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;


        public MovieDetails()
        {
            InitializeComponent();
            MovieData = wnd.MovieToShow;
            DataContext = this;
        }


        private void ClickMovieIndex(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("MovieIndex.xaml", UriKind.Relative));
        }

        public MainWindow Window
        {
            get { return wnd; }
        }

    }
}
