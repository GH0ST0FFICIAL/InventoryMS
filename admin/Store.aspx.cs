using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Store : System.Web.UI.Page
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

    protected void btnStoreSubmit_Click(object sender, EventArgs e)
    {
        Store store = new Store();
        if (imsdb.Stores.Any(stor => stor.StoreName == txtStoredName.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Store Name already exists!" + "');", true);
            txtStoredName.Focus();
        }
        else
        {
            store.StoreName = txtStoredName.Text;
            imsdb.Stores.Add(store);
            imsdb.SaveChanges();
            ScriptManager.RegisterStartupScript(this, GetType(), "",
             "alert('Store Name added successfully!');location.href='Store.aspx'", true);
        }

    }
}