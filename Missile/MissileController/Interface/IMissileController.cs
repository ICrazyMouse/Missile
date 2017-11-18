
using MissileText.Missile.Api;

namespace MissileText.MissileController
{
    interface IMissileController
    {
        void SendMissile(IMissile obj);
        void Start();
        void Stop();
        bool isStarted();
    }
}
