using Microsoft.Xna.Framework;

namespace SoutenanceIII001.dSprite.dPerso
{
    public enum Direction
    {
        Up, Down, Left, Right
    };

    class Personnage : Sprite
    {
        #region FIELDS

        protected Ennemi[,] Tab;
        protected Vector2 Position_dep;

        // Pour le scrolling : position de reference
        protected Vector2 MapPosition;
       // Position = MapPosition + ce qu'on a déplacé

        protected int FrameLine, FrameColumn, timerAnim;

        //stats
        int _vie;
        int _vieMax;
        private int _attaque;
        private float _vitesseAttaque;

        #endregion

        #region CONSTRUCTORS
        public Personnage(int VieMax, int attaque, float vitesseAttaque, string asset, Rectangle position, Ennemi[,] tab, Vector2 position_dep)
            : base(asset, position)
        {
            _vieMax = VieMax;
            _vie = _vieMax;
            _attaque = attaque;
            _vitesseAttaque = vitesseAttaque;

            Tab = tab;
            Position_dep = position_dep;
            MapPosition = position_dep;

            FrameColumn = 0;
            FrameLine = 0;
            timerAnim = 0;
        }
        #endregion

        #region INIT
        #endregion

        #region STATS
        public int Vie
        {
            get { return _vie; }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > _vieMax)
                    value = _vieMax;

                _vie = value;
            }
        }

        public int Attaque
        {
            get { return _attaque; }
            set { _attaque = value; }
        }

        public float VitesseAttaque
        {
            get { return _vitesseAttaque; }
            set { _vitesseAttaque = value; }
        }


        #endregion

        #region METHODS
        public void Animate()
        {
            timerAnim += 1;
            if (timerAnim == 16)
                timerAnim = 0;
            else if (timerAnim % 3 == 0)
                FrameColumn = (FrameColumn % 6) + 1;
        }
        public void CalculDepth(Vector2 positionnement)
        {
            LayerDepth = (10 * (positionnement.X - positionnement.Y) + positionnement.X + 9 * positionnement.Y + 8)
                / (10 * (Tab.GetLength(0)) + Tab.GetLength(0) + 8);
        }
        #endregion

        #region UPDATE & DRAW
        public void Update(Vector2 mapPosition)
        {
        }

        public override void Draw()
        {
        }
        #endregion

    }

}
