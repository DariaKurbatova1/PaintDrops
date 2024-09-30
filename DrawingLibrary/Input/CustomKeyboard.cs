using DrawingLib.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrawingLib.Input
{
    
    public sealed class CustomKeyboard : ICustomKeyboard
    {
        private KeyboardState _previousKeyboardState;
        private KeyboardState _currentKeyboardState;
        private static CustomKeyboard instance = null;
        private CustomKeyboard()
        {
            

            _previousKeyboardState = Keyboard.GetState();
            _currentKeyboardState = Keyboard.GetState();
        }
        public static CustomKeyboard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomKeyboard();
                }
                return instance;
            }
        }

        public bool IsKeyClicked(Keys key)
        {   
            return (_currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key));
        }

        public bool IsKeyDown(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key);
        }

        public void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }
    }
}
