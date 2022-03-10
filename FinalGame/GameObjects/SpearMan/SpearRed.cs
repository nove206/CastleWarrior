using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalGame.GameObjects
{
    class SpearRed : GameObject
    {
        Random rnd = new Random();
        int i = 0;
        public enum SpearState
        {
            WAIT,
            FIRED,
            DIE
        }
        public SpearState spearStates;

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
        public SpearRed(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            switch (spearStates)
            {

                case SpearState.WAIT:
                    {
                        break;
                    }
                case SpearState.FIRED:
                    {

                        if (Position.X <= 0 || Position.X >= Singleton.SCREENWIDTH || Position.Y <= 0 || Position.Y >= Singleton.SCREENHEIGHT)
                        {
                            IsActive = false;
                        }
                        if (IsActive && i % 2 == 0)
                        {
                            Position.Y += 1;
                            Velocity.Y -= 5;

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
                            if (IsTouching(s) && (s.Name.Equals("BlueArcher") || s.Name.Equals("BlueAxeman") || s.Name.Equals("BlueSpearman") || s.Name.Equals("BlueWizard") || s.Name.Equals("BlueFlag")))
                            {
                                s.Hp -= rnd.Next(2) + 12;
                                spearStates = SpearState.DIE;
                            }
                        }
                        i++;
                        break;
                    }
                case SpearState.DIE:
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
