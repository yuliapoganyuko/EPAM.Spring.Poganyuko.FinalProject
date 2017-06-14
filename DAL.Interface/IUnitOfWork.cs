using DAL.Interface.Repositories;
using System;

namespace DAL.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        IUser Users { get; }

        IRole Roles { get; }

        IProfile Profiles { get; }

        IPhoto Photos { get; }

        ILike Likes { get; }

        ITag Tags { get; }

        void Commit();
    }
}
