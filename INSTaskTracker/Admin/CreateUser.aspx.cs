using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using INSTaskTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace INSTaskTracker.Account
{
    public partial class CreateUser : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                if (RadioButtonList1.SelectedValue == "Developer")
                {
                    userMgr.AddToRole(user.Id, "Developer");
                }
                else if (RadioButtonList1.SelectedValue == "Client")
                {
                    userMgr.AddToRole(user.Id, "Client");
                }
                else
                {
                    userMgr.AddToRole(user.Id, "Administrator");
                }
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}