using System;
using Microsoft.Xna.Framework.Input;
using SoutenanceIII001.dMiniJeux.cMemory;
using SoutenanceIII001.dMiniJeux.cRapidityNecessity;

namespace SoutenanceIII001.dSprite.dPerso
{
    class InteractCases
    {
        // Répertorie les trucs qui se passent lorsqu'on interagit avec certaines cases (pour les tabmob et les objinterac)
        // case avec un nombre = case passante
        // case avec des lettres = case bloquante

        // méthodes à peut être mettre directement dans la classe Joueur


        #region SWITCHES
        public static void switchLaCaseBloquante_obj(ref string laCase)
        {
            switch (laCase)
            {

                #region ébauche de code qui sert à rien
                case "P": // POT->NON
                    laCase = sePasseunTrucPOT(laCase);
                    break;
                case "C": // CAISSE
                    laCase = sePasseunTrucCAISSE(laCase);
                    break;
                #endregion

                case "PB": // POT VIDE
                    laCase = sePasseunTrucPOTVIDE();
                    break;
            }
        }

        public static void switchLaCaseBloquante_mob(ref Ennemi monstre) // surement différent des obj...
        {

            if (monstre!=default(Ennemi))
            {
                switch (monstre.Vie)
                {
                    case 0: // monstres
                        monstre = sePasseunTrucMONSTRE();
                        break;
                    default:
                        monstre.Vie-=1;
                        break;
                } 
            }
        }

        public static void switchLaCasePassante_obj(ref string laCase)
        {
            int seca;
            if (Int32.TryParse(laCase, out seca)) // on switche seulement si la case contient bien un int (== case passante)
            {
                switch (seca)
                {
                    case 1: // EAU : on gagne de la mana apparemment
                        laCase = sePasseunTrucEAU();
                        break;
                    case 3: // CACAHUETE : on gagne de la vie et de la mana
                        laCase = sePasseunTrucCACA();
                        break;
                    case 9: // SALLE 
                        sePasseunTrucSALLE();
                        break;
                    case 10: // MEMORY
                        if (GD.kbState.IsKeyDown(Keys.Enter) && GD.previouskbState.IsKeyUp(Keys.Enter))
                            sePasseunTrucMemory();
                        break;
                    case 11: // RAPIDITE 
                        if (GD.kbState.IsKeyDown(Keys.Enter) && GD.previouskbState.IsKeyUp(Keys.Enter))
                            sePasseunTrucRapidityNecessity();
                        break;
                }
            }
        }
        #endregion

        #region CASES
        #region Cases bloquantes
        // POT
        static string sePasseunTrucPOT(string laCase) // si un truc apparait, on peut le choper
        {
            /**/
            Random rand = new Random();
            int objet = rand.Next(0, 42);
            if (objet % 2 == 0)
                objet = 0; // vide
            else if (objet % 3 == 0)
                objet = 1; // eau
            else if (objet % 3 == 1)
                objet = 2; // mana
            return ("" + objet);
        }
        // CAISSE
        static string sePasseunTrucCAISSE(string laCase) // si un truc apparait, on peut le choper // les caisses donnent plus que les pots
        {
            /**/
            Random rand = new Random();
            int objet = rand.Next(0, 42);
            if (objet % 4 == 0)
                objet = 0; // vide
            else if (objet % 3 == 0)
                objet = 1; // mana
            else if (objet % 3 == 1)
                objet = 2; // MONSTRE
            else
                objet = 3; // cacahuète
            return ("" + objet);
        }
        #endregion

        #region Cases passantes
        static void sePasseunTrucSALLE()
        {

        }

        static string sePasseunTrucPOTVIDE()
        {
            return "0";
        }

        static Ennemi sePasseunTrucMONSTRE()
        {

            return default(Ennemi);
        }
        static string sePasseunTrucEAU()
        {
            // donne de la mana
            return "0";
        }

        static string sePasseunTrucCACA()
        {
            // on gagne de la vie et de la mana (mais pas trop)
            return "0";
        }

        static void sePasseunTrucMemory()
        {
            Memory memory = new Memory();
            memory.LoadContent();
            GD.GameStateStack.Push(memory);
        }

        static void sePasseunTrucRapidityNecessity()
        {
            RapidityNecessity rn = new RapidityNecessity();
            rn.Initialize();
            rn.LoadContent();
            GD.GameStateStack.Push(rn);
        }
        #endregion
        #endregion

    }
}
