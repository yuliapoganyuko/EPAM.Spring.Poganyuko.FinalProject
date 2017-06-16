using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL
{
    public static class BllMapper
    {
        #region BLL Entity to DAL Entity

        public static DalTag ToDalEntity(this BllTag bllTag)
        {
            if (bllTag == null)
                return null;
            return new DalTag()
            {
                Id = bllTag.Id,
                Text = bllTag.Text,
                Photos = bllTag.Photos.Select(p => p.ToDalEntity()).ToList()
            };
        }

        public static DalLike ToDalEntity(this BllLike bllLike)
        {
            if (bllLike == null)
                return null;
            return new DalLike()
            {
                Id = bllLike.Id,
                UserId = bllLike.UserId,
                PhotoId = bllLike.PhotoId
            };
        }

        public static DalProfile ToDalEntity(this BllProfile bllProfile)
        {
            if (bllProfile == null)
                return null;
            return new DalProfile()
            {
                Id = bllProfile.Id,
                Avatar = bllProfile.Avatar == null ? null : CopyImage(bllProfile.Avatar)
            };
        }

        public static DalUser ToDalEntity(this BllUser bllUser)
        {
            if (bllUser == null)
                return null;
            return new DalUser()
            {
                Id = bllUser.Id,
                Login = bllUser.Login,
                Email = bllUser.Email,
                Password = bllUser.Password,
                RoleId = bllUser.RoleId
            };
        }

        public static DalPhoto ToDalEntity(this BllPhoto bllPhoto)
        {
            if (bllPhoto == null)
                return null;
            return new DalPhoto()
            {
                Id = bllPhoto.Id,
                UserId = bllPhoto.UserId,
                Image = bllPhoto.Image == null ? null : CopyImage(bllPhoto.Image),
                Description = bllPhoto.Description,
                Time = bllPhoto.Time,
                Likes = bllPhoto.Likes.Select(l => l.ToDalEntity()).ToList(),
                Tags = bllPhoto.Tags.Select(t => new DalTag() { Id = t.Id, Text = t.Text }).ToList()
            };
        }

        public static DalRole ToDalEntity(this BllRole bllRole)
        {
            if (bllRole == null)
                return null;
            return new DalRole()
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };
        }

        #endregion


        #region DAL Entity to BLL Entity

        public static BllTag ToBllEntity(this DalTag dalTag)
        {
            if (dalTag == null)
                return null;
            return new BllTag()
            {
                Id = dalTag.Id,
                Text = dalTag.Text,
                Photos = dalTag.Photos.Select(p => p.ToBllEntity()).ToList()
            };
        }

        public static BllLike ToBllEntity(this DalLike dalLike)
        {
            if (dalLike == null)
                return null;
            return new BllLike()
            {
                Id = dalLike.Id,
                UserId = dalLike.UserId,
                PhotoId = dalLike.PhotoId
            };
        }

        public static BllProfile ToBllEntity(this DalProfile dalProfile)
        {
            if (dalProfile == null)
                return null;
            return new BllProfile()
            {
                Id = dalProfile.Id,
                Avatar = dalProfile.Avatar == null ? null : CopyImage(dalProfile.Avatar)
            };
        }

        public static BllUser ToBllEntity(this DalUser dalUser)
        {
            if (dalUser == null)
                return null;
            return new BllUser()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                Email = dalUser.Email,
                Password = dalUser.Password,
                RoleId = dalUser.RoleId
            };
        }

        public static BllPhoto ToBllEntity(this DalPhoto dalPhoto)
        {
            if (dalPhoto == null)
                return null;
            return new BllPhoto()
            {
                Id = dalPhoto.Id,
                UserId = dalPhoto.UserId,
                Image = dalPhoto.Image == null ? null : CopyImage(dalPhoto.Image),
                Description = dalPhoto.Description,
                Time = dalPhoto.Time,
                Likes = dalPhoto.Likes.Select(l => l.ToBllEntity()).ToList(),
                Tags = dalPhoto.Tags.Select(t => new BllTag() { Id = t.Id, Text = t.Text }).ToList()
            };
        }

        public static BllRole ToBllEntity(this DalRole dalRole)
        {
            if (dalRole == null)
                return null;
            return new BllRole()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        #endregion

        private static byte[] CopyImage(byte[] image)
        {
            byte[] newImage = new byte[image.Length];
            image.CopyTo(newImage, 0);
            return newImage;
        }
    }
}
