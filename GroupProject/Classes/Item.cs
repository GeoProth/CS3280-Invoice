﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Classes
{
    /// <summary>
    /// Item Class representing an Invoice Item from Database
    /// </summary>
    public class Item
    {
        #region Variables
        /// <summary>
        /// Char representing the Item Code
        /// </summary>
        private char Code;
        /// <summary>
        /// string representing the Item Description
        /// </summary>
        private string Description;
        /// <summary>
        /// float representing the Item Cost
        /// </summary>
        private double Cost;
        #endregion
        #region Methods
        /// <summary>
        /// Blank Constructor
        /// </summary>
        public Item() { }
        /// <summary>
        /// Constructor for Item, assigns cost, code, and Description
        /// from database
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        public Item(char code, string desc, double cost)
        {
            Code = code;
            Description = desc;
            Cost = cost;
        }
        /// <summary>
        /// Getter and Setter for Item Cost
        /// </summary>
        public double ItemCost
        {
            get
            {
                return Cost;
            }
            set
            {
                this.Cost = value;
            }
        }
        /// <summary>
        /// Getter and Setter for Item Description
        /// </summary>
        public string ItemDescription
        {
            get
            {
                return Description;
            }
            set
            {
                this.Description = value;
            }
        }
        /// <summary>
        /// Getter and Setter for Item Code
        /// </summary>
        public char ItemCode
        {
            get
            {
                return Code;
            }
            set
            {
                this.Code = value;
            }
        }
        #endregion
    }
}
