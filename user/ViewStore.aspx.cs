using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewStore : System.Web.UI.Page
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
            var data = imsdb.Stores.OrderByDescending(b => b.Id).ToList();
            GridViewStore.DataSource = data;
            GridViewStore.DataBind();
        }
    }
    private void RefreshData()
    {
        var data = imsdb.Stores.OrderByDescending(br => br.Id).ToList();
        GridViewStore.DataSource = data;
        GridViewStore.DataBind();
    }


    protected void GridViewStore_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewStore.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void GridViewStore_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }

    protected void GridViewStore_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblStoredId = GridViewStore.Rows[e.RowIndex].FindControl("Label1") as Label;
        TextBox txtStoreName = GridViewStore.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;

        int x = Convert.ToInt32(lblStoredId.Text);
        var data = imsdb.Stores.Where(d => d.Id == x).FirstOrDefault();
        data.StoreName = txtStoreName.Text;
        imsdb.SaveChanges();

        var data1 = imsdb.Products.Where(d => d.SizeId == x).FirstOrDefault();
        if (data1 != null)
        {
            data1.SizeId = data.Id;
            data1.Size = data.StoreName;
            imsdb.SaveChanges();
        }
        else
        {
            imsdb.SaveChanges();
        }
        GridViewStore.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Store name updated!');location.href='ViewStore.aspx'", true);
    }

    protected void GridViewStore_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewStore.EditIndex = e.NewEditIndex;
        RefreshData();
    }

    protected void GridViewStore_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewStore.EditIndex = -1;
        RefreshData();
    }

    protected void GridViewStore_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnConfirm = (LinkButton)e.Row.FindControl("LinkButton1");
            btnConfirm.Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
}