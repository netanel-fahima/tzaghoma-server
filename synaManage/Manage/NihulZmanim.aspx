<%@ Page Title="ניהול זמנים" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NihulZmanim.aspx.cs" Inherits="synaManage.NihulZmanim" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.
  </h2>
    <h1>
        <label id="labelSynName" runat="server" ></label>

    </h1>
      <asp:Label runat="server" ID="labelLink"></asp:Label>   
        
        <br />
      <h1>  <asp:HyperLink ID="HyperLinkUpdateSettings" runat="server" NavigateUrl="~/Manage/UpdateSettings.aspx"> עריכת כותרות וטקסט  </asp:HyperLink>
     <br />
             </h1>
       <h1>  <asp:LinkButton ID="LinkButtonNewZman" runat="server" PostBackUrl="~/Manage/NewZman.aspx">הוספת זמני תפילות</asp:LinkButton>
       </h1>
   <asp:GridView ID="GridViewZmanim" runat="server">
       <Columns>
           <asp:ButtonField CommandName="Edit" HeaderText="עריכה" ShowHeader="True" Text="עריכת רשומה" />
      <asp:ButtonField CommandName="Delete" HeaderText="מחיקה" ShowHeader="True" Text="מחיקת רשומה" />
       </Columns>
        </asp:GridView>
   
</asp:Content>
