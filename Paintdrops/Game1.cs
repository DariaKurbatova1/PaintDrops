using DrawingLib.Graphics;
using DrawingLib.Input;
using DrawingLibrary.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Paintdrops;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Screen _screen;
    private CustomMouse _customMouse;
    private MouseState _previousMouseState;
    private MouseState _currentMouseState;




    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {

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
        if (_customMouse.IsLeftButtonClicked())
        {
            //check if click happened within bounds
            if (_customMouse.GetScreenPosition(_screen).HasValue)
            {
                
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
