using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_ViewDeletePhoto : PageDataAccess
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ch = (CheckBox)sender;
        foreach (GridViewRow r in GVphotos.Rows)
        {
            CheckBox chk = (CheckBox)r.FindControl("CHKphotos");
            chk.Checked = ch.Checked;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in GVphotos.Rows)
        {
            int deleted = 0;
            CheckBox chk = (CheckBox)r.FindControl("CHKphotos");
            if (chk.Checked)
            {
                DA.DeletePhotos(GVphotos.DataKeys[r.RowIndex].Value.ToString());
                deleted++;
            }
        }
        Lbmsg.Text = "Completed the delete";
        GVphotos.DataBind();
    }
}