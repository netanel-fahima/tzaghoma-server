<%@ Page Title="מסך ראשי" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="synaManage.Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelMenu" runat="server">
    <asp:DropDownList ID="synDropDown"
        DataValueField = "syn_id"
        DataTextField = "syn_name" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="synDropDown_SelectedIndexChanged">    </asp:DropDownList>
      
    
      <asp:Label runat="server" ID="labelLink"></asp:Label>   
        
        <br />
        
        <asp:HyperLink ID="HyperLinkGabai"  runat="server" NavigateUrl="~/Manage/NihulZmanim.aspx">ניהול גבאים</asp:HyperLink>
    
      
   <br />

    
    <asp:HyperLink ID="HyperLinkCity" runat="server" NavigateUrl="~/CityManagement/HodatHerumPage.aspx">ניהול עיריה</asp:HyperLink>
     <br />

    
    <asp:HyperLink ID="HyperLinkNewSyn" runat="server" NavigateUrl="~/Manage/NewSyn.aspx"> הקמת בית כנסת </asp:HyperLink>
    <br />

    
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Manage/usersManage.aspx"> ניהול משתמשים לבית כנסת </asp:HyperLink>

        
    
    

    </asp:Panel>
    <asp:Label runat="server" ID="errorLable" Visible="False" ForeColor="Red"></asp:Label>
    
</asp:Content>
