using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoutenanceIII001.dGameStates;

namespace SoutenanceIII001
{
    public class MainGame : Game
    {
        MainMenu MainMenu;

        public MainGame()
        {
            GD.gameTime = new GameTime();
            GD.GameStateStack = new Stack<GameState>();

            MainMenu = new MainMenu();
            GD.graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            GD.content = Content;

            GD.GameStateStack.Push(MainMenu);
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            GD.spriteBatch = new SpriteBatch(GraphicsDevice);

            // Screenstuff
            GD.graphics.PreferredBackBufferWidth = GD.screenWidth;
            GD.graphics.PreferredBackBufferHeight = GD.screenHeight;
            //graphics.IsFullScreen = true;
            GD.graphics.ApplyChanges();
            IsMouseVisible = true;
            GD.GraphicsDevice = GraphicsDevice;

            GD.GameStateStack.Peek().LoadContent();


        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gametime)
        {
            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();
            /*graphics.PreferredBackBufferHeight = 750;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.ApplyChanges();*/
            GD.gameTime = gametime;
            GD.mouse = Mouse.GetState();
            GD.kbState = Keyboard.GetState();

            GD.GameStateStack.Peek().Update();

            GD.previousmouse = GD.mouse;
            GD.previouskbState = GD.kbState;

            if (GD.mouse.LeftButton == ButtonState.Pressed && GD.kbState.IsKeyDown(Keys.Enter))
                GD.gameTime = gametime;


            base.Update(GD.gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GD.spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            GD.GameStateStack.Peek().Draw();
            GD.game = this;
            GD.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
