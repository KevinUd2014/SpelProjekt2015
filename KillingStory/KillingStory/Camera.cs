using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillingStory
{
    class Camera
    {
        protected ContentManager Content;//denna kommer skapa content över alla gamescreens jag har!
                                         //https://msdn.microsoft.com/en-us/library/microsoft.xna.framework.content.contentmanager.serviceprovider.aspx
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
    }
}
