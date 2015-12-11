using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillingStory
{
    public class StartScreen : Camera //ärver från kameraklassen
    {
        public Texture2D image;
        public string path;

        public override void LoadContent()
        {
            base.LoadContent();//har fortfarande från bas loadcontent
            path = "StartScreenImage2";
            image = Content.Load<Texture2D>(path);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            spriteBatch.Draw(image,Vector2.Zero, Color.White);
            //spriteBatch.End();
        }
    }
}
