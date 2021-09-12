<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportsPage.aspx.cs" Inherits="MEWeb.Examples.ReportsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Add page specific JS -->
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

                                        var ProductsSoldReportList = MainCol.Helpers.BootstrapTableFor<MELib.Reports.ProductsSoldReport>((c) => c.ProductsSoldReportList, false, false, "");
                                        {
                                            var ProductsSoldReportListRow = ProductsSoldReportList.FirstRow;
                                            {
                                                var ProductName = ProductsSoldReportListRow.AddColumn("Product Name");
                                                {
                                                    var ProductNameText = ProductName.Helpers.ReadOnlyFor(c => c.ProductName);
                                                }

                                                var ProductDesc = ProductsSoldReportListRow.AddColumn("Description");
                                                {
                                                    var ProductDescText = ProductDesc.Helpers.ReadOnlyFor(c => c.ProductDescription);
                                                }

                                                var Total = ProductsSoldReportListRow.AddColumn("Amount Sold");
                                                {
                                                    var TotalText = Total.Helpers.ReadOnlyFor(c => c.Total);
                                                }
                                            }
                                        }
                                    }
                                }

                                var MainColRight2 = MainRow.Helpers.DivC("col-md-1");
                                {
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
