using System;
using System.Data;
using System.Data.SqlClient;

public static class DBService
{
	 static string getConnectionString() {
        string con = "";
        if (System.Environment.MachineName == "")
        {
            con = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        else
        {
            con = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }
        return con;
    }


    public static string getResult(string query)
    {
        DataTable dt = getDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0][0].ToString();
        }
        else
        {
            return "";

        }
    }


    public static DataTable getDataTable(string query)
    {
        DataTable dataTable = new DataTable();
        SqlConnection conn = new SqlConnection(getConnectionString());
        try
        {

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
            return dataTable;

        }
        catch (Exception err) { throw err; }
        finally
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Close();
            }


        }

    }
    public static void ExecuteStatement(string statment)
    {

        SqlConnection conn = new SqlConnection(getConnectionString());
        try
        {

            SqlCommand cmd = new SqlCommand(statment, conn);
            conn.Open();

            cmd.ExecuteNonQuery();
          
            conn.Close();
         

        }
        catch (Exception err) { throw err; }
        finally
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Close();
            }


        }

    }


        

 
    
}



