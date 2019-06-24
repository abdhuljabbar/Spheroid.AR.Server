using System;

namespace Spheroid.AR.Server
{
    public readonly struct User
    {
        public Guid SessionId { get; }
        public Guid? UserId { get; }

        public User(Guid sessionId, Guid? userId)
        {
            SessionId = sessionId;
            UserId = userId;
        }
    }
}
