﻿namespace Lab2
{
    public class User
    {
        public string Username { get; set; } = String.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
