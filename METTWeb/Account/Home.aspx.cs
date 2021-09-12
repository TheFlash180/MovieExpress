using System;
using Singular.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Singular.Web.Data;
using MELib.RO;
using MELib.Security;
using Singular;
using System.ComponentModel.DataAnnotations;

namespace MEWeb.Account
{
  public partial class Home : MEPageBase<HomeVM>
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }
  }
  public class HomeVM : MEStatelessViewModel<HomeVM>
  {
    // Declare your page variables/properties here
    public bool FoundUserMoviesInd { get; set; }

    public string LoggedInUserName { get; set; }

    public MELib.Movies.UserMovieList UserMovieList { get; set; }

    public MELib.Accounts.AccountList UserAccountList { get; set; }
    public MELib.Accounts.Account UserAccount { get; set; }

    public MELib.Users.UserList UserList { get; set; }

    public MELib.Users.User CurrentUser { get; set; }
    public MELib.RO.ROAccountTypeList ROAccountTypeList { get; set; }
    public ROAccountType CurrentAccountType { get; set; }
    public string AccountTypeName { get; set; }

 
    //[Singular.DataAnnotations.DropDownWeb(typeof(MELib.RO.ROAccountTypeList), UnselectedText = "Select", ValueMember = "AccountTypeID", DisplayMember = "AccountType")]
    //[Display(Name = "Account Type")]
    //public int AccountTypeID { get; set; }

    public HomeVM()
    {

    }

    protected override void Setup()
    {
      base.Setup();

      // On page load initiate/set your data/variables and or properties here
      // Should pass in criteria for the specific user that is viewing the page, however using current identity
      UserMovieList = MELib.Movies.UserMovieList.GetUserMovieList();
      UserList = MELib.Users.UserList.GetUserList();
      CurrentUser = UserList.GetItem(Singular.Settings.CurrentUserID);
      UserAccountList = MELib.Accounts.AccountList.GetAccountList();
      ROAccountTypeList = ROAccountTypeList.GetROAccountTypeList();
      UserAccount = UserAccountList.FirstOrDefault();
      CurrentAccountType = ROAccountTypeList.GetItem(UserAccount.AccountTypeID);

      if (UserMovieList.Count() > 0) 
      {
        FoundUserMoviesInd = true;
      }
      else
      {
        FoundUserMoviesInd = false;
      }


      LoggedInUserName = Singular.Security.Security.CurrentIdentity.UserName;
    }

    // Place your page's WebCallable methods here

    // Example WebCallable Method called GetSomeData layout/structure

    /// <summary>
    /// This is a very basic example of a WebCallable method
    /// </summary>
    /// <param name="SomeReferenceID"></param>
    /// <returns></returns>
    [Singular.Web.WebCallable(LoggedInOnly = true)]
    public static Singular.Web.Result GetSomeData(int SomeReferenceID)
    {
      Result sr = new Result();
      try
      {
        // Perform some action here and return the result
        // sr.Data = "";
        sr.Success = true;
      }
      catch (Exception e)
      {
        sr.Data = e.InnerException;
        sr.Success = false;
      }
      return sr;
    }
  }
}


