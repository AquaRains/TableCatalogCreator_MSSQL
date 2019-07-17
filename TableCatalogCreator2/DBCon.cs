using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableCatalogCreator2;

namespace TableCatalogCreator2
{
    class DBCon //: IDisposable	
    {

        //접속에 관련된 기본 값 세팅, 추후 ini등의 설정 파일로 값 가져오면 이 부분은 변경됩니다.
#if DEBUG

#else

#endif
        private string ConnectionStr = "";
        private SqlConnection Connection;
        //  private SqlCommand Command = new SqlCommand();


        public DBCon(Modules.PublicVar pVar)
        {
            var connectInfo = pVar.ConnectInfo;
            ConnectionStr = new SqlConnectionStringBuilder()
            {
                DataSource = connectInfo.IpAddress + (string.IsNullOrEmpty(connectInfo.Port) ? "" : $",{connectInfo.Port}"),
                UserID = connectInfo.DbName + "user",
                Password = "@1qaz",
                InitialCatalog = connectInfo.DbName

            }.ToString();

            //$"server{_server} ; uid = {_uid} ; pwd = {_pwd} ; database = {_dbname}";
            // Connection = new SqlConnection(ConnectionStr);
        }

        public void OpenDB()
        {
            if(this.Connection != null && this.Connection.State == ConnectionState.Closed)
            {
                try
                {
                    this.Connection.Open();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        public void CloseDB()
        {
            if(this.Connection != null && this.Connection.State == ConnectionState.Open)
            {
                try
                {
                    this.Connection.Close();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 쿼리문과 쿼리용 매개 변수를 입력 받아 DataTable 객체를 반환합니다.
        /// </summary>
        /// <param name="QueryStr">쿼리문</param>
        /// <param name="sqlParameters">매개 변수의 배열</param>
        /// <returns></returns>
        public DataTable SelectDB( string QueryStr, SqlParameter[] sqlParameters)
        {
            if(sqlParameters == null) sqlParameters = Enumerable.Empty<SqlParameter>().ToArray();

            SqlCommand selectcommand = new SqlCommand();

            selectcommand.Parameters.Clear();
            selectcommand.Parameters.AddRange(sqlParameters);
            selectcommand.CommandText = QueryStr;
            selectcommand.CommandType = CommandType.Text;

            DataTable _datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(selectcommand);

            using(SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                selectcommand.Connection = connection;

                try
                {
                    adapter.Fill(_datatable);
                    return _datatable;
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{ e.ToString()}\n {e.GetType().ToString()}");


                    return new DataTable();
                }
                finally
                {
                    CloseDB();
                }
            }
        }

        public void SelectDB(ref DataSet ds, string tbname, string QueryStr, SqlParameter[] sqlParameters)
        {
            if(sqlParameters == null) sqlParameters = Enumerable.Empty<SqlParameter>().ToArray();

            SqlCommand selectcommand = new SqlCommand();

            selectcommand.Parameters.Clear();
            selectcommand.Parameters.AddRange(sqlParameters);
            selectcommand.CommandText = QueryStr;
            selectcommand.CommandType = CommandType.Text;
            
            SqlDataAdapter adapter = new SqlDataAdapter(selectcommand);

            using(SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                selectcommand.Connection = connection;

                try
                {                    
                    adapter.Fill(ds,tbname);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{ e.ToString()}\n {e.GetType().ToString()}");


                }
                finally
                {
                    CloseDB();
                }
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="QueryStr">쿼리문</param>
        /// <param name="sqlParameters">매개 변수의 배열</param>
        /// <returns></returns>
        public DataTable SelectSchema(string QueryStr)
        {


            SqlCommand selectcommand = new SqlCommand();

            selectcommand.Parameters.Clear();
            selectcommand.CommandText = QueryStr;
            selectcommand.CommandType = CommandType.Text;

            DataTable _datatable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(selectcommand);

            using(SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                selectcommand.Connection = connection;

                try
                {
                    adapter.FillSchema(_datatable, SchemaType.Mapped);
                    return _datatable;
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{ e.ToString()}\n {e.GetType().ToString()}");


                    return new DataTable();
                }
                finally
                {
                    CloseDB();
                }
            }
        }


        public int ExecuteQuery(string QueryStr, SqlParameter[] sqlParameters)
        {
            // 
            if(sqlParameters == null) sqlParameters = Enumerable.Empty<SqlParameter>().ToArray();


            using(Connection = new SqlConnection(ConnectionStr))
            {
                using(SqlCommand Command = Connection.CreateCommand())
                {
                    //   Command.Connection = Connection;
                    OpenDB();

                    SqlTransaction transaction = Connection.BeginTransaction();
                    Command.Transaction = transaction;

                    Command.CommandText = QueryStr;
                    Command.CommandType = CommandType.Text;

                    Command.Parameters.Clear();
                    Command.Parameters.AddRange(sqlParameters);
                    try
                    {
                        int AffectedRowCount = Command.ExecuteNonQuery();
                        transaction.Commit();
                        return AffectedRowCount;
                    }
                    catch(SqlException e)
                    {
                        var n = (from SqlError a in e.Errors
                                 where a.Number == 2627 //중복 키 오류 코드
                                 select a).Count();
                        if(n > 0)
                        {
                            transaction.Rollback();
                            throw new DuplicateNameException("중복된 고유 값이 있습니다. 삭제 처리된 값중에 해당 값이 있는지 문의하세요.");
                        }
                        else
                        {
                            try
                            {
                                transaction.Rollback();
                                throw e;
                            }
                            catch(Exception e2)
                            {
                                throw e2;
                            }
                        }

                    }
                    catch(Exception)
                    {
                        try
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch(Exception)
                        {
                            throw;
                        }
                    }
                    finally
                    {
                        CloseDB();
                    }
                }
            }

        }

        /// <summary>
        /// 첫 행의 값을 반환하는 일반 쿼리입니다.(트랜잭션 없음)
        /// </summary>
        /// <param name="QueryStr"></param>
        /// <param name="sqlParameters"></param>
        /// <returns>첫행의 데이터를 반환합니다.</returns>
        public object ExecuteScalar(string QueryStr, SqlParameter[] sqlParameters)
        {
            // 
            if(sqlParameters == null) sqlParameters = Enumerable.Empty<SqlParameter>().ToArray();
            using(SqlCommand Command = new SqlCommand())
            {
                Command.CommandText = QueryStr;
                Command.CommandType = CommandType.Text;

                Command.Parameters.Clear();
                Command.Parameters.AddRange(sqlParameters);

                using(Connection = new SqlConnection(ConnectionStr))
                {
                    Command.Connection = Connection;
                    try
                    {
                        OpenDB();
                        return Command.ExecuteScalar();
                    }
                    catch(Exception e)
                    {
                        return null;
                    }
                    finally
                    {
                        CloseDB();
                    }
                }
            }
        }



       
    }
}
