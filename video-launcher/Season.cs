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
    public class Season
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public bool IsSpecial { get; set; }
        public string Watched { get; set; }
    }
}
