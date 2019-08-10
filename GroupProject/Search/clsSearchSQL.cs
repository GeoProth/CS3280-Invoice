using GroupProject.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    public class clsSearchSQL
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
        public clsSearchSQL()
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
        /// Get All Invoices
        /// for list box
        /// </summary>
        /// <returns>A List of all Invoices in Database</returns>
        public List<Invoice> GetAllInvoices()
        {
            try
            {
                List<Invoice> invoices = new List<Invoice>();
                //Sql
                string get = "SELECT * FROM Invoices";

                int retVal = 0;
                DS = DataAccess.ExecuteSQLStatement(get, ref retVal);

                foreach(DataRow dr in DS.Tables[0].Rows)
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
        /// <summary>
        /// Get list of Invoice Numbers for ComboBox
        /// </summary>
        /// <returns></returns>
        public List<int> GetInvoiceNumbers()
        {
            try
            {
                List<int> numbers = new List<int>();
                string get = "SELECT InvoiceNum FROM Invoices";

                int retVal = 0;
                DS = DataAccess.ExecuteSQLStatement(get, ref retVal);

                foreach(DataRow dr in DS.Tables[0].Rows)
                {
                    numbers.Add(Convert.ToInt32(dr[0]));
                }

                return numbers;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Get Filtered Invoices based on filters passed
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="totalCost"></param>
        /// <returns></returns>
        public List<Invoice> GetFilteredInvoices(int invoiceNum, string invoiceDate, double totalCost)
        {
            try
            {
                List<Invoice> invoices = new List<Invoice>();
                //partial Sql
                string get = "SELECT * FROM Invoices WHERE ";
                //decide what filter is being used
                //if invoice num is provided, then its specific
                if(invoiceNum != 0)
                {
                   get += "InvoiceNum = " + invoiceNum;
                }
                //check for more than two values with date and cost
               else if((invoiceDate == null ? -1 : 1) + (totalCost == 0 ? -1 : 1) > 1)
                {
                    
                     get += "InvoiceDate = " + "#" + invoiceDate + "#";
                    get += " AND TotalCost = " + totalCost;
                }
                else if(invoiceDate != null)
                {
                    get += "InvoiceDate = " + "#" + invoiceDate + "#";
                }
                else if(totalCost != 0)
                {
                    get += "TotalCost = " + totalCost;
                }

                int retVal = 0;

                DS = DataAccess.ExecuteSQLStatement(get, ref retVal);

                foreach(DataRow dr in DS.Tables[0].Rows)
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
        /// <summary>
        /// Get a list of all Unique Dates from Invoices for Group box
        /// </summary>
        /// <returns></returns>
        public List<string> GetUniqueDates()
        {
            try
            {
                List<string> dates = new List<string>();
                string get = "SELECT DISTINCT InvoiceDate FROM Invoices";

                int retVal = 0;

                DS = DataAccess.ExecuteSQLStatement(get, ref retVal);

                foreach(DataRow dr in DS.Tables[0].Rows)
                {
                    dates.Add(dr[0].ToString());
                }

                return dates;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        /// <summary>
        /// Get all Unique Invoice totals for group box
        /// </summary>
        /// <returns></returns>
        public List<double> GetTotals()
        {
            try
            {
                List<double> totals = new List<double>();
                string get = "SELECT TotalCost FROM Invoices";

                int retVal = 0;

                DS = DataAccess.ExecuteSQLStatement(get, ref retVal);

                foreach(DataRow dr in DS.Tables[0].Rows)
                {
                    totals.Add(Convert.ToDouble(dr[0]));
                }

                return totals;

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
