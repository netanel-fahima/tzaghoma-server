<%@ Page Title="עדכון זמנים" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdZman.aspx.cs" Inherits="synaManage.UpdZman" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="form-group" >

       <label for="text1">סוג תפילה</label>

      <asp:DropDownList ID="DropDownListTfilaType" runat="server">

              <asp:ListItem Value="SHACRIT">שחרית</asp:ListItem>

              <asp:ListItem Value="MINHA">מנחה</asp:ListItem>

              <asp:ListItem Value="ARVIT">ערבית</asp:ListItem>
            <asp:ListItem Value="OTHER">אחר</asp:ListItem>

       </asp:DropDownList>

 

         <label for="text1">&nbsp&nbsp&nbsp&nbsp סוג יום </label>

         <asp:DropDownList ID="DropDownListDayType" runat="server">

          <asp:ListItem Value="CHOL">חול</asp:ListItem>

          <asp:ListItem Value="SHABAT">שבת</asp:ListItem>

          </asp:DropDownList>

   </div>

 

     <div class="form-group" >

       <label for="text1">תיאור תפילה לתצוגה בלוח</label>

          <asp:TextBox ID="textBoxName"  runat="server" Width="120" ></asp:TextBox>

     </div>

 

 

     <div class="form-group" >

         <label for="text1">שעה קבועה</label>

         <asp:TextBox ID="textBoxFixHour" runat="server"  Width="60" Text="08:00" ></asp:TextBox>

     

   </div>

 

     <div class="form-group" >

         <label>או שעה יחסית</label>

      

      

   </div>

     <div class="form-group" >

          <asp:TextBox ID="numericMinutes"  runat="server" TextMode="Number" width="60" placeholder="30"></asp:TextBox>

        

       <label for="text1">&nbsp&nbspדקות&nbsp&nbsp</label>

        <asp:DropDownList ID="DropDownListGapType" runat="server">

            <asp:ListItem Value="AFTER_SUNSET">אחרי השקיעה</asp:ListItem>

            <asp:ListItem Value="PRE_SUNSET">לפני השקיעה</asp:ListItem>

            <asp:ListItem Value="AFTER_SUNRIZE">אחרי הזריחה</asp:ListItem>

            <asp:ListItem Value="PRE_SUNRIZE">לפני הזריחה</asp:ListItem>

          </asp:DropDownList>

 

 

 

 

     <div class="form-group" >

       <label for="text1">סדר תצוגה</label>

            <asp:TextBox ID="numericOrder"  runat="server" TextMode="Number" width="40">1</asp:TextBox>

   

   </div>
    <asp:Button ID="ButtonSave" runat="server" Text="שמירה" OnClick="ButtonSave_Click" Height="50px" Width="60px" />
   
    <asp:Button ID="ButtonCancel" runat="server" Text="ביטול" Height="50px" Width="60px" OnClick="ButtonCancel_Click" />
    
    <asp:Label Visible="false" ID="LabelErr" runat="server" Text="" ForeColor="red"></asp:Label>
    </div>
</asp:Content>
