using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace KillingStory
{
    public class Camera
    {
        protected ContentManager Content;//denna kommer skapa content över alla gamescreens jag har!
                                         //https://msdn.microsoft.com/en-us/library/microsoft.xna.framework.content.contentmanager.serviceprovider.aspx
        [XmlIgnore]
        public Type Type;

        public Camera()
        {
            Type = this.GetType();//varje klass kommer få denna type!
        }
        public virtual void LoadContent()
        {
            Content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }
        public virtual void UnloadContent()
        {
            Content.Unload();
        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        //de äldre funktionerna från tidigare uppgifter med logical coords visual coords osv.

        private int border;
        private float size;
        int height;
        int width;
        private float scale;
        private Vector2 position = Vector2.Zero;
        Viewport graphics;

        public Camera(Viewport Graphics)
        {
            graphics = Graphics;
            size = 100;
            border = 10;
            height = graphics.Height - border * 2; // har en höjd
            width = graphics.Width - border * 2; //har en bredd

            if (height < width)//om höjden är mindre än bredden så sätter vi bredden till höjden!
            {
                width = height;
            }
            else
            {
                height = width;
            }
            scale = width / size;
        }

        public Vector2 convertToLogicalCoords(float x, float y)
        {
            float logicalX = x / graphics.Width * size;
            float logicalY = y / graphics.Height * size;

            return new Vector2(logicalX, logicalY);
        }

        public Vector2 convertToVisualCoords(Vector2 coordinates)
        {
            float visualX = border + coordinates.X * scale;
            float visualY = border + coordinates.Y * scale;

            return new Vector2(visualX, visualY);
        }

        public float scaleSizeTo(float rawsize, float size)
        {
            return size / rawsize * scale;//när man har matrix
        }
    }
}
