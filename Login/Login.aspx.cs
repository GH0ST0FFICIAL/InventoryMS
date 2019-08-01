using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Login : System.Web.UI.Page
{
    imsdbEntities db = new imsdbEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            var data = db.UserAccounts.Where(d => d.Username == txtUsername.Text && d.Password == txtPassword.Text).FirstOrDefault();
            if (data != null)
            {
                if (data.TypeId == 1)
                {
                    Session["userid"] = data.Id;
                    Session["typeid"] = "1";
                    Session["username"] = txtUsername.Text;
                    Session["name"] = data.Name;
                    Response.Redirect("~/admin/Default.aspx");
                }
                else if (data.TypeId == 2)
                {
                    Session["userid"] = data.Id;
                    Session["typeid"] = "2";
                    Session["username"] = txtUsername.Text;
                    Session["name"] = data.Name;
                    Response.Redirect("~/user/Default.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "",
        "alert('Invalid username or password');location.href='Login.aspx'", true);

            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "",
       "alert('Something went wrong!!! Contact administrator.');location.href='Login.aspx'", true);
        }
        FormsAuthentication.SetAuthCookie("test", true);
    }
}