using System;
using System.Collections.Generic;
using System.Text;

namespace HCommon.Helper
{
    public delegate void FileWatchEventHandler(object sender, EventArgs e);
    class EventHelper
    {
        public event FileWatchEventHandler FileWatchEvent;
        

    }
}
