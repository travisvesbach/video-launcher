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
        public Movie movieToShow = null;

        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;

        private BitmapImage thumb = null;


        public MovieDetails()
        {
            InitializeComponent();

            movieToShow = wnd.MovieToShow;

            Console.WriteLine(movieToShow.Name);

            if (movieToShow.Img_thumb != null)
            {
                thumb = new BitmapImage(new Uri(movieToShow.Img_thumb, UriKind.Absolute));
            }

            DataContext = this;
        }

        public Movie MovieData
        {
            get { return movieToShow; }
        }

        public BitmapImage Thumb
        {
            get { return thumb; }
        }

        public static bool IsValidUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return false;
            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        public static bool OpenUri(string uri)
        {
            if (!IsValidUri(uri))
                return false;
            System.Diagnostics.Process.Start(uri);
            return true;
        }

        private void OpenTrailer(object sender, RoutedEventArgs e)
        {
            OpenUri(movieToShow.Trailer);
        }
    }
}
