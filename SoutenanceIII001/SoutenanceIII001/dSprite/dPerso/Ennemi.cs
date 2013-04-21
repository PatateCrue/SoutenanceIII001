using System;
using Microsoft.Xna.Framework;

namespace SoutenanceIII001.dSprite.dPerso
{
    class TabEnnemi
    {
        Ennemi[,] _tabmob;

        public TabEnnemi(int length0, int length1)
        {
            _tabmob = new Ennemi[length0, length1];

            for (int i = 0; i < length0; i++)
                for (int j = 0; j < length1; j++)
                    _tabmob[i, j] = default(Ennemi);

        }

        public void RandomlyFillTabMob(int nb)
        {
            Random rnd = new Random();
            while (nb > 0)
            {
                int x = rnd.Next(0, this._tabmob.GetLength(0));
                int y = rnd.Next(0, this._tabmob.GetLength(1));

                int generateur = rnd.Next(0, 20);
                if (generateur == 2 || generateur == 1)
                {
                    _tabmob[x, y] = new Ennemi(Ennemi.TypeEnnemi.AquaTank, 50, 20, (float)0.7, this._tabmob, @"Sprites\sPersonnage\80x96", new Vector2(0, 0), new Rectangle(0, 0, 80, 96));
                    nb--;
                }

            }
        }
    }
    class Ennemi : Personnage
    {
        public enum TypeEnnemi
        {
            AquaTank, Monkey,
        }

        #region FIELDS
        TypeEnnemi type;
        #endregion

        /* les trucs communs entre ennemi et joueur :
          * - vie
          * - attaques
          * - tableau d'objinter
          * - position (x,y) à checker si on veut bouger
          * 
         */
        #region CONSTRUCTOR

        public Ennemi(TypeEnnemi type, int VieMax, int attaque, float vitesseAttaque, Ennemi[,] tab, string asset, Vector2 position_dep, Rectangle position)
            : base(VieMax, attaque, vitesseAttaque, asset, position, tab, position_dep)
        {
            this.type = type;
        }

        #endregion


        #region METHODS
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

        protected void DessineTableauMob(Ennemi[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
                for (int j = 0; j < tab.GetLength(1); j++)
                    if (tab[i, j] != default(Ennemi))
                        switch (tab[i, j].type)
                        {
                            case TypeEnnemi.Monkey:
                                Dessine(i, j, new Rectangle(0, 0, 80, 96), Color.White);
                                break;
                            case TypeEnnemi.AquaTank:
                                Dessine(i, j, new Rectangle(0, 0, 80, 96), Color.Cyan);
                                break;
                        }
        }

        #endregion

        #region UPDATE & DRAW
        public new void Update(Vector2 mapPosition)
        {
            base.Update();
            MapPosition = mapPosition;
        }

        public override void Draw()
        {
            base.Draw();
            DessineTableauMob(Tab);
        }
        #endregion
    }
}
/* Constuction des ennemis:
 * Dans un tableau à deux dimensions
 
 On a une position x,y pour chaque ennemi ainsi que des caractéristiques
 
 * Une seule texture pour tous les ennemis
 * RANDOM ?
 * si !random ;
 *      - on choisit le nombre de chaque espèce d'ennemi qu'on veut générer
 *      - on les instancie chacun
 *      - on fillrandom la tab des ennemis (ainsi leur position x,y dans le tableau est aléatoire
 *      - on update et draw foreach
 *      
 * Pour le UPDATE :
 * DEPLACEMENT
 * Tous les _vie / VitesseAtt secondes (lawl), on random un int. Si int % kekchose == autchose,
 * le mob se déplace dans une direction rand aussi, sinon, il reste sur place
 * Pour certains mobs, si le joueur est pas trop loin et qu'il n'y a pas d'obstacle, il peut venir le manger
 * Il ne peut pas se déplacer sur une case déjà occupée (sauf celle du joueur ?)
 * ATTAQUE
 * Si le joueur est devant(sur?) le mob, il a *biiiiiiiiip* secondes avant d'être attaqué. 
 * Ensuite, le mob l'attaque toutes les _VitesseAtt secondes si le joueur ne bouge pas
 * MORT
 * Si il n'a plus de vie, il disparait du tableau (et peut faire apparaître un truc dans onjpassant ?)
 * 
 * Les caractéristiques de chaque mob peuvent être modifiée
 * 
 */