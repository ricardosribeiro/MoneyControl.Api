using Dapper;
using MoneyControl.Domain.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace MoneyControl.Data
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : IEntity
    {
        readonly MySqlConnection mySqlConnection;
        const string tableName = "";
        private IEnumerable<PropertyInfo> GetProperties => typeof(TEntity).GetProperties();        
        private IDbConnection CreateConnection()
        {

            var conn = mySqlConnection;
            conn.Open(); ;
            return conn;
        }


        public RepositoryBase()
        {
            mySqlConnection = new MySqlConnection("");
        }
        public async Task<bool> AddAsync(TEntity obj)
        {
            using var conneciton = CreateConnection();
            var query = QueryGenerator.GenerateInsertQuery(tableName, GetProperties);
            var result = await conneciton.ExecuteAsync(query, obj);

            return result > 0;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> obj)
        {
            using var conneciton = CreateConnection();
            var query = QueryGenerator.GenerateInsertQuery(tableName, GetProperties);
            var result = await conneciton.ExecuteAsync(query, obj);

            return result > 0;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<TEntity>($"SELECT * FROM {tableName}");
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstAsync<TEntity>($"SELECT * FROM {tableName} WHERE Id = {id.ToString()}");
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            using var connection= CreateConnection();
            var result =  await connection.ExecuteAsync($"DELETE FROM {tableName} WHERE Id = {id.ToString()}");

            return result == 1;
        }

        public Task<bool> UpdateAsync(Guid id, TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
