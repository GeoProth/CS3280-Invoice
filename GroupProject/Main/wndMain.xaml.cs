using GroupProject.Items;
using GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        private void SearchInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndSearch Search = new wndSearch();
                Search.ShowDialog();
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void ItemListMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndItems Items = new wndItems();
                Items.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void AddInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ItemListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HandleError(string Class, string Method, string Message)
        {
            try
            {
                MessageBox.Show(Class + "." + Method + " --> " + Message);
            }
            catch(System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Errror.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }

}
