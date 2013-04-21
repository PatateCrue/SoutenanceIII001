using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoutenanceIII001.dSprite.dInterface;
using Microsoft.Xna.Framework.Input;
using SoutenanceIII001.dMiniJeux.cMemory;
using SoutenanceIII001.dMiniJeux.cRapidityNecessity;
using SoutenanceIII001.dSprite.dPerso;
using SoutenanceIII001.dMaps;

namespace SoutenanceIII001.dGameStates
{
    class Playing : GameState
    {
       // Vector2 posdep;
        #region TAB
        Ennemi[,] tabmob;
        string[,] tabobj;
        #endregion
        #region MAP & JOUEUR
        Map map01;
        Joueur joueur;
        Ennemi intermob;
        TrucsInteractifs interobj;
        #endregion

        cButton bMainMenu;
        cButton bPause;
        Texture2D bTexture_MainMen;
        HUD barrevie;
        HUD barremana;

        public override void Initialize() { }

        public override void LoadContent()
        {
            bTexture_MainMen = GD.content.Load<Texture2D>(@"Sprites\sBoutonsMainMen\ButtonMainMen");
            bMainMenu = new cButton(bTexture_MainMen, new Rectangle(0, 39 * 4, 144, 38));
            bMainMenu.setPosition(new Vector2(0, 0));
            bPause = new cButton(bTexture_MainMen, new Rectangle(0, 39 * 5, 144, 38));
            bPause.setPosition(new Vector2(1280 - 144, 800 - 38));

            #region INIT
            #region TAB
            tabobj = new string[29, 6];
            tabmob = new Ennemi[tabobj.GetLength(0), tabobj.GetLength(1)];
            for (int i = 0; i < tabmob.GetLength(0); i++)
                for (int j = 0; j < tabmob.GetLength(1); j++)
                {
                    tabmob[i, j] = default(Ennemi);
                    tabobj[i, j] = "0";
                }

            ForTab.RandomlyFillTabMob(ref tabmob, 5);
            tabobj[13, 0] = "PB";
            tabobj[12, 0] = "PB";
            tabobj[14, 0] = "PB";
            tabobj[20, 0] = "10"; // MEMORY
            tabobj[10, 0] = "11"; // RAPIDITY NECESSITY
            #endregion */

            #region MAP & JOUEUR
            map01 = new Map(@"Sprites\couloir", new Rectangle(2000, 250, 1500, 1124));
            joueur = new Joueur(@"Sprites\sPersonnage\plancheSprite01_64x150", new Rectangle(64 * 0, 32 * 20, 64, 150), tabmob, tabobj);
            intermob = new Ennemi(Ennemi.TypeEnnemi.AquaTank, 50, 20, (float)0.7, tabmob, @"Sprites\sPersonnage\80x96", new Vector2(0, 0), new Rectangle(0, 0, 80, 96));
            interobj = new TrucsInteractifs(50, 20, (float)0.7, tabobj, @"Sprites\pot", new Vector2(0, 0), new Rectangle(0, 0, 64, 32));
           // posdep = new Vector2(64 * 0, 32 * 20);
            #endregion
            #endregion

            #region MAP & JOUEUR

            joueur.LoadContent();
            intermob.LoadContent();
            interobj.LoadContent();
            map01.LoadContent();
            #endregion


            barrevie = new HUD(@"Sprites\texturevie", new Rectangle(1000, 500, 99, 32), new Vector2(500, 500), "Vie");
            barremana = new HUD(@"Sprites\texturemana", new Rectangle(1000, 600, 99, 32), new Vector2(500, 500), "Mana");
            // HUD
            barrevie.LoadContent();
            barremana.LoadContent();
        }

        public override void Update()
        {

            bMainMenu.Update();
            if (bMainMenu.isClicked)
                GD.GameStateStack.Pop();

            bPause.Update();
            if (bPause.isClicked)
            {
                Pause pause = new Pause();
                pause.LoadContent();
                GD.GameStateStack.Push(pause);
            }

            #region MAP & JOUEUR
            joueur.isScrolling = !map01.isAuxBords;
            joueur.Update();
            map01.PlyisBloquedUP = joueur.isBloquedUP;
            map01.PlyisBloquedDOWN = joueur.isBloquedDOWN;
            map01.Update();
            //     tabmob = joueur.tabEnnemis;
            //     tabobj = joueur.tabObjInter;
            intermob.Update(new Vector2(map01.Position.X, map01.Position.Y + 16 * 50 - 16));
            interobj.Update(new Vector2(map01.Position.X, map01.Position.Y + 16 * 50 - 16));
            #endregion

            #region TESTS
            barrevie.Update();
            barremana.Update();
            #endregion

            #region CHEATS
            if (GD.kbState.IsKeyDown(Keys.C))
            {
                Memory memory = new Memory();
                memory.LoadContent();
                GD.GameStateStack.Push(memory);
            }
            else if (GD.kbState.IsKeyDown(Keys.O))
            {
                RapidityNecessity rn = new RapidityNecessity();
                rn.Initialize();
                rn.LoadContent();
                GD.GameStateStack.Push(rn);
            }
            #endregion
        }

        public override void Draw()
        {
            bMainMenu.Draw();
            bPause.Draw();

            #region MAPS

            map01.Draw();
            intermob.Draw();
            interobj.Draw();
            joueur.Draw();
            #endregion

            #region TESTS
            // Lecteur musique
            GD.lecteurmus.Draw(2);

            barrevie.Draw();
            barremana.Draw();

            #endregion


            //Ce qu'il y a ci-dessous sert juste à vérifier visuellement si les empilements et les dépilements se passent comme prévu
            //A mettre sur tous les écrans pour bêtre sûr
            if (GD.GameStateStack.Count == 1)
                GD.spriteBatch.Draw(bTexture_MainMen, new Rectangle(0, 0, 30, 30), Color.Red);
            if (GD.GameStateStack.Count == 2)
                GD.spriteBatch.Draw(bTexture_MainMen, new Rectangle(0, 0, 30, 30), Color.Yellow);
            if (GD.GameStateStack.Count == 3)
                GD.spriteBatch.Draw(bTexture_MainMen, new Rectangle(0, 0, 30, 30), Color.Green);
            if (GD.GameStateStack.Count > 3)
                GD.spriteBatch.Draw(bTexture_MainMen, new Rectangle(0, 0, 30, 30), Color.White);
        }
    }
}
