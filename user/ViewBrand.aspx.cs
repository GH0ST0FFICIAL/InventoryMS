using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewBrand : System.Web.UI.Page
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
            var data = imsdb.Brands.OrderByDescending(b => b.Id).ToList();
            GridViewBrand.DataSource = data;
            GridViewBrand.DataBind();
        }
    }
    private void RefreshData()
    {
        var data = imsdb.Brands.OrderByDescending(br => br.Id).ToList();
        GridViewBrand.DataSource = data;
        GridViewBrand.DataBind();
    }

    protected void GridViewBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewBrand.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void GridViewBrand_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblBrandId = GridViewBrand.Rows[e.RowIndex].FindControl("Label1") as Label;
        TextBox txtBrandTitle = GridViewBrand.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;

        int x = Convert.ToInt32(lblBrandId.Text);
        var data = imsdb.Brands.Where(d => d.Id == x).FirstOrDefault();
        data.Title = txtBrandTitle.Text;
        imsdb.SaveChanges();

        var data1 = imsdb.Products.Where(d => d.BrandId == x).FirstOrDefault();
        if (data1 != null)
        {
            data1.BrandId = data.Id;
            data1.Brand = data.Title;
            imsdb.SaveChanges();
        }
        else
        {
            imsdb.SaveChanges();
        }
        GridViewBrand.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Brand updated!');location.href='ViewBrand.aspx'", true);

    }


    protected void GridViewBrand_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewBrand.EditIndex = e.NewEditIndex;
        RefreshData();
    }

    protected void GridViewBrand_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridViewBrand_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewBrand.EditIndex = -1;
        RefreshData();
    }

    protected void GridViewBrand_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnConfirm = (LinkButton)e.Row.FindControl("LinkButton1");
            btnConfirm.Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
}