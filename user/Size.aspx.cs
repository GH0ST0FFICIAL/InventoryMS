using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Size : System.Web.UI.Page
{
    imsdbEntities imsdb = new imsdbEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["typeid"].ToString() != "2")
            {
                Response.Redirect("~/Login/Login.aspx");
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Login/Login.aspx");
        }

    }
    protected void btnSizeSubmit_Click(object sender, EventArgs e)
    {
        Size size = new Size();
        if (imsdb.Sizes.Any(siz => siz.Title == txtSize.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Size already exists!" + "');", true);
            txtSize.Focus();
        }
        else
        {
            size.Title = txtSize.Text;
            imsdb.Sizes.Add(size);
            imsdb.SaveChanges();
            ScriptManager.RegisterStartupScript(this, GetType(), "",
           "alert('Size added successfully!');location.href='Size.aspx'", true);
        }

    }
}