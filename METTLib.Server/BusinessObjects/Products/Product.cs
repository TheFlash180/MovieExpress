// Generated 14 Jul 2021 11:50 - Singular Systems Object Generator Version 2.2.694
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
    public class Product
     : MEBusinessBase<Product>
    {
        #region " Properties and Methods "

        #region " Properties "

        public static PropertyInfo<int> ProductIDProperty = RegisterProperty<int>(c => c.ProductID, "ID", 0);
        /// <summary>
        /// Gets the ID value
        /// </summary>
        [Display(AutoGenerateField = false), Key]
        public int ProductID
        {
            get { return GetProperty(ProductIDProperty); }
        }

        public static PropertyInfo<int> ProductCategoryIDProperty = RegisterProperty<int>(c => c.ProductCategoryID, "Product Category", 0);
        /// <summary>
        /// Gets and sets the Product Category value
        /// </summary>
        [Display(Name = "Product Category", Description = "Link to ProductCategoryID in ProductCategories"),
        Required(ErrorMessage = "Product Category required")]
        public int ProductCategoryID
        {
            get { return GetProperty(ProductCategoryIDProperty); }
            set { SetProperty(ProductCategoryIDProperty, value); }
        }

        public static PropertyInfo<String> ProductNameProperty = RegisterProperty<String>(c => c.ProductName, "Product Name", "GetName");
        /// <summary>
        /// Gets and sets the Product Name value
        /// </summary>
        [Display(Name = "Product Name", Description = ""),
        StringLength(50, ErrorMessage = "Product Name cannot be more than 50 characters")]
        public String ProductName
        {
            get { return GetProperty(ProductNameProperty); }
            set { SetProperty(ProductNameProperty, value); }
        }

        public static PropertyInfo<String> ProductDescriptionProperty = RegisterProperty<String>(c => c.ProductDescription, "Product Description", "Description of product");
        /// <summary>
        /// Gets and sets the Product Description value
        /// </summary>
        [Display(Name = "Product Description", Description = ""),
        StringLength(250, ErrorMessage = "Product Description cannot be more than 250 characters")]
        public String ProductDescription
        {
            get { return GetProperty(ProductDescriptionProperty); }
            set { SetProperty(ProductDescriptionProperty, value); }
        }

        public static PropertyInfo<String> ProductCodeProperty = RegisterProperty<String>(c => c.ProductCode, "Product Code", "Code Needed");
        /// <summary>
        /// Gets and sets the Product Code value
        /// </summary>
        [Display(Name = "Product Code", Description = "Gives a cerain code to each product e.g. (Chips = CHPS)"),
        StringLength(50, ErrorMessage = "Product Code cannot be more than 50 characters")]
        public String ProductCode
        {
            get { return GetProperty(ProductCodeProperty); }
            set { SetProperty(ProductCodeProperty, value); }
        }

        public static PropertyInfo<Decimal> PriceProperty = RegisterProperty<Decimal>(c => c.Price, "Price", Convert.ToDecimal(0.00));
        /// <summary>
        /// Gets and sets the Price value
        /// </summary>
        [Display(Name = "Price", Description = "Selling price of product"),
        Required(ErrorMessage = "Price required")]
        public Decimal Price
        {
            get { return GetProperty(PriceProperty); }
            set { SetProperty(PriceProperty, value); }
        }

        public static PropertyInfo<int> StockProperty = RegisterProperty<int>(c => c.Stock, "Stock", 0);
        /// <summary>
        /// Gets and sets the Stock value
        /// </summary>
        [Display(Name = "Stock", Description = "")]
        public int Stock
        {
            get { return GetProperty(StockProperty); }
            set { SetProperty(StockProperty, value); }
        }

        public static PropertyInfo<DateTime?> DeletedDateProperty = RegisterProperty<DateTime?>(c => c.DeletedDate, "Deleted Date");
        /// <summary>
        /// Gets and sets the Deleted Date value
        /// </summary>
        [Display(Name = "Deleted Date", Description = "When this record was deleted")]
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
        [Display(Name = "Deleted By", Description = "User that deleted the record")]
        public int DeletedBy
        {
            get { return GetProperty(DeletedByProperty); }
            set { SetProperty(DeletedByProperty, value); }
        }

        public static PropertyInfo<SmartDate> CreatedDateProperty = RegisterProperty<SmartDate>(c => c.CreatedDate, "Created Date", new SmartDate(DateTime.Now));
        /// <summary>
        /// Gets the Created Date value
        /// </summary>
        [Display(AutoGenerateField = false)]
        public SmartDate CreatedDate
        {
            get { return GetProperty(CreatedDateProperty); }
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

        public static PropertyInfo<Boolean> IsActiveIndProperty = RegisterProperty<Boolean>(c => c.IsActiveInd, "Is Active", true);
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

        public static PropertyInfo<Boolean> IsAvailableProperty = RegisterProperty<Boolean>(c => c.IsAvailable, "Is Available", true);
        /// <summary>
        /// Gets and sets the Is Available value
        /// </summary>
        [Display(Name = "Is Available", Description = ""),
        Required(ErrorMessage = "Is Available required")]
        public Boolean IsAvailable
        {
            get { return GetProperty(IsAvailableProperty); }
            set { SetProperty(IsAvailableProperty, value); }
        }

        public static PropertyInfo<Boolean> DeletedIndProperty = RegisterProperty<Boolean>(c => c.DeletedInd, "Deleted", false);
        /// <summary>
        /// Gets and sets the Deleted value
        /// </summary>
        [Display(Name = "Deleted", Description = ""),
        Required(ErrorMessage = "Deleted required")]
        public Boolean DeletedInd
        {
            get { return GetProperty(DeletedIndProperty); }
            set { SetProperty(DeletedIndProperty, value); }
        }

        #endregion

        #region " Methods "

        protected override object GetIdValue()
        {
            return GetProperty(ProductIDProperty);
        }

        public override string ToString()
        {
            if (this.ProductName.Length == 0)
            {
                if (this.IsNew)
                {
                    return String.Format("New {0}", "Product");
                }
                else
                {
                    return String.Format("Blank {0}", "Product");
                }
            }
            else
            {
                return this.ProductName;
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
            // Set any variables here, not in the constructor or NewProduct() method.
        }

        public static Product NewProduct()
        {
            return DataPortal.CreateChild<Product>();
        }

        public Product()
        {
            MarkAsChild();
        }

        internal static Product GetProduct(SafeDataReader dr)
        {
            var p = new Product();
            p.Fetch(dr);
            return p;
        }

        protected void Fetch(SafeDataReader sdr)
        {
            using (BypassPropertyChecks)
            {
                int i = 0;
                LoadProperty(ProductIDProperty, sdr.GetInt32(i++));
                LoadProperty(ProductCategoryIDProperty, sdr.GetInt32(i++));
                LoadProperty(ProductNameProperty, sdr.GetString(i++));
                LoadProperty(ProductDescriptionProperty, sdr.GetString(i++));
                LoadProperty(ProductCodeProperty, sdr.GetString(i++));
                LoadProperty(PriceProperty, sdr.GetDecimal(i++));
                LoadProperty(StockProperty, sdr.GetInt32(i++));
                LoadProperty(DeletedDateProperty, sdr.GetValue(i++));
                LoadProperty(DeletedByProperty, sdr.GetInt32(i++));
                LoadProperty(CreatedDateProperty, sdr.GetSmartDate(i++));
                LoadProperty(CreatedByProperty, sdr.GetInt32(i++));
                LoadProperty(ModifiedDateProperty, sdr.GetSmartDate(i++));
                LoadProperty(ModifiedByProperty, sdr.GetInt32(i++));
                LoadProperty(IsActiveIndProperty, sdr.GetBoolean(i++));
                LoadProperty(IsAvailableProperty, sdr.GetBoolean(i++));
                LoadProperty(DeletedIndProperty, sdr.GetBoolean(i++));
            }

            MarkAsChild();
            MarkOld();
            BusinessRules.CheckRules();
        }

        protected override Action<SqlCommand> SetupSaveCommand(SqlCommand cm)
        {
            LoadProperty(ModifiedByProperty, Settings.CurrentUser.UserID);

            AddPrimaryKeyParam(cm, ProductIDProperty);

            cm.Parameters.AddWithValue("@ProductCategoryID", GetProperty(ProductCategoryIDProperty));
            cm.Parameters.AddWithValue("@ProductName", GetProperty(ProductNameProperty));
            cm.Parameters.AddWithValue("@ProductDescription", GetProperty(ProductDescriptionProperty));
            cm.Parameters.AddWithValue("@ProductCode", GetProperty(ProductCodeProperty));
            cm.Parameters.AddWithValue("@Price", GetProperty(PriceProperty));
            cm.Parameters.AddWithValue("@Stock", GetProperty(StockProperty));
            cm.Parameters.AddWithValue("@DeletedDate", Singular.Misc.NothingDBNull(DeletedDate));
            cm.Parameters.AddWithValue("@DeletedBy", GetProperty(DeletedByProperty));
            cm.Parameters.AddWithValue("@ModifiedBy", GetProperty(ModifiedByProperty));
            cm.Parameters.AddWithValue("@IsActiveInd", GetProperty(IsActiveIndProperty));
            cm.Parameters.AddWithValue("@IsAvailable", GetProperty(IsAvailableProperty));
            cm.Parameters.AddWithValue("@DeletedInd", GetProperty(DeletedIndProperty));

            return (scm) =>
            {
                // Post Save
                if (this.IsNew)
                {
                    LoadProperty(ProductIDProperty, scm.Parameters["@ProductID"].Value);
                }
            };
        }

        protected override void SaveChildren()
        {
            // No Children
        }

        protected override void SetupDeleteCommand(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ProductID", GetProperty(ProductIDProperty));
        }

        #endregion

    }

}