using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_launcher
{
    public class Genre : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private bool IsSelected { get; set; }

        public bool IsChecked
        {
            get { return IsSelected; }
            set
            {
                IsSelected = value;
                NotifyPropertyChanged();
            }
        }

        public static List<string> CheckedGenres(List<Genre> genres)
        {
            List<string> checkedGenres = new List<string>();

            foreach (Genre genre in genres)
            {
                if (genre.IsChecked == true)
                {
                    Console.WriteLine(genre.Name + " box checked");
                    checkedGenres.Add((string)genre.Name);
                }
            }

            return checkedGenres;
        }

        public static List<Genre> UncheckGenres(List<Genre> genres)
        {

            foreach (Genre genre in genres)
            {
                if (genre.IsChecked == true)
                {
                    genre.IsChecked = false;
                }
            }

            return genres;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
