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
    class clsItemsSQL
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
    }
}
