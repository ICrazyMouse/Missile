
using Missile.Missile.Api;

namespace Missile.MissileController
{
    interface IMissileController
    {
        void SendMissile(IMissile obj);
        void Start();
        void Stop();
        bool isStarted();
    }
}
