using System.Data.SqlClient;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.DapperSql.Base;
using WebApiContactChallenge.Infrastructure.Interface.Repository;

namespace WebApiContactChallenge.Infrastructure.DapperSql.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(SqlConnection dbConn, User user) : base(dbConn, user)
        {
        }

        protected override string TableName()
        {
            return "Contact";
        }

        protected override string InsertStatement()
        {
            return @"INSERT INTO [Contact] ([Key],[FirstName],[LastName],[Address],[PoBox],[City],[Country],[MobilePhoneNumber],[CreatedDate],[CreatedBy])
            VALUES(@Key,@FirstName,@LastName,@Address,@PoBox,@City,@Country,@MobilePhoneNumber,GETUTCDATE(),@CreatedBy);";
        }

        protected override string UpdateStatement()
        {
            return @"UPDATE [Contact] SET [FirstName] = @FirstName,[LastName] = @LastName,[Address] = @Address,[PoBox] = @PoBox,[City] = @City,[Country] = @Country,[MobilePhoneNumber] = @MobilePhoneNumber    
                    ,[UpdatedDate] = GETUTCDATE(),[UpdatedBy] = @UpdatedBy WHERE [Key] = @Key";
        }
    }
}