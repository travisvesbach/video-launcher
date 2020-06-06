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
    /// Interaction logic for ShowDetailsxaml.xaml
    /// </summary>
    public partial class ShowDetails : Page
    {
        public Show ShowData { get; set; }

        private MainWindow wnd = (MainWindow)Application.Current.MainWindow;


        public ShowDetails()
        {

            InitializeComponent();
            ShowData = wnd.ShowToShow;
            ShowData.ProcessSeasons();
            DataContext = this;
        }


        private void ClickShowIndex(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("ShowIndex.xaml", UriKind.Relative));
        }

        public MainWindow Window
        {
            get { return wnd; }
        }

    }
}
