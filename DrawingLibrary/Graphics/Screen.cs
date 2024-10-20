using DrawingLib.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLibrary.Graphics

{
    public class Screen : IScreen
    {

        private float _screenAspectRatio = (640f / 480f);
        private float _windowAscpectRatio;
        private PresentationParameters _presentationParameters;
        private float _sx;
        private float _sy;

        public float sx { get; private set; }
        public float sy { get; private set; }

        private RenderTarget2D _renderTarget;
        private GraphicsDevice _graphicsDevice;

        public GraphicsDevice GraphicsDevice { get { return _graphicsDevice; } }

        public Screen(GraphicsDevice graphicsDevice, RenderTarget2D renderTarget)
        {
            _renderTarget = renderTarget;
            _graphicsDevice = graphicsDevice;
        }
        public int Height => _graphicsDevice.Viewport.Height;

        public int Width => _graphicsDevice.Viewport.Width;

        public Rectangle CalculateDestinationRectangle()
        {
            //get window height and width and calculate window aspect ratio
            float windowHeight = _graphicsDevice.Viewport.Height;
            float windowWidth = _graphicsDevice.Viewport.Width;
            //get window ration
            _windowAscpectRatio = (windowWidth / windowHeight);

            float screenWidth;
            float screenHeight;

            //black lines will be on left and right
            if (_screenAspectRatio < _windowAscpectRatio)
            {
                screenHeight = windowHeight;
                screenWidth = screenHeight * _screenAspectRatio;
                _sx = (windowWidth - screenWidth) / 2;
                _sy = 0;
            }
            //black lines will be on top and bottom
            else
            {
                screenWidth = windowWidth;
                screenHeight = screenWidth / _screenAspectRatio;
                _sx = 0;
                _sy = (windowHeight - screenHeight) / 2;
            }
            Point size = new Point((int)(screenWidth), (int)(screenHeight));
            Point location = new Point((int)(_sx), (int)(_sy));
            return new Rectangle(location, size);
        }

        public void Dispose()
        {
            _renderTarget.Dispose();
        }

        public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering = true)
        {
            spritesRenderer.Begin(true);

            //_graphicsDevice.SetRenderTarget(_renderTarget);


            spritesRenderer.Draw(_renderTarget, CalculateDestinationRectangle(), Color.White);
            spritesRenderer.End();
        }

        public void Set()
        {
            _renderTarget.GraphicsDevice.SetRenderTarget(_renderTarget);
        }

        public void UnSet()
        {
            _renderTarget.GraphicsDevice.SetRenderTarget(null);
        }
    }
}
