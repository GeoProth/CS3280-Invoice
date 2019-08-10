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
using GroupProject.Classes;

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        #region Variables
        /// <summary>
        /// Items Logic Object
        /// </summary>
        private clsItemsLogic itemsLogic;

        /// <summary>
        /// Currently selected item
        /// </summary>
        private Item selectedItem;

        /// <summary>
        /// String for the current mode
        /// </summary>
        string mode;
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for item window
        /// </summary>
        public wndItems()
        {
            try
            {
                InitializeComponent();
                itemsLogic = new clsItemsLogic();
                selectedItem = null;
                //Starting Mode
                RefreshUI();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Back button click. Allows user to back out of an add, update, or delete without making any changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Go back to starting position
                RefreshUI();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Add Item button click. Allows User to add Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Only blank textboxes, save button, and the back/cancel buttons are enabled
                ItemListBox.IsEnabled = false;
                ItemCodeBox.IsEnabled = true;
                ItemCostBox.IsEnabled = true;
                ItemDescriptionBox.IsEnabled = true;
                ItemCodeBox.Text = "";
                ItemCostBox.Text = "";
                ItemDescriptionBox.Text = "";
                EditItemBtn.IsEnabled = false;
                DeleteItemBtn.IsEnabled = false;
                AddItemBtn.IsEnabled = false;
                SaveItemBtn.IsEnabled = true;
                mode = "add";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Edit Item button click. Allows User to edit Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Enable textboxes and save button, disable other buttons and the datagrid
                ItemListBox.IsEnabled = false;
                ItemCodeBox.IsEnabled = false;
                ItemCostBox.IsEnabled = true;
                ItemDescriptionBox.IsEnabled = true;
                EditItemBtn.IsEnabled = false;
                DeleteItemBtn.IsEnabled = false;
                AddItemBtn.IsEnabled = false;
                SaveItemBtn.IsEnabled = true;
                mode = "edit";

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Delete Item button click. Allows User to Delete Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ItemListBox.SelectedIndex == -1)
                {
                    return;
                }
                //Check if the item can be deleted
                if (itemsLogic.CheckDelete(selectedItem))
                {
                    //If not, show user a list of invoices the item is on
                    MessageBoxResult messageCode = MessageBox.Show("Cannot delete item. Item is on invoices:\n" + itemsLogic.BadInvoices(selectedItem) + "\nDelete these invoices first.",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //Give user confirmation message
                    MessageBoxResult messageWarning = MessageBox.Show("Are you sure you want to delete item " + selectedItem.ItemDescription + "?",
                        "Delete", MessageBoxButton.YesNo);
                    //Check user chose yes
                    if (messageWarning == MessageBoxResult.Yes)
                    {
                        //Delete item
                        itemsLogic.DeleteItem(selectedItem);
                        RefreshUI();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Item List datagrid. Allows User to make desired selection of Items 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Check that item is not null
                if (ItemListBox.SelectedItem != null)
                {
                    selectedItem = (Item)ItemListBox.SelectedItem;
                    //Set textboxes to values of current item
                    ItemCodeBox.Text = selectedItem.ItemCode.ToString();
                    ItemDescriptionBox.Text = selectedItem.ItemDescription;
                    ItemCostBox.Text = selectedItem.ItemCost.ToString();
                    EditItemBtn.IsEnabled = true;
                    DeleteItemBtn.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Save Item button click. Allows User to save a new or updated Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Validate fields, check mode, add/edit item
                if (mode == "add")
                {
                    //Test code length
                    if (ItemCodeBox.Text.Length == 1)
                    {
                        //Test a description exists
                        if (ItemDescriptionBox.Text != "")
                        {
                            //Test a double exists
                            if (double.TryParse(ItemCostBox.Text, out double costAddResult))
                            {
                                //Can still fail because of the same item code being used
                                costAddResult = Math.Round(costAddResult, 2, MidpointRounding.AwayFromZero);
                                itemsLogic.AddItem(ItemCodeBox.Text, ItemDescriptionBox.Text, costAddResult);
                                //Start Again
                                RefreshUI();
                            }
                            else
                            {
                                MessageBoxResult messageCode = MessageBox.Show("Item cost is not a number",
                                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBoxResult messageCode = MessageBox.Show("Item description is missing",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBoxResult messageCode = MessageBox.Show("Item Code must be 1 character",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (mode == "edit")
                {
                    //Test a description exists
                    if (ItemDescriptionBox.Text != "")
                    {
                        //Test a cost exists
                        if (double.TryParse(ItemCostBox.Text, out double costEditResult))
                        {
                            itemsLogic.UpdateItem(selectedItem, ItemDescriptionBox.Text, costEditResult);
                            RefreshUI();
                        }
                        else
                        {
                            MessageBoxResult messageCode = MessageBox.Show("Item cost is not a number",
                                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBoxResult messageCode = MessageBox.Show("Item description is missing",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Set UI to a safe starting screen
        /// </summary>
        private void RefreshUI()
        {
            try
            {
                EditItemBtn.IsEnabled = false;
                DeleteItemBtn.IsEnabled = false;
                AddItemBtn.IsEnabled = true;
                SaveItemBtn.IsEnabled = false;
                ItemCodeBox.IsEnabled = false;
                ItemCostBox.IsEnabled = false;
                ItemDescriptionBox.IsEnabled = false;
                ItemCodeBox.Text = "";
                ItemCostBox.Text = "";
                ItemDescriptionBox.Text = "";
                ItemListBox.IsEnabled = true;
                selectedItem = null;
                mode = "start";
                //Refresh item list
                ItemListBox.ItemsSource = itemsLogic.GetRefreshedItemList();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
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
