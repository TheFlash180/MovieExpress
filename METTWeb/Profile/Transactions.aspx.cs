using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Singular.Web;

namespace MEWeb.Profile
{
    public partial class Transactions : MEPageBase<TransactionsVM>
    {
    }
    public class TransactionsVM : MEStatelessViewModel<TransactionsVM>
    {

        public MELib.Transactions.TransactionList TransactionList { get; set; }
        public MELib.Transactions.TransactionList CurrentTransaction { get; set; }
        public TransactionsVM()
        {

        }
        protected override void Setup()
        {
            base.Setup();
            CurrentTransaction = MELib.Transactions.TransactionList.NewTransactionList();
            TransactionList = MELib.Transactions.TransactionList.GetTransactionList();
            if (Singular.Settings.CurrentUserID == 1)
            {
                CurrentTransaction = TransactionList;
            }
            else
            {
                foreach (var item in TransactionList)
                {
                    if (item.UserID != 1)
                    {
                        CurrentTransaction.Add(item);
                    }
                }
            }


        }
    }
}

