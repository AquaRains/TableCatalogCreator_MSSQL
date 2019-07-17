using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableCatalogCreator2.Modules;

namespace TableCatalogCreator2
{
    class Program
    {
        static void Main(string[] args)
        {
            string OptionsPath = Environment.CurrentDirectory.ToString() + '/'; 
            //1. ini 파일에서 접속정보 가져옴
            PublicVar pVar = new PublicVar(OptionsPath);

            //2. DB에서 테이블 목록 가져옴
            DataTable dt = new DBCon(pVar).SelectDB($@"
SELECT DISTINCT

    A.[TABLE_NAME] '테이블명'

FROM

    INFORMATION_SCHEMA.COLUMNS A

ORDER BY '테이블명'",null);


            //3. 테이블 목록을 좌측 글자 기준으로 쪼갬 ex:LSTD, LSE 등
            var tableNameList = (from DataRow dr in dt.Rows select dr[0].ToString()).ToList();
            List<List<string>> splitList = new List<List<string>>();
            var l = (from string s in tableNameList select s.Split('_')[0]).Distinct();
            foreach (var item in l)
            {
                splitList.Add((from string s in l where s == item select s).ToList());
            }

            DataSet ds = new DataSet("Tables");

            DBCon dBCon = new DBCon(pVar);
            //테이블 이름별로 쿼리해서 저장
            foreach(string name in tableNameList)
            {
                Console.WriteLine($"{name} 테이블 쿼리 중");
                FillTables(dBCon, ref ds, name);
            }

            // 4, 5, 6, 엑셀 파일 만들고 쪼개고 저장하고 마무리 하는건 알아서 던지자.
            xsldoc.WorkThat(splitList, ds);


        }

        private static void FillTables(DBCon dbcon, ref DataSet ds, string tableName)
        {
            string sql = @"
SELECT
	A.[ORDINAL_POSITION] AS '열 일련번호',
	a.[COLUMN_NAME] AS '필드명',
	A.[DATA_TYPE] AS '자료형',
	A.[CHARACTER_MAXIMUM_LENGTH] as '길이',
	A.[IS_NULLABLE] 'NULL 여부',
	D.[CONSTRAINT_TYPE] as 'PK여부',
    '' AS '기본값'
FROM
	INFORMATION_SCHEMA.COLUMNS A
	LEFT OUTER JOIN (select
		B.[TABLE_NAME], B.[TABLE_CATALOG], B.[TABLE_SCHEMA],
		B.[CONSTRAINT_NAME], B.[CONSTRAINT_TYPE], C.[COLUMN_NAME]
	from
		INFORMATION_SCHEMA.TABLE_CONSTRAINTS B,
		INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE C
	WHERE
B.[CONSTRAINT_NAME] = c.[CONSTRAINT_NAME]) D ON
D.COLUMN_NAME = A.COLUMN_NAME AND A.TABLE_NAME = D.TABLE_NAME
WHERE A.[TABLE_NAME] = @tablename
ORDER BY '열 일련번호' asc
";
            try
            {
                dbcon.SelectDB(ref ds, tableName, sql,
                     new System.Data.SqlClient.SqlParameter[] 
                     { new System.Data.SqlClient.SqlParameter("@tablename", tableName) });
       
            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}
