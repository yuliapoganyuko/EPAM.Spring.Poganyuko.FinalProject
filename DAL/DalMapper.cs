﻿using System.Linq;
using ORM.Entities;
using DAL.Interface.DTO;

namespace DAL
{
    public static class DalMapper
    {

        #region DAL Entity to ORM Entity

        public static Tag ToOrmEntity(this DalTag dalTag)
        {
            if (ReferenceEquals(dalTag, null))
                return null;
            return new Tag()
            {
                Id = dalTag.Id,
                Text = dalTag.Text,
                Photos = dalTag.Photos.Select(p => p.ToOrmEntity()).ToList()
            };
        }

        public static Like ToOrmEntity(this DalLike dalLike)
        {
            if (ReferenceEquals(dalLike, null))
                return null;
            return new Like()
            {
                Id = dalLike.Id,
                UserId = dalLike.UserId,
                PhotoId = dalLike.PhotoId
            };
        }

        public static Profile ToOrmEntity(this DalProfile dalProfile)
        {
            if (ReferenceEquals(dalProfile, null))
                return null;
            return new Profile()
            {
                UserId = dalProfile.Id,
                Avatar = ReferenceEquals(dalProfile.Avatar, null) ? null : CopyImage(dalProfile.Avatar)
            };
        }

        public static User ToOrmEntity(this DalUser dalUser)
        {
            if (ReferenceEquals(dalUser, null))
                return null;
            return new User()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                Email = dalUser.Email,
                Password = dalUser.Password,
                RoleId = dalUser.RoleId
            };
        }

        public static Photo ToOrmEntity(this DalPhoto dalPhoto)
        {
            if (ReferenceEquals(dalPhoto, null))
                return null;
            return new Photo()
            {
                Id = dalPhoto.Id,
                UserId = dalPhoto.UserId,
                Image = ReferenceEquals(dalPhoto.Image, null) ? null : CopyImage(dalPhoto.Image),
                Description = dalPhoto.Description,
                Time = dalPhoto.Time,
                Likes = dalPhoto.Likes.Select(l => l.ToOrmEntity()).ToList(),
                Tags = dalPhoto.Tags.Select(t => new Tag() { Id = t.Id, Text = t.Text }).ToList()
            };
        }

        public static Role ToOrmEntity(this DalRole dalRole)
        {
            if (ReferenceEquals(dalRole, null))
                return null;
            return new Role()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };
        }

        #endregion


        #region ORM Entity to DAL Entity

        public static DalTag ToDalEntity(this Tag tag)
        {
            if (ReferenceEquals(tag, null))
                return null;
            return new DalTag()
            {
                Id = tag.Id,
                Text = tag.Text,
                Photos = tag.Photos.Select(p => p.ToDalEntity()).ToList()
            };
        }

        public static DalLike ToDalEntity(this Like like)
        {
            if (ReferenceEquals(like, null))
                return null;
            return new DalLike()
            {
                Id = like.Id,
                UserId = like.UserId,
                PhotoId = like.PhotoId
            };
        }

        public static DalProfile ToDalEntity(this Profile profile)
        {
            if (ReferenceEquals(profile, null))
                    return null;
            return new DalProfile()
            {
                Id = profile.UserId,
                Avatar = ReferenceEquals(profile.Avatar, null) ? null : CopyImage(profile.Avatar)
            };
        }

        public static DalUser ToDalEntity(this User user)
        {
            if (ReferenceEquals(user, null))
                return null;
            return new DalUser()
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }

        public static DalPhoto ToDalEntity(this Photo photo)
        {
            if (ReferenceEquals(photo, null))
                return null;
            return new DalPhoto()
            {
                Id = photo.Id,
                UserId = photo.UserId,
                Image = ReferenceEquals(photo.Image, null) ? null : CopyImage(photo.Image),
                Description = photo.Description,
                Time = photo.Time,
                Likes = photo.Likes.Select(l => l.ToDalEntity()).ToList(),
                Tags = photo.Tags.Select(t => new DalTag() { Id = t.Id, Text = t.Text }).ToList()
            };
        }

        public static DalRole ToDalEntity(this Role role)
        {
            if (ReferenceEquals(role, null))
                return null;
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name
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

