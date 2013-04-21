using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoutenanceIII001.dGameStates
{
    class Credits : GameState
    {
        cButton bMainMenu;
        Texture2D bTexture_MainMen;

        public override void Initialize() { }

        public override void LoadContent()
        {
            bTexture_MainMen = GD.content.Load<Texture2D>(@"Sprites\sBoutonsMainMen\ButtonMainMen");
            bMainMenu = new cButton(bTexture_MainMen, new Rectangle(0, 39 * 4, 144, 38));
            bMainMenu.setPosition(new Vector2(0, 0));
        }

        public override void Update()
        {
            if (bMainMenu.isClicked)
                GD.GameStateStack.Pop();
            bMainMenu.Update();
        }

        public override void Draw()
        {
            bMainMenu.Draw();


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
