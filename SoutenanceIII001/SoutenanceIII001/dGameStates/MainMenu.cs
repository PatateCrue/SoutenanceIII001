using SoutenanceIII001.dMoteurs;
using Microsoft.Xna.Framework.Graphics;
using SoutenanceIII001.dSprite;
using Microsoft.Xna.Framework;
using SoutenanceIII001.dMusic;

namespace SoutenanceIII001.dGameStates
{
    public class MainMenu : GameState
    {

        #region FIELDS

        // Boutons du menu
        cButton bPlay;
        cButton bOptions;
        cButton bExit;
        cButton bCredits;

        // Textures
        Texture2D bTexture_MainMen;

        Sprite BackgroundMen;

        // Moteur part
        Moteur moteur1;

        #endregion

        #region CONSTRUCTOR

        public MainMenu()
        {

            #region TESTS
            // Lecteur musique
            GD.lecteurmus = new SelectionPlayer(5, new string[] { @"Sons\sMusique\song1", @"Sons\sMusique\song2", @"Sons\sMusique\song3", @"Sons\sMusique\song4", @"Sons\sMusique\song5" });
            // Moteur part
            moteur1 = new Moteur(250, 0, 500, 10);

            #endregion

        }

        public override void Initialize() { }
        #endregion

        #region LOADCONTENT
        public override void LoadContent()
        {
            bTexture_MainMen = GD.content.Load<Texture2D>(@"Sprites\sBoutonsMainMen\ButtonMainMen");
            BackgroundMen = new Sprite(@"MainMen_background800x1280", new Rectangle(0, 0, GD.screenWidth, GD.screenHeight));
            BackgroundMen.LoadContent();
            BackgroundMen.LayerDepth = 1;

            Vector2 Position_boutt = new Vector2(GD.screenWidth / 12, GD.screenHeight / 2);
            #region Bouttons du menu
            bPlay = new cButton(bTexture_MainMen, new Rectangle(0, 0, 144, 38));
            bPlay.setPosition(Position_boutt);
            bOptions = new cButton(bTexture_MainMen, new Rectangle(0, 39 * 1, 144, 38));
            bOptions.setPosition(new Vector2(Position_boutt.X, Position_boutt.Y + 75));
            bCredits = new cButton(bTexture_MainMen, new Rectangle(0, 39 * 2, 144, 38));
            bCredits.setPosition(new Vector2(Position_boutt.X, Position_boutt.Y + 150));
            bExit = new cButton(bTexture_MainMen, new Rectangle(0, 39 * 3, 144, 38));
            bExit.setPosition(new Vector2(Position_boutt.X, Position_boutt.Y + 225));
            #endregion

            #region TESTS
            // Moteur part
            moteur1.LoadContent();
            // Lecteur musique
            GD.lecteurmus.LoadContent();
            #endregion
        }
        #endregion


        #region UPDATE & DRAW
        public override void Update()
        {
            bPlay.Update();
            bOptions.Update();
            bCredits.Update();
            bExit.Update();
            if (bPlay.isClicked)
            {
                Playing playing = new Playing();
                playing.LoadContent();
                GD.GameStateStack.Push(playing);
            }
            if (bOptions.isClicked)
            {
                Options options = new Options();
                options.LoadContent();
                GD.GameStateStack.Push(options);
            }
            if (bCredits.isClicked)
            {
                Credits credits = new Credits();
                credits.LoadContent();
                GD.GameStateStack.Push(credits);
            }
            if (bExit.isClicked)
                GD.game.Exit();

            // Moteur
            moteur1.Update();
            // Lecteur musique
            GD.lecteurmus.Update(0);



        }

        public override void Draw()
        {
            BackgroundMen.Draw();
            bPlay.Draw();
            bOptions.Draw();
            bCredits.Draw();
            bExit.Draw();
            // moteur
            moteur1.Draw();
            // Lecteur musique
            GD.lecteurmus.Draw(0);

            //Ce qu'il y a ci-dessous sert juste à vérifier visuellement si les empilements et les dépilements se passent comme prévu
            //A mettre sur tous les écrans pour bêtre sûr
            if (GD.GameStateStack.Count == 1)
                GD.spriteBatch.Draw(bTexture_MainMen, new Rectangle(0, 0, 30, 30), Color.Red);
            if (GD.GameStateStack.Count == 2)
                GD.spriteBatch.Draw(bTexture_MainMen, new Rectangle(0, 0, 30, 30), Color.Yellow);
            if (GD.GameStateStack.Count == 3)
                GD.spriteBatch.Draw(bTexture_MainMen, new Rectangle(0, 0, 30, 30), Color.Green);
            if (GD.GameStateStack.Count > 3)
                GD.spriteBatch.Draw(bTexture_MainMen, new Rectangle(0, 0, 30, 30), Color.White);

        }
        #endregion

    }
}
