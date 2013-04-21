using Microsoft.Xna.Framework;

namespace SoutenanceIII001.dSprite.dPerso
{
    class TrucsInteractifs : Sprite // hmmmmmm... les objets ne sont pas des personnages... Renommer cette classe ?
    {
        #region FIELDS

        protected string[,] Tab;
        // Pour le scrolling : position de reference
        protected Vector2 MapPosition;

        #endregion

        #region CONSTRUCTORS
        public TrucsInteractifs(int VieMax, int attaque, float vitesseAttaque, string[,] tab, string asset, Vector2 position_dep, Rectangle position)
            : base(asset, position)
        //          : base(VieMax, attaque, vitesseAttaque, asset, position, tab, position_dep)
        {
            Tab = tab;
        }
        #endregion

        #region METHODS
        public void CalculDepth(Vector2 positionnement)
        {
            LayerDepth = (10 * (positionnement.X - positionnement.Y) + positionnement.X + 9 * positionnement.Y + 8)
                / (10 * (Tab.GetLength(0)) + Tab.GetLength(0) + 8);
        }

        /// <summary>
        /// Dessine dessine un objet interactif
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="i">position i dans le tableau</param>
        /// <param name="j">position j dans le tableau</param>
        /// <param name="ouSurLaTexture">emplacement du sprite de l'objet sur la texture</param>
        void Dessine(int i, int j, Rectangle ouSurLaTexture, Color color) // tout repenser...
        {
            Vector2 pos = new Vector2();
            pos.X = MapPosition.X;
            pos.Y = MapPosition.Y;

            if (j != 0)
            {
                if (j % 2 != 0)
                {
                    pos.X += ((i * 64 + 64 / 2) + (((j - 1) * 64) / 2)) - i * 64 / 2;
                    pos.Y += ((j * 32) / 2) - (i * 32) / 2;
                }
                else
                {
                    pos.X += (i * 64 + ((j * 64) / 2)) - (i * 64) / 2;
                    pos.Y += (((j * 32) / 2)) - (i * 32) / 2;
                }
            }
            else
            {
                pos.X += (i * 64) - (i * 64) / 2;
                pos.Y += ((j * 32) / 2) - (i * 32) / 2;
            }
            pos.X += 32 - (ouSurLaTexture.Width / 2);
            pos.Y += 16 - (ouSurLaTexture.Height);
            pos.X += 333;
            pos.Y += 10;
            CalculDepth(new Vector2(i, j));
            GD.spriteBatch.Draw(Texture, pos, ouSurLaTexture, color, Rotation, Origin, Scale, Effect, LayerDepth);
        }

        //Dessine la MAPD'OBJINT via un tableau

        protected void DessineTableauPot(string[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    switch (tab[i, j])
                    {
                        case "PA":
                            Dessine(i, j, new Rectangle(0, 0, 80, 96), Color.White);
                            break;
                        case "PB":
                            Dessine(i, j, new Rectangle(0, 0, 64, 32), Color.Cyan);
                            break;
                    }
                }
            }
        }

        #endregion

        #region UPDATE & DRAW
        public void Update(Vector2 mapPosition)
        {
            MapPosition = mapPosition;
        }

        public override void Draw()
        {
            DessineTableauPot(Tab);
        }

        #endregion
    }
}
