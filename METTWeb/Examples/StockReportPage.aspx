<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockReportPage.aspx.cs" Inherits="MEWeb.Examples.StockReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../Theme/Singular/Custom/home.css" rel="stylesheet" />
<link href="../Theme/Singular/Custom/customstyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (var h = this.Helpers)
        {
            var MainContent = h.DivC("row");
            {
                var MainContainer = MainContent.Helpers.DivC("col-md-12");
                {
                    var PageContainer = MainContainer.Helpers.DivC("tabs-container");
                    {
                        var PageTab = PageContainer.Helpers.TabControl();
                        {
                            PageTab.Style.ClearBoth();
                            PageTab.AddClass("nav nav-tabs");
                            var TabHeading = PageTab.AddTab("Product Stock");
                            {
                                var MainRow = TabHeading.Helpers.DivC("row margin 0");
                                {
                                    var MainColRight = MainRow.Helpers.DivC("col-md-4");
                                    {
                                        MainColRight.Helpers.HTML().Heading1("<b>Most available stock</b>");
                                        MainColRight.Helpers.HTML().Heading2("This is a report of all stock.");
                                        var ProductStock = MainColRight.Helpers.BootstrapTableFor<MELib.Reports.ProductStock>((c) => c.ProductStockList, false, false, "");
                                        {
                                            var ProductStockListRow = ProductStock.FirstRow;
                                            {
                                                var ProductName = ProductStockListRow.AddColumn("Product Name");
                                                {
                                                    var ProductNameText = ProductName.Helpers.ReadOnlyFor(c => c.ProductName);
                                                }

                                                var ProductDesc = ProductStockListRow.AddColumn("Product Code");
                                                {
                                                    var ProductDescText = ProductDesc.Helpers.ReadOnlyFor(c => c.ProductCode);
                                                }

                                                var Total = ProductStockListRow.AddColumn("Stock available");
                                                {
                                                    var TotalText = Total.Helpers.ReadOnlyFor(c => c.Stock);
                                                }
                                            }
                                        }
                                    }

                                    var MainColRight2 = MainRow.Helpers.DivC("col-md-1");
                                    {
                                        //MainColRight2.Helpers.HTML().Heading1("<p><b>Report:</b></p>");
                                        //MainColRight2.Helpers.HTML().Heading2("The Movie Express Kiosk has a number of products available with ... as the most stock available and ... has the least stock available in the Kiosk.");
                                    }

                                    var MainColRight3 = MainRow.Helpers.DivC("col-md-4");
                                    {
                                        MainColRight3.Helpers.HTML().Heading1("<p><b>Report:</b></p>");
                                        MainColRight3.Helpers.HTML().Heading2("<p><u>Brief summary of the table:</u></p>");
                                        MainColRight3.Helpers.HTML().Heading2(ViewModel.TestHigh);
                                        MainColRight3.Helpers.HTML().Heading2(ViewModel.Recommend);
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
        //Palce JS
        Singular.OnPageLoad(function () {
            $("#menuItem2").addClass('active');
            $("#menuItem2 > ul").addClass("in");
        });
    </script>
</asp:Content>
