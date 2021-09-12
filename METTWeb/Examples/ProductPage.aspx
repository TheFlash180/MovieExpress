<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="MEWeb.Examples.ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Add page specific styles and Javascript classes below -->
    <link href="../Theme/Singular/Custom/home.css" rel="Stylesheet" />
    <link href="../Theme/Singular/Custom/customstyles.css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
    <!-- Placeholder not used in this eample -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (var h = this.Helpers)
        {
            var MainContent = h.DivC("row pad-top-10");
            {
                var MainContainer = MainContent.Helpers.DivC("col-md-12 p-n-lr");
                {
                    var PageContainer = MainContainer.Helpers.DivC("tabs-container");
                    {
                        var PageTab = PageContainer.Helpers.TabControl();
                        {
                            PageTab.Style.ClearBoth();
                            PageTab.AddClass("nav nav-tabs");
                            var ContainerTab = PageTab.AddTab("Available Products");
                            {
                                var RowContentDiv = ContainerTab.Helpers.DivC("row");
                                {
                                    var RowColMain = RowContentDiv.Helpers.DivC("col-md-12");
                                    {
                                        RowColMain.Helpers.HTML().Heading1("<b>Products</b>");
                                        RowColMain.Helpers.HTML().Heading2("Welcome to Movie Express's Kiosk. Please feel free to add products to your cart:");
                                    }
                                    var ColContentDiv = RowContentDiv.Helpers.DivC("col-md-8");
                                    {
                                        var ProductList = ColContentDiv.Helpers.BootstrapTableFor<MELib.ROProducts.ROProduct>((c) => c.ROProductList, false, false,"");
                                        {
                                            var ProductListRow = ProductList.FirstRow;
                                            {
                                                var ProductName = ProductListRow.AddColumn("Name");
                                                {
                                                    var ProductTitleText = ProductName.Helpers.Span(c => c.ProductName);
                                                }

                                                var ProductCode = ProductListRow.AddColumn("ProductCode");
                                                {
                                                    var ProductCodeText = ProductCode.Helpers.Span(c => c.ProductCode);
                                                }

                                                var ProductDescription = ProductListRow.AddColumn("Description");
                                                {
                                                    var ProductDescriptionText = ProductDescription.Helpers.Span(c => c.ProductDescription);
                                                }

                                                var OrderProduct = ProductListRow.AddColumn("Price");
                                                {
                                                    var OrderBtn = OrderProduct.Helpers.Button("Order Product", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.None);
                                                    {
                                                        OrderBtn.AddBinding(Singular.Web.KnockoutBindingString.text, c => "Add to cart @ R" + (c.Price).ToString("0.00.00"));
                                                        OrderBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "AddProduct($data)");
                                                        OrderBtn.AddClass("btn btn-primary btn-outline");
                                                        OrderBtn.Style.Width = "175px";
                                                    }
                                                }

                                                var Stock = ProductListRow.AddColumn("Stock Available");
                                                {
                                                    var StockText = Stock.Helpers.Span(c => c.Stock);
                                                }

                                                var FormContent = ColContentDiv.Helpers.With<MELib.Accounts.Account>(c => c.CurrentAccount);
                                                {

                                                    var AccountAmount = FormContent.Helpers.DivC("col-md-6");
                                                    {
                                                        AccountAmount.Helpers.HTML("<b>");
                                                        AccountAmount.Helpers.ReadOnlyFor(c => "Balance: R" + c.Balance.ToString("0.00.00")).Style.FontSize = "40px";
                                                        AccountAmount.Helpers.HTML("</b>");
                                                    }
                                                }
                                            }

                                        }

                                    }
                                    var RowColRight = RowContentDiv.Helpers.DivC("col-md-3");
                                    {

                                        var AnotherCardDiv = RowColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                                        {
                                            var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                                            {
                                                CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                                                CardTitleDiv.Helpers.HTML().Heading5("<b>Filter Criteria</b>");
                                            }
                                            var CardTitleToolsDiv = CardTitleDiv.Helpers.DivC("ibox-tools");
                                            {
                                                var aToolsTag = CardTitleToolsDiv.Helpers.HTMLTag("a");
                                                aToolsTag.AddClass("collapse-link");
                                                {
                                                    var iToolsTag = aToolsTag.Helpers.HTMLTag("i");
                                                    iToolsTag.AddClass("fa fa-chevron-up");
                                                }
                                            }
                                            var ContentDiv = AnotherCardDiv.Helpers.DivC("ibox-content");
                                            {
                                                var RightRowContentDiv = ContentDiv.Helpers.DivC("row");
                                                {
                                                    var RightColContentDiv = RightRowContentDiv.Helpers.DivC("col-md-12");
                                                    {
                                                        RightColContentDiv.Helpers.LabelFor(c => ViewModel.ProductCategoryID);
                                                        var CategorySelector = RightColContentDiv.Helpers.EditorFor(c => ViewModel.ProductCategoryID);
                                                        CategorySelector.AddClass("form-control marginBottom20 ");

                                                        var FilterBtn = RightColContentDiv.Helpers.Button("Apply Filter", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.filter);
                                                        {
                                                            FilterBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "FilterProducts($data)");
                                                            FilterBtn.AddClass("btn btn-primary btn-outline");
                                                        }

                                                        var ResetBtn = RightColContentDiv.Helpers.Button("Reset", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.refresh);
                                                        {
                                                            ResetBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "FilterReset($data)");
                                                            ResetBtn.AddClass("btn btn-primary btn-outline");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    var RowColRightDown = RowContentDiv.Helpers.DivC("col-md-4");
                                    {

                                        var AnotherCardDiv = RowColRightDown.Helpers.DivC("ibox float-e-margins paddingBottom");
                                        {
                                            var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                                            {
                                                CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-right'></i>");
                                                CardTitleDiv.Helpers.HTML().Heading5("<b>Shopping Cart</b>");
                                            }
                                            var CardTitleToolsDiv = CardTitleDiv.Helpers.DivC("ibox-tools");
                                            {
                                                var aToolsTag = CardTitleToolsDiv.Helpers.HTMLTag("a");
                                                aToolsTag.AddClass("collapse-link");
                                                {
                                                    var iToolsTag = aToolsTag.Helpers.HTMLTag("i");
                                                    iToolsTag.AddClass("fa fa-chevron-up");
                                                }
                                            }
                                            var ContentDiv = AnotherCardDiv.Helpers.DivC("ibox-content");
                                            {
                                                var RightRowContentDiv = ContentDiv.Helpers.DivC("row");
                                                {
                                                    var RightColContentDiv = RightRowContentDiv.Helpers.DivC("col-md-12");
                                                    {
                                                        var itemsCount = RightColContentDiv.Helpers.ReadOnlyFor(c => "Items: " + c.ItemsCount).Style.FontSize = "25px";
                                                        RightColContentDiv.Helpers.HTML().Heading3("<p></p>");
                                                        var TransactionItemList = RightColContentDiv.Helpers.BootstrapTableFor<MELib.TransactionItems.TransactionItem>((c) => c.TransactionItemList, false, false, "");
                                                        {
                                                            TransactionItemList.AddClass("table table-striped table-bordered table-hover");
                                                            var TransactionItemListRow = TransactionItemList.FirstRow;
                                                            {
                                                                var TransactionID = TransactionItemListRow.AddColumn("Product");
                                                                {
                                                                    var TransactionIDText = TransactionID.Helpers.ReadOnlyFor(c => c.ProductName);
                                                                }
                                                                var TransactionItemSellingPrice = TransactionItemListRow.AddColumn("Price");
                                                                {
                                                                    var TransactionSellingPriceText = TransactionItemSellingPrice.Helpers.ReadOnlyFor(c => "R "+c.SellingPrice.ToString("0.00.00"));
                                                                }
                                                                var Quantity = TransactionItemListRow.AddColumn("Qty");
                                                                {
                                                                    var QuantityText = Quantity.Helpers.ReadOnlyFor(c => c.Quantity).Style.Width = "30px";
                                                                }

                                                                var remove = TransactionItemListRow.AddColumn("Remove");
                                                                {
                                                                    var RemoveBtn = remove.Helpers.Button("", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.minus);
                                                                    {
                                                                        RemoveBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "RemoveProduct($data)");
                                                                        RemoveBtn.AddClass("btn btn-primary btn-outline");
                                                                    }
                                                                    var DeleteBtn = remove.Helpers.Button("", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.trash_o);
                                                                    {
                                                                        DeleteBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "DeleteProduct($data)");
                                                                        DeleteBtn.AddClass("btn btn-primary");
                                                                    }
                                                                }

                                                            }
                                                        }

                                                        RightColContentDiv.Helpers.HTML().Heading3("<b>");
                                                        var totalCost = RightColContentDiv.Helpers.ReadOnlyFor(c => "Total Cost: R" + c.TotalCost.ToString("0.00.00")).Style.FontSize = "30px";
                                                        RightColContentDiv.Helpers.HTML().Heading3("</b>");
                                                        RightColContentDiv.Helpers.HTML().Heading3("<p></p>");


                                                        //When checkout is pressed, ask user to be sure and then subtract the cost from balance
                                                        var CheckoutBtn = RightColContentDiv.Helpers.Button("Checkout", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.check);
                                                        {
                                                            CheckoutBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "Checkout($data)");
                                                            CheckoutBtn.AddClass("btn btn-primary btn-outline");
                                                        }

                                                        var CancelBtn = RightColContentDiv.Helpers.Button("Cancel", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.times);
                                                        {
                                                            CancelBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "Reset($data)");
                                                            CancelBtn.AddClass("btn btn-primary btn-outline");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    %>
    <script type="text/javascript">

        //Place page specific JavaScript here or in a JS file and include in the HeadContent section
        Singular.OnPageLoad(function () {
            $("#menuItem2").addClass('active');
            $("#menuItem2 > url ").addClass('in')
        });

        var RemoveProduct = function (data) {
            ViewModel.CallServerMethod('RemoveProduct', { ProductID: data.Serialise().ProductID, totalCost: ViewModel.TotalCost(), currentCart: ViewModel.TransactionItemList.Serialise(), itemsCount: ViewModel.ItemsCount() }, function (result) {
                ViewModel.TransactionItemList.Set(result);
                var totalItems = 0;
                var total = 0;

                result.forEach(function (c) {
                    total += Math.round((c.SellingPrice * c.Quantity) * 100) / 100;
                    totalItems += c.Quantity;
                })

                ViewModel.ItemsCount(totalItems);
                ViewModel.TotalCost(Math.round(total * 100) / 100);
            }, true);
        }

        var DeleteProduct = function (data) {
            Singular.ShowMessageQuestion("Confirm Delete", "Are you sure you want to remove this product from you basket?", function () {
                ViewModel.CallServerMethod('DeleteProduct', { ProductID: data.Serialise().ProductID, totalCost: ViewModel.TotalCost(), currentCart: ViewModel.TransactionItemList.Serialise(), itemsCount: ViewModel.ItemsCount() }, function (result) {
                    ViewModel.TransactionItemList.Set(result);
                    var totalItems = 0;
                    var total = 0;

                    result.forEach(function (c) {
                        total += Math.round((c.SellingPrice * c.Quantity) * 100) / 100;
                        totalItems += c.Quantity;
                    })

                    ViewModel.ItemsCount(totalItems);
                    ViewModel.TotalCost(Math.round(total * 100) / 100);
                }, true);
            });
        }

        function Checkout(obj) {
            //Yes/No messageBox
            Singular.ShowMessageQuestion("Confirm Checkout", "Are you sure your order is correct?", function () {
                ViewModel.CallServerMethod('Checkout', { account: ViewModel.CurrentAccount.Serialise(), totalCost: ViewModel.TotalCost(), currentCart: ViewModel.TransactionItemList.Serialise(), itemsCount: ViewModel.ItemsCount() }, function (result) {
                    console.log(result);
                    if (result.Data >= 0 && result.Success == true) {
                        var total = ViewModel.CurrentAccount().Balance() - ViewModel.TotalCost();
                        total = Math.round(total * 100) / 100;
                        ViewModel.CurrentAccount().Balance(total);
                        ViewModel.TotalCost(0);
                        FilterReset(obj);
                        MEHelpers.Notification("Order successful. New balance is: " + Math.round(result.Data * 100) / 100, 'center', 'success', 5000);
                        ResetAfterCheckout(0, 0, ViewModel.TransactionItemList());
                    }
                    else {
                        if (result.Data < 0) {
                            Singular.ShowMessageQuestion("Insufficient Funds!", "Not enough credit to complete order! Want to deposit funds?", function () {
                                ViewModel.CurrentAccount().Balance(Math.round((result.Data + ViewModel.TotalCost()) * 100) / 100);
                                window.location = '../Profile/DepositFunds.aspx';
                            });
                        }
                        else if (result.Success == false && ViewModel.TotalCost() == 0) {
                            Singular.ShowMessage("OOPS!", "Please add items to cart before checkout.");
                        }
                    }
                });
            });
        }

        var AddProduct = function (data) {
            ViewModel.CallServerMethod('AddProduct', { Product: data.Serialise(), totalCost: ViewModel.TotalCost(), currentCart: ViewModel.TransactionItemList.Serialise(), itemsCount: ViewModel.ItemsCount() }, function (result) {
                ViewModel.TransactionItemList.Set(result);
                var totalItems = 0;
                var total = 0;
                result.forEach(function (c) {
                    total += Math.round((c.SellingPrice * c.Quantity) * 100) / 100;
                    totalItems += c.Quantity;
                })

                ViewModel.TotalCost(Math.round(total * 100) / 100);
                ViewModel.ItemsCount(totalItems);
                
            }, true);
        }

        var TakeMeAway = function () {
            alert('Where to?');
            window.open('http://getbootstrap.com');
        }

        var FilterProducts = function (obj) {

            ViewModel.CallServerMethod('FilterProducts', { ProductCategoryID: obj.ProductCategoryID(), ResetInd: 0, ShowLoadingBar: true }, function (result) {
                if (result.Success) {
                    MEHelpers.Notification("Products filtered successfully.", 'center', 'info', 1000);
                    ViewModel.ROProductList.Set(result.Data);
                }
                else {
                    MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
                }
            })
        };

        var FilterReset = function (obj) {
            ViewModel.CallServerMethod('FilterProducts', { ProductCategoryID: obj.ProductCategoryID(), ResetInd: 1, itemsCount: ViewModel.ItemsCount(), ShowLoadingBar: true }, function (result) {
                if (result.Success) {
                    MEHelpers.Notification("Products reset successfully.", 'center', 'info', 1000);
                    ViewModel.ROProductList.Set(result.Data);
                    ViewModel.ItemsCount(0);
                }
                else {
                    MEHelpers.Notification(result.ErrorText, 'center', 'warning', 5000);
                }
            })
        };

        var Reset = function (data) {
            ViewModel.CallServerMethod('Reset', { totalCost: ViewModel.TotalCost(), itemsCount: ViewModel.ItemsCount(), currentCart: ViewModel.TransactionItemList.Serialise() }, function (result) {
                Singular.ShowMessageQuestion("Confirm cancellation", "Are you sure you want to cancel order?", function () {
                    ViewModel.TransactionItemList.Set(result);
                    ViewModel.TotalCost(0.00);
                    ViewModel.ItemsCount(0);
                });
            }, true);
        }

        var ResetAfterCheckout = function (data) {
            ViewModel.CallServerMethod('ResetAfterCheckout', { totalCost: ViewModel.TotalCost(), itemsCount: ViewModel.ItemsCount(), currentCart: ViewModel.TransactionItemList.Serialise() }, function (result) {
                ViewModel.TransactionItemList.Set(result);
                ViewModel.TotalCost(0.00);
                ViewModel.ItemsCount(0);
            }, true);
        }


    </script>
</asp:Content>
