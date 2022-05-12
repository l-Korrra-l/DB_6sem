using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [SqlProcedure]
    public static void AllProducts()
    {
        SqlCommand command = new SqlCommand();

        command.Connection = new SqlConnection("Context connection = true");
        command.Connection.Open();

        string sqlString = "select * from products";

        command.CommandText = sqlString.ToString();
        SqlContext.Pipe.ExecuteAndSend(command);
        command.Connection.Close();
    }
}

