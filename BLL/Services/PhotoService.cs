using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        public void AddNewLike(BllLike like)
        {
            throw new NotImplementedException();
        }

        public void Create(BllPhoto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BllPhoto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllPhoto> GetAll()
        {
            throw new NotImplementedException();
        }

        public BllPhoto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllLike> GetLikesForPhoto(int photoId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllTag> GetTagsForPhoto(int photoId)
        {
            throw new NotImplementedException();
        }

        public void RemoveLike(BllLike like)
        {
            throw new NotImplementedException();
        }

        public void Update(BllPhoto entity)
        {
            throw new NotImplementedException();
        }
    }
}
