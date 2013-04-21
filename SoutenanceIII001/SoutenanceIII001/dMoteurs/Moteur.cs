using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SoutenanceIII001.dMoteurs
{
    class Moteur
    {

        #region FIELDS
        List<Particule> Particules = new List<Particule>();
        Random rand = new Random();
        #endregion

        #region CONSTRUCTOR
        public Moteur(int nombre, int x, int y, int hauteur)
        {
            for (int i = 0; i < nombre; i++)
            {
                Particules.Add(new Particule(rand.Next(x, 1280), rand.Next(y, 800), hauteur, "MainMen_background800x1280", Color.Black));
            }
        }
        #endregion

        #region LOADCONTENT
        public virtual void LoadContent()
        {
            foreach (Particule particule in Particules)
                particule.LoadContent(); // à optimiser : la texture est la même pour toutes particules

        }
        #endregion

        #region METHODS
        #endregion

        #region UPDATE & DRAW
        public virtual void Update()
        {
            foreach (Particule particule in Particules)
                particule.Update();
        }

        public virtual void Draw()
        {
            foreach (Particule particule in Particules)
                particule.Draw();
        }
        #endregion

    }
    }
