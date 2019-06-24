using System;

namespace Spheroid.AR.Server
{
    public static class UserExtensions
    {
        public static Guid UserIdOrSessionId(this User user) =>
            user.UserId.GetValueOrDefault(user.SessionId);

        public static bool IsAnonymous(this User user) =>
            !user.UserId.HasValue;
    }
}
