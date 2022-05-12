using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.UserDefined, MaxByteSize = 8000)]
public struct SqlUserDefinedType1: INullable, IBinarySerialize
{
    String description;
    decimal price;
    int avail;

    public override string ToString()
    {
        return description;
        //return $"descr: {description}, price: {price}, avail amount: {avail}";
    }
    
    public bool IsNull
    {
        get
        {
            return _null;
        }
    }
    
    public static SqlUserDefinedType1 Null
    {
        get
        {
            SqlUserDefinedType1 h = new SqlUserDefinedType1();
            h._null = true;
            return h;
        }
    }
    
    public static SqlUserDefinedType1 Parse(SqlString s)
    {
        string[] b = s.Value.Split('-');
        if (s.IsNull)
            return Null;
        SqlUserDefinedType1 u = new SqlUserDefinedType1 { 
            description = b[0],
            price = Convert.ToDecimal(b[1]),
            avail = Convert.ToInt32(b[2])
        };

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

    public void Read(System.IO.BinaryReader r)
    {
        description = r.ReadString();
    }

    public void Write(System.IO.BinaryWriter w)
    {
        w.Write($"descr: {description}, price: {price}, avail amount: {avail}");
    }
}