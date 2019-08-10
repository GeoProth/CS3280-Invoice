using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupProject.Classes;
using System.Reflection;

namespace GroupProject.Items
{
    public class clsItemsLogic
    {
        #region Variables
        /// <summary>
        /// The list of items
        /// </summary>
        private List<Item> items;
        /// <summary>
        /// The item SQL class
        /// </summary>
        private clsItemsSQL SQL;

        #endregion

        #region Methods

        /// <summary>
        /// Constructor for the items logic class
        /// </summary>
        public clsItemsLogic()
        {
            try
            {
                SQL = new clsItemsSQL();
                items = SQL.GetAllItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }

        }

        /// <summary>
        /// Getter/setter for the ItemList
        /// </summary>
        public List<Item> ItemList
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
        /// Refreshes the item list, then returns it
        /// </summary>
        /// <returns></returns>
        public List<Item> GetRefreshedItemList()
        {
            try
            {
                items = SQL.GetAllItems();
                //Round the item cost, so it doesn't display oddly
                foreach (Item i in items)
                {
                    i.ItemCost = Math.Round(i.ItemCost, 2, MidpointRounding.AwayFromZero);
                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Adds an item to the database
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        public void AddItem(string code, string description, double cost)
        {
            try
            {
                //Check if the item code already exists
                if (SQL.CheckCode(code) == code.ToLower() || SQL.CheckCode(code) == code.ToUpper())
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + "Item with code " + code + " already exists");
                }
                else
                {
                    SQL.InsertNewItem(Convert.ToChar(code), description, cost.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the given item in the database
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        public void UpdateItem(Item toUpdate, string description, double cost)
        {
            try
            {
                SQL.UpdateItem(toUpdate.ItemCode, description, cost.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the given item in the database
        /// </summary>
        /// <param name="toDelete"></param>
        public void DeleteItem(Item toDelete)
        {
            try
            {
                SQL.DeleteItem(toDelete.ItemCode.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Checks if the given item can be deleted
        /// </summary>
        /// <param name="toDelete"></param>
        /// <returns>A boolean depending on the length of the list</returns>
        public bool CheckDelete(Item toDelete)
        {
            try
            {
                string code = toDelete.ItemCode.ToString();
                List<Invoice> invoices = new List<Invoice>();
                invoices = SQL.GetBadInvoices(code);
                //If no invoices are on the list, it can be deleted
                if (invoices.Count == 0)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }

        }

        /// <summary>
        /// Gets a string of the invoices that are using the current item
        /// </summary>
        /// <param name="toDelete"></param>
        /// <returns>A string of invoice numbers</returns>
        public string BadInvoices(Item toDelete)
        {
            try
            {
                string sInvoices = "";
                string code = toDelete.ItemCode.ToString();
                List<Invoice> invoices = new List<Invoice>();
                invoices = SQL.GetBadInvoices(code);
                //Put each invoice number on a string
                foreach (Invoice invoice in invoices)
                {
                    sInvoices += invoice.InvoiceNumber.ToString() + ", ";
                }

                return sInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }

        }
        #endregion
    }
}