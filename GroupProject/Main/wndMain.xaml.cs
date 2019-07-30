using GroupProject.Classes;
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
        #region Methods
        /// <summary>
        /// Main Logic Object
        /// </summary>
        private clsMainLogic mainLogic;

        private Item selectedItem;
        /// <summary>
        /// Default Constructor / Initializer
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                mainLogic = new clsMainLogic();
                
                DeleteInvoiceBtn.IsEnabled = false;
                AddInvoiceBtn.IsEnabled = true;
                EditInvoiceBtn.IsEnabled = false;
                SaveInvoiceBtn.IsEnabled = false;
                ItemComboBox.IsEnabled = false;
                ItemListBox.IsEnabled = false;
                AddItemBtn.IsEnabled = false;

                DeleteItemBtn.IsEnabled = false;

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Search Invoice button click
        /// sends user to new Search Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndSearch Search = new wndSearch();
                Search.ShowDialog();

                //Must wait for Search Logic to fully incorporate this
                //but I think its pretty close.
                /*
                //return if nothing selected
                if(Search.searchLogic.SelectedInvoice == null)
                {
                    return;
                }

                mainLogic.CurrentInvoice = Search.searchLogic.SelectedInvoice;

                ItemListBox.IsEnabled = true;
                DeleteInvoiceBtn.IsEnabled = true;
                EditInvoiceBtn.IsEnabled = true;

                TotalLbl.Content = mainLogic.CurrentInvoice.TotalCost.ToString();
                InvoiceNumLbl.Content = mainLogic.CurrentInvoice.InvoiceNumber;
                DateBox.Text = mainLogic.CurrentInvoice.InvoiceDate;
                */
            }
            catch(Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Item List Menu Button
        /// Sends User to list of all Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Add Invoice Button
        /// Enables functionality to add a new Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemListBox.IsEnabled = true;
                ItemComboBox.IsEnabled = true;
                ItemComboBox.ItemsSource = mainLogic.ItemsList;
                ItemComboBox.DisplayMemberPath = "ItemDescription";

                AddInvoiceBtn.IsEnabled = false;

                //new empty invoice
                mainLogic.CreateInvoice();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Edit Invoice Button
        /// Enables User to Edit an Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemListBox.IsEnabled = true;
                ItemComboBox.IsEnabled = true;
                AddInvoiceBtn.IsEnabled = false;
                DeleteInvoiceBtn.IsEnabled = false;
                EditInvoiceBtn.IsEnabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Delete Invoice button
        /// Deletes an Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Message Box warning
                MessageBoxResult messageWarning = MessageBox.Show("Are you sure you want to delete Invoice #: " + mainLogic.CurrentInvoice.InvoiceNumber + "?",
                                            "Delete", MessageBoxButton.YesNo);

                if(messageWarning == MessageBoxResult.Yes)
                {
                    mainLogic.DeleteInvoice();

                    DeleteInvoiceBtn.IsEnabled = false;
                    AddInvoiceBtn.IsEnabled = true;
                    EditInvoiceBtn.IsEnabled = false;
                    mainLogic.CurrentInvoice = null;

                    ItemListBox.ItemsSource = null;
                    ItemListBox.IsEnabled = false;
                    InvoiceNumLbl.Content = "TBD";
                    DateBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Item List Box Selection Changed
        /// allows user to select an Item in the List box and enables ability to Remove item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListBox itemList = (ListBox)sender;
                DeleteItemBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Add Item button
        /// once user has selected an item from the group box,
        /// user can Add the Item to the Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int qnty = Convert.ToInt32(QuantityBox.Text);
                mainLogic.AddItem(selectedItem, qnty);

                QuantityBox.Text = "0";
                CostBox.Text = "$0.00";
                TotalLbl.Content = "$" + mainLogic.CurrentInvoice.TotalCost.ToString();
                ItemComboBox.SelectedIndex = -1;

                ItemListBox.ItemsSource = mainLogic.CurrentInvoice.InvoiceItems.ToList();
                
                SaveInvoiceBtn.IsEnabled = true;

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Delete Item
        /// enables User to Delete item from Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ItemListBox.SelectedIndex == -1)
                {
                    return;
                }
                selectedItem = (Item)ItemListBox.SelectedItem;
                mainLogic.DeleteItem(selectedItem);
                ItemListBox.ItemsSource = mainLogic.CurrentInvoice.InvoiceItems.ToList();
                DeleteItemBtn.IsEnabled = false;

                SaveInvoiceBtn.IsEnabled = true;

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Item Combo Box
        /// Shows user list of Items in Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
                 //selectedPassenger = (Passenger)PassengerComboBox.SelectedItem;
            {
               
                //need to check for selection being -1
                if(((ComboBox)sender).SelectedIndex == -1)
                {
                    QuantityBox.IsEnabled = false;
                    AddItemBtn.IsEnabled = false;
                    return;
                }
                else
                {
                    selectedItem = (Item)ItemComboBox.SelectedItem;
                    if (!QuantityBox.IsEnabled)
                    {
                        QuantityBox.IsEnabled = true;
                    }
                    if (!AddItemBtn.IsEnabled)
                    {
                        AddItemBtn.IsEnabled = true;
                    }
                    QuantityBox.Text = "1";
                    CostBox.Text = "$" + selectedItem.ItemCost.ToString();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Save Invoice Button
        /// Allows user to save new Invoice to Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string date = DateBox.Text;
                mainLogic.SaveInvoice(date);
                DateBox.IsEnabled = false;

                DateBox.Text = mainLogic.CurrentInvoice.InvoiceDate.ToString();
                

                InvoiceNumLbl.Content = mainLogic.CurrentInvoice.InvoiceNumber.ToString();

                DeleteInvoiceBtn.IsEnabled = true;
                EditInvoiceBtn.IsEnabled = true;
                AddInvoiceBtn.IsEnabled = true;

                CostBox.Text = "$0.00";
                QuantityBox.Text = "0";
                ItemComboBox.IsEnabled = false;
                ItemComboBox.SelectedIndex = -1;
                SaveInvoiceBtn.IsEnabled = false;
                ItemListBox.IsEnabled = false;


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
            catch(System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Errror.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
        #endregion
    }
}
