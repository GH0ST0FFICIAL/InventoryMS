using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewProduct : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            var data = imsdb.Products.OrderByDescending(u => u.Id).ToList();
            GridViewProduct.DataSource = data;
            GridViewProduct.DataBind();
        }
    }
    private void RefreshData()
    {
        var data = imsdb.Products.OrderByDescending(d => d.Id).ToList();
        GridViewProduct.DataSource = data;
        GridViewProduct.DataBind();
    }

    protected void GridViewProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewProduct.PageIndex = e.NewPageIndex;
        RefreshData();
    }


    protected void GridViewProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblproductId = GridViewProduct.Rows[e.RowIndex].FindControl("Label1") as Label;
        TextBox txtProductName = GridViewProduct.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        TextBox txtProductDescription = GridViewProduct.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
        TextBox txtProductPrice = GridViewProduct.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
        TextBox txtProductPriceTax = GridViewProduct.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;
        TextBox txtProductQuantity = GridViewProduct.Rows[e.RowIndex].FindControl("TextBox5") as TextBox;
        DropDownList ddlBrand = GridViewProduct.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
        DropDownList ddlSupplier = GridViewProduct.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList;
        DropDownList ddlSize = GridViewProduct.Rows[e.RowIndex].FindControl("DropDownList3") as DropDownList;
        DropDownList ddlCategory = GridViewProduct.Rows[e.RowIndex].FindControl("DropDownList4") as DropDownList;
        //DropDownList ddlStatus = GridViewProduct.Rows[e.RowIndex].FindControl("DropDownList5") as DropDownList;
        DropDownList ddlStore = GridViewProduct.Rows[e.RowIndex].FindControl("DropDownList6") as DropDownList;
        FileUpload photo = GridViewProduct.Rows[e.RowIndex].FindControl("FileUpload1") as FileUpload;

        int x = Convert.ToInt32(lblproductId.Text);
        var data = imsdb.Products.Where(d => d.Id == x).FirstOrDefault();

        //data.Status = ddlStatus.SelectedItem.ToString();
        data.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
        data.Brand = ddlBrand.SelectedItem.ToString();
        data.SupplierId = Convert.ToInt32(ddlSupplier.SelectedValue);
        data.Supplier = ddlSupplier.SelectedItem.ToString();
        data.SizeId = Convert.ToInt32(ddlSize.SelectedValue);
        data.Size = ddlSize.SelectedItem.ToString();
        data.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
        data.Category = ddlCategory.SelectedItem.ToString();
        data.StoreId = Convert.ToInt32(ddlStore.SelectedValue);
        data.StoreName = ddlStore.SelectedItem.ToString();
        data.ProductName = txtProductName.Text;
        data.ProductDescription = txtProductDescription.Text;
        //data.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
        //data.ProductPriceTax = Convert.ToInt32(txtProductPriceTax.Text); 
        //data.Quantity = Convert.ToInt32(txtProductQuantity.Text);
        if (photo.HasFile)
        {
            photo.SaveAs(Server.MapPath("../admin/productImages/" + photo.FileName));
            data.ProductPhoto = photo.FileName;
        }

        imsdb.SaveChanges();
        GridViewProduct.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Product updated!');location.href='ViewProduct.aspx'", true);
    }

    protected void GridViewProduct_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewProduct.EditIndex = e.NewEditIndex;
        RefreshData();
    }

    protected void GridViewProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewProduct.EditIndex = -1;
        RefreshData();
    }

    protected void GridViewProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnConfirm = (LinkButton)e.Row.FindControl("LinkButton1");
            LinkButton btnConfirm2 = (LinkButton)e.Row.FindControl("LinkButton2");
            btnConfirm.Attributes.Add("onclick", "return confirm('Are you sure?');");
            btnConfirm2.Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }

    protected void GridViewProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblproductId = GridViewProduct.Rows[e.RowIndex].FindControl("Label1") as Label;
        int x = Convert.ToInt32(lblproductId.Text);
        var data = imsdb.Products.Where(d => d.Id == x).FirstOrDefault();
        try
        {
            imsdb.Products.Remove(data);
            imsdb.SaveChanges();
            ScriptManager.RegisterStartupScript(this, GetType(), "",
    "alert('Product deleted!');location.href='ViewProduct.aspx'", true);
            RefreshData();
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "",
    "alert('You cannot delete this user! Contact your administator');location.href='ViewProduct.aspx'", true);
        }
    }
    protected override void InitializeCulture()
    {
        CultureInfo ci = new CultureInfo("bn-BD");
        ci.NumberFormat.CurrencySymbol = " &#2547";
        //ci.NumberFormat.CurrencySymbol = " BDT";
        Thread.CurrentThread.CurrentCulture = ci;
        base.InitializeCulture();

    }
}