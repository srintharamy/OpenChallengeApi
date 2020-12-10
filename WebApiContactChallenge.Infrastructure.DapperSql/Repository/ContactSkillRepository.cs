using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.BusinessObject.Interface;
using WebApiContactChallenge.Common;
using WebApiContactChallenge.Infrastructure.DapperSql.Base;
using WebApiContactChallenge.Infrastructure.Interface.Repository;

namespace WebApiContactChallenge.Infrastructure.DapperSql.Repository
{
    public class ContactSkillsRepository : RepositoryBase<ContactSkill>, IContactSkillsRepository
    {
        public ContactSkillsRepository(SqlConnection dbConn, User user) : base(dbConn, user)
        {
        }

        public IEnumerable<IContactSkill> GetByContact(string contactKey)
        {
            return DbConn.Query<ContactSkill>($"Select * from {TableName()} Where [ContactKey] = '{contactKey}'").ToList();
        }

        public IEnumerable<IContactSkill> GetByContacts(IEnumerable<string> contactKeys)
        {
            var inClause = contactKeys.Aggregate((i, j) => $"{i}','{j}");
            return DbConn.Query<ContactSkill>($"Select * from {TableName()} Where [ContactKey] IN ('{inClause}')").ToList();
        }

        protected override string TableName()
        {
            return "ContactSkills";
        }

        protected override string InsertStatement()
        {
            return "INSERT INTO [ContactSkills]([ContactKey],[SkillKey],[Level]) VALUES(@ContactKey,@SkillKey,@Level)";
        }

        protected override string UpdateStatement()
        {
            return "UPDATE [ContactSkills] SET [Level] = @Level WHERE [ContactKey] = @ContactKey and [SkillKey] = @SkillKey";
        }

        public override bool Delete(ContactSkill objToDelete)
        {
            if (objToDelete == null)
            {
                throw new ChallengeFunctionnalException("Nothing to Delete");
            }

            var result = DbConn.Execute($"Delete From {TableName()} Where [ContactKey] ='{objToDelete.ContactKey}' and [SkillKey]='{objToDelete.SkillKey}'");
            return result == 1;

        }
    }
}