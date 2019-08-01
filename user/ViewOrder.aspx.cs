using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewOrder : System.Web.UI.Page
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
            var data = imsdb.Orders.OrderByDescending(d => d.Id).ToList();
            GridViewOrders.DataSource = data;
            GridViewOrders.DataBind();
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
    private void RefreshData()
    {
        var data = imsdb.Orders.OrderByDescending(d => d.Id).ToList();
        GridViewOrders.DataSource = data;
        GridViewOrders.DataBind();
    }
    protected void GridViewOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewOrders.PageIndex = e.NewPageIndex;
        RefreshData();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        var data = imsdb.Orders.Where(d => d.OrderDate.ToString() == txtSearch.Text ||
        d.CustomerName.Contains(txtSearch.Text) ||
        d.CustomerPhone.Contains(txtSearch.Text) ||
        d.Id.ToString() == txtSearch.Text ||
        d.ProductName.Contains(txtSearch.Text) ||
        d.Quantity.ToString() == txtSearch.Text ||
        d.Rate.ToString() == txtSearch.Text ||
        d.Amount.ToString() == txtSearch.Text ||
        d.Vat.ToString() == txtSearch.Text ||
        d.ServiceCharge.ToString() == txtSearch.Text ||
        d.Discount.ToString() == txtSearch.Text ||
        d.NetAmount.ToString() == txtSearch.Text).ToList();
        GridViewOrders.DataSource = data;
        GridViewOrders.DataBind();
    }
}
