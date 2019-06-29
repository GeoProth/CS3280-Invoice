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
        /// <summary>
        /// Data Access Object
        /// </summary>
        clsDataAccess DataAccess;
        /// <summary>
        /// Data Set Object
        /// </summary>
        DataSet DS;
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
                foreach(DataRow dr in DS.Tables[0].Rows)
                {
                    invoice = new Invoice(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                return invoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

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
                    string Sql = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES ("
                        + invoice.InvoiceNumber + ", " + i + ", " + item.ItemCode + ")";
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
                DataAccess.Equals(Sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        #endregion

        #region Insert/Delete Queries
      /*  public int InsertNewInvoice(Invoice newInvoice)
        {
            try
            {
                //need to find the max
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        */
        #endregion


    }
}