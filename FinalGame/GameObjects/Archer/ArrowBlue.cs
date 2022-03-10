using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalGame.GameObjects
{
    class ArrowBlue : GameObject
    {
        Random rnd = new Random();
        int i = 0;
        Vector2 Firstpo;
        public enum ArrowState
        {
            WAIT,
            FIRED,
            DIE
        }
        public ArrowState arrowStates;

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
        public ArrowBlue(Texture2D texture) : base(texture)
        {
           
        }


        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            switch (arrowStates)
            {
                
                case ArrowState.WAIT:
                    {
                        break;
                    }
                case ArrowState.FIRED:
                    {

                        if (Position.X <= 0 || Position.X >= Singleton.SCREENWIDTH || Position.Y <= 0 || Position.Y >= Singleton.SCREENHEIGHT)
                        {
                            IsActive = false;
                        }
                        if (IsActive && i % 2 == 0)
                        {
                            Position.Y += 1;
                            Velocity.Y -= 3;

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
                                arrowStates = ArrowState.DIE;
                            }
                        }
                        i++;
                        break;
                    }
                case ArrowState.DIE:
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
