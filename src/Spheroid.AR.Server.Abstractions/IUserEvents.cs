using Spheroid.Geo;
using System;

namespace Spheroid.AR.Server
{
    public interface IUserEvents
    {
        void UserCameraPosition(User user, Vector3 position, Vector3 rotation);
        void UserLayer(User user, Guid layerId);
        void UserLocation(User user, LatLng location);
        void UserOffline(User user);
        void UserOnline(User user);
    }
}
