using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Classes
{
    /// <summary>
    /// Invoice Class representing an Invoice
    /// from the database
    /// </summary>
    public class Invoice
    {
        #region Variables
        /// <summary>
        /// Int representing the Invoice Number
        /// </summary>
        private int Num;
        /// <summary>
        /// string representing the Invoice Date
        /// </summary>
        private string Date;

        private double Total;
        /// <summary>
        /// List representing Items associated with an Invoice
        /// </summary>
        
        private List<Item> Items;
        #endregion
        #region Methods
        //new blank invoice will instantiate a new list of items
        public Invoice() {
            this.Items = new List<Item>();
        }
        public Invoice(int num, string date, double totalCost)
        {
            Num = num;
            Date = date;
            Total = totalCost;
            Items = new List<Item>();
        }
        /// <summary>
        /// Getter and Setter for Invoice Number
        /// </summary>
        public int InvoiceNumber
        {
            get
            {
                return Num;
            }
            set
            {
                this.Num = value;
            }
        }
        /// <summary>
        /// Getter and Setter for Invoice date
        /// </summary>
        public string InvoiceDate
        {
            get
            {
                return Date;
            }
            set
            {
                this.Date = value;
            }
        }
        /// <summary>
        /// Getter and Setter for List of Items in Invoice
        /// </summary>
        public List<Item> InvoiceItems
        {
            get
            {
                return Items;
            }
            set
            {
                this.Items = value;
            }
        }
        /// <summary>
        /// Getter for total cost of Invoice
        /// </summary>
        public double TotalCost
        {
            get
            {
                return this.Total;
            }
            set
            {
                double total = 0;
                foreach(Item item in Items)
                {
                    total += item.ItemCost;
                    this.Total = total;
                }
                
            }
            
        }
        #endregion
    }
}
