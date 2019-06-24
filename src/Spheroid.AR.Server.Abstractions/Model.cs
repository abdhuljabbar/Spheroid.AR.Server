using System;

namespace Spheroid.AR.Server
{
    public readonly struct Model
    {
        public AssetSource Source { get; }
        public Guid ModelId { get; }

        public Model(AssetSource source, Guid modelId)
        {
            Source = source;
            ModelId = modelId;
        }
    }
}
