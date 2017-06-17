using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using ORM;
using DAL.Interface;
using DAL.Interface.Repositories;
using DAL.Repositories;
using BLL.Interface.Services;
using BLL.Services;
using DAL;

namespace DependencyResolver
{
    public static class Resolver
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<EntityModel>().InSingletonScope();
            }

            #region Repositories binding

            kernel.Bind<ILikeRepository>().To<LikeRepository>();
            kernel.Bind<IPhotoRepository>().To<PhotoRepository>();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            #endregion

            #region Services binding

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IProfileService>().To<ProfileService>();
            kernel.Bind<IPhotoService>().To<PhotoService>();
            kernel.Bind<ITagService>().To<TagService>();
            kernel.Bind<ILikeService>().To<LikeService>();

            #endregion
        }
    }
}
