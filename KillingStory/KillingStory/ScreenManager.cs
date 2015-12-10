using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillingStory
{
    class ScreenManager
    {
        Camera currentScreen;

        public Vector2 screenDimensions//denna kommer användas för att sätta skärmens storlek (dimensioner)
        {
            private set; get;
        }
        public ContentManager Content
        {
            private set; get;
        }

        private ScreenManager()//konstruktorn
        {
            screenDimensions = new Vector2(640, 480);
            currentScreen = new StartScreen();
        }
        private static ScreenManager instance;//skapar en instans
                                              //https://msdn.microsoft.com/en-us/library/k6sa6h87.aspx

        public static ScreenManager Instance
        {
            get//more efficient singleton //https://msdn.microsoft.com/en-us/library/ff650316.aspx
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;//när klassen kallas så kommer denna kallas om det inte är null!
            }
        }
        public void LoadContetnt(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }
        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
        //public void LoadContent(Content)
    }
}
