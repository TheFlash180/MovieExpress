﻿// Generated 26 Jul 2021 12:51 - Singular Systems Object Generator Version 2.2.694
//<auto-generated/>
using System;
using Csla;
using Csla.Serialization;
using Csla.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Singular;
using System.Data;
using System.Data.SqlClient;


namespace MELib.Reports
{
    [Serializable]
    public class ProductStock
     : MEReadOnlyBase<ProductStock>
    {
        #region " Properties and Methods "

        #region " Properties "

        public static PropertyInfo<String> ProductNameProperty = RegisterProperty<String>(c => c.ProductName, "ID");
        /// <summary>
        /// Gets the ID value
        /// </summary>
        [Display(AutoGenerateField = false), Key]
        public String ProductName
        {
            get { return GetProperty(ProductNameProperty); }
        }

        public static PropertyInfo<String> ProductCodeProperty = RegisterProperty<String>(c => c.ProductCode, "Product Code");
        /// <summary>
        /// Gets the Product Description value
        /// </summary>
        [Display(Name = "Product Code", Description = "")]
        public String ProductCode
        {
            get { return GetProperty(ProductCodeProperty); }
        }

        public static PropertyInfo<int> StockProperty = RegisterProperty<int>(c => c.Stock, "Stock");
        /// <summary>
        /// Gets the Total value
        /// </summary>
        [Display(Name = "Stock", Description = "")]
        public int Stock
        {
            get { return GetProperty(StockProperty); }
        }

        #endregion

        #region " Methods "

        protected override object GetIdValue()
        {
            return GetProperty(ProductNameProperty);
        }

        public override string ToString()
        {
            return this.ProductName;
        }

        #endregion

        #endregion

        #region " Data Access & Factory Methods "

        internal static ProductStock GetProductStock(SafeDataReader dr)
        {
            var r = new ProductStock();
            r.Fetch(dr);
            return r;
        }

        protected void Fetch(SafeDataReader sdr)
        {
            int i = 0;
            LoadProperty(ProductNameProperty, sdr.GetString(i++));
            LoadProperty(ProductCodeProperty, sdr.GetString(i++));
            LoadProperty(StockProperty, sdr.GetInt32(i++));
        }

        #endregion

    }

}