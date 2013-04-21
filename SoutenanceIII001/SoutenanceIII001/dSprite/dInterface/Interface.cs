using Microsoft.Xna.Framework;

namespace SoutenanceIII001.dSprite.dInterface
{
    class Interface : Sprite
    {
        #region FIELDS
        protected Vector2 Position_dep;
        #endregion

        #region CONSTRUCTORS

        public Interface(string asset, Rectangle position, Vector2 position_dep)
            : base(asset, position)
        {
            Position_dep = position_dep;
            LayerDepth = 0f;
        }
        #endregion

        #region METHODS

        #endregion

        #region UPDATE

        #endregion

        #region DRAW

        #endregion
    }
}
