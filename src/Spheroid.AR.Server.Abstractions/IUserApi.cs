using System.Collections.Generic;

namespace Spheroid.AR.Server
{
    public interface IUserApi
    {
        IEnumerable<IUserData> GetUsers();
        bool TryGetUserData(User user, out IUserData userData);
        void SetUserStatus(User user, Image? icon, string text);
    }
}
