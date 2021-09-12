using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Singular.Web;

namespace MEWeb.Profile
{
  public partial class DepositFunds : MEPageBase<DepositFundsVM>
  {
  }

  public class DepositFundsVM : MEStatelessViewModel<DepositFundsVM>
  {
    public MELib.Accounts.AccountList AccountList { get; set; }
    public MELib.Accounts.Account CurrentAccount { get; set; }
    public decimal DepositAmount { get; set; } = 0.00M;

    public DepositFundsVM()
    {

    }


    protected override void Setup()
    {
      base.Setup();
      CurrentAccount = MELib.Accounts.AccountList.GetAccountList().FirstOrDefault();
      
    }

    [WebCallable]
    public static bool UpdateBalance(MELib.Accounts.Account account, decimal depositAmount)
    {
      try
      {
        account.Balance += depositAmount;
        if (depositAmount<=0)
        {
            return false;
        }
        account.TrySave(typeof(MELib.Accounts.AccountList));
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}

