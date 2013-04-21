using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SoutenanceIII001.dMusic
{
    class Music
    {
        #region FIELDS
        string Asset;
        Song Chanson;
        #endregion

        #region CONSTRUCTORS
        public Music(string asset)
        {
            Asset = asset;
        }
        #endregion

        #region LOADCONTENT
        public void LoadContent()
        {
            Chanson = GD.content.Load<Song>(Asset);
        }
        #endregion

        #region METHODS
        public void Play()
        {
            MediaPlayer.Play(Chanson);
        }
        #endregion

        #region UPDATE & DRAW
        #endregion

    }
    public class SelectionPlayer
    {
        //Screen Adjustements
        int screenWidth = 1280, screenHeight = 800;

        #region FIELDS
        Music[] SongTab;
        cButton[] SongButtonTab;
        Texture2D ButtonTex; // boutons du sélecteur
        cButton bPause, bRepr; // boutons du lecteur
        bool IsPaused;

        Music SongPlayed, SongMenu, SongJeu;

        #endregion

        #region CONSTRUCTORS
        public SelectionPlayer(int nbSong, string[] songAsset)
        {
            SongTab = new Music[nbSong];
            SongButtonTab = new cButton[nbSong];
            for (int i = 0; i < nbSong; i++)
                SongTab[i] = new Music(songAsset[i]); // la case i de listAsset devient le Asset de la case SongTab i

            SongPlayed = SongTab[0];
            SongMenu = SongTab[0];
            SongJeu = SongTab[0];
            IsPaused = false;
        }
        #endregion

        #region LOADCONTENT
        public void LoadContent()
        {
            foreach (Music song in SongTab)
                song.LoadContent();

            // Init du lecteur de musique
            ButtonTex = GD.content.Load<Texture2D>(@"Sprites\playertex"); // mettre le bon nom de l'image

            bPause = new cButton(ButtonTex, new Rectangle(0, 2 * 20, 11, 20));
            bPause.setPosition(new Vector2(screenWidth - 2 * screenWidth / 15, screenHeight - screenHeight / 10));
            bRepr = new cButton(ButtonTex, new Rectangle(0, 20, 11, 20));
            bRepr.setPosition(new Vector2(screenWidth - 1 * screenWidth / 10, screenHeight - screenHeight / 10));
            
            MediaPlayer.IsRepeating = true;

            for (int i = 0; i < SongButtonTab.Length; i++)
            {
                SongButtonTab[i] = new cButton(ButtonTex, new Rectangle(0, 0, 11, 20));
                SongButtonTab[i].setPosition(new Vector2(screenWidth - 1 * screenWidth / 10 - i * 64, screenHeight - screenHeight / 10 - 50));
            }

            SongPlayed.Play();

        }
        #endregion

        #region METHODS
        #endregion

        #region UPDATE & DRAW
        public void Update(int ou) // ou == 0 : MainMenu, ou == 1 : Options
        {
            bPause.Update();
            bRepr.Update();
            foreach (cButton button in SongButtonTab)
            {
                button.Update();
            }

            for (int i = 0; i < SongButtonTab.Length; i++)
            {
                switch (ou)
                {
                    case 0:
                        if (SongButtonTab[i].isClicked)
                            SongMenu = SongTab[i];
                        if (bPause.isClicked)
                            if (!IsPaused)
                            {
                                MediaPlayer.Pause();
                                IsPaused = true;
                            }
                        if (bRepr.isClicked)
                            if (IsPaused)
                            {
                                MediaPlayer.Resume();
                                IsPaused = false;
                            }
                        break;

                    case 1:
                        if (SongButtonTab[i].isClicked)
                            SongJeu = SongTab[i];
                        if (bPause.isClicked)
                            if (!IsPaused)
                            {
                                MediaPlayer.Pause();
                                IsPaused = true;
                            }
                        if (bRepr.isClicked)
                            if (IsPaused)
                            {
                                MediaPlayer.Resume();
                                IsPaused = false;
                            }
                        break;
                }
            }
        }

        public void Draw(int ou) // ou == 0 : MainMen, ou == 1 : Options, ou == 2 : Playing
        {
            switch (ou)
            {
                case 0:
                    if (SongPlayed != SongMenu)
                    {
                        SongPlayed = SongMenu;
                        SongPlayed.Play();
                    }
                    break;

                case 1:
                    if (SongPlayed != SongJeu)
                    {
                        SongPlayed = SongJeu;
                        SongPlayed.Play();
                    }
                    break;

                case 2:
                    if (SongPlayed != SongJeu)
                    {
                        SongPlayed = SongJeu;
                        SongPlayed.Play();
                    }
                    break;
            }

            if (ou == 1 || ou == 0)
            {
                foreach (cButton button in SongButtonTab)
                {
                    button.Draw();
                }
                bPause.Draw();
                bRepr.Draw();
            }

        }

        #endregion
    }
}
