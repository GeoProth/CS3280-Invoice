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
                string del = "DELETE FROM ItemDesc WHERE ItemCode = " + code;

                DataAccess.ExecuteNonQuery(del);
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
                string update = "UPDATE ItemDesc SET ";
                // check for null values, might just update one thing
                if(desc != null && cost != null)
                {
                    update += "ItemDesc = '" + desc + "', Cost = '" + cost + "'";
                }
                else if(desc == null)
                {
                    update += "Cost = '" + cost + "'";
                }
                else if(cost == null)
                {
                    update += "ItemDesc = '" + desc + "'";
                }

                update += " WHERE ItemCode = '" + code + "'";

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
