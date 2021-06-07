using System;

namespace BifrostRemoteDesktop.Common.SystemControllers
{
    public class WindowsSystemController : ISystemController
    {
        private WindowsMouseController _pointer;

        public WindowsSystemController()
        {
            _pointer = new WindowsMouseController();
        }

        public bool SetPointerPosition(double x, double y)
        {
            _pointer.SetCursorPosition(x, y);
            return true;
        }

        public void SetPointerState()
        {
            throw new NotImplementedException();
        }

    }
}
