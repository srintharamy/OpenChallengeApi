using System;
using WebApiContactChallenge.Infrastructure.Interface.Repository;

namespace WebApiContactChallenge.Infrastructure.Interface.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository ContactRepository { get; }
        IContactSkillsRepository ContactSkillsRepository { get; }
        ISkillRepository SkillRepository { get; }

        void Complete();

        void Save();
    }
}