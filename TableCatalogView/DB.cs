using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TableCatalogView
{
    internal class DB
    {
        static string GetConnectstring(ConnectionInfo connectInfo)
        {
            return new SqlConnectionStringBuilder()
            {
                DataSource = connectInfo.Server + (string.IsNullOrEmpty(connectInfo.Port) ? "" : $",{connectInfo.Port}"),
                UserID = connectInfo.ID,
                Password = connectInfo.Pass,
                InitialCatalog = connectInfo.DBName
            }.ToString();
        }

        internal static DataTable GetTableList(ConnectionInfo connectionInfo)
        {
            string sql = $@"
SELECT        NAME, (SELECT VALUE FROM SYS.EXTENDED_PROPERTIES WHERE MAJOR_ID = A.ID AND MINOR_ID = 0 ) COMMENT
FROM SYSOBJECTS A
WHERE RTRIM(A.XTYPE) = 'U' -- AND name like 'TBL_%'
ORDER BY NAME
";
            DataTable dt = SelectDB(connectionInfo, sql, null);
            return dt;            
        }

        internal static DataTable GetTableInfo(ConnectionInfo connectionInfo, string s)
        {
            string sql = $@"
SELECT
    ROW_NUMBER() OVER( ORDER BY A.TABLE_NAME, A.ORDINAL_POSITION ) RNUM,
    A.COLUMN_NAME,
    CASE WHEN B.VALUE IS NULL THEN '' ELSE B.VALUE END AS COLUM_COMMENT,
    A.DATA_TYPE + ISNULL('(' + 
       ISNULL(CAST(A.CHARACTER_MAXIMUM_LENGTH AS VARCHAR),  
              CAST(A.NUMERIC_PRECISION AS VARCHAR) + ',' +
              CAST(A.NUMERIC_SCALE AS VARCHAR)) + ')','') AS COLUMN_LENGTH,
    CASE WHEN D.COLUMN_NAME IS NOT NULL THEN 'Y' ELSE '' END AS PK_YN, '' F_K,
    CASE WHEN A.IS_NULLABLE = 'NO' THEN 'Y' ELSE '' END NOT_NULL
FROM INFORMATION_SCHEMA.COLUMNS A
    LEFT OUTER JOIN SYS.EXTENDED_PROPERTIES B
    ON B.major_id = object_id(A.TABLE_NAME)
        AND A.ORDINAL_POSITION = B.minor_id
    LEFT OUTER JOIN
    (SELECT object_id(objname) AS TABLE_ID, VALUE
    FROM ::FN_LISTEXTENDEDPROPERTY
                (NULL, 'User','dbo','table',
                 NULL, NULL, NULL)
           ) C
    ON object_id(A.TABLE_NAME) = C.TABLE_ID
    LEFT OUTER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE D
    ON D.TABLE_NAME = A.TABLE_NAME AND D.COLUMN_NAME = A.COLUMN_NAME
WHERE A.TABLE_NAME = @tbname
ORDER BY A.TABLE_NAME, A.ORDINAL_POSITION

";

            DataTable dt = SelectDB(connectionInfo, sql, new SqlParameter[] { new SqlParameter("@tbname", s) });
            return dt;
        }

        internal static DataTable GetTableConstraints(ConnectionInfo connectionInfo, string s)
        {
            string sql = $@"
SELECT 
    tab.name AS [Table]
    ,tab.id AS [Table Id]
    ,constr.name AS [Constraint Name]
    ,constr.xtype AS [Constraint Type]
    ,CASE constr.xtype WHEN 'PK' THEN 'Primary Key' WHEN 'UQ' THEN 'Unique' ELSE '' END AS [Constraint Name]
    ,i.index_id AS [Index ID]
    ,ic.column_id AS [Column ID]
    ,clmns.name AS [Column Name]
    ,clmns.max_length AS [Column Max Length]
    ,clmns.precision AS [Column Precision]
    ,CASE WHEN clmns.is_nullable = 0 THEN 'NO' ELSE 'YES' END AS [Column Nullable]
    ,CASE WHEN clmns.is_identity = 0 THEN 'NO' ELSE 'YES' END AS [Column IS IDENTITY]
FROM SysObjects AS tab
INNER JOIN SysObjects AS constr ON(constr.parent_obj = tab.id AND constr.type = 'K')
INNER JOIN sys.indexes AS i ON( (i.index_id > 0 and i.is_hypothetical = 0) AND (i.object_id=tab.id) AND i.name = constr.name )
INNER JOIN sys.index_columns AS ic ON (ic.column_id > 0 and (ic.key_ordinal > 0 or ic.partition_ordinal = 0 or ic.is_included_column != 0)) 
                                    AND (ic.index_id=CAST(i.index_id AS int) 
                                    AND ic.object_id=i.object_id)
INNER JOIN sys.columns AS clmns ON clmns.object_id = ic.object_id and clmns.column_id = ic.column_id
WHERE tab.name = @tbname
ORDER BY tab.name
";

            DataTable dt = SelectDB(connectionInfo, sql, new SqlParameter[] { new SqlParameter("@tbname", s) });
            return dt;
        }

        public static DataTable SelectDB(ConnectionInfo connectionInfo, string QueryStr, SqlParameter[] sqlParameters)
        {
            if (sqlParameters == null) sqlParameters = Enumerable.Empty<SqlParameter>().ToArray();

            string connectstr = GetConnectstring(connectionInfo);
            SqlCommand selectcommand = new SqlCommand();

            selectcommand.Parameters.Clear();
            selectcommand.Parameters.AddRange(sqlParameters);
            selectcommand.CommandText = QueryStr;
            selectcommand.CommandType = CommandType.Text;

            DataTable _datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(selectcommand);

            using (SqlConnection connection = new SqlConnection(connectstr))
            {
                selectcommand.Connection = connection;

                try
                {
                    adapter.Fill(_datatable);
                    return _datatable;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{ e.ToString()}{Environment.NewLine} {e.GetType().ToString()}");


                    return new DataTable();
                }
                finally
                {
                }
            }
        }

    }
}