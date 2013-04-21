using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoutenanceIII001.dGameStates;

namespace SoutenanceIII001.dMiniJeux.cMemory
{
    class Memory : GameState
    {
        Carte[,] jeu_cartes = new Carte[3, 4];
        Texture2D dos;
        Texture2D fond;
        Texture2D fin;
        Texture2D gameover;
        Texture2D touteslesfaces;
        int combienDePairesATrouver;
        int combienSontVisibles;
        int retournee1_x;
        int retournee1_y;
        int retournee2_x;
        int retournee2_y;
        int timer;
        bool gagne;
        bool jeu;
        SpriteFont s_donnee;


        public override void Initialize()
        {
        }

        public override void LoadContent()
        {
            s_donnee = GD.content.Load<SpriteFont>("SpriteFont1");
            timer = 60 * 60;

            gagne = true;
            jeu = true;
            combienDePairesATrouver = 6;
            combienSontVisibles = 0;
            fond = GD.content.Load<Texture2D>("fond");
            fin = GD.content.Load<Texture2D>("fin");
            gameover = GD.content.Load<Texture2D>("gameover");
            dos = GD.content.Load<Texture2D>("dos");
            touteslesfaces = GD.content.Load<Texture2D>("face");

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    jeu_cartes[i, j] = new Carte(i, j, dos, new Vector2(j * 250 + 150, i * 250 + 70), touteslesfaces);

            jeu_cartes[0, 0].type = 0;
            jeu_cartes[0, 1].type = 1;
            jeu_cartes[0, 2].type = 0;
            jeu_cartes[0, 3].type = 2;
            jeu_cartes[1, 0].type = 4;
            jeu_cartes[1, 1].type = 5;
            jeu_cartes[1, 2].type = 2;
            jeu_cartes[1, 3].type = 1;
            jeu_cartes[2, 0].type = 4;
            jeu_cartes[2, 1].type = 3;
            jeu_cartes[2, 2].type = 3;
            jeu_cartes[2, 3].type = 5;

        }

        public override void Update()
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                GD.GameStateStack.Pop();

            // TODO: Add your update logic here
            if (!jeu)
            {
                if (GD.mouse.LeftButton == ButtonState.Pressed)
                    GD.GameStateStack.Pop();
            }
            else
            {
                if (combienDePairesATrouver == 0 && GD.mouse.LeftButton == ButtonState.Released)
                {
                    gagne = true;
                    jeu = false;
                }
                if (timer < 0 && GD.mouse.LeftButton == ButtonState.Released)
                {
                    gagne = false;
                    jeu = false;
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 4; j++)
                            jeu_cartes[i, j].Update(ref combienDePairesATrouver, ref combienSontVisibles, ref retournee1_x, ref retournee1_y, ref retournee2_x, ref retournee2_y, ref jeu_cartes);
                }
            }
        }

        public override void Draw()
        {
            if (!jeu)
            {
                if (gagne)
                    GD.spriteBatch.Draw(fin, new Rectangle(0, 0, GD.screenWidth, GD.screenHeight), Color.White);
                else
                    GD.spriteBatch.Draw(gameover, new Rectangle(0, 0, GD.screenWidth, GD.screenHeight), Color.White);
            }

            else
            {
                AfficheTemps();
                GD.spriteBatch.Draw(fond, new Rectangle(0, 0, GD.screenWidth, GD.screenHeight), new Rectangle(0, 0, fond.Width, fond.Height), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1.0f);
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                        jeu_cartes[i, j].Draw();
            }


            //Ce qu'il y a ci-dessous sert juste à vérifier visuellement si les empilements et les dépilements se passent comme prévu
            //A mettre sur tous les écrans pour bêtre sûr
            if (GD.GameStateStack.Count == 1)
                GD.spriteBatch.Draw(fin, new Rectangle(0, 0, 30, 30), Color.Red);
            if (GD.GameStateStack.Count == 2)
                GD.spriteBatch.Draw(fin, new Rectangle(0, 0, 30, 30), Color.Yellow);
            if (GD.GameStateStack.Count == 3)
                GD.spriteBatch.Draw(fin, new Rectangle(0, 0, 30, 30), Color.Green);
            if (GD.GameStateStack.Count > 3)
                GD.spriteBatch.Draw(fin, new Rectangle(0, 0, 30, 30), Color.White);
        }


        public void AfficheTemps()
        {
            timer--;
            string text = (timer / 60).ToString();
            GD.spriteBatch.DrawString(s_donnee, text, new Vector2(GD.screenWidth / 2, 30), Color.Black);

        }
    }
}
