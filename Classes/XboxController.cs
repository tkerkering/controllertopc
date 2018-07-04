using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.XInput;



namespace ControllerToPokeOne.Classes
{
    public class XboxController
    {
        int XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE = 7849;
        int XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE = 8689;
        int XINPUT_GAMEPAD_TRIGGER_THRESHOLD = 30;

        public float magnitudeRight = 0;
        public float magnitudeLeft = 0;


        Controller controller;
        Gamepad gamepad;

        public float leftTrigger;               //Hinten Links
        public float rightTrigger;              //Hinten Rechts


        public short[] leftThumb = new short[2];       // 0 = X-Coord ; 1 = Y-Coord
        public short[] rightThumb = new short[2];      // 0 = X-Coord ; 1 = Y-Coord

        public GamepadButtonFlags padButtons;   //GamepadButtons

        bool isConnected = false;
        public bool IsConnected
        {
            get { return isConnected; }
        }

        public XboxController()
        {
            controller = new Controller(UserIndex.One);
            isConnected = controller.IsConnected;
        }

        public XboxController(Controller controllerg)
        {
            controller = controllerg;
        }


        public float normalizedRX = 0;
        public float normalizedRY = 0;
        public float normalizedLX = 0;
        public float normalizedLY = 0;
        public float normalizedMagnitudeLeft;
        public float normalizedMagnitudeRight;
        public void Update()
        {
            if (!IsConnected)
                return;

            gamepad = controller.GetState().Gamepad;

            leftTrigger = gamepad.LeftTrigger;
            rightTrigger = gamepad.RightTrigger;

            padButtons = gamepad.Buttons;

            rightThumb[0] = gamepad.RightThumbX;
            rightThumb[1] = gamepad.RightThumbY;

            leftThumb[0] = gamepad.LeftThumbX;
            leftThumb[1] = gamepad.LeftThumbY;

            //determine how far the controller is pushed
            magnitudeLeft = (float)Math.Sqrt(leftThumb[0] * leftThumb[0] + leftThumb[1] * leftThumb[1]);
            //determine the direction the controller is pushed
            normalizedLX = leftThumb[0] / magnitudeLeft;
            normalizedLY = leftThumb[1] / magnitudeLeft;

            normalizedMagnitudeLeft = 0;

            //check if the controller is outside a circular dead zone
            if (magnitudeLeft > XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE)
            {
                //clip the magnitude at its expected maximum value
                if (magnitudeLeft > 32767) magnitudeLeft = 32767;

                //adjust magnitude relative to the end of the dead zone
                magnitudeLeft -= XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE;

                //optionally normalize the magnitude with respect to its expected range
                //giving a magnitude value of 0.0 to 1.0
                normalizedMagnitudeLeft = magnitudeLeft / (32767 - XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE);
            }
            else //if the controller is in the deadzone zero out the magnitude
            {
                magnitudeLeft = 0.0f;
                normalizedMagnitudeLeft = 0.0f;
            }

            //determine how far the controller is pushed
            magnitudeRight = (float)Math.Sqrt(rightThumb[0] * rightThumb[0] + rightThumb[1] * rightThumb[1]);
            //determine the direction the controller is pushed
            normalizedRX = rightThumb[0] / magnitudeRight;
            normalizedRY = rightThumb[1] / magnitudeRight;

            normalizedMagnitudeRight = 0;

            //check if the controller is outside a circular dead zone
            if (magnitudeRight > XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE)
            {
                //clip the magnitude at its expected maximum value
                if (magnitudeRight > 32767) magnitudeRight = 32767;

                //adjust magnitude relative to the end of the dead zone
                magnitudeRight -= XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE;

                //optionally normalize the magnitude with respect to its expected range
                //giving a magnitude value of 0.0 to 1.0
                normalizedMagnitudeRight = magnitudeRight / (32767 - XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE);
            }
            else //if the controller is in the deadzone zero out the magnitude
            {
                magnitudeRight = 0.0f;
                normalizedMagnitudeRight = 0.0f;
            }
        }
    }
}
