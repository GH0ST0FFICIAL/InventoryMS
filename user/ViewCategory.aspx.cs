using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewCategory : System.Web.UI.Page
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
            var data = imsdb.Categories.OrderByDescending(b => b.Id).ToList();
            GridViewCategory.DataSource = data;
            GridViewCategory.DataBind();
        }
    }
    private void RefreshData()
    {
        var data = imsdb.Categories.OrderByDescending(br => br.Id).ToList();
        GridViewCategory.DataSource = data;
        GridViewCategory.DataBind();
    }

    protected void GridViewCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewCategory.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void GridViewCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblCategorydId = GridViewCategory.Rows[e.RowIndex].FindControl("Label1") as Label;
        TextBox txtCategoryTitle = GridViewCategory.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;

        int x = Convert.ToInt32(lblCategorydId.Text);
        var data = imsdb.Categories.Where(d => d.Id == x).FirstOrDefault();
        data.Title = txtCategoryTitle.Text;
        imsdb.SaveChanges();

        var data1 = imsdb.Products.Where(d => d.CategoryId == x).FirstOrDefault();
        if (data1 != null)
        {
            data1.CategoryId = data.Id;
            data1.Category = data.Title;
            imsdb.SaveChanges();
        }
        else
        {
            imsdb.SaveChanges();
        }
        GridViewCategory.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Category updated!');location.href='ViewCategory.aspx'", true);

    }

    protected void GridViewCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewCategory.EditIndex = e.NewEditIndex;
        RefreshData();
    }

    protected void GridViewCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewCategory.EditIndex = -1;
        RefreshData();
    }

    protected void GridViewCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnConfirm = (LinkButton)e.Row.FindControl("LinkButton1");
            btnConfirm.Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
}