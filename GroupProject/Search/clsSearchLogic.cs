using GroupProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GroupProject.Search
{
    public class clsSearchLogic
    {
        #region Variables
        /// <summary>
        /// SQL object for Search
        /// </summary>
        public clsSearchSQL SQL;
        /// <summary>
        /// Private list of invoices
        /// </summary>
        private List<Invoice> invoice;
        /// <summary>
        /// Private list of invoice numbers
        /// </summary>
        private List<int> numbers;
        /// <summary>
        /// Private list of invoice dates
        /// </summary>
        private List<string> dates;
        /// <summary>
        /// Private list of invoice total costs
        /// </summary>
        private List<double> totals;
        /// <summary>
        /// Private list of filtered invoices
        /// </summary>
        private List<Invoice> filtered;
        /// <summary>
        /// Private object to store selected invoice
        /// </summary>
        private Invoice Invoice;
        #endregion

        #region Methods
        /// <summary>
        /// Default Constructor
        /// </summary>
        public clsSearchLogic()
        {
            try
            {
                SQL = new clsSearchSQL();
                //get all invoices
                invoice = SQL.GetAllInvoices();
                //get all invoice numbers
                numbers = SQL.GetInvoiceNumbers();
                //get dates of all invoices
                dates = SQL.GetUniqueDates();
                //get total costs of all invoices
                totals = SQL.GetTotals();
                ////
                //filtered = SQL.GetFilteredInvoices();

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        #region Getters/Setters
        /// <summary>
        /// Getter and Setter for list of invoices
        /// </summary>
        public List<Invoice> InvoiceList
        {
            get
            {
                return invoice;
            }
            set
            {
                this.invoice = value;
            }
        }
        /// <summary>
        /// Getter and Setter for list of invoice numbers
        /// </summary>
        public List<int> NumbersList
        {  
            get
            {
                return numbers;
            }
            set
            {
                this.numbers = value;
            }
        }

        /// <summary>
        /// Getter and Setter for list of invoice dates
        /// </summary>
        public List<string> DatesList
        {
            get
            {
                return dates;
            }
            set
            {
                this.dates = value;
            }
        }

        /// <summary>
        /// Getter and Setter for list of invoice total costs
        /// </summary>
        public List<double> TotalsList
        {
            get
            {
                return totals;
            }
            set
            {
                this.totals = value;
            }
        }

        /// <summary>
        /// Getter and Setter for list of invoices
        /// </summary>
        public List<Invoice> FilteredList
        {
            get
            {
                return filtered;
            }
            set
            {
                this.filtered = value;
            }
        }

        /// <summary>
        /// Getter/Setter for selected invoice
        /// </summary>
        public Invoice SelectedInvoice
        {
            get
            {
                return this.Invoice;
            }
            set
            {
                this.Invoice = value;
            }
        }
        #endregion
        #region methods
        /// <summary>
        /// function to reset invoices after clear filter
        /// </summary>
        public void ResetInvoices()
        {
            try
            {
                InvoiceList.Clear();
                InvoiceList = SQL.GetAllInvoices();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        public void InstantiateFilteredInvoices(object num, object date, object total)
        {
            try
            {
                ComboBox InvoiceNum = (ComboBox)num;
                ComboBox InvoiceDate = (ComboBox)date;
                ComboBox InvoiceTotal = (ComboBox)total;
                string Idate;
                if (InvoiceDate.SelectedIndex == -1)
                {
                    Idate = null;
                }
                else
                {
                    Idate = InvoiceDate.SelectedItem.ToString();
                }
                int Inum = Convert.ToInt32(InvoiceNum.SelectedValue);
                double Itot = Convert.ToDouble(InvoiceTotal.SelectedValue);
                InvoiceList.Clear();
                InvoiceList = SQL.GetFilteredInvoices(Inum, Idate, Itot);
            }

            catch(Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion
        #endregion
    }
}
