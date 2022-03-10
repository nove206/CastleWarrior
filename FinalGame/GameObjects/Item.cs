using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalGame.GameObjects
{
    class Item : GameObject
    {
        //GameObject Ga = new GameObject();

        Random rnd = new Random();
        int i = 0;
        public enum ItemState
        {
            WAIT,
            HEALACTIVATE,
            METEORACTIVATE,
            DIE
        }
        public ItemState itemState;

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
        public Item(Texture2D texture) : base(texture)
        {

        }


        public override void Update(GameTime gameTime, List<GameObject> gameObjects)
        {
            switch (itemState)
            {

                case ItemState.WAIT:
                    {
                        
                        foreach (GameObject s in gameObjects)
                        {
                            if(IsTouching(s))
                            {
                                i = rnd.Next(3)+1;
                                if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && i == 1)
                                {
                                    Singleton.Instance.RedHaveItemHeal = true;
                                    Singleton.Instance.RndItemOnMap = true;
                                    itemState = ItemState.DIE;
                                    break;
                                }
                                else if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && i == 2)
                                {
                                    Singleton.Instance.RedHaveItemMeteor = true;
                                    Singleton.Instance.RndItemOnMap = true;
                                    itemState = ItemState.DIE;
                                    break;
                                }
                                else if (Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && i == 1)
                                {
                                    Singleton.Instance.BlueHaveItemHeal = true;
                                    Singleton.Instance.RndItemOnMap = true;
                                    itemState = ItemState.DIE;
                                    break;
                                }
                                else if (Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && i == 2)
                                {
                                    Singleton.Instance.BlueHaveItemMeteor = true;
                                    Singleton.Instance.RndItemOnMap = true;
                                    itemState = ItemState.DIE;
                                    break;
                                }
                            }
                            
                        }

                        break;
                    }
                case ItemState.HEALACTIVATE:
                    {
                        foreach (GameObject s in gameObjects)
                        {
                            if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && (s.Name.Equals("BlueArcher") || s.Name.Equals("BlueAxeman") || s.Name.Equals("BlueSpearman") || s.Name.Equals("BlueWizard")))
                            {
                                s.Hp += 15;
                            }  
                            else if (Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && (s.Name.Equals("RedArcher") || s.Name.Equals("RedAxeman") || s.Name.Equals("RedSpearman") || s.Name.Equals("RedWizard")))
                            {
                                s.Hp += 15;
                            } 
                        }
                        if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
                        {
                            Singleton.Instance.BlueHaveItemHeal = false;
                        }
                        else if(Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
                        {
                            Singleton.Instance.RedHaveItemHeal = false;
                        }
                        itemState = ItemState.WAIT;
                        break;
                    }
                case ItemState.METEORACTIVATE:
                    {
                        foreach (GameObject s in gameObjects)
                        {
                            if (Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && (s.Name.Equals("BlueArcher") || s.Name.Equals("BlueAxeman") || s.Name.Equals("BlueSpearman") || s.Name.Equals("BlueWizard")))
                            {
                                s.Hp -= 20;
                            }
                            else if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && (s.Name.Equals("RedArcher") || s.Name.Equals("RedAxeman") || s.Name.Equals("RedSpearman") || s.Name.Equals("RedWizard")))
                            {
                                s.Hp -= 20;
                            }
                        }
                        if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
                        {
                            Singleton.Instance.BlueHaveItemMeteor = false;
                        }
                        else if (Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
                        {
                            Singleton.Instance.RedHaveItemMeteor = false;
                        }
                        itemState = ItemState.WAIT;
                        break;
                    }
                case ItemState.DIE:
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
