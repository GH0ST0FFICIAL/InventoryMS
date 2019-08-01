using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Default : System.Web.UI.Page
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
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd");
        DateTime currentdate = Convert.ToDateTime(date);
        int CurrentYear = DateTime.Today.Year;
        int CurrentMonth = DateTime.Today.Month;
        DateTime startDate = DateTime.Today.Date.AddDays(-(int)DateTime.Today.DayOfWeek), // prev sunday 00:00
        endDate = startDate.AddDays(7); // next sunday 00:00


        //today income
        var todayincome = imsdb.Orders.Where(d => d.OrderDate == currentdate).Select(d => d.NetAmount).Sum();
        if (todayincome != null)
        {
            lblTodayIncome.Text = string.Format("{0:c}", todayincome);
        }
        else
        {
            lblTodayIncome.Text = string.Format("{0:c}", 0);
        }

        //today expenditure
        var todayexpenditure = imsdb.Products.Where(d => d.Date.Value.Day == currentdate.Day).Select(d => d.TotalPrice).Sum();
        if (todayexpenditure != null)
        {
            lblTodayExpenditure.Text = string.Format("{0:c}", todayexpenditure);
        }
        else
        {
            lblTodayExpenditure.Text = string.Format("{0:c}", 0);
        }

        //today profit/loss
        var todayprofit = todayincome - todayexpenditure;
        if (todayprofit != null)
        {
            lblTodayProfit.Text = string.Format("{0:c}", todayprofit);
        }
        else
        {
            lblTodayProfit.Text = string.Format("{0:c}", 0);
        }

        //total stock 
        var stock = imsdb.Products.Select(d => d.Quantity).Sum();
        if (stock != null)
        {
            lblTotalStock.Text = stock.ToString();
        }
        else
        {
            lblTotalStock.Text = "0";
        }

        //total order 
        var order = imsdb.Orders.Select(d => d.Id).Count();
        if (order != 0)
        {
            lblTotalOrder.Text = order.ToString();
        }
        else
        {
            lblTotalOrder.Text = "0";
        }

        //total customer 
        var customer = imsdb.Customers.GroupBy(x => x.CustomerName).Select(x => x.FirstOrDefault()).ToList().Count();
        if (customer != 0)
        {
            lblTotalCustomer.Text = customer.ToString();
        }
        else
        {
            lblTotalCustomer.Text = "0";
        }

        //total stock out 
        var stockout = imsdb.Products.Where(d => d.Quantity == 0).Count();
        if (stockout != 0)
        {
            lblTotalStockOut.Text = stockout.ToString();
        }
        else
        {
            lblTotalStockOut.Text = "0";
        }
    }
    protected override void InitializeCulture()
    {
        CultureInfo ci = new CultureInfo("bn-BD");
        ci.NumberFormat.CurrencySymbol = " &#2547";
        //ci.NumberFormat.CurrencySymbol = " BDT";
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        base.InitializeCulture();
    }
}