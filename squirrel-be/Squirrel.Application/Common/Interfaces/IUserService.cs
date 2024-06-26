﻿namespace Squirrel.Application.Common.Interfaces
{
    public interface IUserService
    {
        TimeZoneInfo ClientTimeZone { get; }
        DateTime? ClientTime { get; }
        string JsonHeader { get; }
        string Method { get; }
        string RoleName { get; }
        string Url { get; }
        string Name { get; }
        string UserName { get; }
        int UserId { get; }

        void DeserializeUserId(string userSerialized);
    }
}