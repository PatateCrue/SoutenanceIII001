using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SoutenanceIII001.dGameStates;

namespace SoutenanceIII001.dMiniJeux.cRapidityNecessity
{
    class RapidityNecessity : GameState
    {
        int score = 0;
        int difficulte = 60;
        int niveau = 0;
        int longueur = 100;
        int timer = 0;
        int vie = 5;
        int redonnevie = 0;
        bool findepartie = false;
        bool JeuEnPause = true;
        bool DebutdePartie = true;
        bool[] tabbool = new bool[100];
        int[,] tabdonnees = new int[100, 3];

        SpriteFont s_donnee;
        SpriteFont lettres;

        public override void Initialize()
        {
            InitTabBool();
        }
        public override void LoadContent()
        {
            s_donnee = GD.content.Load<SpriteFont>("spritefont");
            lettres = GD.content.Load<SpriteFont>("Spritefont2");
        }

        public override void Update()
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                GD.GameStateStack.Pop();

            timer++;
            if (timer == difficulte)
            {

                for (int l = 0; l < longueur; l++)
                {
                    if (tabbool[l])
                    {
                        Modif_carre_coordonees(l);
                        diminue_vie();
                    }
                }
                creer_carre(new Random().Next(1, 4));
                timer = 0;
            }
            else
            {
                creer_carre(new Random().Next(0, 1));
            }
            bouton_press();
        }

        public override void Draw()
        {
            if (DebutdePartie)
            {
                Affichage_nouvelle_partie();
            }
            else
            {
                if (findepartie)
                {
                    GD.GraphicsDevice.Clear(Color.Yellow);
                }
                else
                {
                    GD.GraphicsDevice.Clear(Color.White);
                }
                dessine_all();
            }
            timer = timer % difficulte;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Bleu=1, Noir=2, Rouge=3, Vert=4
        public void InitTabBool()
        {
            for (int i = 0; i < longueur; i++)
            {
                tabbool[i] = false;
            }
        }
        public void dessine(int pos)
        {
            string lettre;
            switch (tabdonnees[pos, 2])
            {
                case 1:
                    lettre = "A";
                    break;
                case 2:
                    lettre = "B";
                    break;
                case 3:
                    lettre = "C";
                    break;
                case 4:
                    lettre = "D";
                    break;
                case 5:
                    lettre = "E";
                    break;
                case 6:
                    lettre = "F";
                    break;
                case 7:
                    lettre = "G";
                    break;
                case 8:
                    lettre = "H";
                    break;
                case 9:
                    lettre = "I";
                    break;
                case 10:
                    lettre = "J";
                    break;
                case 11:
                    lettre = "K";
                    break;
                case 12:
                    lettre = "L";
                    break;
                case 13:
                    lettre = "M";
                    break;
                case 14:
                    lettre = "N";
                    break;
                case 15:
                    lettre = "O";
                    break;
                case 16:
                    lettre = "P";
                    break;
                case 17:
                    lettre = "Q";
                    break;
                case 18:
                    lettre = "R";
                    break;
                case 19:
                    lettre = "S";
                    break;
                case 20:
                    lettre = "T";
                    break;
                case 21:
                    lettre = "U";
                    break;
                case 22:
                    lettre = "V";
                    break;
                case 23:
                    lettre = "W";
                    break;
                case 24:
                    lettre = "X";
                    break;
                case 25:
                    lettre = "Y";
                    break;
                default:
                    lettre = "Z";
                    break;
            }
            Vector2 position = new Vector2((tabdonnees[pos, 0]), tabdonnees[pos, 1]);
            GD.spriteBatch.DrawString(lettres, lettre, position, Color.Black);
        }
        public void dessine_all()
        {

            for (int i = 0; i < longueur; i++)
            {
                if (tabbool[i])
                {
                    dessine(i);
                }
            }
            affiche_donnee();
        }
        public void bouton_press()
        {
            if ((findepartie || JeuEnPause) && GD.mouse.LeftButton == ButtonState.Pressed)
                GD.GameStateStack.Pop();

            if (GD.kbState.IsKeyDown(Keys.A) && GD.previouskbState.IsKeyUp(Keys.A))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 1)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.B) && GD.previouskbState.IsKeyUp(Keys.B))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 2)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.C) && GD.previouskbState.IsKeyUp(Keys.C))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 3)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.D) && GD.previouskbState.IsKeyUp(Keys.D))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 4)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.E) && GD.previouskbState.IsKeyUp(Keys.E))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 5)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.F) && GD.previouskbState.IsKeyUp(Keys.F))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 6)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.G) && GD.previouskbState.IsKeyUp(Keys.G))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 7)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.H) && GD.previouskbState.IsKeyUp(Keys.H))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 8)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.I) && GD.previouskbState.IsKeyUp(Keys.I))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 9)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.J) && GD.previouskbState.IsKeyUp(Keys.J))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 10)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.K) && GD.previouskbState.IsKeyUp(Keys.K))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 11)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.L) && GD.previouskbState.IsKeyUp(Keys.L))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 12)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.M) && GD.previouskbState.IsKeyUp(Keys.M))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 13)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.N) && GD.previouskbState.IsKeyUp(Keys.N))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 14)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.O) && GD.previouskbState.IsKeyUp(Keys.O))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 15)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.P) && GD.previouskbState.IsKeyUp(Keys.P))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 16)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.Q) && GD.previouskbState.IsKeyUp(Keys.Q))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 17)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.R) && GD.previouskbState.IsKeyUp(Keys.R))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 18)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.S) && GD.previouskbState.IsKeyUp(Keys.S))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 19)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.T) && GD.previouskbState.IsKeyUp(Keys.T))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 20)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.U) && GD.previouskbState.IsKeyUp(Keys.U))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 21)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.V) && GD.previouskbState.IsKeyUp(Keys.V))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 22)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.W) && GD.previouskbState.IsKeyUp(Keys.W))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 23)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.X) && GD.previouskbState.IsKeyUp(Keys.X))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 24)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.Y) && GD.previouskbState.IsKeyUp(Keys.Y))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 25)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.Z) && GD.previouskbState.IsKeyUp(Keys.Z))
            {
                for (int i = 0; i < longueur; i++)
                {
                    if (tabdonnees[i, 2] == 26)
                    {
                        Elimine_carre(i);
                    }
                }
            }
            if (GD.kbState.IsKeyDown(Keys.Enter) && GD.previouskbState.IsKeyUp(Keys.Enter))
            {
                if (DebutdePartie)
                {
                    DebutdePartie = false;
                }

                if (JeuEnPause)
                {
                    InitTabBool();
                    findepartie = false;
                    score = 0;
                    vie = 5;
                    JeuEnPause = false;
                }
                if (findepartie)
                {
                    DebutdePartie = true;
                    JeuEnPause = true;
                }
            }
            if (GD.kbState.IsKeyDown(Keys.Space) && GD.previouskbState.IsKeyUp(Keys.Space))
            {
                if (!findepartie)
                {
                    if (JeuEnPause)
                    {
                        JeuEnPause = false;
                    }
                    else
                    {
                        JeuEnPause = true;
                    }
                }
            }
            GD.previouskbState = GD.kbState;
        }
        public void Elimine_carre(int pos)
        {
            if (!findepartie && !JeuEnPause)
            {
                tabbool[pos] = false;
                for (int c = 0; c < 1; c++)
                {
                    Modifscore();
                }
            }
        }
        public void Modifscore()
        {
            Modifniveau();
            score += 10 + niveau;
            Modifdifficulte();
        }
        public void Modifdifficulte()
        {
            difficulte = Math.Abs(60 - niveau);
        }
        public void Modifniveau()
        {
            if (niveau < 30)
            {
                niveau = Convert.ToInt32(Math.Log(score + 1));
            }
            else
            {
                redonnevie++;
                if (redonnevie == 20)
                {
                    redonnevie = 0;
                    vie++;
                }
            }

        }
        public void creer_carre(int nb_de_carre_a_creer)
        {
            if (!findepartie && !JeuEnPause)
            {
                Random rand = new Random();
                int k = 0;
                while ((nb_de_carre_a_creer > 0) && (k < longueur))
                {
                    if (tabbool[k] == false)
                    {
                        tabbool[k] = true;
                        tabdonnees[k, 0] = rand.Next(1, GD.graphics.GraphicsDevice.Viewport.Width - 50/*Taille de l'image*/);//X
                        tabdonnees[k, 1] = 0;//Y
                        tabdonnees[k, 2] = rand.Next(1, 27);//image
                        nb_de_carre_a_creer--;
                    }
                    k++;
                }
            }
        }
        public void Modif_carre_coordonees(int pos)
        {
            if (!JeuEnPause)
            {
                if (tabbool[pos])
                {
                    tabdonnees[pos, 1] += 50;
                }
            }
        }
        public void fin_vie()
        {
            vie--;
            if (vie == 0)
            {
                findepartie = true;

            }
        }
        public void diminue_vie()
        {
            for (int o = 0; o < longueur; o++)
            {
                if (tabbool[o])
                {
                    if (tabdonnees[o, 1] >= GD.graphics.GraphicsDevice.Viewport.Height - 70)
                    {
                        if (!findepartie)
                        {
                            fin_vie();
                        }
                        tabbool[o] = false;
                    }
                }
            }

        }
        public void affiche_donnee()
        {
            if (!findepartie && !JeuEnPause)
            {
                string text3 = string.Format("Niveau : {0}", niveau);
                GD.spriteBatch.DrawString(s_donnee, text3, new Vector2(0, 30), Color.DarkGreen);
                string text = string.Format("Score : {0}", score);
                GD.spriteBatch.DrawString(s_donnee, text, new Vector2(0, 70), Color.DarkGreen);
                string text2 = string.Format("vie: {0}", vie);
                GD.spriteBatch.DrawString(s_donnee, text2, new Vector2(0, 50), Color.DarkGreen);
            }
            else
            {
                if (findepartie)
                {
                    string text = "GAME OVER";
                    GD.spriteBatch.DrawString(s_donnee, text, new Vector2((GD.graphics.GraphicsDevice.Viewport.Width - (text.Length) * 10) / 2, GD.graphics.GraphicsDevice.Viewport.Height / 2 - 10), Color.Purple);
                    string text2 = /*"Ton score: 100000000000000000000000000000000000000";*/string.Format("Ton score: {0}", score);
                    GD.spriteBatch.DrawString(s_donnee, text2, new Vector2((GD.graphics.GraphicsDevice.Viewport.Width - (text2.Length) * 10) / 2, GD.graphics.GraphicsDevice.Viewport.Height / 2 + 10), Color.Purple);
                    string text3 = /*"Ton niveau: 999999";*/string.Format("Ton niveau: {0}", niveau);
                    GD.spriteBatch.DrawString(s_donnee, text3, new Vector2((GD.graphics.GraphicsDevice.Viewport.Width - (text3.Length) * 10) / 2, GD.graphics.GraphicsDevice.Viewport.Height / 2 + 30), Color.Purple);
                }
                if (JeuEnPause)
                {
                    string text = "Pause";
                    GD.spriteBatch.DrawString(s_donnee, text, new Vector2((GD.graphics.GraphicsDevice.Viewport.Width - (text.Length) * 10) / 2, GD.graphics.GraphicsDevice.Viewport.Height / 2 - 20), Color.Purple);
                    string text4 = string.Format("Tu es au niveau {0}.", niveau);
                    GD.spriteBatch.DrawString(s_donnee, text4, new Vector2((GD.graphics.GraphicsDevice.Viewport.Width - (text4.Length) * 10) / 2, GD.graphics.GraphicsDevice.Viewport.Height / 2), Color.Purple);
                    string text2 = string.Format("Il te reste seulement {0} vie(s).", vie);
                    GD.spriteBatch.DrawString(s_donnee, text2, new Vector2((GD.graphics.GraphicsDevice.Viewport.Width - (text2.Length) * 10) / 2, GD.graphics.GraphicsDevice.Viewport.Height / 2 + 20), Color.Purple);
                    string text3 = string.Format("Ton score est de {0} point(s).", score);
                    GD.spriteBatch.DrawString(s_donnee, text3, new Vector2((GD.graphics.GraphicsDevice.Viewport.Width - (text3.Length) * 10) / 2, GD.graphics.GraphicsDevice.Viewport.Height / 2 + 40), Color.Purple);
                }
            }
        }
        public void Affichage_nouvelle_partie()
        {
            GD.GraphicsDevice.Clear(Color.LemonChiffon);
            int nombre_de_ligne = 11;
            string ligne1 = "A l'aide du renard!";
            GD.spriteBatch.DrawString(s_donnee, ligne1, new Vector2(((GD.screenWidth - (ligne1.Length) * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 - 30)), Color.Red);
            string ligne2 = "Partie 1: Une rapidite necessaire!";
            GD.spriteBatch.DrawString(s_donnee, ligne2, new Vector2(((GD.screenWidth - ligne2.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 - 10)), Color.Red);
            string ligne3 = "Afin de pouvoir sortir d'ici, il te faut entrainer ta rapidite.  ";
            GD.spriteBatch.DrawString(s_donnee, ligne3, new Vector2(((GD.screenWidth - ligne3.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 30)), Color.DarkOrange);
            string ligne4 = "Pour cela je t'ai prepare un petit entrainement, rien de bien    ";
            GD.spriteBatch.DrawString(s_donnee, ligne4, new Vector2(((GD.screenWidth - ligne4.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 50)), Color.DarkOrange);
            string ligne5 = "complique, tu verra des lettres tomber face a toi. Ton objectifs,";
            GD.spriteBatch.DrawString(s_donnee, ligne5, new Vector2(((GD.screenWidth - ligne5.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 70)), Color.DarkOrange);
            string ligne6 = "les empecher de toucher le sol, pour cela il te faut cliquer sur ";
            GD.spriteBatch.DrawString(s_donnee, ligne6, new Vector2(((GD.screenWidth - ligne6.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 90)), Color.DarkOrange);
            string ligne7 = "Les lettres correspondantes se trouvant sur ton clavier.         ";
            GD.spriteBatch.DrawString(s_donnee, ligne7, new Vector2(((GD.screenWidth - ligne7.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 110)), Color.DarkOrange);
            string ligne8 = "Touches necessaire pour jouer:                                   ";
            GD.spriteBatch.DrawString(s_donnee, ligne8, new Vector2(((GD.screenWidth - ligne8.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 130)), Color.DarkOrange);
            string ligne9 = "-Toutes les touches de lettres(Q,W,E,R,T,Y,...)                  ";
            GD.spriteBatch.DrawString(s_donnee, ligne9, new Vector2(((GD.screenWidth - ligne9.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 150)), Color.DarkOrange);
            string ligne10 = "-La touche Espace pour mettre le jeu en pause.                   ";
            GD.spriteBatch.DrawString(s_donnee, ligne10, new Vector2(((GD.screenWidth - ligne10.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 170)), Color.DarkOrange);
            string ligne11 = "POUR COMMENCER, APPUYER SUR ENTREE.";
            GD.spriteBatch.DrawString(s_donnee, ligne11, new Vector2(((GD.screenWidth - ligne11.Length * 11) / 2), ((GD.screenHeight - (nombre_de_ligne * 20)) / 2 + 200)), Color.Red);
        }
    }
}
