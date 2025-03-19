<%@ Page Title="שיוך משתמשים " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usersManage.aspx.cs" Inherits="synaManage.usersManage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.
  </h2>
    <h1>
        <label id="labelSynName" runat="server" ></label>
</h1>
    <asp:CheckBox AutoPostBack="true" ID="CheckBoxOnlyGabayim" runat="server"  Checked="false" Text="הצג גבאים לא משוייכים" />
   <asp:GridView ID="GridViewUsers" runat="server">
       <Columns>
           <asp:ButtonField CommandName="Delete" HeaderText="שיוך" ShowHeader="True" Text="שיוך משתמש" />
       </Columns>
        </asp:GridView>
  <asp:Button ID="ButtonCancel" runat="server" Text="ביטול" Height="50px" Width="60px" OnClick="ButtonCancel_Click" /> 
</asp:Content>
