<%@ Page Title="עריכת כותרות וטקסט " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateSettings.aspx.cs" Inherits="synaManage.UpdateSettings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title %>.
  </h2>
    <br />
   
    <label id="labelTitle" runat="server"></label>
 

     <div class="form-group" >
       <label for="text1">כותרת 1 ימין למעלה  </label>
       &nbsp;<asp:TextBox ID="textBoxTitle1"  runat="server" Width="186px"  ></asp:TextBox>
     </div>
     <div class="form-group" >
       <label for="text1">כותרת 2 שמאל למעלה</label>
       <asp:TextBox ID="textBoxTitle2"  runat="server" Width="186px"  ></asp:TextBox>
     </div>
     <div class="form-group" >
       <label for="text1">כותרת 3 ימין למטה </label>
       <asp:TextBox ID="textBoxTitle3"  runat="server" Width="186px"  ></asp:TextBox>
     </div>
     <div class="form-group" >
       <label for="text1">כותרת 4 שמאל למטה</label>
       <asp:TextBox ID="textBoxTitle4"  runat="server" Width="186px"  ></asp:TextBox>
     </div>
      <div class="form-group" >
       <label for="text1">תוכן תחתון ימני&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
       &nbsp;<asp:TextBox ID="textBoxMessage1"  runat="server" Width="275px" Height="100px" TextMode="MultiLine"  ></asp:TextBox>
     </div>
      <div class="form-group" >
       <label for="text1">תוכן תחתון שמאלי</label>
       <asp:TextBox ID="textBoxMessage2"  runat="server" Width="275px" Height="99px" TextMode="MultiLine"  ></asp:TextBox>
     </div>
     
 

    <div>
    <asp:Button ID="ButtonSave" runat="server" Text="שמירה" OnClick="ButtonSave_Click" Height="50px" Width="60px" />
   
    <asp:Button ID="ButtonCancel" runat="server" Text="ביטול" Height="50px" Width="60px" OnClick="ButtonCancel_Click" />
    
    <asp:Label Visible="false" ID="LabelErr" runat="server" Text="" ForeColor="red"></asp:Label>
    </div>
</asp:Content>
