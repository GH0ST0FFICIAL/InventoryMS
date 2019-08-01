using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewSupplier : System.Web.UI.Page
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
            var data = imsdb.Suppliers.OrderByDescending(b => b.Id).ToList();
            GridViewSupplier.DataSource = data;
            GridViewSupplier.DataBind();
        }
    }
    private void RefreshData()
    {
        var data = imsdb.Suppliers.OrderByDescending(br => br.Id).ToList();
        GridViewSupplier.DataSource = data;
        GridViewSupplier.DataBind();
    }


    protected void GridViewSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewSupplier.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void GridViewSupplier_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblSupplierId = GridViewSupplier.Rows[e.RowIndex].FindControl("Label1") as Label;
        TextBox txtSupplierName = GridViewSupplier.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        TextBox txtSupplierPhone = GridViewSupplier.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
        TextBox txtSupplierAddress = GridViewSupplier.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
        TextBox txtSupplierProduct = GridViewSupplier.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;

        int x = Convert.ToInt32(lblSupplierId.Text);
        var data = imsdb.Suppliers.Where(d => d.Id == x).FirstOrDefault();
        data.SupplierName = txtSupplierName.Text;
        data.SupplierPhone = txtSupplierPhone.Text;
        data.SupplierAddress = txtSupplierAddress.Text;
        data.SupplierProduct = txtSupplierProduct.Text;
        imsdb.SaveChanges();

        var data1 = imsdb.Products.Where(d => d.SizeId == x).FirstOrDefault();
        if (data1 != null)
        {
            data1.SizeId = data.Id;
            data1.Size = data.SupplierName;
            imsdb.SaveChanges();
        }
        else
        {
            imsdb.SaveChanges();
        }
        GridViewSupplier.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('Store name updated!');location.href='ViewStore.aspx'", true);
    }

    protected void GridViewSupplier_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewSupplier.EditIndex = -1;
        RefreshData();
    }

    protected void GridViewSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnConfirm = (LinkButton)e.Row.FindControl("LinkButton1");
            btnConfirm.Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }

    protected void GridViewSupplier_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewSupplier.EditIndex = e.NewEditIndex;
        RefreshData();
    }
}