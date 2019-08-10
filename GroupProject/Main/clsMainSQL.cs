using GroupProject.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace GroupProject.Main
{
    /// <summary>
    /// SQL Class for Queries to Data Access
    /// </summary>
    class clsMainSQL
    {
        #region Variables
        /// <summary>
        /// Data Access Object
        /// </summary>
        clsDataAccess DataAccess;
        /// <summary>
        /// Data Set Object
        /// </summary>
        DataSet DS;
        #endregion

        #region Methods
        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsMainSQL()
        {
            try
            {
                DataAccess = new clsDataAccess();
            }
            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #region Get Queries
        /// <summary>
        /// Query to retrieve all the Items from Database
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAllItems()
        {
            try
            {
                List<Item> items = new List<Item>();

                //Sql Statement
                string Sql = "SELECT * FROM ItemDesc";

                int retVal = 0;

                DS = DataAccess.ExecuteSQLStatement(Sql, ref retVal);
                //Loop through DS and add Items
                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    items.Add(new Item(Convert.ToChar(dr[0]), dr[1].ToString(), (float)Convert.ToDouble(dr[2])));
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Query to extract an Invoice from Database by Id
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public Invoice GetInvoiceByID(int invoiceNum)
        {
            try
            {
                //Sql Statement
                string Sql = "SELECT * FROM Invoices WHERE InvoiceNum = " + invoiceNum;
                Invoice invoice = null;

                int retVal = 0;

                DS = DataAccess.ExecuteSQLStatement(Sql, ref retVal);
                //this should only pull one invoice
                DataRow dr = DS.Tables[0].Rows[0];
                
                invoice = new Invoice(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDouble(dr[2]));
                

                return invoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Query to get all Items within an Invoice by Invoice Number
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public List<Item> GetItemsByInvoiceNum(int invoiceNum)
        {
            try
            {
                List<Item> items = new List<Item>();

                //Sql Statement
                string Sql = "SELECT ID.ItemCode, ID.ItemDesc, ID.Cost FROM ITemDesc ID " +
                    "INNER JOIN LineItems LI ON ID.ItemCode = LI.ItemCode " +
                    "WHERE LI.InvoiceNum = " + invoiceNum;

                int retVal = 0;

                DS = DataAccess.ExecuteSQLStatement(Sql, ref retVal);

                foreach(DataRow dr in DS.Tables[0].Rows)
                {
                    items.Add(new Item(Convert.ToChar(dr[0]), dr[1].ToString(), (float)Convert.ToDouble(dr[2])));

                }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion

        #region Update Queries
        /// <summary>
        /// Update Query to update Invoice Items
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateInvoiceItems(Invoice invoice)
        {
            try
            {
                //Need to delete Lines from Invoice first, then update
                //Sql Statement
                string delete = "DELETE FROM LineItems WHERE InvoiceNum = " + invoice.InvoiceNumber;

                DataAccess.ExecuteNonQuery(delete);

                //Need to loop through Invoice items and add new rows
                int i = 1;// integer representing Line Item Number
                foreach(Item item in invoice.InvoiceItems)
                {
                    string Sql = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES ('"
                        + invoice.InvoiceNumber + "', '" + i + "', '" + item.ItemCode + "')";
                    DataAccess.ExecuteNonQuery(Sql);
                    i++;//increment LineItemNumber
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Update Invoice Date Query
        /// updates Invoice Date base on InvoiceNumber
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateInvoiceDate(Invoice invoice)
        {
            try
            {
                //SQl Statement
                string Sql = "UPDATE Invoices SET InvoiceDate = " + invoice.InvoiceDate + " WHERE InvoiceNum = " + invoice.InvoiceNumber;
                DataAccess.ExecuteNonQuery(Sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        
        #endregion

        #region Insert/Delete Queries
        
        ///<summary>
        ///Insert new Invoice, return its number for displaying
        ///</summary>
        ///<param name="newInvoice">Invoice number</param>
        public int InsertNewInvoice(Invoice newInvoice)
        {
            try
            {
                //Insert new Invoice first
                string Sql = "INSERT INTO Invoices(InvoiceDate, TotalCost) VALUES('" + newInvoice.InvoiceDate + "', '" + newInvoice.TotalCost + "')";

                DataAccess.ExecuteNonQuery(Sql);

                //Get that Invoice Number
                Sql = "SELECT TOP 1 InvoiceNum FROM Invoices ORDER BY InvoiceNum DESC";
                int retVal = 0;
                DS = DataAccess.ExecuteSQLStatement(Sql, ref retVal);
                int invoiceNum = Convert.ToInt32(DS.Tables[0].Rows[0][0]);

                //insert Line items
                int i = 1;//line item number
                foreach(Item item in newInvoice.InvoiceItems)
                {
                    Sql = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES('" + invoiceNum + "', '" + i + "', '" + item.ItemCode + "')";
                    DataAccess.ExecuteNonQuery(Sql);
                    i++;

                }

                return invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Delete an Invoice from both tables
        /// </summary>
        /// <param name="invoice"></param>
        public void DeleteInvoice(Invoice invoice)
        {
            try
            {
                //need to delete from Line Items first
                //Sql statement
                string Sql = "DELETE FROM LineItems WHERE InvoiceNum = " + invoice.InvoiceNumber;
                DataAccess.ExecuteNonQuery(Sql);

                //delete from Invoices
                Sql = "DELETE FROM Invoices WHERE InvoiceNum = " + invoice.InvoiceNumber;
                DataAccess.ExecuteNonQuery(Sql);
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