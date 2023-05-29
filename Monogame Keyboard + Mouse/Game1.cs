using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Keyboard___Mouse
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D pacRTexture;
        Texture2D pacLTexture;
        Texture2D pacDTexture;
        Texture2D pacUTexture;
        Texture2D pacSTexture;
        Texture2D pacTexture;
        Rectangle pacLocation;
        KeyboardState keyboardState;
        MouseState mouseState;

        Vector2 pacSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            pacLocation = new Rectangle(10, 10, 75, 75);
            pacSpeed = new Vector2(0, 0);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pacRTexture = Content.Load<Texture2D>("PacRight");
            pacLTexture = Content.Load<Texture2D>("PacLeft");
            pacDTexture = Content.Load<Texture2D>("Pacdown");
            pacUTexture = Content.Load<Texture2D>("PacUp");
            pacSTexture = Content.Load<Texture2D>("pacSleep");
            pacTexture = pacSTexture;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            pacSpeed.X = 0;
            pacSpeed.Y = 0;

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacSpeed.Y += -2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacSpeed.Y += 2;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacSpeed.X += 2; 
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacSpeed.X += -2;
            }

            pacLocation.X += (int)pacSpeed.X;
            pacLocation.Y += (int)pacSpeed.Y;

            if (pacSpeed.X > 0)
                pacTexture = pacRTexture;
            if (pacSpeed.X < 0)
                pacTexture = pacLTexture;
            if (pacSpeed.Y > 0)
                pacTexture = pacDTexture;
            if (pacSpeed.Y < 0)
                pacTexture = pacUTexture;
            if (pacLocation.Top > 500)
            {
                pacLocation = new Rectangle(pacLocation.X, -75, 75, 75);
            }
            if (pacLocation.Bottom < 0)
            {
                pacLocation = new Rectangle(pacLocation.X, 495, 75, 75);
            }
            if (pacLocation.Right < 0)
            {
                pacLocation = new Rectangle(800, pacLocation.Y, 75, 75);
            }
            if (pacLocation.Left > 800)
            {
                pacLocation = new Rectangle(-75, pacLocation.Y, 75, 75);
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                pacLocation = new Rectangle(mouseState.X, mouseState.Y, 75, 75);
            }




            //if (mouseState.ScrollWheelValue)
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);
       
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}