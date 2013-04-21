using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SoutenanceIII001.dSprite;

namespace SoutenanceIII001.dMaps
{
    class Map : Sprite
    {
        #region FIELDS

        public bool PlyisBloquedUP; // Player is Bloqued, soit par la map, soit par un obj
        public bool PlyisBloquedDOWN;
        public bool isAuxBords
        {
            get { return _isAuxBords; }
        }
        private bool _isAuxBords;

        int Speed;

        bool depUP, depDOWN; // deplacementUP et deplacementDOWN
        int timerDep;

        Rectangle PosDep, newPosition, fakePos;

        KeyboardState _keyboardState, _oldKeyboardState;
        #endregion

        #region CONSTRUCTOR
        public Map(string asset, Rectangle position)
            : base(asset, position)
        {
            PlyisBloquedUP = false;
            PlyisBloquedDOWN = true;
            _isAuxBords = true;
            PosDep = position;
            Speed = 1;
            LayerDepth = 1;

        }
        #endregion

        #region METHODS
        #endregion

        #region UPDATE & DRAW
        public override void Update()
        {
            //   _isAuxBords = false;
            _keyboardState = Keyboard.GetState(); /*GENERAL*/


            if (/*&& !isAuxBords*/ !depUP && !depDOWN)
            // si le joueur n'est pas bloqué ou que la map n'est pas sur les bords de la map on peut scroller la map
            {
                if (!PlyisBloquedDOWN && _keyboardState.IsKeyDown(Keys.Down) && _oldKeyboardState.IsKeyUp(Keys.Down) && fakePos.X < PosDep.X)
                {
                    newPosition = new Rectangle(fakePos.X + 32, fakePos.Y - 16, Texture.Width, Texture.Height);
                    depDOWN = true;
                }
                else if (!PlyisBloquedUP && _keyboardState.IsKeyDown(Keys.Up) && _oldKeyboardState.IsKeyUp(Keys.Up) && fakePos.X + PosDep.Width > 1280)
                {
                    newPosition = new Rectangle(fakePos.X - 32, fakePos.Y + 16, Texture.Width, Texture.Height);
                    depUP = true;
                }
            }

            if (!PlyisBloquedUP || !PlyisBloquedDOWN)
            {
                if (depUP && /*fakePos.X == newfakePos.X*/ timerDep == 16)
                {
                    timerDep = 0;
                    depUP = false;
                }
                else if (depDOWN && /*fakePos.X == newfakePos.X*/ timerDep == 16)
                {
                    timerDep = 0;
                    depDOWN = false;
                }
                else if (depUP)
                {
                    fakePos.X -= Speed * 2;
                    fakePos.Y += Speed;
                    timerDep++;
                }
                else if (depDOWN)
                {
                    fakePos.X += Speed * 2;
                    fakePos.Y -= Speed;
                    timerDep++;
                }
            }

            if (fakePos.X >= PosDep.X || fakePos.X + PosDep.Width <= 1280)
                _isAuxBords = true;
            else
                _isAuxBords = false;

            _oldKeyboardState = _keyboardState;

            Position.X = fakePos.X - 333;
            Position.Y = fakePos.Y - 96;
        }

        public override void Draw()
        {
            base.Draw();
        }
        #endregion

    }
}
