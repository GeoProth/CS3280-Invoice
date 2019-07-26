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
        #endregion
    }
}
