using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonKIT
{
    public class InputManager
    {
        public static float Vertical { get { return Input.GetAxis("Vertical"); } }  //Variable of vertical controller
        public static float Horizontal { get { return Input.GetAxis("Horizontal"); } } //Variable of Horizontal controller


        public static Vector3 MousePosition { get { return Input.mousePosition; } } //Mouse position

        public static float MouseXPositon //Only X position of the mouse
        {
            get
            {
                float x = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
                return x;
            }
        }

        //List of Controls 
        public static bool Attack { get { return Input.GetButton(InputSettings.AttackKey); } } // Input.GetKey(InputSettings.YourKey);

        public static bool Interaction { get { return Input.GetKeyDown(InputSettings.InteractionKey); } set { } }

        public static bool Pause { get { return Input.GetKeyDown(InputSettings.PauseKey); } set { } }

        public static bool Health { get { return Input.GetKeyDown(InputSettings.HealthKey); } set { } }

    }

    public class InputSettings
    {
        //List of KeyCodes
        public static KeyCode InteractionKey { get { return KeyCode.E; } } //Here you can add or edit control settings
        public static string AttackKey { get { return "Attack"; } } //string for Unity Input system(Edit-Projects settings-Input) 
        public static KeyCode PauseKey { get { return KeyCode.Escape; } }
        public static KeyCode HealthKey { get { return KeyCode.Q; } }
    }
}