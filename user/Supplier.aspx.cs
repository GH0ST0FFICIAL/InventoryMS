using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Supplier : System.Web.UI.Page
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
    protected void btnSupplierSubmit_Click(object sender, EventArgs e)
    {
        Supplier supplier = new Supplier();
        supplier.SupplierName = txtSupplierName.Text;
        supplier.SupplierAddress = txtSupplierAddress.Text;
        supplier.SupplierPhone = txtSupplierPhone.Text;
        supplier.SupplierProduct = txtSupplierProduct.Text;
        imsdb.Suppliers.Add(supplier);
        imsdb.SaveChanges();


        ScriptManager.RegisterStartupScript(this, GetType(), " ",
           "alert('Supplier added successfully!');location.href='Supplier.aspx'", true);

    }
}