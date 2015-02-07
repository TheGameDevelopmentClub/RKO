﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RkoOuttaNowhere.Input;
using RkoOuttaNowhere.Gameplay;
using RkoOuttaNowhere.Gameplay.Units;

namespace RkoOuttaNowhere.Screens
{
    public class GameplayScreen : GameScreen
    {

        private Player _player;
        private List<Unit> _units;
        public GameplayScreen()
            : base()
        {
            _player = new Player();
            _units = new List<Unit>();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _backgroundImage.Path = "backgrounds/gameplay";
            _backgroundImage.LoadContent();
            _player.LoadContent();

            // Test unit
            Unit u = new Unit();
            u.LoadContent("testUnit", new Vector2(0, 300), 100, 100);
            _units.Add(u);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            _player.UnloadContent();

            foreach (Unit u in _units)
            {
                u.UnloadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // Process input
            if (InputManager.Instance.KeyPressed(Keys.U))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.Upgrade);
            }
            else if (InputManager.Instance.KeyPressed(Keys.X))
            {
                ScreenManager.Instance.ChangeScreens(ScreenType.GameOver);
            }
            _player.Update(gameTime);
            _player.laserHitEnemy(_units);
            // Process units
            foreach (Unit u in _units)
            {
                u.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            _player.Draw(spriteBatch);
            // Process units
            foreach (Unit u in _units)
            {
                u.Draw(spriteBatch);
            }
        }
    }
}
