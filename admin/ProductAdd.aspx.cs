using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ProducAdd : System.Web.UI.Page
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
            //load brand data
            var dataStore = imsdb.Stores.ToList();
            ddlstore.DataSource = dataStore;
            ddlstore.DataTextField = "StoreName";
            ddlstore.DataValueField = "Id";
            ddlstore.DataBind();

            //load brand data
            var data = imsdb.Brands.ToList();
            ddlBrand.DataSource = data;
            ddlBrand.DataTextField = "Title";
            ddlBrand.DataValueField = "Id";
            ddlBrand.DataBind();


            //load size data
            var data1 = imsdb.Sizes.ToList();
            ddlSize.DataSource = data1;
            ddlSize.DataTextField = "Title";
            ddlSize.DataValueField = "Id";
            ddlSize.DataBind();

            //load category data
            var data2 = imsdb.Categories.ToList();
            ddlCategory.DataSource = data2;
            ddlCategory.DataTextField = "Title";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();

            //load supplier name data
            var data3 = imsdb.Suppliers.ToList();
            ddlSupplier.DataSource = data3;
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataValueField = "Id";
            ddlSupplier.DataBind();

        }
    }

    protected void btnProductAddSubmit_Click(object sender, EventArgs e)
    {
        Product product = new Product();
        product.ProductName = txtProductName.Text;
        product.ProductDescription = txtDescription.Text;
        product.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
        product.ProductPriceTax = Convert.ToInt32(txtTax.Text);
        product.Quantity = Convert.ToInt32(txtQuantity.Text);

        //if (txtProductPrice.Text == string.Empty || txtProductPrice.Text.StartsWith("-") || txtProductPrice.Text == "0")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Price value cannot be negative or empty or zero!" + "');", true);
        //    txtProductPrice.Focus();
        //}
        //else
        //{
           
        //}
        //if (txtTax.Text.StartsWith("-"))
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Tax value cannot be negative!" + "');", true);
        //    txtTax.Focus();
        //}
        //else
        //{
            
        //}

        //if (txtQuantity.Text == string.Empty || txtQuantity.Text.StartsWith("-") || txtQuantity.Text == "0")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Quantity value cannot be negative or empty or zero!" + "');", true);
        //    txtQuantity.Focus();
        //}
        //else
        //{
            
        //}
        product.TotalPrice = Convert.ToInt32(txtTotalPrice.Text);
        if (ddlSize.SelectedIndex == 0)
        {
            product.SizeId = null;
            product.Size = null;
        }
        else
        {
            product.SizeId = Convert.ToInt32(ddlSize.SelectedValue);
            product.Size = ddlSize.SelectedItem.ToString();
        }
        if (ddlBrand.SelectedIndex == 0)
        {
            product.BrandId = null;
            product.Brand = null;
        }
        else
        {
            product.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
            product.Brand = ddlBrand.SelectedItem.ToString();
        }
        if (ddlCategory.SelectedIndex == 0)
        {
            product.CategoryId = null;
            product.Category = null;
        }
        else
        {
            product.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            product.Category = ddlCategory.SelectedItem.ToString();
        }
        if (ddlSupplier.SelectedIndex == 0)
        {
            product.SupplierId = null;
            product.Supplier = null;
        }
        else
        {
            product.SupplierId = Convert.ToInt32(ddlSupplier.SelectedValue);
            product.Supplier = ddlSupplier.SelectedItem.ToString();
        }
        if (ddlSupplier.SelectedIndex == 0)
        {
            product.StoreId = null;
            product.StoreName = null;
        }
        else
        {
            product.StoreId = Convert.ToInt32(ddlstore.SelectedValue);
            product.StoreName = ddlstore.SelectedItem.ToString();
        }
        product.Status = "Available";
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd");
        //string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");
        product.Date = Convert.ToDateTime(date);
        Session["getProductId"] = product.Id;
        if (fupProductPhoto.HasFile)
        {
            fupProductPhoto.SaveAs(Server.MapPath("./productImages/" + fupProductPhoto.FileName));
            product.ProductPhoto = fupProductPhoto.FileName;
        }
        imsdb.Products.Add(product);
        imsdb.SaveChanges();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
       "alert('Product added successfully!');location.href='ProductAdd.aspx'", true);

    }


    protected void btnCalculate_Click(object sender, EventArgs e)
    {

        decimal productprice = Convert.ToDecimal(txtProductPrice.Text);
        decimal taxprice;
        decimal totalprice;
        int quantity = Convert.ToInt32(txtQuantity.Text);

        if (txtProductPrice.Text == string.Empty || txtProductPrice.Text.StartsWith("-") || txtProductPrice.Text == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Price value cannot be negative or empty or zero!" + "');", true);
            txtProductPrice.Focus();
        }
      
        else if (txtQuantity.Text == string.Empty || txtQuantity.Text.StartsWith("-") || txtQuantity.Text == "0")
        {  
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Quantity value cannot be negative or empty or zero!" + "');", true);
            txtQuantity.Focus();
        }
       
        else if (txtTax.Text == string.Empty)
        {
            taxprice = 0 * productprice;
            totalprice = quantity * productprice + taxprice;
            txtTotalPrice.Text = (Math.Round(totalprice).ToString());
        }
        else if (txtTax.Text.StartsWith("-"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Tax value cannot be negative!" + "');", true);
            txtTax.Focus();
        }
        else
        {
            taxprice = ((Convert.ToDecimal(txtTax.Text)) / 100) * productprice;
            totalprice = quantity * productprice + taxprice;
            txtTotalPrice.Text = (Math.Round(totalprice).ToString());
            txtProductPrice.Text = productprice.ToString();
            txtQuantity.Text = quantity.ToString();
        }
    }
}