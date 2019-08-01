using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ViewUser : System.Web.UI.Page
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
            var data = imsdb.UserAccounts.OrderByDescending(u => u.Id).ToList();
            GridViewUsers.DataSource = data;
            GridViewUsers.DataBind(); 
        }
    }
    private void RefreshData()
    {
        var data = imsdb.UserAccounts.OrderByDescending(d => d.Id).ToList();
        GridViewUsers.DataSource = data;
        GridViewUsers.DataBind();
    }

    protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewUsers.PageIndex = e.NewPageIndex;
        RefreshData();
    }

    protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label lblId = GridViewUsers.Rows[e.RowIndex].FindControl("Label1") as Label;
        DropDownList ddlType = GridViewUsers.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList;
        DropDownList ddlStatus = GridViewUsers.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
        FileUpload photo = GridViewUsers.Rows[e.RowIndex].FindControl("FileUpload1") as FileUpload;

        int x = Convert.ToInt32(lblId.Text);
        var data = imsdb.UserAccounts.Where(d => d.Id == x).FirstOrDefault();
        
        data.Status = ddlStatus.SelectedValue;
        //Session["Type"] = ddlType.SelectedItem.ToString();
        data.TypeId = Convert.ToInt32(ddlType.SelectedValue);
        data.Type = ddlType.SelectedItem.ToString();

        if (photo.HasFile)
        {
            photo.SaveAs(Server.MapPath("./userImages/" + photo.FileName));
            data.Photo = photo.FileName;
        }

        imsdb.SaveChanges();
        GridViewUsers.EditIndex = -1;
        RefreshData();
        ScriptManager.RegisterStartupScript(this, GetType(), "",
"alert('User updated!');location.href='ViewUser.aspx'", true);
    }

    protected void GridViewUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewUsers.EditIndex = e.NewEditIndex;
        RefreshData();
    }

    protected void GridViewUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewUsers.EditIndex = -1;
        RefreshData();
    }

    protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    //    Label lblId = GridViewUsers.Rows[e.RowIndex].FindControl("Label1") as Label;
    //    int x = Convert.ToInt32(lblId.Text);
    //    var data = imsdb.UserAccounts.Where(d => d.Id == x).FirstOrDefault();
    //    try
    //    {
    //        imsdb.UserAccounts.Remove(data);
    //        imsdb.SaveChanges();
    //        ScriptManager.RegisterStartupScript(this, GetType(), "",
    //"alert('User deleted!');location.href='ViewUser.aspx'", true);
    //        RefreshData();
    //    }
    //    catch (Exception)
    //    {
    //        ScriptManager.RegisterStartupScript(this, GetType(), "",
    //"alert('You cannot delete this user! Contact your administator');location.href='ViewUser.aspx'", true);
    //    }
    }

    protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnConfirm = (LinkButton)e.Row.FindControl("LinkButton1");
            btnConfirm.Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
}