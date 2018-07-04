using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using SlimDX.XInput;

namespace ControllerToPokeOne.Classes
{
    public class ConvertInput
    {
        InputSimulator inputsimulate;
        Cursor Cursor;
        GamepadButtonFlags oldstate;
    
        public ConvertInput()
        {
            inputsimulate = new InputSimulator();
        }

        public void ConvertAllInput(XboxController controller)
        {
            if(controller.magnitudeLeft != 0)       //linker Stick wird bewegt, beweg mal die Figur mit
            {
                if (controller.normalizedLX >= 0.6 && controller.normalizedLY <= 0.5)
                    sendInputToKeyboard(0);
                else if (controller.normalizedLX <= -0.5 && controller.normalizedLY >= -0.49)
                    sendInputToKeyboard(1);
                else if (controller.normalizedLX >= -0.49 && controller.normalizedLY <= -0.5)
                    sendInputToKeyboard(2);
                else if (controller.normalizedLX <= 0.49 && controller.normalizedLY >= 0.5)
                    sendInputToKeyboard(3);
            }

            if(controller.magnitudeRight != 0)      //rechter Stick wird bewegt beweg mal die Maus mit
                MoveCursor(controller.normalizedRX, controller.normalizedRY, controller.normalizedMagnitudeRight);


            if (controller.padButtons == GamepadButtonFlags.LeftShoulder && oldstate != GamepadButtonFlags.LeftShoulder)
                inputsimulate.Mouse.LeftButtonDown();
            else if (oldstate == GamepadButtonFlags.LeftShoulder && controller.padButtons != GamepadButtonFlags.LeftShoulder)
                inputsimulate.Mouse.LeftButtonUp();

            if (controller.padButtons == GamepadButtonFlags.RightShoulder && oldstate != GamepadButtonFlags.RightShoulder)
                inputsimulate.Mouse.RightButtonDown();
            else if(oldstate == GamepadButtonFlags.RightShoulder && controller.padButtons != GamepadButtonFlags.RightShoulder)
                inputsimulate.Mouse.RightButtonUp();

            //if (controller.padButtons == GamepadButtonFlags.RightShoulder)
            //    inputsimulate.Mouse.RightButtonClick();

            if (controller.padButtons == GamepadButtonFlags.LeftThumb && oldstate != GamepadButtonFlags.LeftThumb)
                inputsimulate.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
            else if (oldstate == GamepadButtonFlags.LeftThumb && controller.padButtons != GamepadButtonFlags.LeftThumb)
                inputsimulate.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);

            //if (controller.padButtons == GamepadButtonFlags.A)
            //    inputsimulate.Keyboard.KeyPress(VirtualKeyCode.SPACE);

            if (controller.padButtons == GamepadButtonFlags.A && oldstate != GamepadButtonFlags.A)
                inputsimulate.Keyboard.KeyDown(VirtualKeyCode.SPACE);
            else if (oldstate == GamepadButtonFlags.A && controller.padButtons != GamepadButtonFlags.A)
                inputsimulate.Keyboard.KeyUp(VirtualKeyCode.SPACE);

            if (controller.padButtons == GamepadButtonFlags.B && oldstate != GamepadButtonFlags.B)
                inputsimulate.Mouse.LeftButtonDown();
            else if (oldstate == GamepadButtonFlags.B && controller.padButtons != GamepadButtonFlags.B)
                inputsimulate.Mouse.LeftButtonUp();

            oldstate = controller.padButtons;
        }

        public void sendInputToKeyboard(int WhichKey)
        {
            switch (WhichKey)
            {
                case 0:
                    inputsimulate.Keyboard.KeyPress(VirtualKeyCode.VK_D);
                    break;
                case 1:
                    inputsimulate.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                    break;
                case 2:
                    inputsimulate.Keyboard.KeyPress(VirtualKeyCode.VK_S);
                    break;
                case 3:
                    inputsimulate.Keyboard.KeyPress(VirtualKeyCode.VK_W);
                    break;
            }
        }

        private void MoveCursor(float x, float y, float magnitude)
        {
            int xinint;
            int yinint;

            x = x * (magnitude*15);
            y = y * (magnitude*15);

            try
            {
                xinint = Convert.ToInt32(x);
                yinint = Convert.ToInt32(y);
            }
            catch
            {
                return;
            }

            yinint = yinint * (-1);     //controller ist sonst reversed

            //if (xinint == 1)
            //    xinint = xinint + 6;    
            //else if (xinint == -1)
            //    xinint = xinint - 6;

            //if (yinint == 1)
            //    yinint = yinint + 6;
            //else if (yinint == -1)
            //    yinint = yinint - 6;

            this.Cursor = new Cursor(Cursor.Current.Handle);

            Cursor.Position = new Point(Cursor.Position.X + xinint, Cursor.Position.Y + yinint);
        }

    }
}
