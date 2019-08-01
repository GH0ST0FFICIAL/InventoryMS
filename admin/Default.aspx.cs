using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
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
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd");
        DateTime currentdate = Convert.ToDateTime(date);
        int CurrentYear = DateTime.Today.Year;
        int CurrentMonth = DateTime.Today.Month;
        DateTime startDate = DateTime.Today.Date.AddDays(-(int)DateTime.Today.DayOfWeek), // prev sunday 00:00
        endDate = startDate.AddDays(7); // next sunday 00:00
        try
        {
            //income ::

            //today income
            var todayincome = imsdb.Orders.Where(d => d.OrderDate == currentdate).Select(d => d.NetAmount).Sum();
            if (todayincome!=null)
            {
                lblTodayIncome.Text = string.Format("{0:c}", todayincome); 
            }
            else
            {
                lblTodayIncome.Text = string.Format("{0:c}", 0);
            }

            //this week income        
            var weeklyincome = imsdb.Orders.Where(d => d.OrderDate >= startDate && d.OrderDate < endDate).Select(d => d.NetAmount).Sum();
            if (weeklyincome != null)
            {
                lblWeeklyIncome.Text = string.Format("{0:c}", weeklyincome); 
            }
            else
            {
                lblWeeklyIncome.Text = string.Format("{0:c}", 0);
            }

            //this month income         
            var monthlyincome = imsdb.Orders.Where(d => d.OrderDate.Value.Month==CurrentMonth).Select(d => d.NetAmount).Sum();
            if (monthlyincome != null)
            {
                lblMonthlyIncome.Text = string.Format("{0:c}", monthlyincome);
            }
            else
            {
                lblMonthlyIncome.Text = string.Format("{0:c}", 0);
            }

            //this year income
            var yearlyincome = imsdb.Orders.Where(d => d.OrderDate.Value.Year == CurrentYear).Select(d => d.NetAmount).Sum();
            if (yearlyincome != null)
            {
                lblYearlyIncome.Text = string.Format("{0:c}", yearlyincome);
            }
            else
            {
                lblYearlyIncome.Text = string.Format("{0:c}", 0);
            }

            //total income
            var totalincome = imsdb.Orders.Select(d => d.NetAmount).Sum();
            if (totalincome != null)
            {
                lblTotalIncome.Text = string.Format("{0:c}", totalincome);
            }
            else
            {
                lblTotalIncome.Text = string.Format("{0:c}", 0);
            }

            //expenditure ::

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

            //this week expenditure
            var weeklyexpenditure = imsdb.Products.Where(d => d.Date >= startDate && d.Date < endDate).Select(d => d.TotalPrice).Sum();
            if (weeklyexpenditure != null)
            {
                lblWeeklyExpenditure.Text = string.Format("{0:c}", weeklyexpenditure);
            }
            else
            {
                lblWeeklyExpenditure.Text = string.Format("{0:c}", 0);
            }

            //this month expenditure         
            var monthlyexpenditure = imsdb.Products.Where(d => d.Date.Value.Month == CurrentMonth).Select(d => d.TotalPrice).Sum();
            if (monthlyexpenditure != null)
            {
                lblMonthlyExpenditure.Text = string.Format("{0:c}", monthlyexpenditure);
            }
            else
            {
                lblMonthlyExpenditure.Text = string.Format("{0:c}", 0);
            }

            //this year expenditure         
            var yearlyexpenditure = imsdb.Products.Where(d => d.Date.Value.Year == CurrentYear).Select(d => d.TotalPrice).Sum();
            if (yearlyexpenditure != null)
            {
                lblYearlyExpenditure.Text = string.Format("{0:c}", yearlyexpenditure);
            }
            else
            {
                lblYearlyExpenditure.Text = string.Format("{0:c}", 0);
            }

            //total expenditure
            var totalexpenditure = imsdb.Products.Select(d => d.TotalPrice).Sum();
            if (totalexpenditure != null)
            {
                lblTotalExpenditure.Text = string.Format("{0:c}", totalexpenditure);
            }
            else
            {
                lblTotalExpenditure.Text = string.Format("{0:c}", 0);
            }

            //profit/loss ::

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

            //this week profit/loss
            var weeklyprofit = weeklyincome - weeklyexpenditure;
            if (weeklyprofit != null)
            {
                lblWeeklyProfit.Text = string.Format("{0:c}", weeklyprofit);
            }
            else
            {
                lblWeeklyProfit.Text = string.Format("{0:c}", 0);
            }

            //this month profit/loss
            var monthlyprofit = monthlyincome - monthlyexpenditure;
            if (monthlyprofit != null)
            {
                lblMonthlyProfit.Text = string.Format("{0:c}", monthlyprofit);
            }
            else
            {
                lblMonthlyProfit.Text = string.Format("{0:c}", 0);
            }

            //this year profit/loss
            var yearlyprofit = yearlyincome - yearlyexpenditure;
            if (yearlyprofit != null)
            {
                lblYearlyProfit.Text = string.Format("{0:c}", yearlyprofit);
            }
            else
            {
                lblYearlyProfit.Text = string.Format("{0:c}", 0);
            }

            //total profit/loss
            var totalprofit = totalincome - totalexpenditure;
            if (totalprofit != null)
            {
                lblTotalProfit.Text = string.Format("{0:c}", totalprofit);
            }
            else
            {
                lblTotalProfit.Text = string.Format("{0:c}", 0);
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
            var stockout = imsdb.Products.Where(d => d.Quantity==0).Count();
            if (stockout != 0)
            {
                lblTotalStockOut.Text = stockout.ToString();
            }
            else
            {
                lblTotalStockOut.Text = "0";
            }

        }
        catch (Exception)
        {
            //throw;
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