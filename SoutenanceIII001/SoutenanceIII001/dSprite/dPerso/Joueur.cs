using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoutenanceIII001.dSprite.dPerso
{
    class Joueur : Personnage
    {
        #region FIELDS

        // peut être bloqué par un objet, un ennemi ou le bout du mur
        public bool isBloquedUP, isBloquedDOWN, isBloquedLEFT, isBloquedRIGHT;
        bool seDeplace;
        public bool isScrolling; // si on scrolle ben le perso ne bouge aps, donc si la map est isauxBords // modifié par la map 

        int PosI;
        int PosJ;

        public Ennemi[,] tabEnnemis;
        public string[,] tabObjInter;
        int mapWidth, mapHeight;
        int Speed;

        Direction Direction;
        int timerDep;

        /**/
        bool attak;

        #endregion

        #region CONSTRUCTOR
        public Joueur(string asset, Rectangle position, Ennemi[,] ennemis, string[,] objinter)
            : base(50, 2, (float)0.7, asset, position, ennemis, new Vector2(position.X, position.Y))
        {

            tabEnnemis = ennemis;
            tabObjInter = objinter;
            mapWidth = ennemis.GetLength(0) - 1; // si il y a un probleme d'index, c'est ici qu'il faut corriger
            mapHeight = ennemis.GetLength(1) - 1;

            PosI = 0;
            PosJ = mapHeight; //
            // Milieu de la case ou est place le sprite (ici, en bas à gauche de la map)

            Position.X = (mapHeight + 1);
            Position.Y = 80 * (mapHeight + 2);
            if (PosJ != 0)
            {
                if (PosJ % 2 != 0)
                {
                    Position.X += ((PosI * 64 + 64 / 2) + (((PosJ - 1) * 64) / 2)) - PosI * 64 / 2;
                    Position.Y += ((PosJ * 32) / 2) - (PosI * 32) / 2;
                }
                else
                {
                    Position.X += (PosI * 64 + ((PosJ * 64) / 2)) - (PosI * 64) / 2;
                    Position.Y += (((PosJ * 32) / 2)) - (PosI * 32) / 2;
                }
            }
            else
            {
                Position.X += (PosI * 64) - (PosI * 64) / 2;
                Position.Y += ((PosJ * 32) / 2) - (PosI * 32) / 2;
            }

            Speed = 1;

            Direction = Direction.Left;
            seDeplace = false;
            isScrolling = false;

            attak = false;

            timerDep = 0;


        }
        #endregion

        #region METHODS
        void Deplacement()
        {
            int n = 0;

            if (GD.kbState.IsKeyDown(Keys.Space) && GD.previouskbState.IsKeyUp(Keys.Space))
                attak = true;

            // on verifie toutes les directions de la position ou il est
            if (PosI != mapWidth && tabEnnemis[PosI + 1, PosJ] == default(Ennemi) && Int32.TryParse(tabObjInter[PosI + 1, PosJ], out n)) // si il n'y a pas de mob ou d'objets bloquants
                isBloquedUP = false;
            else
                isBloquedUP = true;
            if (PosI != 0 && tabEnnemis[PosI - 1, PosJ] == default(Ennemi) && Int32.TryParse(tabObjInter[PosI - 1, PosJ], out n)) // si il n'y a pas de mob ou d'objets bloquants
                isBloquedDOWN = false;
            else
                isBloquedDOWN = true;
            if (PosJ != 0 && tabEnnemis[PosI, PosJ - 1] == default(Ennemi) && Int32.TryParse(tabObjInter[PosI, PosJ - 1], out n)) // si il n'y a pas de mob ou d'objets bloquants
                isBloquedLEFT = false;
            else
                isBloquedLEFT = true;
            if (PosJ != mapHeight && tabEnnemis[PosI, PosJ + 1] == default(Ennemi) && Int32.TryParse(tabObjInter[PosI, PosJ + 1], out n)) // si il n'y a pas de mob ou d'objets bloquants
                isBloquedRIGHT = false;
            else
                isBloquedRIGHT = true;

            if (!seDeplace) // s'il ne se déplace pas, il peut bouger (Y)
            {
                if (GD.kbState.IsKeyDown(Keys.Up) && GD.previouskbState.IsKeyUp(Keys.Up))
                {
                    this.Direction = Direction.Up;

                    if (!isBloquedUP)
                    {
                        // on peut se déplacer, on active le déplacement
                        PosI++;
                       seDeplace = true;
                    }

                }

                else if (GD.kbState.IsKeyDown(Keys.Down) && GD.previouskbState.IsKeyUp(Keys.Down) && PosI >= 0)
                {
                    this.Direction = Direction.Down;

                    if (!isBloquedDOWN) // si il n'y a pas de mob ou d'objets bloquants
                    {
                        // on peut se déplacer, on active le déplacement
                        PosI--;
                        seDeplace = true;
                    }
                }

                else if (GD.kbState.IsKeyDown(Keys.Left) && GD.previouskbState.IsKeyUp(Keys.Left))
                {
                    this.Direction = Direction.Left;

                    if (!isBloquedLEFT)
                    {
                        // on peut se déplacer, on active le déplacement
                        PosJ--;
                       seDeplace = true;
                    }
                }

                else if (GD.kbState.IsKeyDown(Keys.Right) && GD.previouskbState.IsKeyUp(Keys.Right))
                {
                    Direction = Direction.Right;

                    if (!isBloquedRIGHT)
                    {
                        // on peut se déplacer, on active le déplacement
                        PosJ++;
                       seDeplace = true;
                    }
                }

            }


            // si le déplacement est activé, on switch la direction et on exécute le deplacement jusqu'à la nouvelle position ? 
            if (seDeplace && (timerDep == 16))
            {
                seDeplace = false;
                timerDep = 0;
            }
            else if (seDeplace)
            {
                timerDep++;
                switch (Direction) // (le switch doit pas etre très optimisé)
                {
                    case Direction.Up: // il y a un problme avec le scrolling haut/bas...
                        if (!isScrolling && !isBloquedUP)
                        { Position.X += Speed * 2; Position.Y -= Speed; }
                        break;
                    case Direction.Down:
                        if (!isScrolling && !isBloquedDOWN)
                        { Position.X -= Speed * 2; Position.Y += Speed; }
                        break;
                    case Direction.Left: Position.X -= Speed * 2; Position.Y -= Speed;
                        break;
                    case Direction.Right: Position.X += Speed * 2; Position.Y += Speed;
                        break;
                }

            }

            GD.previouskbState = GD.kbState;
        }

        private void Interaction01()
        {
            if (attak) // touche d'attaque
            {
                // animation de l'attaque
                // se passe kekchose s'il y a kekchose dans la bonne direction
                // faire gaffe aux sorties d'index : si le joueur est près d'un mur, c'est impossible qu'il y ait un objet... DONC verifier sa position
                switch (Direction)
                {
                    case Direction.Up:
                        if (PosI != mapWidth)
                        {
                            InteractCases.switchLaCaseBloquante_mob(ref tabEnnemis[PosI + 1, PosJ]);
                            InteractCases.switchLaCaseBloquante_obj(ref tabObjInter[PosI + 1, PosJ]);
                        }
                        break;
                    case Direction.Down:
                        if (PosI != 0)
                        {
                            InteractCases.switchLaCaseBloquante_mob(ref tabEnnemis[PosI - 1, PosJ]);
                            InteractCases.switchLaCaseBloquante_obj(ref tabObjInter[PosI - 1, PosJ]);
                        }
                        break;
                    case Direction.Left:
                        if (PosJ != 0)
                        {
                            InteractCases.switchLaCaseBloquante_mob(ref tabEnnemis[PosI, PosJ - 1]);
                            InteractCases.switchLaCaseBloquante_obj(ref tabObjInter[PosI, PosJ - 1]);
                        }
                        break;
                    case Direction.Right:
                        if (PosJ != mapHeight)
                        {
                            InteractCases.switchLaCaseBloquante_mob(ref tabEnnemis[PosI, PosJ + 1]);
                            InteractCases.switchLaCaseBloquante_obj(ref tabObjInter[PosI, PosJ + 1]);
                        }
                        break;
                }
                attak = false;
            }
        }

        #endregion

        #region UPDATE & DRAW
        public override void Update()
        {

            Deplacement();

            // on fait ce qu'il y a sur la case lorsqu'on est arrete sur une case
            if (!seDeplace)
                InteractCases.switchLaCasePassante_obj(ref tabObjInter[PosI, PosJ]);

            //  Pour l'animation
            if (!seDeplace)
                FrameColumn = 0;
            switch (Direction)
            {
                case Direction.Up: FrameLine = 1;
                    break;
                case Direction.Down: FrameLine = 0;
                    break;
                case Direction.Left: FrameLine = 2;
                    break;
                case Direction.Right: FrameLine = 3;
                    break;
            }

            // interaction avec les obj/mob avec vérification de l'index
            //  if (PosI != 0 && PosJ != 0 && PosI != mapWidth && PosJ != mapHeight)
            Interaction01();


            if (seDeplace)
                Animate();

            // calcul de la nouvelle profondeur (peut etre a optimiser...)
            CalculDepth(new Vector2(PosI, PosJ));
        }

        public override void Draw()
        {
            GD.spriteBatch.Draw(Texture, new Vector2(Position.X, Position.Y),
                new Rectangle(Position.Width * FrameColumn, Position.Height * FrameLine, Position.Width, Position.Height),
                Color.White, Rotation, Origin, Scale, Effect, LayerDepth + 0.000001f);
            if (Direction == Direction.Down)
                GD.spriteBatch.Draw(Texture, new Vector2(Position.X, Position.Y - 3),
                     new Rectangle(Position.Width * 0, Position.Height * 0 + 8 * 150, Position.Width, Position.Height),
                     Color.White, Rotation, Origin, Scale, Effect, LayerDepth);
            else if (Direction == Direction.Right)
                GD.spriteBatch.Draw(Texture, new Vector2(Position.X, Position.Y - 3),
                     new Rectangle(Position.Width * 0, Position.Height * 0 + 8 * 150, Position.Width, Position.Height),
                     Color.White, Rotation, Origin, Scale, SpriteEffects.FlipHorizontally, LayerDepth);
            else
                GD.spriteBatch.Draw(Texture, new Vector2(Position.X, Position.Y),
                     new Rectangle(Position.Width * 4, Position.Height * 0 + 8 * 150, Position.Width, Position.Height),
                     Color.White, Rotation, Origin, Scale, Effect, LayerDepth);
            GD.spriteBatch.Draw(Texture, new Vector2(Position.X + 1, Position.Y - 2),
                new Rectangle(Position.Width * FrameColumn, Position.Height * FrameLine + 4 * 150, Position.Width, Position.Height),
                Color.White, Rotation, Origin, Scale, Effect, LayerDepth - 0.000000001f);

        }
        #endregion
    }
}
