using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SoutenanceIII001.dMiniJeux.cMemory
{
    class Carte
    {
        Texture2D toutesLesFaces;
        public int type;

        Texture2D dos;
        Vector2 position;
        Rectangle rectangle;
        int x_ouDansLeTableau;
        int y_ouDansLeTableau;

        bool estFaceCachee;
        bool estTrouvee;


        public Carte(int newx_ouDansLeTableau, int newy_ouDansLeTableau, Texture2D newDos, Vector2 newPosition, Texture2D newtoutesLesFaces)
        {
            toutesLesFaces = newtoutesLesFaces;
            x_ouDansLeTableau = newx_ouDansLeTableau;
            y_ouDansLeTableau = newy_ouDansLeTableau;
            dos = newDos;
            position = newPosition;
            estFaceCachee = true;
            estTrouvee = false;
        }

        public void Update(ref int combienDePairesATrouver, ref int combienSontVisibles, ref int retournee1_x, ref int retournee1_y, ref int retournee2_x, ref int retournee2_y, ref Carte[,] jeu_cartes)
        {
            if (!estTrouvee)
            {
                rectangle = new Rectangle((int)position.X, (int)position.Y, 200, 200);
                Rectangle mouseRectangle = new Rectangle(GD.mouse.X, GD.mouse.Y, 1, 1);

                if (mouseRectangle.Intersects(rectangle) && GD.mouse.LeftButton == ButtonState.Pressed && estFaceCachee)
                {

                    if (combienSontVisibles == 0)
                    {
                        combienSontVisibles = 1;
                        estFaceCachee = false;
                        retournee1_x = this.x_ouDansLeTableau;
                        retournee1_y = this.y_ouDansLeTableau;
                    }

                    else if (combienSontVisibles == 1)
                    {
                        combienSontVisibles = 2;
                        estFaceCachee = false;
                        retournee2_x = this.x_ouDansLeTableau;
                        retournee2_y = this.y_ouDansLeTableau;
                        if (jeu_cartes[retournee1_x, retournee1_y].type == this.type)
                        {
                            jeu_cartes[retournee1_x, retournee1_y].estTrouvee = true;
                            this.estTrouvee = true;
                            combienDePairesATrouver -= 1;
                        }
                    }

                    else
                    {
                        combienSontVisibles = 0;
                        jeu_cartes[retournee1_x, retournee1_y].estFaceCachee = true;
                        jeu_cartes[retournee2_x, retournee2_y].estFaceCachee = true;
                    }
                }

            }

        }

        public void Draw()
        {
            if (!estTrouvee)
            {
                if (!estFaceCachee)
                    GD.spriteBatch.Draw(toutesLesFaces, rectangle, new Rectangle(type * 300, 0, 300, 300), Color.White);
                else
                    GD.spriteBatch.Draw(dos, rectangle, Color.White);
            }
        }
    }
}
