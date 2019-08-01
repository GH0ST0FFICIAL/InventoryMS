using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_StoreProductReports : System.Web.UI.Page
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
            var data = imsdb.Stores.GroupBy(x => x.StoreName).Select(x => x.FirstOrDefault()).ToList();
            ddlSelectStoreName.DataSource = data;
            ddlSelectStoreName.DataTextField = "StoreName";
            ddlSelectStoreName.DataValueField = "Id";
            ddlSelectStoreName.DataBind();
        }
    }

    protected void GridViewStoresProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewStoresProduct.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void ddlSelectStoreName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getstorename = ddlSelectStoreName.SelectedItem.ToString();
        var stores = imsdb.Products.Where(x => x.StoreName == getstorename).ToList();
        var countProduct = imsdb.Products.Where(x => x.StoreName == getstorename).ToList().Count();
        if (ddlSelectStoreName.SelectedValue == "0")
        {
            lblStoreName.Text = " ";
            lblTotalProduct.Text = " ";
            GridViewStoresProduct.DataSource = stores;
            GridViewStoresProduct.DataBind();
        }
        else
        {
            lblStoreName.Text = ddlSelectStoreName.SelectedItem.ToString();
            lblTotalProduct.Text = countProduct.ToString();
            GridViewStoresProduct.DataSource = stores;
            GridViewStoresProduct.DataBind();
        }
    }
    private void RefreshData()
    {
        var customerorders = imsdb.Stores.Where(x => x.StoreName == ddlSelectStoreName.SelectedItem.ToString()).ToList();
        GridViewStoresProduct.DataSource = customerorders;
        GridViewStoresProduct.DataBind();
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