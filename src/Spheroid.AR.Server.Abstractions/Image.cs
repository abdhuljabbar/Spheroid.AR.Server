using System;

namespace Spheroid.AR.Server
{
    public readonly struct Image
    {
        public AssetSource Source { get; }
        public Guid ImageId { get; }

        public Image(AssetSource source, Guid imageId)
        {
            Source = source;
            ImageId = imageId;
        }
    }
}
