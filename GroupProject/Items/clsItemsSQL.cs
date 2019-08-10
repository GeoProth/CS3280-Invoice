using GroupProject.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
    /// <summary>
    /// 
    /// </summary>
    public class clsItemsSQL
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
        public clsItemsSQL()
        {
            try
            {
                DataAccess = new clsDataAccess();

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        #region Get Queries
        /// <summary>
        /// Query to retrieve all the Items from Database
        /// </summary>
        /// <returns>A list of all items</returns>
        public List<Item> GetAllItems()
        {
            try
            {
                List<Item> items = new List<Item>();

                //Sql Statement
                string Sql = "SELECT * FROM ItemDesc ORDER BY ItemCode";

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
        /// Checks for the given code in the database
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Returns the code if in the database</returns>
        public string CheckCode(string code)
        {
            try
            {
                //Sql statement
                string sql = "SELECT TOP 1 ItemCode FROM ItemDesc WHERE ItemCode = '" + code + "'";

                string result = DataAccess.ExecuteScalarSQL(sql);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion

        #region Insert/Delete Queries
        /// <summary>
        /// Insert New Item into ItemDesc table
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        public void InsertNewItem(char code, string desc, string cost)
        {
            try
            {
                //Sql statement
                string insert = "INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES('" + code + "', '" + desc + "', '" + cost + "')";

                DataAccess.ExecuteNonQuery(insert);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Delete Item From ItemDesc table
        /// </summary>
        /// <param name="code"></param>
        public void DeleteItem(string code)
        {
            try
            {
                ///Sql statement
                string del = "DELETE FROM ItemDesc WHERE ItemCode = '" + code + "'";

                DataAccess.ExecuteNonQuery(del);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets a list of invoices that have the given item code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>A list of invoices</returns>
        public List<Invoice> GetBadInvoices(string code)
        {
            try
            {
                List<Invoice> invoices = new List<Invoice>();
                //Sql statement
                string sql = "SELECT DISTINCT I.InvoiceNum, I.InvoiceDate, I.TotalCost FROM Invoices I INNER JOIN LineItems LI ON LI.InvoiceNum = I.InvoiceNum WHERE LI.ItemCode = '" + code + "'";
                int retVal = 0;
                DS = DataAccess.ExecuteSQLStatement(sql, ref retVal);

                foreach (DataRow dr in DS.Tables[0].Rows)
                {
                    invoices.Add(new Invoice(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDouble(dr[2])));
                }

                return invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }

        }
        #endregion

        #region Update
        /// <summary>
        /// Update Item,
        /// checks for possibility of updating one element of Item
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        public void UpdateItem(char code, string desc, string cost)
        {
            try
            {
                //Partial SQl statement
                //string update = "UPDATE ItemDesc SET ";
                //// check for null values, might just update one thing
                //if(desc != null && cost != null)
                //{
                //    update += "ItemDesc = '" + desc + "', Cost = '" + cost + "'";
                //}
                //else if(desc == null)
                //{
                //    update += "Cost = '" + cost + "'";
                //}
                //else if(cost == null)
                //{
                //    update += "ItemDesc = '" + desc + "'";
                //}

                //update += " WHERE ItemCode = '" + code + "'";
                //UPDATE ItemDesc Set ItemDesc = 'GTS Plat', Cost = 30 WHERE ItemCode = 'E'
                //Sql statement
                string update = "UPDATE ItemDesc SET ItemDesc = '" + desc + "', Cost = " + cost + " WHERE ItemCode = '" + code + "'";
                DataAccess.ExecuteNonQuery(update);
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
