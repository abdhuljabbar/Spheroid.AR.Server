using System;

namespace Spheroid.AR.Server
{
    [Flags]
    public enum ObjectRotationOptions : byte
    {
        None = 0,
        IsMirrored = 0b_0000_0001,
        YAlwaysFollowUser = 0b_0000_0010
    }
}
