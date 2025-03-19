using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using synaManage.Models;

namespace synaManage.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                DBService.ExecuteStatement(" insert into dbo.users values('" + user.UserName + "','GABAI',NULL,NULL)");

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                if (result.Errors.FirstOrDefault().Contains("Passwords must"))
                {
                    ErrorMessage.Text = "הסיסמה חייבת להכיל : " + Environment.NewLine +
                                        "1.אות גדולה באנגלית, ואות קטנה באנגלית." + Environment.NewLine +
                                        "2.חייב להכיל מספרים." + Environment.NewLine +
                                        "3.חייב להכיל סימן אחד, כמו:   #!%?*&+." + Environment.NewLine +
                                        "4.אורך כל הסיסמה, יהיה לפחות 6 תווים.";

                   //Passwords must be at least 6 characters.Passwords must have at least one digit('0' - '9').Passwords must have at least one lowercase('a' - 'z'). Passwords must have at least one uppercase('A' - 'Z').
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
                
            }
        }
    }
}