<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepositFunds.aspx.cs" Inherits="MEWeb.Profile.DepositFunds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <!-- Add page specific styles and JavaScript classes below -->
  <link href="../Theme/Singular/Custom/home.css" rel="stylesheet" />
  <link href="../Theme/Singular/Custom/customstyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
  <!-- Placeholder not used in this example -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 
  <%
      using (var h = this.Helpers)
      {
          var MainHDiv = h.DivC("row pad-top-10");
          {
              var PanelContainer = MainHDiv.Helpers.DivC("col-md-12 p-n-lr");
              {
                  var HomeContainer = PanelContainer.Helpers.DivC("tabs-container");
                  {
                      var AssessmentsTab = HomeContainer.Helpers.TabControl();
                      {
                          AssessmentsTab.Style.ClearBoth();
                          AssessmentsTab.AddClass("nav nav-tabs");
                          var HomeContainerTab = AssessmentsTab.AddTab("Deposit Funds");
                          {
                              var Row = HomeContainerTab.Helpers.DivC("row margin0");
                              {
                                  var RowCol = Row.Helpers.DivC("col-md-12");
                                  {
                                      RowCol.Helpers.HTML().Heading2("<p style=font-size:30px;><b>Deposit Funds</b></p>");
                                      RowCol.Helpers.HTMLTag("p").HTML = "<p style=font-size:20px;>Add some money to your account below:</p>";

                                      var CardDiv = RowCol.Helpers.DivC("ibox float-e-margins paddingBottom");
                                      {
                                          var CardTitleDiv = CardDiv.Helpers.DivC("ibox-title");
                                          {
                                              CardTitleDiv.Helpers.HTML("<i class='fa fa-book fa-lg fa-fw pull-left'></i>");
                                              CardTitleDiv.Helpers.HTML().Heading5("Deposit");
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
                                          var ContentDiv = CardDiv.Helpers.DivC("ibox-content");
                                          {
                                              var RowContentDiv = ContentDiv.Helpers.DivC("row");
                                              {
                                                  var LeftColContentDiv = RowContentDiv.Helpers.DivC("col-md-2");
                                                  {
                                                      // Place holder
                                                  }
                                                  var MiddleColContentDiv = RowContentDiv.Helpers.DivC("col-md-8");
                                                  {
                                                      var FormContent = MiddleColContentDiv.Helpers.With<MELib.Accounts.Account>(c => c.CurrentAccount);
                                                      {

                                                          var AccountAmount = FormContent.Helpers.DivC("col-md-6");
                                                          {
                                                              AccountAmount.Helpers.HTML("<p style=font-size:20px;>Current account balance: </p><b>");
                                                              AccountAmount.Helpers.ReadOnlyFor(c => "R "+c.Balance.ToString("0.00.00")).Style.FontSize = "25px";
                                                              AccountAmount.Helpers.HTML("</b><p></p>");

                                                              AccountAmount.Helpers.HTML("<p style=font-size:20px;>Enter the amount to deposit below:</p>");
                                                              AccountAmount.Helpers.HTML("<p style=font-size:20px;><b>");
                                                              AccountAmount.Helpers.EditorFor(c => ViewModel.DepositAmount).Style.FontSize = "20px";
                                                              AccountAmount.Helpers.HTML("</b></p>");
                                                              AccountAmount.Helpers.HTML("<p></p>");
                                                          }
                                                          var ActionsDiv = FormContent.Helpers.DivC("col-md-12");
                                                          {

                                                              var DepositBtn = ActionsDiv.Helpers.Button("Deposit", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.bank);
                                                              {
                                                                  DepositBtn.AddBinding(Singular.Web.KnockoutBindingString.click, "UpdateBalance()");
                                                                  DepositBtn.AddClass("btn btn-primary");
                                                              }

                                                              var Addtn = ActionsDiv.Helpers.Button("Go Shopping", Singular.Web.ButtonMainStyle.Primary, Singular.Web.ButtonSize.Normal, Singular.Web.FontAwesomeIcon.shoppingCart);
                                                              {
                                                                  Addtn.AddBinding(Singular.Web.KnockoutBindingString.click, "Shop()");
                                                                  Addtn.AddClass("btn btn-primary");
                                                              }
                                                          }
                                                      }
                                                  }
                                                  var RightColContentDiv = RowContentDiv.Helpers.DivC("col-md-2");
                                                  {
                                                      // Place holder
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
    // Place page specific JavaScript here or in a JS file and include in the HeadContent section
    Singular.OnPageLoad(function () {
      $("#menuItem1").addClass('active');
      $("#menuItem1 > ul").addClass('in');
    });

      var Shop = function () {
          alert("Leaving this page. Happy shopping!")
          window.location = '../Examples/ProductPage.aspx';
      }

    function UpdateBalance() {
        ViewModel.CallServerMethod('UpdateBalance', { account: ViewModel.CurrentAccount.Serialise(), depositAmount: ViewModel.DepositAmount() }, function (result) {
            //console.log(result);
            if (result) {
                var total = ViewModel.CurrentAccount().Balance() + ViewModel.DepositAmount();
                MEHelpers.Notification("Balance updated successfully. New balance is: " + (Math.round(total * 100) / 100), 'center', 'success', 5000);
                ViewModel.CurrentAccount().Balance(Math.round(total * 100) / 100);
                ViewModel.DepositAmount(0);
            }
            else {
                if (ViewModel.DepositAmount() == 0) {
                    MEHelpers.Notification('Please enter amount before depositting.', 'center', 'warning', 5000);
                }
                else if (ViewModel.DepositAmount() < 0) {
                    MEHelpers.Notification('Invalid amount to deposit. Ensure your deposit amout is non negative.', 'center', 'warning', 5000);
                }
                else {
                    MEHelpers.Notification('Account balance update failed.', 'center', 'warning', 5000);
                }
            }
        }, true);
      }

  </script>
</asp:Content>
