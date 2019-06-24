using Spheroid.Geo;
using System;

namespace Spheroid.AR.Server
{
    public interface IObjectEvents
    {
        void ObjectModel(User user, Guid objectId, AssetSource modelSource, Guid modelId);
        void ObjectClick(User user, Guid objectId);
        void RenderObjects(User user, Bounds bounds);
    }
}
