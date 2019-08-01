using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_AddOrder : System.Web.UI.Page
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
            var data = imsdb.Companies.ToList();
            ddlvat.DataSource = data;
            ddlvat.DataTextField = "PriceVat";
            ddlvat.DataValueField = "Id";
            ddlvat.DataBind();

            var data1 = imsdb.Companies.ToList();
            ddlServiceCharge.DataSource = data1;
            ddlServiceCharge.DataTextField = "ServiceCharge";
            ddlServiceCharge.DataValueField = "Id";
            ddlServiceCharge.DataBind();

            var data2 = imsdb.Products.Where(p => p.Quantity != 0).ToList();
            ddlProduct.DataSource = data2;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();
        }
    }
    protected void btnOrderSubmit_Click(object sender, EventArgs e)
    {
        Order order = new Order();
        Customer customer = new Customer();
        customer.CustomerName = txtCustomerName.Text;
        customer.CustomerAddress = txtAddress.Text;
        customer.CustomerPhone = txtCustomerphn.Text;
        customer.CustomerDOB = Convert.ToDateTime(txtCDOB.Text);
        imsdb.Customers.Add(customer);
        imsdb.SaveChanges();
        order.CustomerName = customer.CustomerName;
        order.CustomerAddress = customer.CustomerAddress;
        order.CustomerPhone = customer.CustomerPhone;
        order.CustomerDOB = customer.CustomerDOB;
        order.ProductName = ddlProduct.SelectedItem.ToString();
        order.Quantity = Convert.ToInt32(txtQuantity.Text);
        order.Rate = Convert.ToDecimal(txtRate.Text);
        order.Amount = Convert.ToDecimal(txtAmount.Text);
        if (ddlvat.SelectedItem.ToString() == "Please Select")
        {
            order.Vat = Convert.ToInt32(ddlvat.SelectedValue);
        }
        else
        {
            order.Vat = Convert.ToInt32(ddlvat.SelectedItem.ToString());
        }
        if (ddlServiceCharge.SelectedItem.ToString() == "Please Select")
        {
            order.ServiceCharge = Convert.ToInt32(ddlServiceCharge.SelectedValue);
        }
        else
        {
            order.ServiceCharge = Convert.ToInt32(ddlServiceCharge.SelectedItem.ToString());
        }
        if (txtDiscount.Text == string.Empty)
        {
            order.Discount = Convert.ToInt32("0");
        }
        else
        {
            order.Discount = Convert.ToInt32(txtDiscount.Text);
        }
        order.NetAmount = Convert.ToDecimal(txtNetAmount.Text);
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        string date = now.ToString("yyyy-MM-dd hh:mm:ss tt");
        order.OrderDate = Convert.ToDateTime(date);
        imsdb.Orders.Add(order);
        imsdb.SaveChanges();
        var data = imsdb.Products.Where(d => d.ProductName == order.ProductName).FirstOrDefault();
        data.Quantity = data.Quantity - order.Quantity;
        if (data.Quantity == 0)
        {
            data.Status = "Out of Stock";
        }
        imsdb.SaveChanges();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Order submitted successfully!');location.href='AddOrder.aspx'", true);

    }
    protected void btnCalculateNet_Click(object sender, EventArgs e)
    {
        decimal vat;
        decimal sc;
        decimal discount;
        decimal netamount;

        if (txtDiscount.Text.StartsWith("-"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Discount value cannot be negative!" + "');", true);
            txtDiscount.Focus();
        }
        else
        {
            if (ddlvat.SelectedItem.ToString() == "Please Select" && ddlServiceCharge.SelectedItem.ToString() == "Please Select" && txtDiscount.Text == string.Empty)
            {
                vat = 0 * Convert.ToDecimal(txtAmount.Text);
                sc = 0 * Convert.ToDecimal(txtAmount.Text);
                discount = (0 * Convert.ToDecimal(txtAmount.Text));

                netamount = Convert.ToDecimal(Session["getamount"]) + vat + sc - discount;
                txtNetAmount.Text = (Math.Round(netamount).ToString());
            }
            else if (ddlvat.SelectedItem.ToString() == "Please Select" && ddlServiceCharge.SelectedItem.ToString() == "Please Select")
            {
                vat = 0 * Convert.ToDecimal(txtAmount.Text);
                sc = 0 * Convert.ToDecimal(txtAmount.Text);
                discount = ((Convert.ToDecimal(txtDiscount.Text)) / 100) * (Convert.ToDecimal(Session["getamount"]));

                netamount = Convert.ToDecimal(Session["getamount"]) + vat + sc - discount;
                txtNetAmount.Text = (Math.Round(netamount).ToString());

            }
            else if (ddlvat.SelectedItem.ToString() == "Please Select" && txtDiscount.Text == string.Empty)
            {
                vat = 0 * Convert.ToDecimal(txtAmount.Text);
                sc = ((Convert.ToDecimal(ddlServiceCharge.SelectedItem.ToString())) / 100) * (Convert.ToDecimal(Session["getamount"]));
                discount = (0 * Convert.ToDecimal(txtAmount.Text));

                netamount = Convert.ToDecimal(Session["getamount"]) + vat + sc - discount;
                txtNetAmount.Text = (Math.Round(netamount).ToString());
            }
            else if (ddlServiceCharge.SelectedItem.ToString() == "Please Select" && txtDiscount.Text == string.Empty)
            {
                vat = ((Convert.ToDecimal(ddlvat.SelectedItem.ToString())) / 100) * (Convert.ToDecimal(Session["getamount"]));
                sc = 0 * Convert.ToDecimal(txtAmount.Text);
                discount = (0 * Convert.ToDecimal(txtAmount.Text));

                netamount = Convert.ToDecimal(Session["getamount"]) + vat + sc - discount;
                txtNetAmount.Text = (Math.Round(netamount).ToString());
            }
            else if (ddlvat.SelectedItem.ToString() == "Please Select")
            {
                vat = 0 * Convert.ToDecimal(txtAmount.Text);
                sc = ((Convert.ToDecimal(ddlServiceCharge.SelectedItem.ToString())) / 100) * (Convert.ToDecimal(Session["getamount"]));
                discount = ((Convert.ToDecimal(txtDiscount.Text)) / 100) * (Convert.ToDecimal(Session["getamount"]));

                netamount = Convert.ToDecimal(Session["getamount"]) + vat + sc - discount;
                txtNetAmount.Text = (Math.Round(netamount).ToString());
            }
            else if (ddlServiceCharge.SelectedItem.ToString() == "Please Select")
            {
                vat = ((Convert.ToDecimal(ddlvat.SelectedItem.ToString())) / 100) * (Convert.ToDecimal(Session["getamount"]));
                sc = 0 * Convert.ToDecimal(txtAmount.Text);
                discount = ((Convert.ToDecimal(txtDiscount.Text)) / 100) * (Convert.ToDecimal(Session["getamount"]));

                netamount = Convert.ToDecimal(Session["getamount"]) + vat + sc - discount;
                txtNetAmount.Text = (Math.Round(netamount).ToString());
            }
            else if (txtDiscount.Text == string.Empty)
            {
                vat = ((Convert.ToDecimal(ddlvat.SelectedItem.ToString())) / 100) * (Convert.ToDecimal(Session["getamount"]));
                sc = ((Convert.ToDecimal(ddlServiceCharge.SelectedItem.ToString())) / 100) * (Convert.ToDecimal(Session["getamount"]));
                discount = (0 * Convert.ToDecimal(txtAmount.Text));

                netamount = Convert.ToDecimal(Session["getamount"]) + vat + sc - discount;
                txtNetAmount.Text = (Math.Round(netamount).ToString());
            }
            else
            {
                vat = ((Convert.ToDecimal(ddlvat.SelectedItem.ToString())) / 100) * (Convert.ToDecimal(Session["getamount"]));
                sc = ((Convert.ToDecimal(ddlServiceCharge.SelectedItem.ToString())) / 100) * (Convert.ToDecimal(Session["getamount"]));
                discount = ((Convert.ToDecimal(txtDiscount.Text)) / 100) * (Convert.ToDecimal(Session["getamount"]));

                netamount = Convert.ToDecimal(Session["getamount"]) + Convert.ToDecimal(vat) + Convert.ToDecimal(sc) - Convert.ToDecimal(discount);
                txtNetAmount.Text = (Math.Round(netamount).ToString());
            }

        }
    }

    protected void btnCalculateAmount_Click(object sender, EventArgs e)
    {
        int getproductid = Convert.ToInt32(ddlProduct.SelectedValue);
        var data = imsdb.Products.Where(d => d.Id == getproductid).FirstOrDefault();
        int getquantity = Convert.ToInt32(data.Quantity);
        var getquantityvalue = Convert.ToInt32(txtQuantity.Text);

        if (getquantityvalue > getquantity)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Quantity exceeded! " + getquantity + " " + ddlProduct.SelectedItem + " " + " are available" + "');", true);
            txtQuantity.Text = getquantity.ToString();
            txtQuantity.Focus();
            txtAmount.Text = "";

        }
        else if (txtQuantity.Text == string.Empty || txtQuantity.Text.StartsWith("-") || txtQuantity.Text == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Quantity value cannot be negative or empty or zero!" + "');", true);
            txtQuantity.Focus();

        }
        else if (txtRate.Text == string.Empty || txtRate.Text.StartsWith("-") || txtRate.Text == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Price rate cannot be negative or empty or zero!" + "');", true);
            txtRate.Focus();

        }
        else
        {
            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal rate = Convert.ToDecimal(txtRate.Text);
            var amount = quantity * rate;
            txtAmount.Text = Convert.ToString(amount);
            Session["getamount"] = txtAmount.Text;
        }
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        string productname = ddlProduct.SelectedItem.ToString();
        var data1 = imsdb.Products.Where(d => d.ProductName == productname).ToList();
        foreach (var item in data1)
        {
            DateTime entrydate = Convert.ToDateTime(item.Date);
            DateTime expirydate = entrydate.AddDays(20);
            if (DateTime.Now > expirydate && ddlProduct.SelectedValue != "0")
            {
                txtDiscount.Enabled = false;
                txtDiscount.Text = "5";
            }
            else
            {
                txtDiscount.Enabled = true;
                txtDiscount.Text = "";
            }
        }
        int getproductid = Convert.ToInt32(ddlProduct.SelectedValue);
        var data = imsdb.Products.Where(d => d.Id == getproductid).FirstOrDefault();
        if (ddlProduct.SelectedValue != "0")
        {
            txtQuantity.Text = data.Quantity.ToString();
            txtRate.Text = Math.Round(Convert.ToDecimal(data.ProductPrice)).ToString();
        }
        else
        {
            txtRate.Text = "";
            txtQuantity.Text = "";
        }
    }
}