using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public class DataAccess
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DamascusConn"].ToString());

    public DataAccess()
    {
        conn.Open();
    }

    public void CloseConn()
    {
        conn.Close();
    }

    public int AddEditPhoto(string id, string title, string sum, string details, string cid, Byte[] image)
    {
        SqlCommand cmd = new SqlCommand("AddEditPhoto", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@title", title);
        cmd.Parameters.AddWithValue("@sum", sum);
        cmd.Parameters.AddWithValue("@details", details);
        cmd.Parameters.AddWithValue("@cid", cid);
        cmd.Parameters.AddWithValue("@image", image);
        cmd.Parameters.AddWithValue("@id", id);
        return cmd.ExecuteNonQuery();
    }

    public DataTable GetAllCategory()
    {
        SqlDataAdapter sda = new SqlDataAdapter("GetAllCategory", conn);
        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        sda.Fill(dt);
        return dt;
    }

    public int DeletePhotos(string id)
    {
        SqlCommand cmd = new SqlCommand("DeletePhotos", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);
        return cmd.ExecuteNonQuery();
    }

    public DataTable GetPhotos(string id)
    {
        SqlDataAdapter sda = new SqlDataAdapter("GetPhotos", conn);
        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        sda.SelectCommand.Parameters.AddWithValue("@id", id);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        return dt;
    }

    public int ActiveComments(string id, bool active)
    {
        SqlCommand cmd = new SqlCommand("ActiveComments", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@active", active);
        return cmd.ExecuteNonQuery();
    }

    public int AddComments(string coid, string name, string email, string comment, string id)
    {
        SqlCommand cmd = new SqlCommand("AddComments", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@coid", coid);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@comment", comment);
        cmd.Parameters.AddWithValue("@id", id);
        return cmd.ExecuteNonQuery();
    }
}
