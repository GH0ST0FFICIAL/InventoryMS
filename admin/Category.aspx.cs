using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Category : System.Web.UI.Page
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
    }

    protected void btnCategorySubmit_Click(object sender, EventArgs e)
    {
        Category category = new Category();
        if (imsdb.Categories.Any(cat => cat.Title == txtCategoryName.Text))
        {
           ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Category already exists!" + "');", true);
           txtCategoryName.Focus();
        }
        else
        {
            category.Title = txtCategoryName.Text;
            imsdb.Categories.Add(category);
            imsdb.SaveChanges();
            ScriptManager.RegisterStartupScript(this, GetType(), "",
            "alert('Category added successfully!');location.href='Category.aspx'", true);
        }
        
    }
}