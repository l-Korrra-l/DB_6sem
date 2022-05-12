using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [SqlFunction]
    public static SqlBoolean RelocateFile(SqlString pathfrom, SqlString pathto)
    {
        try
        {
            if (!pathfrom.IsNull && !pathto.IsNull)
            {
                var dir = Path.GetDirectoryName(pathto.Value);
                if (!Directory.Exists(dir))
                    if (dir != null)
                        Directory.CreateDirectory(dir);
                System.IO.File.Copy(Path.Combine(Path.GetDirectoryName(pathfrom.Value), Path.Combine(Path.GetFileName(pathfrom.Value))), Path.Combine(Path.GetDirectoryName(pathto.Value), Path.Combine(Path.GetFileName(pathto.Value))), true);
            }
            return SqlBoolean.Null;
        }
        catch (Exception)
        {
            return SqlBoolean.Null;
        }
    }
}
