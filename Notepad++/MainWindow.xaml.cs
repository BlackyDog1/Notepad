using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Notepad__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Tab> Tabs = new ObservableCollection<Tab>();
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();

            Tabs.Add(new Tab("File") { HasChanged = true });

            DataContext = Tabs;
        }
        #region File
        public void MenuItem_ClickNew(object parameter, RoutedEventArgs e)
        {
            Tabs.Add(new Tab("File" + count.ToString() +" .txt") { HasChanged = true });
            count++;

        }

        public void MenuItem_ClickOpen(object parameter, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
                Tabs.Add(new Tab(openFile.FileName));

        }

        public void MenuItem_Save(object parameter, RoutedEventArgs e)
        {
            Tab currentTab = tabControl.SelectedItem as Tab;

            if (currentTab == null)
                return;

            if(!System.IO.File.Exists(currentTab.FilePath))
            //save
            {
                MenuItem_SaveAs(null, null);
            }
            else
            {
                currentTab.WriteFile();
            }
        }

        public void MenuItem_SaveAs(object parameter, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "New File";
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Text documents (.txt)|*.txt";

            Tab selectedTab = tabControl.SelectedItem as Tab;

            if(selectedTab == null)
            {
                MessageBox.Show("Nu ati selectat niciun tab");
                return;
            }

            if(saveFile.ShowDialog() == true)
            {
                selectedTab.FilePath = saveFile.FileName;
                selectedTab.WriteFile();
            }
        }

        public void MenuItem_Exit(object parameter, RoutedEventArgs e)
        {
            if(Tabs.Count == 0)
                Application.Current.Shutdown();
            foreach (Tab tab in Tabs)
            {
                if (tab.HasChanged)
                {
                    MessageBoxResult result = MessageBox.Show("Exista taburi nesalvate, doriti sa inchideti aplicatia?", "Warning", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        Application.Current.Shutdown();
                    }
                }
            }
        }

        // la inchiderea ferestrei
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
        {
            foreach(Tab tab in Tabs)
            {
                if(tab.HasChanged)
                {
                    MessageBoxResult result = MessageBox.Show("Exista taburi nesalvate, doriti sa inchideti aplicatia?", "Warning", MessageBoxButton.YesNo);

                    if(result == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void CloseTab_Clicked(object parameter, RoutedEventArgs e)
        {
            Button closeButton = parameter as Button;

            foreach(var tab in Tabs)
                if(tab.FilePath == closeButton.Tag.ToString())
                {
                    if (tab.HasChanged)
                    {
                        MessageBoxResult result = MessageBox.Show("Acest tab este nesalvat, doriti sa il inchideti?", "Warning", MessageBoxButton.YesNo);

                        if (result == MessageBoxResult.No)
                        {
                            return;
                        }
                        else
                        {
                            Tabs.Remove(tab);
                            return;
                        }
                    }
                    else
                        Tabs.Remove(tab);
                    break;
                }    
        }
        #endregion

        #region Help
        private void About_Clicked(object parameter, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.Show();
        }
        #endregion

        #region Search
        private void MenuItem_Find(object parameter, RoutedEventArgs e)
        {
            FindWindow window = new FindWindow(this);
            window.Show();
        }

        private void MenuItem_Replace(object parameter, RoutedEventArgs e)
        {
            ReplaceWindow window = new ReplaceWindow(this);
            window.Show();
        }
        #endregion

        #region Edit
        private void MenuItem_ToUppercase(object parameter, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == -1)
            {
                MessageBox.Show("No file selected!");
                return;
            }

            Tab currentTab = tabControl.SelectedItem as Tab;

            string content = currentTab.Content;


            string newString = content.ToUpper();

            currentTab.Content = newString;
        }

        private void MenuItem_ToLowercase(object parameter, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == -1)
            {
                MessageBox.Show("No file selected!");
                return;
            }
            Tab currentTab = tabControl.SelectedItem as Tab;

            string content = currentTab.Content;


            string newString = content.ToLower();

            currentTab.Content = newString;
        }

        private void RemoveEmpty_Clicked(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == -1)
            {
                MessageBox.Show("No file selected!");
                return;
            }

            Tab selectedFile = tabControl.SelectedItem as Tab;
            selectedFile.Content = RemoveEmptyLines(selectedFile.Content);
        }

        public static string RemoveEmptyLines(string text)
        {
            return Regex.Replace(text, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline);
        }
        #endregion

        #region  TreeView

        private void Window_Loaded(object parameter, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive
                };


                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object parameter, RoutedEventArgs e)
        {
            var item = (TreeViewItem)parameter;

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            item.Items.Clear();

            var fullPath = (string)item.Tag;

            // get folders

            var directories = new List<string>();

            try
            {

                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);


            }
            catch { }

            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(directoryPath),

                    Tag = directoryPath
                };

                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;


                item.Items.Add(subItem);
            }
            );

            //get files

            var files = new List<string>();

            try
            {

                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    files.AddRange(fs);


            }
            catch { }

            files.ForEach(filePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(filePath),

                    Tag = filePath
                };

                item.Items.Add(subItem);
            }
            );


        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;


            var normalizedPath = path.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');


            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex + 1);
        }

        private void FileExplorer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = FolderView.SelectedItem as TreeViewItem;
            string filePath = item.Tag.ToString();
            FileAttributes attributes = System.IO.File.GetAttributes(filePath);

            //check if the user double clicked on file and if yes, open the file
            if ((attributes & FileAttributes.Directory) != FileAttributes.Directory)
                Tabs.Add(new Tab(filePath));

        }

        #endregion


    }
}
