using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoutenanceIII001.dGameStates;
using SoutenanceIII001.dMusic;

namespace SoutenanceIII001
{
    public static class GD //Global Data, les données utilisées partout
    {
        //Screen Adjustements
        public static int screenWidth = 1280, screenHeight = 800;

        public static ContentManager content;

        public static SelectionPlayer lecteurmus;

        public static GraphicsDeviceManager graphics;

        public static SpriteBatch spriteBatch;

        public static Game game;

        public static MouseState mouse, previousmouse;

        public static KeyboardState kbState, previouskbState;

        public static GameTime gameTime;

        public static Stack<GameState> GameStateStack;

        public static GraphicsDevice GraphicsDevice;

    }
}
