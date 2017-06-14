using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Repositories
{
    public interface IPhoto: IRepository<Photo>
    {
        IEnumerable<Like> GetLikesForPhoto(int photoId);

        IEnumerable<Tag> GetTagsForPhoto(int photoId);

        void AddNewLike(Like like);

        void AddNewTag(Tag tag);

        void RemoveLike(Like like);
    }
}
