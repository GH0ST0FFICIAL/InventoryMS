using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewSize : System.Web.UI.Page
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
            var data = imsdb.Sizes.OrderByDescending(b => b.Id).ToList();
            GridViewSize.DataSource = data;
            GridViewSize.DataBind();
        }

    }
    private void RefreshData()
    {
        var data = imsdb.Sizes.OrderByDescending(br => br.Id).ToList();
        GridViewSize.DataSource = data;
        GridViewSize.DataBind();
    }

    protected void GridViewSize_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewSize.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void GridViewSize_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblSizedId = GridViewSize.Rows[e.RowIndex].FindControl("Label1") as Label;
        TextBox txtSizeTitle = GridViewSize.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;

        int x = Convert.ToInt32(lblSizedId.Text);
        var data = imsdb.Sizes.Where(d => d.Id == x).FirstOrDefault();
        data.Title = txtSizeTitle.Text;
        imsdb.SaveChanges();

        var data1 = imsdb.Products.Where(d => d.SizeId == x).FirstOrDefault();
        if (data1 != null)
        {
            data1.SizeId = data.Id;
            data1.Size = data.Title;
            imsdb.SaveChanges();
        }
        else
        {
            imsdb.SaveChanges();
        }
        GridViewSize.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Size updated!');location.href='ViewSize.aspx'", true);
    }

    protected void GridViewSize_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewSize.EditIndex = e.NewEditIndex;
        RefreshData();
    }

    protected void GridViewSize_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewSize.EditIndex = -1;
        RefreshData();
    }

    protected void GridViewSize_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnConfirm = (LinkButton)e.Row.FindControl("LinkButton1");
            btnConfirm.Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
}