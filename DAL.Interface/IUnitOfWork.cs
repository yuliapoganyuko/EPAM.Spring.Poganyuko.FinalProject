using DAL.Interface.Repositories;
using System;

namespace DAL.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }

        IRoleRepository Roles { get; }

        IProfileRepository Profiles { get; }

        IPhotoRepository Photos { get; }

        ILikeRepository Likes { get; }

        ITagRepository Tags { get; }

        void Commit();
    }
}
