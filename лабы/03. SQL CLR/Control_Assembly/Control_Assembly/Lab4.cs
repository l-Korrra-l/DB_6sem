using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;

public partial class StoredProcedures
{
    [SqlProcedure]
    public static void inters()
    {
        int rows;
        SqlConnection conn = new SqlConnection("Context Connection=true");
        conn.Open();
        SqlCommand sqlCmd = conn.CreateCommand();

        sqlCmd.CommandText = @"exec intersection";

        SqlContext.Pipe.ExecuteAndSend(sqlCmd);
        conn.Close();
    }

}

