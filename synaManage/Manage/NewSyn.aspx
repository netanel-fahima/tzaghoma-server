<%@ Page Title="ניהול זמנים" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewSyn.aspx.cs" Inherits="synaManage.NewSyn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
   

 

     <div class="form-group" >
       <label for="text1">שם בית הכנסת</label>
       <asp:TextBox ID="textBoxName"  runat="server" Width="186px"  ></asp:TextBox>
     </div>
      <div class="form-group" >
       <label for="textBoxAdress">כתובת</label>
       <asp:TextBox ID="textBoxAdress"  runat="server" Width="234px"  ></asp:TextBox>
     </div>
 


     <div class="form-group" >

        <asp:DropDownList ID="DropDownListCities" runat="server">

          

          </asp:DropDownList>

   

   </div>
    <div>
    <asp:Button ID="ButtonSave" runat="server" Text="שמירה" OnClick="ButtonSave_Click" Height="50px" Width="60px" />
   
    <asp:Button ID="ButtonCancel" runat="server" Text="ביטול" Height="50px" Width="60px" OnClick="ButtonCancel_Click" />
    
    <asp:Label Visible="false" ID="LabelErr" runat="server" Text="" ForeColor="red"></asp:Label>
    </div>
</asp:Content>
