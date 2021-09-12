<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MEWeb.Profile.Profile" %>

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
                          var ContainerTab = PageTab.AddTab("Profile");
                          {
                              var RowContentDiv = ContainerTab.Helpers.DivC("row");
                              {

                                  #region Left Column / Data
                                  var LeftColRight = RowContentDiv.Helpers.DivC("col-md-9");
                                  {

                                      var AnotherCardDiv = LeftColRight.Helpers.DivC("ibox float-e-margins paddingBottom");
                                      {
                                          var CardTitleDiv = AnotherCardDiv.Helpers.DivC("ibox-title");
                                          {
                                              CardTitleDiv.Helpers.HTML("<i class='ffa-lg fa-fw pull-left'></i>");
                                              CardTitleDiv.Helpers.HTML().Heading5("Profile");
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
                                      }

                                      var CurrentUserList = AnotherCardDiv.Helpers.BootstrapTableFor<MELib.Users.User>((c) => c.CurrentUser, false, false, "");
                                      {
                                          var UserListRow = CurrentUserList.FirstRow;
                                          {
                                              var UserID = UserListRow.AddColumn("UserID");
                                              {
                                                  var UserTitleText = UserID.Helpers.ReadOnlyFor(c => c.UserID);
                                              }

                                              var UserName = UserListRow.AddColumn("User Name");
                                              {
                                                  var UserTitleText = UserName.Helpers.ReadOnlyFor(c => c.UserName);
                                              }

                                              var Email = UserListRow.AddColumn("Email");
                                              {
                                                  var UserTitleText = Email.Helpers.ReadOnlyFor(c => c.EmailAddress);
                                              }

                                              var Number = UserListRow.AddColumn("Contact Number");
                                              {
                                                  var UserTitleText = Number.Helpers.ReadOnlyFor(c => c.ContactNumber);
                                              }

                                              var Job = UserListRow.AddColumn("Job Description");
                                              {
                                                  var UserTitleText = Job.Helpers.ReadOnlyFor(c => c.JobDescription);
                                              }
                                          }
                                      }

                                      var SecondRowCol = AnotherCardDiv.Helpers.DivC("col-md-6");
                                      {
                                        SecondRowCol.Helpers.HTML().Heading2("<b><u>About User:</u></b>");
                                        SecondRowCol.Helpers.HTML().Heading3(ViewModel.About);
                                      }
                                  }
                                  #endregion
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


  </script>
</asp:Content>
