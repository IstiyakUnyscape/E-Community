
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServices
{
    public class GenericRepository<T> : BaseRepository,IGenericRepository<T> where T:class
    {
        IDbConnection db;
        public GenericRepository(IConfiguration configuration): base(configuration)
        {
                db=CreateConnection();
            if (db.State == ConnectionState.Open)
            {
                db.Close();
            }
            else
            {
                db.Open();
            }
        }

        public Task<int> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync(string query)
        {
            try
            {
                
                using (var db = CreateConnection())
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    return (await db.QueryAsync<T>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<T>> GetByIdAsync(int id ,string query)
        {
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using ( db = CreateConnection())
                {
                    return ((List<T>)await db.QueryAsync<T>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
