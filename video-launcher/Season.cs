using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;

namespace video_launcher
{
    public class Season : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public bool IsSpecial { get; set; }
        public string Watched { get; set; }
        public Show Parent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CheckIfWatched()
        {
            int total = 0;
            int watchedCount = 0;
            foreach (Episode episode in Parent.Episodes)
            {
                if (episode.Season == Number.ToString())
                {
                    total++;
                    if (episode.Watched == "true")
                    {
                        watchedCount++;
                    }
                }
            }
            if (watchedCount == total)
            {
                Watched = "true";
            }
            else if (watchedCount > 0)
            {
                Watched = "in-progress";
            } 
            else
            {
                Watched = "false";
            }
            
            NotifyPropertyChanged("Watched");
        }


        public string WatchedIcon
        {
            get
            {
                if (Watched == "true")
                {
                    return "Solid_CheckCircle";
                }
                else if (Watched == "in-progress")
                {
                    return "Solid_Eye";
                }
                else
                {
                    return "Solid_TimesCircle";
                }
            }
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
