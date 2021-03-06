// Generated 28 May 2018 08:56 - Singular Systems Object Generator Version 2.2.694
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


namespace METTLib.RO
{
	[Serializable]
	public class ROCountryList
	 : METTReadOnlyListBase<ROCountryList, ROCountry>
	{
		#region " Business Methods "

		public ROCountry GetItem(int CountryID)
		{
			foreach (ROCountry child in this)
			{
				if (child.CountryID == CountryID)
				{
					return child;
				}
			}
			return null;
		}

		public override string ToString()
		{
			return "Countrys";
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

		public static ROCountryList NewROCountryList()
		{
			return new ROCountryList();
		}

		public ROCountryList()
		{
			// must have parameter-less constructor
		}

		public static ROCountryList GetROCountryList()
		{
			return DataPortal.Fetch<ROCountryList>(new Criteria());
		}

		protected void Fetch(SafeDataReader sdr)
		{
			this.RaiseListChangedEvents = false;
			this.IsReadOnly = false;
			while (sdr.Read())
			{
				this.Add(ROCountry.GetROCountry(sdr));
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
						cm.CommandText = "GetProcs.getROCountryList";
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