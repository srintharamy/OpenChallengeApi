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
        where T : BusinessObjectBaseKey
    {
        protected RepositoryBase(SqlConnection dbConn, User user)
        {
            DbConn = dbConn;
            User = user;
        }

        protected SqlConnection DbConn { get; }
        private User User { get; }

        public virtual IEnumerable<T> GetAll()
        {
            return DbConn.Query<T>($"Select * from {TableName()}").ToList();
        }

        public virtual T Get(string key)
        {
            return DbConn.Query<T>($"Select * from {TableName()} Where [key] = '{key}'").FirstOrDefault();
        }

        public virtual bool Delete(T objToDelete)
        {
            if (objToDelete == null)
            {
                throw new ChallengeFunctionnalException("Nothing to Delete");
            }

            var result = DbConn.Execute($"Delete From {TableName()} Where [Key] ='{objToDelete.Key}'");
            return result == 1;
        }

        public virtual IEnumerable<T> Insert(IEnumerable<T> objListToInsert)
        {
            return objListToInsert.Select(Insert).ToList();
        }

        public virtual T Insert(T objToInsert)
        {
            objToInsert.CreatedBy = User.Key;
            DbConn.ExecuteScalar<int>(InsertStatement(), objToInsert);
            return objToInsert;
        }

        public virtual T Update(T objToUpdate)
        {
            objToUpdate.UpdatedBy = User.Key;
            DbConn.Execute(UpdateStatement(), objToUpdate);
            return objToUpdate;
        }

        public virtual IEnumerable<T> Update(IEnumerable<T> objListToUpdate)
        {
            foreach (var obj in objListToUpdate)
            {
                obj.UpdatedBy = User.Key;
            }

            return objListToUpdate.Select(Update).ToList();
        }

        protected abstract string TableName();
        protected abstract string InsertStatement();
        protected abstract string UpdateStatement();
    }
}