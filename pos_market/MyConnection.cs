using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

public static class StringExtensions
{
    public static string ConnStr = string.Format(@"datasource={0};port={1};username={2};password={3}",
              Datasource, Port, Username, Password);

    public static bool CheckConection()
    {
        var con = new MySqlConnection(ConnStr);
        try
        {
            con.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
          
            return false;
        }
        finally
        {
            con.Close();
            con.Dispose();

        }
        return true;
    }


}