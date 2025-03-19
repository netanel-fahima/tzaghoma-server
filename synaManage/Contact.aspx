<%@ Page Title="צור קשר" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="synaManage.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <br />
    <div style="font-size:30px;" >
    שם חברה - צג דיגיטל
    <address>
        <br />
       
        <abbr title="טלפון">טלפון</abbr>
        052-3292977
    </address>

    <address>
        &nbsp;<strong>מכירות ושירות</strong>   <a href="mailto:Info@a-digital.co.il">Info@a-digital.co.il</a><br />
     
    </address>



   <a href="https://wa.me/972502727505/?text=שלום"><img src="images/whatsapp-48.png" /></a>
        צור קשר ב WHATSUP
        <br />
      <br />
      <br />

        </div>
    <asp:HyperLink  runat="server" Text="TEAM VIEWER" NavigateUrl="~/AddFiles/TeamViewerQS.exe">  </asp:HyperLink>
    
  
    <br />
    <br />
</asp:Content>
