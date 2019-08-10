using GroupProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    /// <summary>
    /// Logic Class for Main Window
    /// </summary>
    class clsMainLogic
    {
        #region Variables
        /// <summary>
        /// SQL Object for main
        /// </summary>
        private clsMainSQL SQL;
        /// <summary>
        /// private list of Items
        /// </summary>
        private List<Item> items;
        /// <summary>
        /// current invoice
        /// </summary>
        private Invoice invoice;
        #endregion

        #region Methods
        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsMainLogic()
        {
            try
            {
                SQL = new clsMainSQL();
                //get all items
                items = SQL.GetAllItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #region Getters/Setters
        /// <summary>
        /// Getter and Setter for list of items
        /// </summary>
        public List<Item> ItemsList
        {
            get
            {
                return items;
            }
            set
            {
                this.items = value;
            }
        }
        /// <summary>
        /// Getter/Setter for this Invoice (Current)
        /// </summary>
        public Invoice CurrentInvoice
        {
            get
            {
                return this.invoice;
            }
            set
            {
                this.invoice = value;
            }
        }

        #endregion

        #region Invoice functionality
        /// <summary>
        /// Method to Create a new Invoice
        /// </summary>
        public void CreateInvoice()
        {
            try
            {
                invoice = new Invoice(); //set current invoice to new invoice
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Delete Current Invoice
        /// </summary>
        public void DeleteInvoice()
        {
            try
            {
                SQL.DeleteInvoice(this.invoice);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        ///  Save current Invoice
        /// </summary>
        /// <param name="Dt">Date</param>
        public void SaveInvoice(string Date)
        {
            try
            {
                //if user doesn't specify a date, then we need to give them an automatic date
                if(Date == "")
                {
                    CurrentInvoice.InvoiceDate = DateTime.Now.ToString("MM/dd/yyy");

                }
                else
                {
                    CurrentInvoice.InvoiceDate = Date;
                }
                //Determine whether this is a new Invoice or not
                //If Invoice number is equal to 0, then it is new
                if(CurrentInvoice.InvoiceNumber == 0)
                {
                    int newInvoiceNum = SQL.InsertNewInvoice(CurrentInvoice);
                    CurrentInvoice.InvoiceNumber = newInvoiceNum;
                }
                else //update existing invoice
                {
                    //update Date and new items
                    SQL.UpdateInvoiceDate(CurrentInvoice);
                    SQL.UpdateInvoiceItems(CurrentInvoice);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Add Item to current Invoice
        /// </summary>
        /// <param name="ItemSelected">Item to add</param>
        /// <param name="Qnty">Number of this item to add</param>
        public void AddItem(Item ItemSelected, Int32 Qnty)
        {
            try
            {
                //add new item for each
                for (int i = 0; i < Qnty; i++)
                {
                    CurrentInvoice.InvoiceItems.Add(new Item(ItemSelected.ItemCode, ItemSelected.ItemDescription, ItemSelected.ItemCost));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

  
        /// <summary>
        /// Delete Item from invoice list
        /// </summary>
        /// <param name="ItemSelected"></param>
        public void DeleteItem(Item ItemSelected)
        {
            try
            {
                CurrentInvoice.InvoiceItems.Remove(ItemSelected);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        //reset current invoice list
        public void ResetSelectedInvoice()
        {
            try { 
                CurrentInvoice.InvoiceItems.Clear();

                CurrentInvoice.InvoiceItems = SQL.GetItemsByInvoiceNum(CurrentInvoice.InvoiceNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion
        #endregion
    }
}
