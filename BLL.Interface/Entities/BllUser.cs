﻿namespace BLL.Interface.Entities
{
    public class BllUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
