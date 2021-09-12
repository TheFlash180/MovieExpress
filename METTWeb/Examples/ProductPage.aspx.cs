using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using Singular.Web;
using Csla;
using MELib.Transactions;

namespace MEWeb.Examples
{
    public partial class ProductPage : MEPageBase<ProductPageVM>
    {

    }

    public class ProductPageVM : MEStatelessViewModel<ProductPageVM>
    {
        public MELib.ROProducts.ROProductList ROProductList { get; set; }
        public MELib.TransactionItems.TransactionItemList TransactionItemList { get; set; }

        public MELib.TransactionItems.TransactionItemList CurrentTransactionItems { get; set; }
        public Transaction CurrentTransaction { get; set; }
        public MELib.Accounts.Account CurrentAccount { get; set; }

        public bool Premium { get; set; }

        public static PropertyInfo<int> ItemsCountProperty = RegisterSProperty<int>(c => c.ItemsCount, 0);

        [Display(Name = "Total Items", Description = "")]
        public int ItemsCount
        {
            get { return GetProperty(ItemsCountProperty); }
            set { SetProperty(ItemsCountProperty, value); }
        }

        public static PropertyInfo<String> CurrentCodeProperty = RegisterSProperty<String>(c => c.CurrentCode, "");

        [Display(Name = "CurrentProduct Code", Description = "")]
        public String CurrentCode
        {
            get { return GetProperty(CurrentCodeProperty); }
            set { SetProperty(CurrentCodeProperty, value); }
        }

        public static PropertyInfo<decimal> TotalCostProperty = RegisterSProperty<decimal>(c => c.TotalCost, 0);

        [Display(Name = "Total Cost", Description = "")]
        public decimal TotalCost
        {
            get { return GetProperty(TotalCostProperty); }
            set { SetProperty(TotalCostProperty, value); }
        }

        [Singular.DataAnnotations.DropDownWeb(typeof(MELib.RO.ROProductCategoryList), UnselectedText = "Select", ValueMember = "ProductCategoryID", DisplayMember = "Category")]
        [Display(Name = "Choose a category:")]
        public int? ProductCategoryID { get; set; }

        public ProductPageVM()
        {

        }

        protected override void Setup()
        {
            base.Setup();
            ROProductList = MELib.ROProducts.ROProductList.GetROProductList();
            CurrentTransactionItems = MELib.TransactionItems.TransactionItemList.GetTransactionItemList();
            TransactionItemList = MELib.TransactionItems.TransactionItemList.NewTransactionItemList();
            CurrentAccount = MELib.Accounts.AccountList.GetAccountList().FirstOrDefault();
            this.TotalCost = 0.00M;
            this.ItemsCount = 0;
            this.CurrentCode = "";
            if (Singular.Settings.CurrentUserID == 1)
            {
                Premium = false;
            }
            else
            {
                Premium = true;
            }
        }

        [WebCallable]
        public static MELib.TransactionItems.TransactionItemList AddProduct(MELib.ROProducts.ROProduct Product, decimal totalCost, MELib.TransactionItems.TransactionItemList currentCart, int itemsCount)
        {
            var ROProductList = MELib.ROProducts.ROProductList.GetROProductList();
            var currentProduct = ROProductList.GetItem(Product.ProductID);
            var item = MELib.TransactionItems.TransactionItemList.NewTransactionItemList();
            

            var currentAddedProduct = currentCart.FirstOrDefault(c => c.ProductID == Product.ProductID && c.IsActiveInd == true && c.CreatedBy == Singular.Security.Security.CurrentIdentity.UserID);

            if (currentAddedProduct != null)
            {
                if (currentProduct.Stock > currentAddedProduct.Quantity)
                {
                    currentAddedProduct.Quantity += 1;
                }
                return currentCart;
            }
            else
            {
                var newCartItem = currentCart.AddNew();
                newCartItem.ProductName = currentProduct.ProductName;
                newCartItem.ProductID = currentProduct.ProductID;
                newCartItem.SellingPrice = currentProduct.Price;
                newCartItem.Quantity = 1;
                newCartItem.IsActiveInd = true;
            }
            return currentCart;
        }

        [WebCallable]
        public static MELib.TransactionItems.TransactionItemList RemoveProduct(int ProductID, decimal totalCost, MELib.TransactionItems.TransactionItemList currentCart, int itemsCount)
        {
            var ROProductList = MELib.ROProducts.ROProductList.GetROProductList();
            var currentProduct = ROProductList.GetItem(ProductID);

            var currentAddedProduct = currentCart.FirstOrDefault(c => c.ProductID == ProductID && c.IsActiveInd == true && c.CreatedBy == Singular.Security.Security.CurrentIdentity.UserID);

            if(currentAddedProduct.Quantity>1)
            {
                currentAddedProduct.Quantity -= 1;
            }

            return currentCart;
        }

        [WebCallable]
        public static MELib.TransactionItems.TransactionItemList DeleteProduct(int ProductID, decimal totalCost, MELib.TransactionItems.TransactionItemList currentCart, int itemsCount)
        {
            var ROProductList = MELib.ROProducts.ROProductList.GetROProductList();
            var currentProduct = ROProductList.GetItem(ProductID);

            var currentAddedProduct = currentCart.FirstOrDefault(c => c.ProductID == ProductID && c.IsActiveInd == true && c.CreatedBy == Singular.Security.Security.CurrentIdentity.UserID);

            currentCart.Remove(currentAddedProduct);   
            currentAddedProduct.Quantity = 0;

            return currentCart;
        }

        [WebCallable]
        public static MELib.TransactionItems.TransactionItemList Reset(decimal totalCost, int itemsCount, MELib.TransactionItems.TransactionItemList currentCart)
        {
            currentCart.Clear();
            return currentCart;
        }

        [WebCallable]
        public static MELib.TransactionItems.TransactionItemList ResetAfterCheckout(decimal totalCost, int itemsCount, MELib.TransactionItems.TransactionItemList currentCart)
        {
            currentCart.Clear();
            return currentCart;
        }

        [WebCallable]
        public Result FilterProducts(int ProductCategoryID, int ResetInd, int itemsCount)
        {
            Result sr = new Result();

            try
            {
                if (ResetInd == 0)
                {
                    MELib.ROProducts.ROProductList ROProductList = MELib.ROProducts.ROProductList.GetROProductList(ProductCategoryID);
                    sr.Data = ROProductList;
                }
                else
                {
                    MELib.ROProducts.ROProductList ROProductList = MELib.ROProducts.ROProductList.GetROProductList();
                    sr.Data = ROProductList;
                }

                sr.Success = true;
            }
            catch (Exception e)
            {
                WebError.LogError(e, "Page: Products.aspx | Method: FilterProducts", $"(int ProductCategoryID, ({ProductCategoryID})");
                sr.Data = e.InnerException;
                sr.ErrorText = "Could not filter products by category.";
                sr.Success = false;
            }
            return sr;
        }

        [WebCallable]
        public static Result Checkout(MELib.Accounts.Account account, decimal totalCost, MELib.TransactionItems.TransactionItemList currentCart, int itemsCount)
        {
            Result sr = new Result();
            if(totalCost==0){
                sr.Success = false;
                return sr;
            }
            var transaction = TransactionList.NewTransactionList();
            var productList = MELib.Products.ProductList.GetProductList();
            var savedTransactionID = TransactionList.GetTransactionList().LastOrDefault().TransactionID;
            var total = account.Balance - totalCost;
            var count = 0;

            foreach (var item in currentCart)
            {
                count++;
                item.TransactionID = savedTransactionID;
                var currentProduct = productList.GetItem(item.ProductID);
                if (item.Quantity <= currentProduct.Stock)
                {
                    currentProduct.Stock -= item.Quantity;
                    item.IsActiveInd = false;
                    sr.Success = true;
                }
                else
                {
                    currentProduct.IsAvailable = false;
                    sr.Success = false;
                    sr.ErrorText = "Not enough stock.";
                    return sr;
                    
                }

                if(total>=0 && count==currentCart.Count){
                    var newTransaction = transaction.AddNew();
                    newTransaction.UserID = Singular.Security.Security.CurrentIdentity.UserID;
                    newTransaction.Amount = totalCost;
                    newTransaction.Description = "Purchased "+ itemsCount.ToString() + " item(s) from kiosk";
                    newTransaction.TransactionTypeID = 1;
                    newTransaction.IsActiveInd = true;

                    newTransaction.TrySave(typeof(TransactionList));
                    currentProduct.TrySave(typeof(MELib.Products.ProductList));
                }
            }


            if (total >= 0)
            {
                account.Balance = total;
                account.TrySave(typeof(MELib.Accounts.AccountList));
                currentCart.TrySave();
                currentCart.ClearNewItems();
                sr.Data = account.Balance;
                sr.Success = true;
                return sr;
            }
            else
            {
                sr.Data = account.Balance - totalCost;
                sr.Success = true;
                sr.ErrorText = "Insufficient Funds. Please deposit some funds";
                return sr;
            }
        }
    }
}