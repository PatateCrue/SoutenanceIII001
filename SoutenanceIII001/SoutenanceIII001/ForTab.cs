using System;
using Microsoft.Xna.Framework;
using SoutenanceIII001.dSprite.dPerso;

namespace SoutenanceIII001
{
    class ForTab
    {
        public static void RandomlyFillTabPot(ref string[,] tab, int nb)
        {
            Random rnd = new Random();
            while (nb > 0)
            {
                int x = rnd.Next(0, tab.GetLength(0));
                int y = rnd.Next(0, tab.GetLength(1));

                int generateur = rnd.Next(0, 20);
                if (generateur == 2 || generateur == 1)
                {
                    tab[x, y] = "PA";
                    nb--;
                }
            }
        }
        public static void RandomlyFillTabMob(ref Ennemi[,] tab, int nb)
        {
            Random rnd = new Random();
            while (nb > 0)
            {
                int x = rnd.Next(0, tab.GetLength(0));
                int y = rnd.Next(0, tab.GetLength(1));

                int generateur = rnd.Next(0, 20);
                if (generateur == 2 || generateur == 1)
                {
                    tab[x, y] = new Ennemi(Ennemi.TypeEnnemi.AquaTank, 50, 20, (float)0.7, tab, @"Sprites\sPersonnage\80x96", new Vector2(0, 0), new Rectangle(0, 0, 80, 96));
                    nb--;
                }
            }
        }
    }
}
