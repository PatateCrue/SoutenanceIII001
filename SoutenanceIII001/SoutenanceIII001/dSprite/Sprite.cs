using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoutenanceIII001.dSprite
{
    class Sprite
    {
        #region FIELDS
        protected Texture2D Texture;
        protected string Asset;
        public Rectangle Position; // lololol c'est sale

        Rectangle? sourceRectangle = null;
        public Rectangle? SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }
        Color color = Color.White;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        float rotation = 0;
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        Vector2 origin = Vector2.Zero;
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        Vector2 scale = Vector2.One;
        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        SpriteEffects effect = SpriteEffects.None;
        public SpriteEffects Effect
        {
            get { return effect; }
            set { effect = value; }
        }
        float layerDepth = 0;
        public float LayerDepth
        {
            get { return layerDepth; }
            set { layerDepth = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Sprite(string asset, Rectangle position)
        {
            Asset = asset;
            Position = position;
        }

        public Sprite(Rectangle position)
        {
            Position = position;
        }
        public Sprite(Rectangle position, Rectangle? sourceRectangle)
        {
            Position = position;
            this.sourceRectangle = sourceRectangle;
        }
        public Sprite(Rectangle position, Rectangle? sourceRectangle, Color color)
        {
            Position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
        }
        public Sprite(Rectangle position, Rectangle? sourceRectangle, Color color, float
        rotation)
        {
            Position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
        }
        public Sprite(Rectangle position, Rectangle? sourceRectangle, Color color, float
        rotation, Vector2 origin)
        {
            Position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
        }
        public Sprite(Rectangle position, Rectangle? sourceRectangle, Color color, float
        rotation, Vector2 origin, Vector2 scale)
        {
            Position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
        }
        public Sprite(Rectangle position, Rectangle? sourceRectangle, Color color, float
        rotation, Vector2 origin, Vector2 scale, SpriteEffects effect)
        {
            Position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effect = effect;
        }
        public Sprite(Rectangle position, Rectangle? sourceRectangle, Color color, float
        rotation, Vector2 origin, Vector2 scale, SpriteEffects effect, float layerDepth)
        {
            Position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effect = effect;
            this.layerDepth = layerDepth;
        }
        #endregion

        #region INIT
        #endregion

        #region LOADCONTENT
        public virtual void LoadContent()
        {
            Texture = GD.content.Load<Texture2D>(Asset);
        }
        #endregion

        #region METHODS
        #endregion

        #region UPDATE & DRAW
        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
            GD.spriteBatch.Draw(Texture, new Vector2(Position.X, Position.Y), sourceRectangle, color, rotation,
          origin, scale, effect, layerDepth);
        }
        #endregion
    }
}
