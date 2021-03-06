// Generated 26 Jul 2021 12:51 - Singular Systems Object Generator Version 2.2.694
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
    public class ProductsSoldReport
     : MEReadOnlyBase<ProductsSoldReport>
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

        public static PropertyInfo<String> ProductDescriptionProperty = RegisterProperty<String>(c => c.ProductDescription, "Product Description");
        /// <summary>
        /// Gets the Product Description value
        /// </summary>
        [Display(Name = "Product Description", Description = "")]
        public String ProductDescription
        {
            get { return GetProperty(ProductDescriptionProperty); }
        }

        public static PropertyInfo<int> TotalProperty = RegisterProperty<int>(c => c.Total, "Total");
        /// <summary>
        /// Gets the Total value
        /// </summary>
        [Display(Name = "Total", Description = "")]
        public int Total
        {
            get { return GetProperty(TotalProperty); }
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

        internal static ProductsSoldReport GetProductsSoldReport(SafeDataReader dr)
        {
            var r = new ProductsSoldReport();
            r.Fetch(dr);
            return r;
        }

        protected void Fetch(SafeDataReader sdr)
        {
            int i = 0;
            LoadProperty(ProductNameProperty, sdr.GetString(i++));
            LoadProperty(ProductDescriptionProperty, sdr.GetString(i++));
            LoadProperty(TotalProperty, sdr.GetInt32(i++));
        }

        #endregion

    }

}