using System.Collections.Generic;
using System.Data.SqlClient;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.DapperSql.Base;
using WebApiContactChallenge.Infrastructure.Interface.Repository;

namespace WebApiContactChallenge.Infrastructure.DapperSql.Repository
{
    public class SkillRepository : RepositoryBase<Skill> ,ISkillRepository
    {
        public SkillRepository(SqlConnection dbConn, User user) : base(dbConn, user)
        {

        }

        public override string TableName()
        {
            return "Skill";
        }

        public override string InsertStatement()
        {
            throw new System.NotImplementedException();
        }

        public override string UpdateStatement()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Skill> Insert(IEnumerable<Skill> objListToInsert)
        {
            throw new System.NotImplementedException();
        }

        public Skill Insert(Skill objToInsert)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Skill objToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IEnumerable<Skill> objListToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Skill objToDelete)
        {
            throw new System.NotImplementedException();
        }

    }
}