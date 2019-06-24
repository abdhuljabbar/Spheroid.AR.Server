using Spheroid.Geo;

namespace Spheroid.AR.Server
{
    public static class BoundsExtensions
    {
        public static bool Intersects(this Bounds bounds, LatLng location) =>
            location.Lat >= bounds.Southwest.Lat && location.Lat <= bounds.Northeast.Lat &&
            location.Lng >= bounds.Southwest.Lng && location.Lng <= bounds.Northeast.Lng;
    }
}
