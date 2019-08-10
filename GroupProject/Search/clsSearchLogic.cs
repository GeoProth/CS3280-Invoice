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
                totals = SQL.GetUniqueTotals();
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

        //public void InstantiateFilteredInvoices(object num, object date, object total)
        //{
        //    ComboBox InvoiceNum = (ComboBox)num;
        //    ComboBox InvoiceDate = (ComboBox)date;
        //    ComboBox InvoiceTotal = (ComboBox)total;

        //    InvoiceList.Clear();
        //    foreach(Invoice i in SQL.GetFilteredInvoices(
        //            InvoiceNum.SelectedIndex == -1 ? -1 : Convert.ToInt32(InvoiceNum.SelectedItem),
        //            InvoiceDate.SelectedIndex == -1 ? "" : InvoiceDate.SelectedItem.ToString(), 
        //            InvoiceTotal.SelectedIndex == -1 ? -1 : Convert.ToInt32(InvoiceTotal.SelectedItem)))
        //    {
        //        InvoiceList.Add(i);
        //    }
        //}
        #endregion
    }
}
