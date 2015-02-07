﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RkoOuttaNowhere.Input;

namespace RkoOuttaNowhere.Screens
{
    public class SplashScreen : GameScreen
    {
        private bool _loaded;

        public SplashScreen()
            : base()
        {
            
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _backgroundImage.Path = "backgrounds/splash";
            _backgroundImage.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!_loaded)
            {
                ScreenManager.Instance.LoadAll();
                _loaded = true;
            }

            if(InputManager.Instance.KeyPressed(Keys.Enter)) 
            {
#if DEBUG
                ScreenManager.Instance.ChangeScreens(ScreenType.Gameplay);
#else
                ScreenManager.Instance.ChangeScreens(ScreenType.Title);
#endif
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
