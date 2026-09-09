using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddEditPhoto : PageDataAccess
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "Control Panel= Add Edit Photo";
        if (!IsPostBack)
        {
            ddlCategory.DataSource = DA.GetAllCategory();
            ddlCategory.DataBind();
            if (Request.QueryString["id"] != null)
            {
                DataTable dt = DA.GetPhotos(Request.QueryString["id"].ToString());
                txtTitle.Text = dt.Rows[0]["title"].ToString();
                txtSummary.Text = dt.Rows[0]["sum"].ToString();
                txtDetails.Text = dt.Rows[0]["details"].ToString();
                ddlCategory.SelectedValue = dt.Rows[0]["cid"].ToString();
                ImgThumb.Visible = true;
                ImgThumb.ImageUrl = "../GetImageFromDB.aspx?id=" + Request.QueryString["id"];
                btnAdd.Text = "Alter";
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Byte[] imageByte = null;
        {
            if (fileImage.HasFile)
            {
                if (fileImage.PostedFile.ContentType.Contains("image"))
                {
                    imageByte = new Byte[fileImage.PostedFile.ContentLength];
                    fileImage.PostedFile.InputStream.Read(imageByte, 0, imageByte.Length);
                    fileImage.PostedFile.InputStream.Close();
                }
                else
                {
                    Lbmsg.Text = "  الصورة خاطئة هي ملف";
                    return;
                }
            }

            else if (btnAdd.Text.Equals("Add"))
            {
                Lbmsg.Text = "الصورة خاطئة";
                return;
            }
        }
        if (btnAdd.Text.Equals("Add"))
        {
            if (DA.AddEditPhoto("-1", txtTitle.Text, txtSummary.Text, txtDetails.Text, ddlCategory.SelectedValue, imageByte) > 0)

                Lbmsg.Text = "تم اضافة الصورة بنجاح";
            txtTitle.Text = txtSummary.Text = txtDetails.Text = "";
        }
        else
        {
            if (DA.AddEditPhoto(Request.QueryString["id"], txtTitle.Text, txtSummary.Text, txtDetails.Text, ddlCategory.SelectedValue, imageByte) > 0)

                Lbmsg.Text = "تم تحديث الصورة بنجاح";
            Response.Redirect("~/Admin/ViewDeletePhoto.aspx");
        }
    }
}
