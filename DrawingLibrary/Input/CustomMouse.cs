using DrawingLib.Graphics;
using DrawingLib.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLib.Input
{
    public class CustomMouse : ICustomMouse
    {
        private MouseState _previousMouseState;
        private MouseState _currentMouseState;
        private GraphicsDevice _graphicsDevice;
        private static CustomMouse instance = null;
        private CustomMouse()
        {
            _previousMouseState = Mouse.GetState();
            _currentMouseState = Mouse.GetState();
        }
        public static CustomMouse Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomMouse();
                }
                return instance;
            }
        }
        public Point WindowPosition => new Point(_currentMouseState.X, _currentMouseState.Y);

        public Vector2? GetScreenPosition(IScreen screen)
        {
            Rectangle rectangle = screen.CalculateDestinationRectangle();
            
            Point size = rectangle.Size;
            Point location = rectangle.Location;

            float screenX = (_currentMouseState.X - location.X) * 640f / size.X;
            float screenY = (_currentMouseState.Y - location.Y) * 480f / size.Y;

            //check if value not in screen bounds
            if (screenX > 640 || screenY > 480)
            {
                return null;
            }

            
            return new Vector2(screenX, screenY);

        }

        public bool IsLeftButtonClicked()
        {
            return (_currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released);
        }

        public bool IsLeftButtonDown()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftButtonUp()
        {
            return _currentMouseState.LeftButton == ButtonState.Released;
        }

        public bool IsMiddleButtonClicked()
        {
            return (_currentMouseState.MiddleButton == ButtonState.Pressed && _previousMouseState.MiddleButton == ButtonState.Released);
        }

        public bool IsMiddleButtonDown()
        {
            return _currentMouseState.MiddleButton == ButtonState.Pressed;
        }

        public bool IsRightButtonClicked()
        {
            return (_currentMouseState.RightButton == ButtonState.Pressed && _previousMouseState.RightButton == ButtonState.Released);
        }

        public bool IsRightButtonDown()
        {
            return _currentMouseState.RightButton == ButtonState.Pressed;
        }

        public void Update()
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
        }
    }
}
