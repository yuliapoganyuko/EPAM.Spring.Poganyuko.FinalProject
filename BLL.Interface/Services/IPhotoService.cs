using BLL.Interface.Entities;
using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface IPhotoService : IService<BllPhoto>
    {
        IEnumerable<BllLike> GetLikesForPhoto(int photoId);

        IEnumerable<BllTag> GetTagsForPhoto(int photoId);

        void AddNewLike(BllLike like);

        void RemoveLike(BllLike like);
    }
}
