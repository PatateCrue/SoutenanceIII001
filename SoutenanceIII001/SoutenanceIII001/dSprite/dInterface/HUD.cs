using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SoutenanceIII001.dSprite.dInterface
{
    class HUD : Interface
    {
        #region FIELDS

        SpriteFont spfont;
        private Texture2D barre;
        private Vector2 vec_barre;
        string _Asset;
        string Texte;

        #endregion

        #region CONSTRUCTORS

        public HUD(string asset, Rectangle position, Vector2 position_dep, string nomBarre)
            : base(asset, position, position_dep)
        {
            _Asset = asset;
            vec_barre = position_dep;
            Position = position;
            Texte = nomBarre;
        }
        #endregion

        #region METHODS
        public override void LoadContent()
        {
            base.LoadContent();

            barre = GD.content.Load<Texture2D>(_Asset);
            spfont = GD.content.Load<SpriteFont>("SpriteFont1");
        }


        #endregion

        #region UPDATE
        public override void Update()
        {
            if (GD.kbState.IsKeyDown(Keys.A))
            {
                Position.Width -= 5;
            }

            if (GD.kbState.IsKeyDown(Keys.B))
            {
                Position.Width += 5;
            }
            base.Update();
        }

        #endregion

        #region DRAW

        public override void Draw()
        {
            for (int i = 0; i <= Position.Width; i++)
            {
                if (i != 0)
                    vec_barre.X += 32;
                GD.spriteBatch.Draw(barre, Position, new Rectangle(0, 0, barre.Width, barre.Height), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
            }
            base.Draw();
            GD.spriteBatch.DrawString(spfont, Texte, new Vector2(Position.X - (Texte.Length * 20), Position.Y), Color.White);
        }

        #endregion
    }
}
