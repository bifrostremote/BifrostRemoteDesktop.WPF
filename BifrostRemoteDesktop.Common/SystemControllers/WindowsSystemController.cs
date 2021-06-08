using System;

namespace BifrostRemoteDesktop.Common.SystemControllers
{
    public class WindowsSystemController : ISystemController
    {
        private WindowsMouseController _mouseController;
        private WindowsKeyboardController _keyboardController;

        public WindowsSystemController()
        {
            _mouseController = new WindowsMouseController();
            _keyboardController = new WindowsKeyboardController();
        }

        public bool SetMousePosition(double x, double y)
        {
            _mouseController.SetCursorPosition(x, y);
            return true;
        }

        public void SetMouseState()
        {
            throw new NotImplementedException();
        }

        public void PressKey(char key)
        {
            _keyboardController.PressKey(key);
        }

    }
}
