using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        private MainWindow window;
        public FindWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            window = mainWindow;
        }


        private void FindButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (!(bool)allFiles.IsChecked)
            {

                Tab currentTab = window.tabControl.SelectedItem as Tab;

                string text = currentTab.Content;

                string searchedText = textBox.Text;

                List<int> indexes = text.AllIndexesOf(searchedText);

                if (indexes.Count == 0)
                    MessageBox.Show("Substringul cautat nu a fost gasit");
                else
                {
                    string newInd = string.Empty;
                    foreach (int index in indexes)
                        newInd += index.ToString() + " ";
                    MessageBox.Show("Substringul cautat a fost gasit la indicii : " + newInd);
                }
            }
            else
            {
                // find pentru toate taburile
            }
            
        }

    }


}
