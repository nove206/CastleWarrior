using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalGame.GameObjects
{
    class WizardBulletBlue : GameObject
    {
        int i = 0;
        Random rnd = new Random();
        public enum WizardBulletState
        {
            WAIT,
            BULLETFIRED,
            FIREBALLFIRED,
            THUNDERFIRED,
            DIE
        }
        public WizardBulletState wizardbulletStates;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,
                            Position,
                            Viewport,
                            Color.White);
            base.Draw(spriteBatch);
        }

        public override void Reset()
        {
            base.Reset();
        }
        public WizardBulletBlue(Texture2D texture) : base(texture)
        {

        }


        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            switch (wizardbulletStates)
            {

                case WizardBulletState.WAIT:
                    {
                        break;
                    }
                case WizardBulletState.BULLETFIRED:
                    {

                        if (Position.X <= 0 || Position.X >= Singleton.SCREENWIDTH || Position.Y <= 0 || Position.Y >= Singleton.SCREENHEIGHT)
                        {

                            IsActive = false;
                        }
                        if (IsActive && i % 2 == 0)
                        {
                            Position.Y += 1;
                            Velocity.Y -= 4;

                        }
                        if (IsActive && i % 5 == 0)
                        {
                            Velocity.X -= Singleton.Instance.Wind * 0.4f;
                            i = 0;
                        }
                        BDirection.X = (float)Math.Cos(Angle);
                        BDirection.Y = (float)Math.Sin(Angle);
                        Position -= BDirection * Velocity * gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;

                        foreach (GameObject s in gameObjects)
                        {
                            if (IsTouching(s) && (s.Name.Equals("RedArcher") || s.Name.Equals("RedAxeman") || s.Name.Equals("RedSpearman") || s.Name.Equals("RedWizard") || s.Name.Equals("RedFlag")))
                            {
                                s.Hp -= rnd.Next(4) + 12;
                                wizardbulletStates = WizardBulletState.DIE;
                            }
                        }
                        i++;
                        break;
                    }
                case WizardBulletState.FIREBALLFIRED:
                    {

                        if (Position.X <= 0 || Position.X >= Singleton.SCREENWIDTH || Position.Y <= 0 || Position.Y >= Singleton.SCREENHEIGHT)
                        {

                            IsActive = false;
                        }
                        if (IsActive && i % 2 == 0)
                        {
                            Position.Y += 1;
                            Velocity.Y -= 4;

                        }
                        if (IsActive && i % 5 == 0)
                        {
                            Velocity.X -= Singleton.Instance.Wind * 0.4f;
                            i = 0;
                        }
                        BDirection.X = (float)Math.Cos(Angle);
                        BDirection.Y = (float)Math.Sin(Angle);
                        Position -= BDirection * Velocity * gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;

                        foreach (GameObject s in gameObjects)
                        {
                            if (IsTouching(s) && (s.Name.Equals("RedArcher") || s.Name.Equals("RedAxeman") || s.Name.Equals("RedSpearman") || s.Name.Equals("RedWizard")))
                            {
                                s.Hp -= rnd.Next(4) + 8;
                                wizardbulletStates = WizardBulletState.DIE;
                            }
                            if (IsTouching(s) && (s.Name.Equals("RedFlag")))
                            {
                                s.Hp -= rnd.Next(9) + 15;
                                wizardbulletStates = WizardBulletState.DIE;
                            }
                        }
                        i++;
                        break;
                    }
                case WizardBulletState.THUNDERFIRED:
                    {

                        if (Position.X <= 0 || Position.X >= Singleton.SCREENWIDTH || Position.Y <= 0 || Position.Y >= Singleton.SCREENHEIGHT)
                        {

                            IsActive = false;
                        }
                        if (IsActive && i % 2 == 0)
                        {
                            Position.Y += 1;
                            Velocity.Y -= 4;

                        }
                        if (IsActive && i % 5 == 0)
                        {
                            Velocity.X -= Singleton.Instance.Wind * 0.4f;
                            i = 0;
                        }
                        BDirection.X = (float)Math.Cos(Angle);
                        BDirection.Y = (float)Math.Sin(Angle);
                        Position -= BDirection * Velocity * gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;

                        foreach (GameObject s in gameObjects)
                        {
                            if (IsTouching(s) && (s.Name.Equals("RedArcher") || s.Name.Equals("RedAxeman") || s.Name.Equals("RedSpearman") || s.Name.Equals("RedWizard")))
                            {
                                s.Hp -= rnd.Next(9) + 15;
                                wizardbulletStates = WizardBulletState.DIE;
                            }
                            if (IsTouching(s) && s.Name.Equals("RedFlag"))
                            {
                                s.Hp -= rnd.Next(4) + 8;
                                wizardbulletStates = WizardBulletState.DIE;
                            }
                        }
                        i++;
                        break;
                    }
                case WizardBulletState.DIE:
                    {
                        IsActive = false;
                        break;
                    }
                default:
                    break;
            }
            base.Update(gameTime, gameObjects);
        }
    }

}
