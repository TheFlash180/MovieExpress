// Generated 22 Jul 2021 15:42 - Singular Systems Object Generator Version 2.2.694
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


namespace MELib.Products
{
    [Serializable]
    public class ProductCategoryList
     : MEBusinessListBase<ProductCategoryList, ProductCategory>
    {
        #region " Business Methods "

        public ProductCategory GetItem(int ProductCategoryID)
        {
            foreach (ProductCategory child in this)
            {
                if (child.ProductCategoryID == ProductCategoryID)
                {
                    return child;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "Product Categorys";
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

        public static ProductCategoryList NewProductCategoryList()
        {
            return new ProductCategoryList();
        }

        public ProductCategoryList()
        {
            // must have parameter-less constructor
        }

        public static ProductCategoryList GetProductCategoryList()
        {
            return DataPortal.Fetch<ProductCategoryList>(new Criteria());
        }

        protected void Fetch(SafeDataReader sdr)
        {
            this.RaiseListChangedEvents = false;
            while (sdr.Read())
            {
                this.Add(ProductCategory.GetProductCategory(sdr));
            }
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
                        cm.CommandText = "GetProcs.getProductCategoryList";
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