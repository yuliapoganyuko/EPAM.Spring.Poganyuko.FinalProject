using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Repositories
{
    public interface IPhotoRepository: IRepository<DalPhoto>
    {
        IEnumerable<DalLike> GetLikesForPhoto(int photoId);

        IEnumerable<DalTag> GetTagsForPhoto(int photoId);

        void AddNewLike(DalLike like);

        void RemoveLike(DalLike like);
    }
}
