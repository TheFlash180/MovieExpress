using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using Singular.Web;

namespace MEWeb.Profile
{
    public partial class Profile : MEPageBase<ProfileVM>
    {
    }
    public class ProfileVM : MEStatelessViewModel<ProfileVM>
    {
        public MELib.Accounts.AccountList AccountList { get; set; }
        public MELib.Users.UserList UserList { get; set; }

        public MELib.Accounts.Account UserAccount { get; set; }
        public MELib.Users.UserList CurrentUser { get; set; }
        public string AccountTypeName { get; set; }

        public string About { get; set; }


        public ProfileVM()
        {

        }
        protected override void Setup()
        {
            base.Setup();
            AccountList = MELib.Accounts.AccountList.GetAccountList();
            UserList = MELib.Users.UserList.GetUserList();
            CurrentUser = MELib.Users.UserList.NewUserList();
            foreach (var item in UserList)
            {
                if (item.UserID == Singular.Settings.CurrentUserID)
                {
                    CurrentUser.Add(item);
                }
            }

            if (Singular.Settings.CurrentUserID == 1)
            {
                About = "<p>This user is an admin and therefore has admin access (Access to all of the application). This user has the same priveleges as the normal user and more. This user can do maintenance on all product and product categories, if there is no stock left on products this user is the person to ensure that stock is maintained at all  time. This application provides reports to this user to evluate how the kiosk is doing.</p>";
            }
            else if(Singular.Settings.CurrentUserID == 1324)
            {
                About = "<p>This user is a normal user who has access to most of the application's features. The user visits the site regularly to purchase products from the kiosk and the rent out movies. If the user purchases item from the Kiosk, this user can then go and view it's transactions at the left side menu. If the user is short of money this user can go deposit some funds into his/her account by entering the amount.</p>";
            }
        }
    }
}

