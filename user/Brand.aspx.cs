using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Brand : System.Web.UI.Page
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
    protected void btnBrandSubmit_Click(object sender, EventArgs e)
    {
        Brand brand = new Brand();
        if (imsdb.Brands.Any(brnd => brnd.Title == txtBrandName.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Brand already exists!" + "');", true);
            txtBrandName.Focus();
        }
        else
        {
            brand.Title = txtBrandName.Text;
            imsdb.Brands.Add(brand);
            imsdb.SaveChanges();
            ScriptManager.RegisterStartupScript(this, GetType(), "",
             "alert('Brand added successfully!');location.href='Brand.aspx'", true);
        }


    }
}