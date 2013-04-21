using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SoutenanceIII001
{
    public class cButton
    {
        #region FIELDS
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        Rectangle Placement;

        Color colour = new Color(255, 255, 255, 255);

        #endregion

        #region CONSTRUCTORS
        public cButton(Texture2D newTexture, Rectangle ouSurlaTexture)
        {
            texture = newTexture;
            Placement = ouSurlaTexture;

        }
        #endregion

        #region UPDATE & DRAW
        bool down;
        public bool isClicked;
        public void Update()
        {
            // rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            rectangle = new Rectangle((int)position.X, (int)position.Y, Placement.Width, Placement.Height);
            Rectangle mouseRectangle = new Rectangle(GD.mouse.X, GD.mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (colour.R == 255)
                    down = false;
                if (colour.R == 105)
                    down = true;
                if (down)
                    colour.R += 5;
                else
                    colour.R -= 5;
                if (GD.mouse.LeftButton == ButtonState.Pressed)
                    isClicked = true;
            }

            else if (colour.R < 255)
            {
                colour.R += 5;
                isClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw()
        {
            GD.spriteBatch.Draw(texture, rectangle, Placement, colour);
        }
        #endregion
    }
}

