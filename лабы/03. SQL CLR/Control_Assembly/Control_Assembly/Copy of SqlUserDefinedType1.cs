using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined, MaxByteSize = 8000)]
public struct SqlUserDefinedType3 : INullable, IBinarySerialize
{
    String task;
    DateTime order_d;
    DateTime del_d;
    public override string ToString()
    {
        // Replace with your own code
        return task;
    }

    public bool IsNull
    {
        get
        {
            // Put your code here
            return _null;
        }
    }

    public static SqlUserDefinedType3 Null
    {
        get
        {
            SqlUserDefinedType3 h = new SqlUserDefinedType3();
            return h;
        }
    }

    public static SqlUserDefinedType3 Parse(SqlString s)
    {
        string[] b = s.Value.Split('&');
        if (s.IsNull)
            return Null;
        SqlUserDefinedType3 u = new SqlUserDefinedType3
        {
            task = b[0],
            order_d = Convert.ToDateTime(b[1]),
            del_d = b[2] != null && b[2] != "" ?Convert.ToDateTime(b[2]) : new DateTime()
        };

        // Put your code here
        return u;
    }

    // This is a place-holder method
    public string Method1()
    {
        // Put your code here
        return string.Empty;
    }

    // This is a place-holder static method
    public static SqlString Method2()
    {
        // Put your code here
        return new SqlString("");
    }

    public void Read(BinaryReader r)
    {
        task = r.ReadString();
    }

    public void Write(BinaryWriter w)
    {
        w.Write($"task: {task}, date: {order_d}, dalivery: {del_d}, current:{del_d == null}, overd: {order_d > new DateTime() && del_d == null}");
    }

    // This is a place-holder member field
    public int _var1;

    //  Private member
    private bool _null;
}