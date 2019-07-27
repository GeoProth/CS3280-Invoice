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

namespace GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        #region Variables
        /// <summary>
        /// search Logic Object
        /// </summary>
        private clsSearchLogic searchLogic;
        #endregion

        #region Methods
        public wndSearch()
        {
            //On initialization, get the current database of invoices from the MainLogic class
            //Set it in the SearchLogic class
            try
            {
                InitializeComponent();
                searchLogic = new clsSearchLogic();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Cancel button click. Allows user to cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Invoice combo box. Allows user to select an invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Clear Filter button. Allows User to clear the filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Invoice list box. Allows User to select an invoice of a listed invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
       
        /// <summary>
        /// Select Invoice button click. Allows User to select and invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Validate an invoice is selected
                //Set the selected invoice as the current invoice in the SearchLogic class
                //In the main class, get the current invoice from the SearchLogic class
                //Display the current invoice
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Exception Handling for Main Window
        /// Shows Message Box to user
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Method"></param>
        /// <param name="Message"></param>
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
        #endregion
    }
}
