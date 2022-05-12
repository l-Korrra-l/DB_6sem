using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct SqlUserDefinedType2: INullable
{
    public override string ToString()
    {
        // Replace with your own code
        return StoredProcedures.GetCurrentStr(new SqlDateTime(2000,12,1), new SqlDateTime(2023,12,12));
    }
    
    public bool IsNull
    {
        get
        {
            // Put your code here
            return _null;
        }
    }
    
    public static SqlUserDefinedType2 Null
    {
        get
        {
            SqlUserDefinedType2 h = new SqlUserDefinedType2();
            return h;
        }
    }
    
    public static SqlUserDefinedType2 Parse(SqlString s)
    {
        string[] b = s.Value.Split('-');
        if (s.IsNull)
            return Null;
        SqlUserDefinedType2 u = new SqlUserDefinedType2();
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
    
    // This is a place-holder member field
    public int _var1;
 
    //  Private member
    private bool _null;
}

