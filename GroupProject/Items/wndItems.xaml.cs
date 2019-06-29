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
using System.Windows.Shapes;

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        public wndItems()
        {
            InitializeComponent();
        }

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ItemListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void HandleError(string Class, string Method, string Message)
        {
            try
            {
                MessageBox.Show(Class + "." + Method + " --> " + Message);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Errror.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
