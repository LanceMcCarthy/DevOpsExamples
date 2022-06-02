<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSingleMenu.Master" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="MySite.Web.Grid" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="styles/grid.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadPageLayout runat="server" ID="JumbotronLayout" CssClass="jumbotron" GridType="Fluid">
        <Rows>
            <telerik:LayoutRow>
                <Columns>
                    <telerik:LayoutColumn Span="10" SpanMd="12" SpanSm="12" SpanXs="12">
                        <h1>H1 title, font size 36px. Duis nibh dolor, rhoncus in euismod at, feugiat id magna.</h1>
                        <h2>H2 Title, font size 30 px.</h2>
                        <telerik:RadButton runat="server" ID="RadButton0" Text="Button" ButtonType="SkinnedButton"></telerik:RadButton>
                    </telerik:LayoutColumn>
                    <telerik:LayoutColumn Span="2" HiddenMd="true" HiddenSm="true" HiddenXs="true">
                        <img src="images/Thumbnails/Desert.jpg" />
                    </telerik:LayoutColumn>
                </Columns>
            </telerik:LayoutRow>
        </Rows>
    </telerik:RadPageLayout>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="grid_wrapper">
        <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="10" PagerStyle-PageButtonCount="5"
            OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCreated="RadGrid1_ItemCreated" OnItemDataBound="RadGrid1_ItemDataBound"
            OnUpdateCommand="RadGrid1_UpdateCommand" OnInsertCommand="RadGrid1_InsertCommand" OnDeleteCommand="RadGrid1_DeleteCommand"
            AllowPaging="True" AllowSorting="true" ShowGroupPanel="true" RenderMode="Auto">
            <GroupingSettings ShowUnGroupButton="true" />
            <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
            <MasterTableView AutoGenerateColumns="False"
                AllowFilteringByColumn="true" TableLayout="Fixed"
                DataKeyNames="ID" CommandItemDisplay="Top"
                InsertItemPageIndexAction="ShowItemOnFirstPage">
                <CommandItemSettings ShowExportToCsvButton="true" ShowExportToExcelButton="true" ShowExportToPdfButton="true" ShowExportToWordButton="true" />
                <Columns>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="Name" SortExpression="Name"
                        UniqueName="Name">
                        <HeaderStyle Width="150px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridNumericColumn DataField="Age" HeaderText="Age" SortExpression="Age"
                        UniqueName="Age">
                        <HeaderStyle Width="150px" />
                    </telerik:GridNumericColumn>
                    <telerik:GridDateTimeColumn DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate"
                        UniqueName="BirthDate" PickerType="DatePicker" DataFormatString="{0:MM/dd/yyyy}">
                        <HeaderStyle Width="150px" />
                    </telerik:GridDateTimeColumn>
                    <telerik:GridRatingColumn DataField="Rating" HeaderText="Rating" SortExpression="Rating"
                        UniqueName="Rating" GroupByExpression="Rating Group By Rating">
                        <HeaderStyle Width="150px" />
                    </telerik:GridRatingColumn>
                    <telerik:GridDropDownColumn DataField="City" HeaderText="City" SortExpression="City"
                        ListDataMember="City" ListTextField="City"
                        UniqueName="City" DropDownControlType="RadComboBox">
                        <HeaderStyle Width="150px" />
                    </telerik:GridDropDownColumn>
                    <telerik:GridEditCommandColumn UniqueName="EditColumn" HeaderText="Edit Command Column">
                        <HeaderStyle Width="70px" />
                    </telerik:GridEditCommandColumn>
                    <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="Delete Command Column">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings AllowColumnsReorder="true" AllowColumnHide="true" AllowDragToGroup="true">
                <Selecting AllowRowSelect="true" />
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
            </ClientSettings>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
    <telerik:RadCodeBlock runat="server">
        <script type="text/javascript">
            function onRequestStart(sender, args) {
                if (args.get_eventTarget().indexOf("Button") >= 0) {
                    args.set_enableAjax(false);
                }
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>


