namespace BifrostRemoteDesktop.Common.SystemControllers
{
    public interface ISystemController
    {
        bool SetMousePosition(double x, double y);
        void SetMouseState();
    }
}
