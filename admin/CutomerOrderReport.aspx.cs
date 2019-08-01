using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_report_CutomerOrderReport : System.Web.UI.Page
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
            var data = imsdb.Orders.GroupBy(x => x.CustomerName).Select(x => x.FirstOrDefault()).ToList();
            ddlSelectCustomer.DataSource = data;
            ddlSelectCustomer.DataTextField = "CustomerName";
            ddlSelectCustomer.DataValueField = "Id";
            ddlSelectCustomer.DataBind();
        }
    }

    protected void ddlSelectCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getcustomer = ddlSelectCustomer.SelectedItem.ToString();
        var customerorders = imsdb.Orders.Where(x => x.CustomerName == getcustomer).ToList();
        var countOrder = imsdb.Orders.Where(x => x.CustomerName == getcustomer).ToList().Count();
        if (ddlSelectCustomer.SelectedValue == "0")
        {
            lblCustomerName.Text = " ";
            lblTotalOrder.Text = " ";            
            GridViewCustomerOrders.DataSource = customerorders;
            GridViewCustomerOrders.DataBind();         
        }
        else
        {
            lblCustomerName.Text = ddlSelectCustomer.SelectedItem.ToString();
            lblTotalOrder.Text = countOrder.ToString();
            GridViewCustomerOrders.DataSource = customerorders;
            GridViewCustomerOrders.DataBind();
        }
    }

    protected void GridViewCustomerOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewCustomerOrders.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    private void RefreshData()
    {
        var customerorders = imsdb.Orders.Where(x => x.CustomerName == ddlSelectCustomer.SelectedItem.ToString()).ToList();
        GridViewCustomerOrders.DataSource = customerorders;
        GridViewCustomerOrders.DataBind();
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