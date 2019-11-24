using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace sql_server_application_test
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver15
    /// 使用AppKey 获取数据库锁，多个应用程序使用相同AppKey同时请求时，只会有一个获得锁
    /// </summary>
    public class SqlLock:IDisposable
    {
        private readonly string _dbPrincipal = "public";
        private readonly string _appKey = "MyAppLock";
        private readonly string _lockMode = "Exclusive";
        /// <summary>
        /// 获取锁的超时时长，如1000ms内得不到锁就抛异常
        /// </summary>
        private readonly int _lockTimeout = 1000;
        private readonly string _lockOwner = "Transaction";

        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public bool LockCreated;

        public SqlLock(string connectionStr, string appKey, int tLockTimeout=1000)
        {
            _appKey = appKey;
            _lockTimeout = tLockTimeout;
            _connection = new SqlConnection(connectionStr);
            _connection.Open();
            CreateLock();
        }
        public void Dispose()
        {
            //Release the Application Lock if it was created
            if (LockCreated)
            {
                ReleaseLock();
            }

            _connection.Close();
            _connection.Dispose();
        }
        private void CreateLock()
        {
            _transaction = _connection.BeginTransaction();

            using (SqlCommand createCmd = _connection.CreateCommand())
            {
                createCmd.Transaction = _transaction;
                createCmd.CommandType = System.Data.CommandType.Text;

                createCmd.CommandText = $@"DECLARE @result int;  
                                            EXEC @result=sp_getapplock  
                                                @DbPrincipal='{_dbPrincipal}',  
                                                @Resource='{_appKey}',  
                                                @LockMode='{_lockMode}',  
	                                            @LockTimeout={_lockTimeout.ToString()},
                                                @LockOwner='{_lockOwner}';  
                                            IF @result NOT IN (0, 1)
                                            BEGIN
                                                RAISERROR ( 'Unable to acquire Lock', 16, 1 )
                                            END";

                try
                {
                    createCmd.ExecuteNonQuery();
                    LockCreated = true;
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                    //throw new Exception(string.Format("Unable to get SQL Application Lock on '{0}'", AppKey), ex);
                }
            }
        }
        private void ReleaseLock()
        {
            using (SqlCommand releaseCmd = _connection.CreateCommand())
            {
                releaseCmd.Transaction = _transaction;
                releaseCmd.CommandType = System.Data.CommandType.StoredProcedure;
                releaseCmd.CommandText = "sp_releaseapplock";

                releaseCmd.Parameters.AddWithValue("@Resource", _appKey);
                releaseCmd.Parameters.AddWithValue("@LockOwner", _lockOwner);
                releaseCmd.Parameters.AddWithValue("@DbPrincipal", _dbPrincipal);

                try
                {
                    releaseCmd.ExecuteNonQuery();
                }
                catch { }
            }

            _transaction.Commit();
        }
    }
}
