using DrawingLib.Graphics;
using DrawingLib.Input;
using DrawingLibrary.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShapeLibrary;
using System.Collections.Generic;
using PaintDropSimulation;
using System;
namespace Paintdrops;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    //private SpriteBatch _spriteBatch;
    private ShapesRenderer _shapesRenderer;
    private Screen _screen;
    private CustomMouse _customMouse;
    private MouseState _previousMouseState;
    private MouseState _currentMouseState;
    private List<IShape> _shapeList;
    private PaintDropSimulation.Surface _surface;
    //private List<IPaintDrop> _paintDropList;


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
        _surface = new Surface(640, 480);


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _shapesRenderer = new ShapesRenderer(GraphicsDevice);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _customMouse.Update();
        //clear shapes
        if (_customMouse.IsRightButtonClicked())
        {
            //check if click happened within bounds
            if (_customMouse.GetScreenPosition(_screen).HasValue)
            {
                _shapeList.Clear();
                _surface.Drops.Clear();

            }
        }
        //add circle
        if (_customMouse.IsLeftButtonClicked())
        {
            //check if click happened within bounds
            if (_customMouse.GetScreenPosition(_screen).HasValue)
            {
                Vector2 clickPosition = (Vector2)_customMouse.GetScreenPosition(_screen);
                //Colour colour = new Colour(240, 132, 207);
                //create random colour
                Random rnd = new Random();
                int red = rnd.Next(1, 256);
                int green = rnd.Next(1, 256);
                int blue = rnd.Next(1, 256); 
                Colour colour = new Colour(red, green, blue);
                Circle r = new Circle(clickPosition.X, clickPosition.Y, 40, colour);
                _shapeList.Add(r);
                PaintDrop p = new PaintDrop(r);
                _surface.AddPaintDrop(p);

            }
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        
        _screen.Set();
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _shapesRenderer.Begin();

        /*foreach (IShape shape in _shapeList)
        {
            _shapesRenderer.DrawShape(shape);

        }*/
           foreach (IPaintDrop drop in _surface.Drops)
           {
                _shapesRenderer.DrawShape(drop.Circle);

           }
        

        _shapesRenderer.End();
        _screen.UnSet();

        SpritesRenderer renderer = new SpritesRenderer(GraphicsDevice);
        _screen.Present(renderer);






        base.Draw(gameTime);
    }
}
