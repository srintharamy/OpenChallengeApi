using System.Data.SqlClient;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.DapperSql.Base;
using WebApiContactChallenge.Infrastructure.Interface.Repository;

namespace WebApiContactChallenge.Infrastructure.DapperSql.Repository
{
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        public SkillRepository(SqlConnection dbConn, User user) : base(dbConn, user)
        {
        }

        protected override string TableName()
        {
            return "Skill";
        }

        protected override string InsertStatement()
        {
            return "INSERT INTO [Skill]([Key],[Description],[CreatedDate],[CreatedBy]) VALUES(@Key,@Description,GETUTCDATE(),@CreatedBy)";
        }

        protected override string UpdateStatement()
        {
            return "UPDATE [Skill] SET [Description] = @Description ,[UpdateDate] = GETUTCDATE(),[UpdatedBy] = @UpdatedBy WHERE [Key] = @Key";
        }
    }
}