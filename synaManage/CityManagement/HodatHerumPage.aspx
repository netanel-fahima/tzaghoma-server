<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HodatHerumPage.aspx.cs" Inherits="kanis.HodatHerumPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <h2>
        <asp:Label ID="LabelTitle" runat="server"></asp:Label>
        <asp:DropDownList ID="DropDownListCities" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCities_SelectedIndexChanged">
        </asp:DropDownList>
     </h2>
    <h2>  
        <asp:TextBox ID="TextBoxEergency" runat="server" Height="262px" TextMode="MultiLine" Width="646px"></asp:TextBox>
    </h2>
    <h3>
        <asp:Label ID="LabelStatus" runat="server"></asp:Label>
    </h3>
    <p>
        <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="שמירה" />
        <asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="בטל הודעה" />
&nbsp;&nbsp;
        </p>
</asp:Content>
