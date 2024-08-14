using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Ado 的摘要描述
/// </summary>
public class Ado
{
    public DataTable GetTable()
    {
        DataTable dt = new DataTable();

        string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        string strSql = "select * from products";

        using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(strSql, conn);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            conn.Close();

        }

        return dt;
    }
}