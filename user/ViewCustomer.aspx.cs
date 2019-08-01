using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewCustomer : System.Web.UI.Page
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
            var data = imsdb.Customers.OrderByDescending(d => d.Id).ToList();
            GridViewCustomer.DataSource = data;
            GridViewCustomer.DataBind();
        }
    }
    private void RefreshData()
    {
        var data = imsdb.Customers.OrderByDescending(d => d.Id).ToList();
        GridViewCustomer.DataSource = data;
        GridViewCustomer.DataBind();
    }

    protected void GridViewCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewCustomer.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void GridViewCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblproductId = GridViewCustomer.Rows[e.RowIndex].FindControl("Label1") as Label;
        TextBox txtCustomerName = GridViewCustomer.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        TextBox txtCustomerAddress = GridViewCustomer.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
        TextBox txtCustomerPhone = GridViewCustomer.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
        TextBox txtCustomerDOB = GridViewCustomer.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;


        int x = Convert.ToInt32(lblproductId.Text);
        var data = imsdb.Customers.Where(d => d.Id == x).FirstOrDefault();


        data.CustomerName = txtCustomerName.Text;
        data.CustomerAddress = txtCustomerAddress.Text;
        data.CustomerPhone = txtCustomerPhone.Text;
        data.CustomerDOB = Convert.ToDateTime(txtCustomerDOB.Text);


        imsdb.SaveChanges();
        GridViewCustomer.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Customer data updated!');location.href='ViewCustomer.aspx'", true);
    }


    protected void GridViewCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewCustomer.EditIndex = e.NewEditIndex;
        RefreshData();
    }

    protected void GridViewCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewCustomer.EditIndex = -1;
        RefreshData();
    }
}