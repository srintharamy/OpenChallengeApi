using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using WebApiContactChallenge.BusinessObject.Base;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Common;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Infrastructure.DapperSql.Base
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : BusinessObjectBase
    {
        public abstract string TableName();
        public abstract string InsertStatement();
        public abstract string UpdateStatement();
        protected SqlConnection DbConn { get; }
        protected User User { get; }

        protected RepositoryBase(SqlConnection dbConn, User user)
        {
            DbConn = dbConn;
            User = user;
        }

        public IEnumerable<T> GetAll()
        {
            return DbConn.Query<T>($"Select * from {TableName()} Where DeletedDate Is Null").ToList();
        }

        public T Get(string key)
        {
            return DbConn.Query<T>($"Select * from {TableName()} Where [key] = '{key}'").FirstOrDefault();
        }

        public bool Delete(T objToDelete)
        {
            if (objToDelete == null)
            {
                throw new ChallengeFunctionnalException("Nothing to Delete");
            }
            var result = DbConn.Execute($"Delete From {TableName()} Where [Key] ='{objToDelete.Key}'");
            return result == 1;
        }

        public IEnumerable<T> Insert(IEnumerable<T> objListToInsert)
        {
            return objListToInsert.Select(Insert).ToList();
        }

        public T Insert(T objToInsert)
        {
            objToInsert.CreatedBy = User.Key;
            DbConn.ExecuteScalar<int>(InsertStatement(), objToInsert);
            return objToInsert;
        }

        public T Update(T objToUpdate)
        {
            objToUpdate.UpdatedBy = User.Key;
            DbConn.Execute(UpdateStatement(), objToUpdate);
            return objToUpdate;
        }

        public IEnumerable<T> Update(IEnumerable<T> objListToUpdate)
        {
            foreach (var obj in objListToUpdate)
            {
                obj.UpdatedBy = User.Key;
            }
            return objListToUpdate.Select(Update).ToList();
        }
    }
}