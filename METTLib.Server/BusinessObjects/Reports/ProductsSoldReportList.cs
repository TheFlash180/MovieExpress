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
    public class ProductsSoldReportList
     : MEReadOnlyListBase<ProductsSoldReportList, ProductsSoldReport>
    {
        #region " Business Methods "

        public ProductsSoldReport GetItem(string ProductName)
        {
            foreach (ProductsSoldReport child in this)
            {
                if (child.ProductName == ProductName)
                {
                    return child;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "S";
        }

        #endregion

        #region " Data Access "

        [Serializable]
        public class Criteria
          : CriteriaBase<Criteria>
        {
            public Criteria()
            {
            }

        }

        public static ProductsSoldReportList NewProductsSoldReportList()
        {
            return new ProductsSoldReportList();
        }

        public ProductsSoldReportList()
        {
            // must have parameter-less constructor
        }

        public static ProductsSoldReportList GetProductsSoldReportList()
        {
            return DataPortal.Fetch<ProductsSoldReportList>(new Criteria());
        }

        protected void Fetch(SafeDataReader sdr)
        {
            this.RaiseListChangedEvents = false;
            this.IsReadOnly = false;
            while (sdr.Read())
            {
                this.Add(ProductsSoldReport.GetProductsSoldReport(sdr));
            }
            this.IsReadOnly = true;
            this.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Fetch(Object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Singular.Settings.ConnectionString))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "GetProcs.getProductsSoldReport";
                        using (SafeDataReader sdr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            Fetch(sdr);
                        }
                    }
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        #endregion

    }

}