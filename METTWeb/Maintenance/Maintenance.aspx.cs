using Singular.Web.MaintenanceHelpers;

namespace MEWeb.Maintenance
{
  /// <summary>
  /// The Maintenance custom page class
  /// </summary>
  public partial class Maintenance : MEPageBase<MaintenanceVM>
  {
  }

  /// <summary>
  /// The MaintenanceVM ViewModel class
  /// </summary>
  public class MaintenanceVM: StatelessMaintenanceVM
  {
    /// <summary>
    /// Setup the ViewModel
    /// </summary>
    protected override void Setup()
    {
      base.Setup();

      // Add Maintenance pages here.
      MainSection mainSection = AddMainSection("General");
      mainSection.AddMaintenancePage<MELib.Maintenance.MovieGenreList>("Movie Genre Maintenance");
      mainSection.AddMaintenancePage<MELib.Products.ProductList>("Product Maintenance");
      mainSection.AddMaintenancePage<MELib.Products.ProductCategoryList>("ProductCategory Maintenance");
      mainSection.AddMaintenancePage<MELib.TransactionItems.TransactionItemList>("Purchased Items Maintenance");
      mainSection.AddMaintenancePage<MELib.Transactions.TransactionList>("Transactions Maintenance");
      // Add more lists here for maintaining, e.g. Status List, Years or lookup tables used in the project
        }
	}
}
