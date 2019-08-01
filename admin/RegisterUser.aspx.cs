using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_RegisterUser : System.Web.UI.Page
{
    imsdbEntities imsdb = new imsdbEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["typeid"].ToString() != "1")
            {
                Response.Redirect("~/Login/Login.aspx");
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        if (!IsPostBack)
        {
            var data = imsdb.UserTypes.ToList();
            ddlUserType.DataSource = data;
            ddlUserType.DataTextField = "Type";
            ddlUserType.DataValueField = "Id";
            ddlUserType.DataBind(); 
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UserAccount acc = new UserAccount();
        acc.Name = txtName.Text;
        acc.Password = txtPassword.Text;
        acc.Phone = txtPhone.Text;
        if (imsdb.UserAccounts.Any(eml => eml.Email == txtEmail.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Email already exists!" + "');", true);
            txtEmail.Focus();
        }
        else if (imsdb.UserAccounts.Any(u => u.Username == txtUserName.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Username already exists!" + "');", true);
            txtUserName.Focus();
        }
        else if (ddlUserType.SelectedIndex == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Select a User Type!" + "');", true);
            ddlUserType.Focus();
        }
        else if (fupPhoto.HasFile!=true)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Select an image!" + "');", true);
            fupPhoto.Focus();
        }
        else
        {
            acc.Email = txtEmail.Text;
            acc.Username = txtUserName.Text;
            acc.TypeId = ddlUserType.SelectedIndex;
            acc.Type = ddlUserType.SelectedItem.ToString();
            acc.Photo = fupPhoto.FileName;
            acc.Status = "Active";
            fupPhoto.SaveAs(Server.MapPath("./userImages/" + fupPhoto.FileName));


            imsdb.UserAccounts.Add(acc);
            imsdb.SaveChanges();
            ScriptManager.RegisterStartupScript(this, GetType(), "",
            "alert('User added successfully!');location.href='RegisterUser.aspx'", true);
        }       
      
    }
}