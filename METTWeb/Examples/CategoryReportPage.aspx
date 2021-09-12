<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryReportPage.aspx.cs" Inherits="MEWeb.Examples.CategoryReportPage" %>
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
                            var TabHeading = PageTab.AddTab("Reports Page");
                            {
                                var MainRow = TabHeading.Helpers.DivC("row margin 0");
                                {
                                    var MainCol = MainRow.Helpers.DivC("col-md-4");
                                    {
                                        MainCol.Helpers.HTML().Heading1("<b>Most sold products</b>");
                                        MainCol.Helpers.HTML().Heading2("This is a report of all products purchased.");

                                        var CategoryReportList = MainCol.Helpers.BootstrapTableFor<MELib.Reports.ProductCategory>((c) => c.ProductCategoryList, false, false, "");
                                        {
                                            var CategoryReportListRow = CategoryReportList.FirstRow;
                                            {
                                                var CategoryName = CategoryReportListRow.AddColumn("Category");
                                                {
                                                    var CategoryNameText = CategoryName.Helpers.ReadOnlyFor(c => c.Category);
                                                }

                                                var Total = CategoryReportListRow.AddColumn("Amount Sold");
                                                {
                                                    var TotalText = Total.Helpers.ReadOnlyFor(c => c.Total);
                                                }
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
    %>
    <script type="text/javascript">
        //Palce JS
        Singular.OnPageLoad(function () {
            $("#menuItem2").addClass('active');
            $("#menuItem2 > ul").addClass("in");
        });
    </script>
</asp:Content>
