﻿// Generated 11 Jul 2018 18:12 - Singular Systems Object Generator Version 2.2.693
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


namespace METTLib.Maintenance
{
	[Serializable]
	public class Legaldesignation
	 : METTBusinessBase<Legaldesignation>
	{
		#region " Properties and Methods "

		#region " Properties "

		public static PropertyInfo<int> LegalDesignationIDProperty = RegisterProperty<int>(c => c.LegalDesignationID, "ID", 0);
		/// <summary>
		/// Gets the ID value
		/// </summary>
		[Display(AutoGenerateField = false), Key, DisplayName("ID")]
		public int LegalDesignationID
		{
			get { return GetProperty(LegalDesignationIDProperty); }
		}

		public static PropertyInfo<String> LegalDesignationProperty = RegisterProperty<String>(c => c.LegalDesignation, "Legaldesignation", "");
		/// <summary>
		/// Gets and sets the Legaldesignation value
		/// </summary>
		[Display(Name = "Legaldesignation", Description = "Description of Legal Designation e.g. NationalPark, Ramsar, Marine"), DisplayName("Legaldesignation"),
		StringLength(100, ErrorMessage = "Legaldesignation cannot be more than 100 characters")]
		public String LegalDesignation
		{
			get { return GetProperty(LegalDesignationProperty); }
			set { SetProperty(LegalDesignationProperty, value); }
		}

		public static PropertyInfo<Boolean> IsActiveIndProperty = RegisterProperty<Boolean>(c => c.IsActiveInd, "Isactiveind", true);
		/// <summary>
		/// Gets and sets the Isactiveind value
		/// </summary>
		[Display(Name = "Isactiveind", Description = ""), DisplayName("Isactiveind"),
		Required(ErrorMessage = "Isactiveind required")]
		public Boolean IsActiveInd
		{
			get { return GetProperty(IsActiveIndProperty); }
			set { SetProperty(IsActiveIndProperty, value); }
		}

		public static PropertyInfo<int> CreatedByProperty = RegisterProperty<int>(c => c.CreatedBy, "Createdby", 0);
		/// <summary>
		/// Gets the Createdby value
		/// </summary>
		[Display(AutoGenerateField = false), DisplayName("Createdby")]
		public int? CreatedBy
		{
			get { return GetProperty(CreatedByProperty); }
		}

		public static PropertyInfo<SmartDate> CreatedDateTimeProperty = RegisterProperty<SmartDate>(c => c.CreatedDateTime, "Createddatetime", new SmartDate(DateTime.Now));
		/// <summary>
		/// Gets the Createddatetime value
		/// </summary>
		[Display(AutoGenerateField = false), DisplayName("Createddatetime")]
		public SmartDate CreatedDateTime
		{
			get { return GetProperty(CreatedDateTimeProperty); }
		}

		public static PropertyInfo<int> ModifiedByProperty = RegisterProperty<int>(c => c.ModifiedBy, "Modifiedby", 0);
		/// <summary>
		/// Gets the Modifiedby value
		/// </summary>
		[Display(AutoGenerateField = false), DisplayName("Modifiedby")]
		public int? ModifiedBy
		{
			get { return GetProperty(ModifiedByProperty); }
		}

		public static PropertyInfo<SmartDate> ModifiedDateTimeProperty = RegisterProperty<SmartDate>(c => c.ModifiedDateTime, "Modifieddatetime", new SmartDate(DateTime.Now));
		/// <summary>
		/// Gets the Modifieddatetime value
		/// </summary>
		[Display(AutoGenerateField = false), DisplayName("Modifieddatetime")]
		public SmartDate ModifiedDateTime
		{
			get { return GetProperty(ModifiedDateTimeProperty); }
		}

		#endregion

		#region " Methods "

		protected override object GetIdValue()
		{
			return GetProperty(LegalDesignationIDProperty);
		}

		public override string ToString()
		{
			if (this.LegalDesignation.Length == 0)
			{
				if (this.IsNew)
				{
					return String.Format("New {0}", "Legaldesignation");
				}
				else
				{
					return String.Format("Blank {0}", "Legaldesignation");
				}
			}
			else
			{
				return this.LegalDesignation;
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
			// Set any variables here, not in the constructor or NewLegaldesignation() method.
		}

		public static Legaldesignation NewLegaldesignation()
		{
			return DataPortal.CreateChild<Legaldesignation>();
		}

		public Legaldesignation()
		{
			MarkAsChild();
		}

		internal static Legaldesignation GetLegaldesignation(SafeDataReader dr)
		{
			var l = new Legaldesignation();
			l.Fetch(dr);
			return l;
		}

		protected void Fetch(SafeDataReader sdr)
		{
			using (BypassPropertyChecks)
			{
				int i = 0;
				LoadProperty(LegalDesignationIDProperty, sdr.GetInt32(i++));
				LoadProperty(LegalDesignationProperty, sdr.GetString(i++));
				LoadProperty(IsActiveIndProperty, sdr.GetBoolean(i++));
				LoadProperty(CreatedByProperty, sdr.GetInt32(i++));
				LoadProperty(CreatedDateTimeProperty, sdr.GetSmartDate(i++));
				LoadProperty(ModifiedByProperty, sdr.GetInt32(i++));
				LoadProperty(ModifiedDateTimeProperty, sdr.GetSmartDate(i++));
			}

			MarkAsChild();
			MarkOld();
			BusinessRules.CheckRules();
		}

		protected override Action<SqlCommand> SetupSaveCommand(SqlCommand cm)
		{
			LoadProperty(ModifiedByProperty, Settings.CurrentUser.UserID);

			AddPrimaryKeyParam(cm, LegalDesignationIDProperty);

			cm.Parameters.AddWithValue("@LegalDesignation", GetProperty(LegalDesignationProperty));
			cm.Parameters.AddWithValue("@IsActiveInd", GetProperty(IsActiveIndProperty));
			cm.Parameters.AddWithValue("@ModifiedBy", GetProperty(ModifiedByProperty));

			return (scm) =>
			{
	// Post Save
	if (this.IsNew)
				{
					LoadProperty(LegalDesignationIDProperty, scm.Parameters["@LegalDesignationID"].Value);
				}
			};
		}

		protected override void SaveChildren()
		{
			// No Children
		}

		protected override void SetupDeleteCommand(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@LegalDesignationID", GetProperty(LegalDesignationIDProperty));
		}

		#endregion

	}

}