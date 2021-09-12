﻿// Generated 22 Jul 2021 15:42 - Singular Systems Object Generator Version 2.2.694
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
    public class ProductCategory
     : MEBusinessBase<ProductCategory>
    {
        #region " Properties and Methods "

        #region " Properties "

        public static PropertyInfo<int> ProductCategoryIDProperty = RegisterProperty<int>(c => c.ProductCategoryID, "ID", 0);
        /// <summary>
        /// Gets the ID value
        /// </summary>
        [Display(AutoGenerateField = false), Key]
        public int ProductCategoryID
        {
            get { return GetProperty(ProductCategoryIDProperty); }
        }

        public static PropertyInfo<String> CategoryProperty = RegisterProperty<String>(c => c.Category, "Category", "");
        /// <summary>
        /// Gets and sets the Category value
        /// </summary>
        [Display(Name = "Category", Description = ""),
        StringLength(50, ErrorMessage = "Category cannot be more than 50 characters")]
        public String Category
        {
            get { return GetProperty(CategoryProperty); }
            set { SetProperty(CategoryProperty, value); }
        }

        public static PropertyInfo<DateTime?> DeletedDateProperty = RegisterProperty<DateTime?>(c => c.DeletedDate, "Deleted Date");
        /// <summary>
        /// Gets and sets the Deleted Date value
        /// </summary>
        [Display(Name = "Deleted Date", Description = "")]
        public DateTime? DeletedDate
        {
            get
            {
                return GetProperty(DeletedDateProperty);
            }
            set
            {
                SetProperty(DeletedDateProperty, value);
            }
        }

        public static PropertyInfo<int> DeletedByProperty = RegisterProperty<int>(c => c.DeletedBy, "Deleted By", 0);
        /// <summary>
        /// Gets and sets the Deleted By value
        /// </summary>
        [Display(Name = "Deleted By", Description = "")]
        public int DeletedBy
        {
            get { return GetProperty(DeletedByProperty); }
            set { SetProperty(DeletedByProperty, value); }
        }

        public static PropertyInfo<DateTime> CreadetDateProperty = RegisterProperty<DateTime>(c => c.CreadetDate, "Creadet Date");
        /// <summary>
        /// Gets and sets the Creadet Date value
        /// </summary>
        [Display(Name = "Creadet Date", Description = ""),
        Required(ErrorMessage = "Creadet Date required")]
        public DateTime CreadetDate
        {
            get
            {
                return GetProperty(CreadetDateProperty);
            }
            set
            {
                SetProperty(CreadetDateProperty, value);
            }
        }

        public static PropertyInfo<int> CreatedByProperty = RegisterProperty<int>(c => c.CreatedBy, "Created By", 0);
        /// <summary>
        /// Gets the Created By value
        /// </summary>
        [Display(AutoGenerateField = false)]
        public int CreatedBy
        {
            get { return GetProperty(CreatedByProperty); }
        }

        public static PropertyInfo<SmartDate> ModifiedDateProperty = RegisterProperty<SmartDate>(c => c.ModifiedDate, "Modified Date", new SmartDate(DateTime.Now));
        /// <summary>
        /// Gets the Modified Date value
        /// </summary>
        [Display(AutoGenerateField = false)]
        public SmartDate ModifiedDate
        {
            get { return GetProperty(ModifiedDateProperty); }
        }

        public static PropertyInfo<int> ModifiedByProperty = RegisterProperty<int>(c => c.ModifiedBy, "Modified By", 0);
        /// <summary>
        /// Gets the Modified By value
        /// </summary>
        [Display(AutoGenerateField = false)]
        public int ModifiedBy
        {
            get { return GetProperty(ModifiedByProperty); }
        }

        public static PropertyInfo<Boolean> IsActiveIndProperty = RegisterProperty<Boolean>(c => c.IsActiveInd, "Is Active", false);
        /// <summary>
        /// Gets and sets the Is Active value
        /// </summary>
        [Display(Name = "Is Active", Description = ""),
        Required(ErrorMessage = "Is Active required")]
        public Boolean IsActiveInd
        {
            get { return GetProperty(IsActiveIndProperty); }
            set { SetProperty(IsActiveIndProperty, value); }
        }

        #endregion

        #region " Methods "

        protected override object GetIdValue()
        {
            return GetProperty(ProductCategoryIDProperty);
        }

        public override string ToString()
        {
            if (this.Category.Length == 0)
            {
                if (this.IsNew)
                {
                    return String.Format("New {0}", "Product Category");
                }
                else
                {
                    return String.Format("Blank {0}", "Product Category");
                }
            }
            else
            {
                return this.Category;
            }
        }

        #endregion

        #endregion

        #region " Validation Rules "

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
        }

        #endregion

        #region " Data Access & Factory Methods "

        protected override void OnCreate()
        {
            // This is called when a new object is created
            // Set any variables here, not in the constructor or NewProductCategory() method.
        }

        public static ProductCategory NewProductCategory()
        {
            return DataPortal.CreateChild<ProductCategory>();
        }

        public ProductCategory()
        {
            MarkAsChild();
        }

        internal static ProductCategory GetProductCategory(SafeDataReader dr)
        {
            var p = new ProductCategory();
            p.Fetch(dr);
            return p;
        }

        protected void Fetch(SafeDataReader sdr)
        {
            using (BypassPropertyChecks)
            {
                int i = 0;
                LoadProperty(ProductCategoryIDProperty, sdr.GetInt32(i++));
                LoadProperty(CategoryProperty, sdr.GetString(i++));
                LoadProperty(DeletedDateProperty, sdr.GetValue(i++));
                LoadProperty(DeletedByProperty, sdr.GetInt32(i++));
                LoadProperty(CreadetDateProperty, sdr.GetValue(i++));
                LoadProperty(CreatedByProperty, sdr.GetInt32(i++));
                LoadProperty(ModifiedDateProperty, sdr.GetSmartDate(i++));
                LoadProperty(ModifiedByProperty, sdr.GetInt32(i++));
                LoadProperty(IsActiveIndProperty, sdr.GetBoolean(i++));
            }

            MarkAsChild();
            MarkOld();
            BusinessRules.CheckRules();
        }

        protected override Action<SqlCommand> SetupSaveCommand(SqlCommand cm)
        {
            LoadProperty(ModifiedByProperty, Settings.CurrentUser.UserID);

            AddPrimaryKeyParam(cm, ProductCategoryIDProperty);

            cm.Parameters.AddWithValue("@Category", GetProperty(CategoryProperty));
            cm.Parameters.AddWithValue("@DeletedDate", Singular.Misc.NothingDBNull(DeletedDate));
            cm.Parameters.AddWithValue("@DeletedBy", GetProperty(DeletedByProperty));
            cm.Parameters.AddWithValue("@CreadetDate", CreadetDate);
            cm.Parameters.AddWithValue("@ModifiedBy", GetProperty(ModifiedByProperty));
            cm.Parameters.AddWithValue("@IsActiveInd", GetProperty(IsActiveIndProperty));

            return (scm) =>
            {
    // Post Save
    if (this.IsNew)
                {
                    LoadProperty(ProductCategoryIDProperty, scm.Parameters["@ProductCategoryID"].Value);
                }
            };
        }

        protected override void SaveChildren()
        {
            // No Children
        }

        protected override void SetupDeleteCommand(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ProductCategoryID", GetProperty(ProductCategoryIDProperty));
        }

        #endregion

    }

}