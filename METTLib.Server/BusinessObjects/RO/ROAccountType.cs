﻿// Generated 22 Jul 2021 13:45 - Singular Systems Object Generator Version 2.2.694
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


namespace MELib.RO
{
    [Serializable]
    public class ROAccountType
     : MEReadOnlyBase<ROAccountType>
    {
        #region " Properties and Methods "

        #region " Properties "

        public static PropertyInfo<int> AccountTypeIDProperty = RegisterProperty<int>(c => c.AccountTypeID, "ID", 0);
        /// <summary>
        /// Gets the ID value
        /// </summary>
        [Display(AutoGenerateField = false), Key]
        public int AccountTypeID
        {
            get { return GetProperty(AccountTypeIDProperty); }
        }

        public static PropertyInfo<String> AccountTypeProperty = RegisterProperty<String>(c => c.AccountType, "Account Type", "");
        /// <summary>
        /// Gets the Account Type value
        /// </summary>
        [Display(Name = "Account Type", Description = "")]
        public String AccountType
        {
            get { return GetProperty(AccountTypeProperty); }
        }

        public static PropertyInfo<String> AccountTypeCodeProperty = RegisterProperty<String>(c => c.AccountTypeCode, "Account Type Code", "");
        /// <summary>
        /// Gets the Account Type Code value
        /// </summary>
        [Display(Name = "Account Type Code", Description = "")]
        public String AccountTypeCode
        {
            get { return GetProperty(AccountTypeCodeProperty); }
        }

        public static PropertyInfo<Boolean> IsActiveIndProperty = RegisterProperty<Boolean>(c => c.IsActiveInd, "Is Active", true);
        /// <summary>
        /// Gets the Is Active value
        /// </summary>
        [Display(Name = "Is Active", Description = "Indicator showing if the Movie is Active")]
        public Boolean IsActiveInd
        {
            get { return GetProperty(IsActiveIndProperty); }
        }

        public static PropertyInfo<DateTime?> DeletedDateProperty = RegisterProperty<DateTime?>(c => c.DeletedDate, "Deleted Date");
        /// <summary>
        /// Gets the Deleted Date value
        /// </summary>
        [Display(Name = "Deleted Date", Description = "When this record was deleted")]
        public DateTime? DeletedDate
        {
            get
            {
                return GetProperty(DeletedDateProperty);
            }
        }

        public static PropertyInfo<int> DeletedByProperty = RegisterProperty<int>(c => c.DeletedBy, "Deleted By", 0);
        /// <summary>
        /// Gets the Deleted By value
        /// </summary>
        [Display(Name = "Deleted By", Description = "User that deleted the record")]
        public int DeletedBy
        {
            get { return GetProperty(DeletedByProperty); }
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

        #endregion

        #region " Methods "

        protected override object GetIdValue()
        {
            return GetProperty(AccountTypeIDProperty);
        }

        public override string ToString()
        {
            return this.AccountType;
        }

        #endregion

        #endregion

        #region " Data Access & Factory Methods "

        internal static ROAccountType GetROAccountType(SafeDataReader dr)
        {
            var r = new ROAccountType();
            r.Fetch(dr);
            return r;
        }

        protected void Fetch(SafeDataReader sdr)
        {
            int i = 0;
            LoadProperty(AccountTypeIDProperty, sdr.GetInt32(i++));
            LoadProperty(AccountTypeProperty, sdr.GetString(i++));
            LoadProperty(AccountTypeCodeProperty, sdr.GetString(i++));
            LoadProperty(IsActiveIndProperty, sdr.GetBoolean(i++));
            LoadProperty(DeletedDateProperty, sdr.GetValue(i++));
            LoadProperty(DeletedByProperty, sdr.GetInt32(i++));
            LoadProperty(CreatedDateProperty, sdr.GetSmartDate(i++));
            LoadProperty(CreatedByProperty, sdr.GetInt32(i++));
            LoadProperty(ModifiedDateProperty, sdr.GetSmartDate(i++));
            LoadProperty(ModifiedByProperty, sdr.GetInt32(i++));
        }

        #endregion

    }

}