using Microsoft.Xna.Framework;
using SoutenanceIII001.dSprite;
using Microsoft.Xna.Framework.Graphics;

namespace SoutenanceIII001.dGameStates
{
    class Options : GameState
    {
        Sprite stringSelect;
        cButton bMainMenu;
        Texture2D bTexture_MainMen;

        public override void Initialize() { }

        public override void LoadContent()
        {
            bTexture_MainMen = GD.content.Load<Texture2D>(@"Sprites\sBoutonsMainMen\ButtonMainMen");
            bMainMenu = new cButton(bTexture_MainMen, new Rectangle(0, 39 * 4, 144, 38));
            bMainMenu.setPosition(new Vector2(0, 0));

            stringSelect = new Sprite(@"Sprites\selectionnersonggame", new Rectangle(GD.screenWidth - 494 - 30, GD.screenHeight - 34 * 5 - 15, 494, 34));
            stringSelect.LoadContent();
        }

        public override void Update()
        {
            if (bMainMenu.isClicked)
                GD.GameStateStack.Pop();
            bMainMenu.Update();
            // if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            // {
            //     graphics.IsFullScreen = true;
            // }
            // Lecteur musique
            GD.lecteurmus.Update(1);
        }

        public override void Draw()
        {
            bMainMenu.Draw();
            // Slect song
            stringSelect.Draw();
            // Lecteur musique
            GD.lecteurmus.Draw(1);


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
    }
}
