<%@ Page Title="רישום" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="synaManage.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal" dir="rtl" >
        <h4>צור משתמש חדש</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group" dir="rtl">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">מייל</asp:Label>
         
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="חובה להזין שדה מייל" />
            </div>
             
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="חובה למלא סיסמא" />
            </div>
              <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">סיסמא</asp:Label>
          
        </div>
        <div class="form-group">
              <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="חובה למלא שדה סיסמא" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="סיסמא ואימות סיסמא שונות" />
            </div>
             <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">אימות סיסמא</asp:Label>
         
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="הרשמה" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
