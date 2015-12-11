using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillingStory
{
    class ScreenManager
    {
        Camera currentScreen;

        //mouse
        Texture2D cursorImage;
        Vector2 cursorPos;
        Camera camera = new Camera();

        private float radius = 10f;

        public Vector2 screenDimensions//denna kommer användas för att sätta skärmens storlek (dimensioner)
        {
            private set; get;
        }
        public ContentManager Content
        {
            private set; get;
        }
        XMLDAL<Camera> xmlScreenManager;

        private ScreenManager()//konstruktorn
        {
            screenDimensions = new Vector2(640, 480);//sätter storleken på skärmen!
            //cursorImage = CursorImage;
            currentScreen = new StartScreen();
            //xmlScreenManager = new XMLDAL<Camera>();
            //xmlScreenManager.type = currentScreen.Type;
            //currentScreen = xmlScreenManager.Load("Load/StartScreen.xml");
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
            MouseState mouseState = Mouse.GetState();
            cursorPos = new Vector2(mouseState.X, mouseState.Y);
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(cursorImage,
            //    cursorPos,
            //    null, Color.White,
            //    0f,
            //    new Vector2(cursorImage.Width / 2, cursorImage.Height / 2),//denna sätter ut cirkeln!
            //    camera.scaleSizeTo(cursorImage.Width, radius * 2),
            //    SpriteEffects.None,
            //    0f);//denna håller koll på muspekarbilden!
            currentScreen.Draw(spriteBatch);
        }
        //public void LoadContent(Content)
    }
}
