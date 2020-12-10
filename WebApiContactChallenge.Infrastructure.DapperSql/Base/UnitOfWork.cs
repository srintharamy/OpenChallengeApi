using System.Data.SqlClient;
using System.Transactions;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Common.Configuration;
using WebApiContactChallenge.Infrastructure.DapperSql.Repository;
using WebApiContactChallenge.Infrastructure.Interface.Base;
using WebApiContactChallenge.Infrastructure.Interface.Repository;

namespace WebApiContactChallenge.Infrastructure.DapperSql.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IContactRepository _contactRepository;
        private IContactSkillsRepository _contactSkillsRepository;
        private ISkillRepository _skillRepository;

        public UnitOfWork(User user, bool useTransactionScope = false)
        {
            User = user;
            DbConn = new SqlConnection(ConfigHelper.GetConfig(ConfigHelper.ConnectionStringKey));

            if (useTransactionScope)
            {
                TransactionScope = new TransactionScope();
            }
        }

        public User User { get; set; }
        private TransactionScope TransactionScope { get; }

        private SqlConnection DbConn { get; }

        public IContactRepository ContactRepository => _contactRepository ?? (_contactRepository = new ContactRepository(DbConn, User));
        public IContactSkillsRepository ContactSkillsRepository => _contactSkillsRepository ?? (_contactSkillsRepository = new ContactSkillsRepository(DbConn, User));
        public ISkillRepository SkillRepository => _skillRepository ?? (_skillRepository = new SkillRepository(DbConn, User));

        public void Complete()
        {
            TransactionScope?.Complete();
        }

        public void Save()
        {
        }

        public void Dispose()
        {
            DbConn.Close();
            DbConn.Dispose();
        }
    }
}