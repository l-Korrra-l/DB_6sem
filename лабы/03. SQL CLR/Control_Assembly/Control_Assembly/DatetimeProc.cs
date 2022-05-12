using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;

public partial class StoredProcedures
{
    [SqlProcedure]
    public static void GetCurrent(SqlDateTime dateStart, SqlDateTime dateEnd)
    {
        int rows;
        SqlConnection conn = new SqlConnection("Context Connection=true");
        conn.Open();
        SqlCommand sqlCmd = conn.CreateCommand();

        sqlCmd.CommandText = @"select * from ORDERS where ((order_date between @dateStart and @dateEnd) or (PLANNED_D_DAY between @dateStart and @dateEnd))  and (DELIVERED is null or (DELIVERED > PLANNED_D_DAY and DELIVERED > @dateEnd))";

        sqlCmd.Parameters.Add("@dateStart", dateStart);
        sqlCmd.Parameters.Add("@dateEnd", dateEnd);

        SqlContext.Pipe.ExecuteAndSend(sqlCmd);
        conn.Close();
    }

    [SqlProcedure]
    public static string GetCurrentStr(SqlDateTime dateStart, SqlDateTime dateEnd)
    {
        int rows;
        SqlConnection conn = new SqlConnection("Context Connection=true");
        conn.Open();
        SqlCommand sqlCmd = conn.CreateCommand();

        sqlCmd.CommandText = @"select * from ORDERS where ((order_date between @dateStart and @dateEnd) or (PLANNED_D_DAY between @dateStart and @dateEnd))  and (DELIVERED is null or (DELIVERED > PLANNED_D_DAY and DELIVERED > @dateEnd))";

        sqlCmd.Parameters.Add("@dateStart", dateStart);
        sqlCmd.Parameters.Add("@dateEnd", dateEnd);

        string res = "";
        using (var reader = sqlCmd.ExecuteReader())
        {
            while (reader.Read())
            {
                res += reader[0];
                res += "\n";
            }
        }
        conn.Close();
        return res;
    }

    [SqlProcedure]
    public static void GetOverdue(SqlDateTime dateStart, SqlDateTime dateEnd)
    {
        int rows;
        SqlConnection conn = new SqlConnection("Context Connection=true");
        conn.Open();
        SqlCommand sqlCmd = conn.CreateCommand();

        sqlCmd.CommandText = @"select * from ORDERS where ((order_date between @dateStart and @dateEnd) or (PLANNED_D_DAY between @dateStart and @dateEnd) or (DELIVERED between @dateStart and @dateEnd)) 
                            and ((DELIVERED is null and PLANNED_D_DAY < GETDATE())or DELIVERED > PLANNED_D_DAY)";

        sqlCmd.Parameters.Add("@dateStart", dateStart);
        sqlCmd.Parameters.Add("@dateEnd", dateEnd);

        SqlContext.Pipe.ExecuteAndSend(sqlCmd);
        conn.Close();
    }
}

