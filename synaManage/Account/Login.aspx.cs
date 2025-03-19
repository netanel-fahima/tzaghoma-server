using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using synaManage.Models;

namespace synaManage.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            GeneralService.logger("LogIn","log in start");

            GeneralService.logger("LogIn", "IsValid = " + IsValid);

            if (IsValid)
            {
                GeneralService.logger("LogIn", "1");

                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                GeneralService.logger("LogIn", "2");

                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                GeneralService.logger("LogIn", "3");

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);
                GeneralService.logger("LogIn", "result-" + result);
                

                switch (result)
                {
                    case SignInStatus.Success:
                        GeneralService.logger("LogIn", "Success-" + Request.QueryString["ReturnUrl"]);
                        Session["userName"] = Email.Text;

                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "שם משתמש או סיסמא לא תקינים";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}