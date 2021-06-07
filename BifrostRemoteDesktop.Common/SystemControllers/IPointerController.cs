using BifrostRemoteDesktop.Common.Models;

namespace BifrostRemoteDesktop.Common.SystemControllers
{
    public interface IPointerController
    {
        bool CanSetCursorPosition { get; }
        void SetCursorPosition(int x, int y);

        bool CanGetCursorPosition { get; }
        LPPoint GetCursorPosition();
    }
}
