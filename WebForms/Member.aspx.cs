using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static string getMember(string p1, string p2, string p3, string p4)
    {
        string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string strSql = "select id,cname,ename,email,tel,identification,createTime from members";
        string pSql = "";

        SqlDataReader dr;
        List<Members> memberList = new List<Members>();

        using (SqlConnection con = new SqlConnection(conn))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                if (p1 != "")
                {
                    pSql = " cname=@cname ";
                    cmd.Parameters.AddWithValue("@cname", p1);
                }
                if (p2 != "")
                {
                    if (pSql == "") pSql = " ename=@ename ";
                    else pSql += " and ename=@ename ";
                    cmd.Parameters.AddWithValue("@ename", p2);
                }
                if (p3 != "")
                {
                    if (pSql == "") pSql = " email=@email ";
                    else pSql += " and email=@email ";
                    cmd.Parameters.AddWithValue("@email", p3);
                }
                if (p4 != "")
                {
                    if (pSql == "") pSql = " tel=@tel ";
                    else pSql += " and tel=@tel ";
                    cmd.Parameters.AddWithValue("@tel", p4);
                }

                if (pSql != "") strSql += " where " + pSql;

                cmd.CommandText = strSql;
                cmd.Connection = con;

                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string id = dr["id"].ToString();
                        string cname = dr["cname"].ToString();
                        string ename = dr["ename"].ToString();
                        string email = dr["email"].ToString();
                        string tel = dr["tel"].ToString();
                        string identification = dr["identification"].ToString();
                        string createTime = dr["createTime"].ToString();

                        memberList.Add(new Members
                        {
                            id = id,
                            cname = cname,
                            ename = ename,
                            email = email,
                            tel = tel,
                            identification = identification,
                            createTime = createTime

                        });
                    }
                }
            }
        }

        return JsonConvert.SerializeObject(memberList);
    }

    public class Members
    {
        public string id;
        public string cname;
        public string ename;
        public string email;
        public string tel;
        public string identification;
        public string createTime;

    }
}