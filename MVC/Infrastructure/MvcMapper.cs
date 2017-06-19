using BLL.Interface.Entities;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Infrastructure
{
    public static class MvcMapper
    {
        #region BLL Entity to MVC Entity

        public static TagModel ToMvcEntity(this BllTag bllTag)
        {
            if (ReferenceEquals(bllTag, null))
                return null;
            return new TagModel()
            {
                Id = bllTag.Id,
                Text = bllTag.Text,
                Photos = bllTag.Photos.Select(p => p.ToMvcEntity()).ToList()
            };
        }

        public static LikeModel ToMvcEntity(this BllLike bllLike)
        {
            if (ReferenceEquals(bllLike, null))
                return null;
            return new LikeModel()
            {
                Id = bllLike.Id,
                UserId = bllLike.UserId,
                PhotoId = bllLike.PhotoId
            };
        }

        public static ProfileModel ToMvcEntity(this BllProfile bllProfile)
        {
            if (ReferenceEquals(bllProfile, null))
                return null;
            return new ProfileModel()
            {
                Id = bllProfile.Id,
                Avatar = ReferenceEquals(bllProfile.Avatar, null) ? null : CopyImage(bllProfile.Avatar)
            };
        }

        public static UserModel ToMvcEntity(this BllUser bllUser)
        {
            if (ReferenceEquals(bllUser, null))
                return null;
            return new UserModel()
            {
                Id = bllUser.Id,
                Login = bllUser.Login,
                Email = bllUser.Email,
                Password = bllUser.Password,
                RoleId = bllUser.RoleId
            };
        }

        public static PhotoModel ToMvcEntity(this BllPhoto bllPhoto)
        {
            if (ReferenceEquals(bllPhoto, null))
                return null;
            return new PhotoModel()
            {
                Id = bllPhoto.Id,
                UserId = bllPhoto.UserId,
                Image = ReferenceEquals(bllPhoto.Image, null) ? null : CopyImage(bllPhoto.Image),
                Description = bllPhoto.Description,
                Time = bllPhoto.Time,
                Likes = bllPhoto.Likes.Select(l => l.ToMvcEntity()).ToList(),
                Tags = bllPhoto.Tags.Select(t => new TagModel() { Id = t.Id, Text = t.Text }).ToList()
            };
        }

        public static RoleModel ToMvcEntity(this BllRole bllRole)
        {
            if (ReferenceEquals(bllRole, null))
                return null;
            return new RoleModel()
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };
        }

        #endregion


        #region MVC Entity to BLL Entity

        public static BllTag ToBllEntity(this TagModel tagModel)
        {
            if (ReferenceEquals(tagModel, null))
                return null;
            return new BllTag()
            {
                Id = tagModel.Id,
                Text = tagModel.Text,
                Photos = tagModel.Photos.Select(p => p.ToBllEntity()).ToList()
            };
        }

        public static BllLike ToBllEntity(this LikeModel likeModel)
        {
            if (ReferenceEquals(likeModel, null))
                return null;
            return new BllLike()
            {
                Id = likeModel.Id,
                UserId = likeModel.UserId,
                PhotoId = likeModel.PhotoId
            };
        }

        public static BllProfile ToBllEntity(this ProfileModel profileModel)
        {
            if (ReferenceEquals(profileModel, null))
                return null;
            return new BllProfile()
            {
                Id = profileModel.Id,
                Avatar = ReferenceEquals(profileModel.Avatar, null) ? null : CopyImage(profileModel.Avatar)
            };
        }

        public static BllUser ToBllEntity(this UserModel userModel)
        {
            if (ReferenceEquals(userModel, null))
                return null;
            return new BllUser()
            {
                Id = userModel.Id,
                Login = userModel.Login,
                Email = userModel.Email,
                Password = userModel.Password,
                RoleId = userModel.RoleId
            };
        }

        public static BllPhoto ToBllEntity(this PhotoModel photoModel)
        {
            if (ReferenceEquals(photoModel, null))
                return null;
            return new BllPhoto()
            {
                Id = photoModel.Id,
                UserId = photoModel.UserId,
                Image = ReferenceEquals(photoModel.Image, null) ? null : CopyImage(photoModel.Image),
                Description = photoModel.Description,
                Time = photoModel.Time,
                Likes = photoModel.Likes.Select(l => l.ToBllEntity()).ToList(),
                Tags = photoModel.Tags.Select(t => new BllTag() { Id = t.Id, Text = t.Text }).ToList()
            };
        }

        public static BllRole ToBllEntity(this RoleModel roleModel)
        {
            if (ReferenceEquals(roleModel, null))
                return null;
            return new BllRole()
            {
                Id = roleModel.Id,
                Name = roleModel.Name
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