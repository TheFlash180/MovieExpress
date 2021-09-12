﻿// Generated 15 Jul 2021 07:05 - Singular Systems Object Generator Version 2.2.694
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


namespace MELib.Transactions
{
    [Serializable]
    public class Transaction
     : MEBusinessBase<Transaction>
    {
        #region " Properties and Methods "

        #region " Properties "

        public static PropertyInfo<int> TransactionIDProperty = RegisterProperty<int>(c => c.TransactionID, "ID", 0);
        /// <summary>
        /// Gets the ID value
        /// </summary>
        [Display(AutoGenerateField = false), Key]
        public int TransactionID
        {
            get { return GetProperty(TransactionIDProperty); }
        }

        public static PropertyInfo<int?> TransactionTypeIDProperty = RegisterProperty<int?>(c => c.TransactionTypeID, "Transaction Type", null);
        /// <summary>
        /// Gets and sets the Transaction Type value
        /// </summary>
        [Display(Name = "Transaction Type", Description = ""),
        Required(ErrorMessage = "Transaction Type required")]
        public int? TransactionTypeID
        {
            get { return GetProperty(TransactionTypeIDProperty); }
            set { SetProperty(TransactionTypeIDProperty, value); }
        }

        public static PropertyInfo<int?> UserIDProperty = RegisterProperty<int?>(c => c.UserID, "User", null);
        /// <summary>
        /// Gets and sets the User value
        /// </summary>
        [Display(Name = "User", Description = ""),
        Required(ErrorMessage = "User required")]
        public int? UserID
        {
            get { return GetProperty(UserIDProperty); }
            set { SetProperty(UserIDProperty, value); }
        }

        public static PropertyInfo<String> DescriptionProperty = RegisterProperty<String>(c => c.Description, "Description", "n/a");
        /// <summary>
        /// Gets and sets the Description value
        /// </summary>
        [Display(Name = "Description", Description = "")]
        public String Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }

        public static PropertyInfo<Decimal> AmountProperty = RegisterProperty<Decimal>(c => c.Amount, "Amount", Convert.ToDecimal(0));
        /// <summary>
        /// Gets and sets the Amount value
        /// </summary>
        [Display(Name = "Amount", Description = ""),
        Required(ErrorMessage = "Amount required")]
        public Decimal Amount
        {
            get { return GetProperty(AmountProperty); }
            set { SetProperty(AmountProperty, value); }
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

        #endregion

        #region " Methods "

        protected override object GetIdValue()
        {
            return GetProperty(TransactionIDProperty);
        }

        public override string ToString()
        {
            if (this.Description.Length == 0)
            {
                if (this.IsNew)
                {
                    return String.Format("New {0}", "Transaction");
                }
                else
                {
                    return String.Format("Blank {0}", "Transaction");
                }
            }
            else
            {
                return this.Description;
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
            // Set any variables here, not in the constructor or NewTransaction() method.
        }

        public static Transaction NewTransaction()
        {
            return DataPortal.CreateChild<Transaction>();
        }

        public Transaction()
        {
            MarkAsChild();
        }

        internal static Transaction GetTransaction(SafeDataReader dr)
        {
            var t = new Transaction();
            t.Fetch(dr);
            return t;
        }

        protected void Fetch(SafeDataReader sdr)
        {
            using (BypassPropertyChecks)
            {
                int i = 0;
                LoadProperty(TransactionIDProperty, sdr.GetInt32(i++));
                LoadProperty(TransactionTypeIDProperty, Singular.Misc.ZeroNothing(sdr.GetInt32(i++)));
                LoadProperty(UserIDProperty, Singular.Misc.ZeroNothing(sdr.GetInt32(i++)));
                LoadProperty(DescriptionProperty, sdr.GetString(i++));
                LoadProperty(AmountProperty, sdr.GetDecimal(i++));
                LoadProperty(DeletedDateProperty, sdr.GetValue(i++));
                LoadProperty(DeletedByProperty, sdr.GetInt32(i++));
                LoadProperty(CreatedDateProperty, sdr.GetSmartDate(i++));
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

            AddPrimaryKeyParam(cm, TransactionIDProperty);

            cm.Parameters.AddWithValue("@TransactionTypeID", GetProperty(TransactionTypeIDProperty));
            cm.Parameters.AddWithValue("@UserID", GetProperty(UserIDProperty));
            cm.Parameters.AddWithValue("@Description", GetProperty(DescriptionProperty));
            cm.Parameters.AddWithValue("@Amount", GetProperty(AmountProperty));
            cm.Parameters.AddWithValue("@DeletedDate", Singular.Misc.NothingDBNull(DeletedDate));
            cm.Parameters.AddWithValue("@DeletedBy", GetProperty(DeletedByProperty));
            cm.Parameters.AddWithValue("@ModifiedBy", GetProperty(ModifiedByProperty));
            cm.Parameters.AddWithValue("@IsActiveInd", GetProperty(IsActiveIndProperty));

            return (scm) =>
            {
                // Post Save
                if (this.IsNew)
                {
                    LoadProperty(TransactionIDProperty, scm.Parameters["@TransactionID"].Value);
                }
            };
        }

        protected override void SaveChildren()
        {
            // No Children
        }

        protected override void SetupDeleteCommand(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@TransactionID", GetProperty(TransactionIDProperty));
        }

        #endregion

    }

}