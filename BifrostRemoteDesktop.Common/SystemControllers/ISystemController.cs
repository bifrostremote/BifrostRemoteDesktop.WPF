namespace BifrostRemoteDesktop.Common.SystemControllers
{
    public interface ISystemController
    {
        bool SetPointerPosition(double x, double y);
        void SetPointerState();
    }
}
