using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServices
{
    public class Dapperr : IDapper
    {
        SqlConnection Connection;
        private readonly ConnectionString _con;
        IDbConnection db;
        public Dapperr(SqlConnection Conn = null)
        {
            _con = new ConnectionString();
            Conn = _con.GetConnection();
            Connection = Conn;
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            else
            {
                Connection.Open();
            }
        }
        public T Execute<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (db = _con.GetConnection())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                using var transaction = db.BeginTransaction();
                try
                {
                    db.Query<T>(sp, parms, commandType: commandType, transaction: transaction);
                    transaction.Commit();
                    result = parms.Get<T>("retVal") ; //get output parameter value
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            };
            return result;
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (db = _con.GetConnection())
            {
                return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }

        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (db = _con.GetConnection())
            {
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            }
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (db = _con.GetConnection())
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            this.Dispose();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (db = _con.GetConnection())
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            this.Dispose();
                            throw ex;
                        }
                    }
                       
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;

        }
        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public List<Usp_UserData_Result> UserData()
        //{
        //    var Data = _con.Database.SqlQuery<Usp_UserData_Result>("Usp_UserData").ToList();
        //    return Data;
        //}
        #endregion
    }
}
