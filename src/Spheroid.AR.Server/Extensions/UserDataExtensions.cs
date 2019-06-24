using System;

namespace Spheroid.AR.Server
{
    public static class UserDataExtensions
    {
        public static Guid UserIdOrSessionId(this IUserData userData) =>
            userData.UserId.GetValueOrDefault(userData.SessionId);

        public static bool IsAnonymous(this IUserData userData) =>
            !userData.UserId.HasValue;
    }
}
