// Generated 22 Jul 2021 13:45 - Singular Systems Object Generator Version 2.2.694
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
    public class ROAccountTypeList
     : MEReadOnlyListBase<ROAccountTypeList, ROAccountType>
    {
        #region " Business Methods "

        public ROAccountType GetItem(int AccountTypeID)
        {
            foreach (ROAccountType child in this)
            {
                if (child.AccountTypeID == AccountTypeID)
                {
                    return child;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "Account Types";
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

        public static ROAccountTypeList NewROAccountTypeList()
        {
            return new ROAccountTypeList();
        }

        public ROAccountTypeList()
        {
            // must have parameter-less constructor
        }

        public static ROAccountTypeList GetROAccountTypeList()
        {
            return DataPortal.Fetch<ROAccountTypeList>(new Criteria());
        }

        protected void Fetch(SafeDataReader sdr)
        {
            this.RaiseListChangedEvents = false;
            this.IsReadOnly = false;
            while (sdr.Read())
            {
                this.Add(ROAccountType.GetROAccountType(sdr));
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
                        cm.CommandText = "GetProcs.getROAccountTypeList";
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