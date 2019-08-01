using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ViewCompanyPolicy : System.Web.UI.Page
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
            var data = imsdb.Companies.OrderByDescending(u => u.Id).ToList();
            GridViewCompanyPolicy.DataSource = data;
            GridViewCompanyPolicy.DataBind();
        }
    }
    private void RefreshData()
    {
        var data = imsdb.Companies.OrderByDescending(d => d.Id).ToList();
        GridViewCompanyPolicy.DataSource = data;
        GridViewCompanyPolicy.DataBind();
    }


    protected void GridViewCompanyPolicy_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewCompanyPolicy.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void GridViewCompanyPolicy_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }

    protected void GridViewCompanyPolicy_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewCompanyPolicy.EditIndex = e.NewEditIndex;
        RefreshData();
    }

    protected void GridViewCompanyPolicy_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblId = GridViewCompanyPolicy.Rows[e.RowIndex].FindControl("Label1") as Label;
        TextBox txtServiceCharge = GridViewCompanyPolicy.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        TextBox txtVat = GridViewCompanyPolicy.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;


        int x = Convert.ToInt32(lblId.Text);
        var data = imsdb.Companies.Where(d => d.Id == x).FirstOrDefault();
        data.ServiceCharge = Convert.ToInt32(txtServiceCharge.Text);
        data.PriceVat = Convert.ToInt32(txtVat.Text);

        imsdb.SaveChanges();
        GridViewCompanyPolicy.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Policy updated!');location.href='ViewCompanyPolicy.aspx'", true);
    }

    protected void GridViewCompanyPolicy_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewCompanyPolicy.EditIndex = -1;
        RefreshData();
    }

    protected void GridViewCompanyPolicy_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //LinkButton btnConfirm = (LinkButton)e.Row.FindControl("LinkButton1");
        //btnConfirm.Attributes.Add("onclick", "return confirm('Are you sure?');");
    }
}