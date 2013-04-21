using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoutenanceIII001.dGameStates
{
    class Pause : GameState
    {
        cButton bPlay;
        Texture2D bTexture_MainMen;

        public override void Initialize() { }

        public override void LoadContent()
        {
            bTexture_MainMen = GD.content.Load<Texture2D>(@"Sprites\sBoutonsMainMen\ButtonMainMen");

            bPlay = new cButton(bTexture_MainMen, new Rectangle(0, 0, 144, 38));
            bPlay.setPosition(new Vector2(GD.screenWidth / 2 - 144 / 2, GD.screenHeight / 2 - 38 / 2));

        }

        public override void Update()
        {
            bPlay.Update();
            if (bPlay.isClicked)
                GD.GameStateStack.Pop();
        }

        public override void Draw()
        {
            bPlay.Draw();

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
