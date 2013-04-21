using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoutenanceIII001.dTimer;

namespace SoutenanceIII001.dMoteurs
{
    class Particule
    {
        Random rand = new Random();

        #region FIELDS
        Vector2 Position;
        Rectangle Position_depart;
        string Asset;
        Texture2D Texture;
        Color Couleur;
        Countdown timer;
        int conteur;
        int hauteurmax;
        #endregion

        #region CONSTRUCTOR
        public Particule(int posx, int posy, int hauteur, string asset, Color color)
        {
            Position_depart = new Rectangle(posx, posy, 0, 0);
            Position.X = Position_depart.X;
            Position.Y = Position_depart.Y;
            Asset = asset;
            Couleur = color;
            timer = new Countdown(TimeSpan.FromMilliseconds(rand.Next(7, 20)), Action);
            conteur = rand.Next(-15, 15);
            hauteurmax = hauteur;
        }
        #endregion

        #region LOADCONTENT
        public virtual void LoadContent()
        {
            Texture = GD.content.Load<Texture2D>(Asset);
        }
        #endregion

        #region METHODS
        void Action(object sender, EventArgs e)
        {
            if (conteur > 0)
            {
                Position.X += rand.Next(1, 5);
                conteur--;
            }
            else if (conteur < 0)
            {
                Position.X -= rand.Next(1, 5);
                conteur++;
            }

            else
            {
                conteur = rand.Next(-15, 15);
            }

            if (Position.Y <= rand.Next(0, hauteurmax))
            {
                Position.Y = Position_depart.Y;
                Position.X = Position_depart.X;
            }
            else
            {   // vitesse de déplacement vers le haut
                Position.Y -= rand.Next(1, 7);
            }
        }
        #endregion

        #region UPDATE & DRAW

        // UPDATE
        public virtual void Update()
        {
            timer.Update();
        }

        // DRAW
        public virtual void Draw()
        {
            GD.spriteBatch.Draw(Texture, Position, new Rectangle(0, 0, 3, 4), Couleur);
        }

        #endregion
    }
}
