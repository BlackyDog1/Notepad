using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Notepad__
{
    public class Tab : INotifyPropertyChanged
    {
        private string content;
        private string path;
        private bool hasChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FilePath
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChange();
                OnPropertyChange("Name"); // binded field to the tab menu is "Name", notifies that the field changed in order to update UI
            }
        }

        public string Content
        {
            get { return content; }
            set { content = value; 
                hasChanged = true;
                OnPropertyChange();
                OnPropertyChange("HasChanged");
            }
        }

        public string Name => Path.GetFileName(FilePath);

        public bool HasChanged { get { return hasChanged; } set { hasChanged = value; } }

        public Tab(string FilePath)
        {
            path = FilePath;
            content = string.Empty;
            ReadFile();
        }

        private void ReadFile()
        {
            if (System.IO.File.Exists(path))
                content = System.IO.File.ReadAllText(path);
        }

        public void WriteFile()
        {
            System.IO.File.WriteAllText(path, Content);
            hasChanged = false;
            OnPropertyChange("HasChanged");
        }
        
        protected void OnPropertyChange([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
