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
using System.IO;
using System.Drawing;

public partial class GetImagFromDB : PageDataAccess
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = DA.GetPhotos(Request.QueryString["id"].ToString());
        if (dt.Rows.Count > 0)
        {
            if (!(dt.Rows[0]["image"] is DBNull))
            {
                Byte[] imageByte = (Byte[])dt.Rows[0]["image"];
                MemoryStream ms = new MemoryStream(imageByte);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                img.Save(Response.OutputStream,System.Drawing.Imaging.ImageFormat.Jpeg);
                img.Dispose();
            }
        }
    }
}
