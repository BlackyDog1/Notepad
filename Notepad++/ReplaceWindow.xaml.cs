using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notepad__
{
    /// <summary>
    /// Interaction logic for ReplaceWindow.xaml
    /// </summary>
    public partial class ReplaceWindow : Window
    {
        private MainWindow window;
        public ReplaceWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            window = mainWindow;
        }

        private void ReplaceButton_Clicked(object parameter, RoutedEventArgs e)
        {
            string replace = replaceTextBox.Text;
            string with = withTextBox.Text;

            if(!(bool)allFiles.IsChecked)
            {
                Tab currentTab = window.tabControl.SelectedItem as Tab;

                string context = currentTab.Content;

                var regex = new Regex(Regex.Escape(replace));
                var newText = regex.Replace(context, with, 1);

                currentTab.Content = newText;
            }
            else
            {
                foreach(Tab t in window.Tabs)
                {
                    string context = t.Content;

                    var regex = new Regex(Regex.Escape(replace));
                    var newText = regex.Replace(context, with, 1);

                    t.Content = newText;
                }
            }
        }

        private void ReplaceAllButton_Clicked(object parameter, RoutedEventArgs e)
        {
            Tab currentTab = window.tabControl.SelectedItem as Tab;

            string context = currentTab.Content;

            string replace = replaceTextBox.Text;
            string with = withTextBox.Text;

            if (!(bool)allFiles.IsChecked)
            {
                string newString = context.Replace(replace, with);
                currentTab.Content = newString;
                return;
            }
            else
            {
                foreach(Tab t in window.Tabs)
                {
                    string content = t.Content;
                    
                    string newString = content.Replace(replace, with);

                    t.Content = newString;
                    
                }

                return;
            }
        }
    }
}
