using Spheroid.Geo;
using System;

namespace Spheroid.AR.Server
{
    public interface IUserData
    {
        Guid SessionId { get; }
        Guid? UserId { get; }
        bool IsOnline { get; }
        LatLng? Location { get; }
        Guid? LayerId { get; }
    }
}
