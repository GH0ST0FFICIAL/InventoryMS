using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Company : System.Web.UI.Page
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

    protected void btnComSubmit_Click(object sender, EventArgs e)
    {

        Company company = new Company();
        if (txtServiceCharge.Text == string.Empty || txtServiceCharge.Text.StartsWith("-") || txtServiceCharge.Text == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Service Charge value cannot be negative or empty or zero!" + "');", true);
            txtServiceCharge.Focus();
        }
        else if ( txtVat.Text.StartsWith("-") )
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Vat value cannot be negative !" + "');", true);
            txtVat.Focus();
        }
        else 
        {
            company.ServiceCharge = Convert.ToInt32(txtServiceCharge.Text);
            company.PriceVat = Convert.ToInt32(txtVat.Text);
            imsdb.Companies.Add(company);
            imsdb.SaveChanges();


            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Data added successfully!" + "');", true);
        }

    }
}