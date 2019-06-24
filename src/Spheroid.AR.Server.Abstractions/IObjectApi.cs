using Spheroid.Geo;
using System;

namespace Spheroid.AR.Server
{
    public interface IObjectApi
    {
        void DeleteAllObjects(User? user);
        void DeleteObject(Guid objectId, User? user);
        void PlayObjectAnimation(Guid objectId, string animationId, string stateId, User? user);
        void PlayObjectAnimationAndDelete(Guid objectId, string animationId, User? user);
        void RenderObject(Guid objectId, User? user);
        void SetObjectOnClickPlayAnimation(Guid objectId, string animationId, string stateId, User? user);
        void SetObjectGeoPosition(Guid objectId, LatLng location, Height height, User? user);
        void SetObjectModel(Guid objectId, Model model, User? user);
        void SetObjectRotation(Guid objectId, ObjectRotationOptions options, Vector3 rotation, User? user);
        void SetObjectScale(Guid objectId, float scale, User? user);
        void SetObjectScenePosition(Guid objectId, Vector3 position, HeightOptions heightOptions, User? user);
        void SetObjectSize(Guid objectId, float size, User? user);
        void SetObjectState(Guid objectId, string stateId, User? user);
        void SetObjectViewDistance(Guid objectId, float viewDistance, User? user);
    }
}
