using DrawingLib.Graphics;
using DrawingLib.Input;
using DrawingLibrary.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShapeLibrary;
using System.Collections.Generic;
namespace Paintdrops;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Screen _screen;
    private CustomMouse _customMouse;
    private MouseState _previousMouseState;
    private MouseState _currentMouseState;
    private List<IShape> _shapeList;



    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {
        _shapeList = new List<IShape>();
        _previousMouseState = Mouse.GetState();
        _currentMouseState = Mouse.GetState();
        RenderTarget2D renderTarget = new RenderTarget2D(GraphicsDevice, 640, 480);
        _screen = new Screen(GraphicsDevice, renderTarget);
        _customMouse = CustomMouse.Instance;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _customMouse.Update();
        //add rectangle
        if (_customMouse.IsRightButtonClicked())
        {
            //check if click happened within bounds
            if (_customMouse.GetScreenPosition(_screen).HasValue)
            {
                Vector2 clickPosition = (Vector2)_customMouse.GetScreenPosition(_screen);
                ShapeLibrary.IRectangle r = ShapeFactory.CreateRectangle();
                _shapeList.Add(r);

            }
        }
        //add circle
        if (_customMouse.IsLeftButtonClicked())
        {
            //check if click happened within bounds
            if (_customMouse.GetScreenPosition(_screen).HasValue)
            {
                Vector2 clickPosition = (Vector2)_customMouse.GetScreenPosition(_screen);
                ShapeLibrary.ICircle c = ShapeFactory.CreateCircle();
                _shapeList.Add(c);

            }
        }
        //clear shapes
        if (_customMouse.IsMiddleButtonClicked())
        {
            //check if click happened within bounds
            if (_customMouse.GetScreenPosition(_screen).HasValue)
            {
                ShapeLibrary.IRectangle r = ShapeFactory.CreateRectangle();

            }
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        RenderTarget2D renderTarget2D = new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        _screen.Set();
        //GraphicsDevice.Clear(_color);
        _spriteBatch.Begin();
        //draw whatever
        _spriteBatch.End();
        _screen.UnSet();

        SpritesRenderer renderer = new SpritesRenderer(GraphicsDevice);
        _screen.Present(renderer);





        base.Draw(gameTime);
    }
}
