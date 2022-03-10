using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using FinalGame.GameObjects;
using System;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace FinalGame
{
    public class MainGames : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        SpriteFont _spriteFont;
        SpriteFont TextUI;
        List<GameObject> _gameObjects;
        ArcherBlue BArcher;
        ArcherRed RArcher;
        AxeManBlue BAxeman;
        AxeManRed RAxeman;
        SpearManBlue BSpearman;
        SpearManRed RSpearman;
        WizardBlue BWizard;
        WizardRed RWizard;
        AxeBlue _BlueAxeshooted, _BlueNextAxe;
        AxeRed _RedAxeshooted, _RedNextAxe;
        ArrowBlue _BlueArrowshooted, _BlueNextArrow;
        ArrowRed _RedArrowshooted, _RedNextArrow;
        SpearBlue _BlueSpearshooted, _BlueNextSpear;
        SpearRed _RedSpearshooted, _RedNextSpear;
        WizardBulletBlue _BlueWizardBulletshooted, _BlueWizardBulletshooted2, _BlueWizardBulletshooted3, _BlueNextWizardBullet, _BlueNextWizardBullet2, _BlueNextWizardBullet3;
        WizardBulletRed _RedWizardBulletshooted, _RedWizardBulletshooted2, _RedWizardBulletshooted3, _RedNextWizardBullet, _RedNextWizardBullet2, _RedNextWizardBullet3;//--
        Flag BFlag;
        Flag RFlag;
        Item DItem;

        Song _bgm, _bgp;
        Boolean PlaySong = false, PlayEffect = false;
        SoundEffectInstance SongWin, Archershoot, Axeshoot, Spearshoot, Wizardshoot, GetItem, WariorDie;

        long time;
        float tick, Cooldown, test1, test2, countRndWizard;
        int _numObject, PoXI, PoYI;
        Texture2D background, StartPage, BlueArcher, BlueArrow, RedArcher, RedArrow, BlueAxeman, BlueAxe, RedAxeman, RedAxe, BlueSpearman, BlueSpear,
            RedSpearman, RedSpear, BlueWizardBullet, RedWizardBullet, BlueWizard, RedWizard, BlueFireBall, BLUEThunder, RedFireBall, REDThunder;
        Texture2D BlueCastle1, RedCastle1, Ground, ChaBoard, BlueFlag, RedFlag, ItemNaja, AttackBotton, ItemMeteor, ItemHeal;
        Texture2D BLUEArchermark, BLUEAxemanmark, BLUESpearmanmark, BLUEWizardmark, PopUpBluewin, PopUpRedwin;
        Texture2D REDArchermark, REDAxemanmark, REDSpearmanmark, REDWizardmark, minHP, maxHP, TextTurnBlue, TextTurnRed;
        Vector2 mousePosition, fontLength;
        String Text = "---", Turn = "BlueTurn";
        Boolean randWind = false, randwizard = false;
        Boolean ResetAP = false;
        Random rnd;




        public MainGames()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = Singleton.SCREENWIDTH;
            graphics.PreferredBackBufferHeight = Singleton.SCREENHEIGHT;
            graphics.ApplyChanges();
            _gameObjects = new List<GameObject>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Images/Background");
            StartPage = Content.Load<Texture2D>("Images/StartPage");
            BlueArcher = Content.Load<Texture2D>("Images/BLUEArcher");
            BlueArrow = Content.Load<Texture2D>("Images/BlueArrow");
            RedArcher = Content.Load<Texture2D>("Images/RedArcher");
            RedArrow = Content.Load<Texture2D>("Images/RedArrow");
            BlueAxeman = Content.Load<Texture2D>("Images/BLUEAxeman");
            BlueAxe = Content.Load<Texture2D>("Images/BLUEAxe");
            RedAxeman = Content.Load<Texture2D>("Images/RedAxeman");
            RedAxe = Content.Load<Texture2D>("Images/RedAxe");
            BlueSpearman = Content.Load<Texture2D>("Images/BlueSpearman");
            BlueSpear = Content.Load<Texture2D>("Images/BlueSpear");
            RedSpearman = Content.Load<Texture2D>("Images/RedSpearman");
            RedSpear = Content.Load<Texture2D>("Images/RedSpear");
            BlueWizard = Content.Load<Texture2D>("Images/BlueWizard");
            BlueWizardBullet = Content.Load<Texture2D>("Images/BlueWizardBullet");
            RedWizard = Content.Load<Texture2D>("Images/RedWizard");
            RedWizardBullet = Content.Load<Texture2D>("Images/RedWizardBullet");
            _spriteFont = Content.Load<SpriteFont>("Fonts/GameText");
            BlueCastle1 = Content.Load<Texture2D>("Images/BlueCastle1");
            RedCastle1 = Content.Load<Texture2D>("Images/RedCastle1");
            Ground = Content.Load<Texture2D>("Images/Ground");
            BLUEArchermark = Content.Load<Texture2D>("Images/Bmark/BLUEArcher");
            BLUEAxemanmark = Content.Load<Texture2D>("Images/Bmark/BLUEAxeman");
            BLUESpearmanmark = Content.Load<Texture2D>("Images/Bmark/BLUESpearman");
            BLUEWizardmark = Content.Load<Texture2D>("Images/Bmark/BLUEWizard");
            BlueFireBall = Content.Load<Texture2D>("Images/BLUEFireball");
            BLUEThunder = Content.Load<Texture2D>("Images/BLUEThunder");
            RedFireBall = Content.Load<Texture2D>("Images/REDFireBall");//--
            REDThunder = Content.Load<Texture2D>("Images/REDThunder");//--
            maxHP = Content.Load<Texture2D>("Images/maxHP");
            minHP = Content.Load<Texture2D>("Images/minHP");
            REDArchermark = Content.Load<Texture2D>("Images/Rmark/REDArcher");
            REDAxemanmark = Content.Load<Texture2D>("Images/Rmark/REDAxeman");
            REDSpearmanmark = Content.Load<Texture2D>("Images/Rmark/REDSpearman");
            REDWizardmark = Content.Load<Texture2D>("Images/Rmark/REDWizard");
            BlueFlag = Content.Load<Texture2D>("Images/BlueFlag");
            RedFlag = Content.Load<Texture2D>("Images/RedFlag");
            ItemNaja = Content.Load<Texture2D>("Images/Item");
            TextUI = Content.Load<SpriteFont>("Fonts/FontUI");
            AttackBotton = Content.Load<Texture2D>("Images/AttackButton");
            ItemMeteor = Content.Load<Texture2D>("Images/ItemMeteor");
            ItemHeal = Content.Load<Texture2D>("Images/ItemHeal");
            TextTurnBlue = Content.Load<Texture2D>("Images/TextTurnBlue");
            TextTurnRed = Content.Load<Texture2D>("Images/TextTurnRed");

            PopUpBluewin = Content.Load<Texture2D>("Images/PopUpBluewin");
            PopUpRedwin = Content.Load<Texture2D>("Images/PopUpRedwin");


            _bgm = Content.Load<Song>("Song/_bgm");
            _bgp = Content.Load<Song>("Song/_bgp");
            SongWin = Content.Load<SoundEffect>("Song/SongWin").CreateInstance();
            Archershoot = Content.Load<SoundEffect>("Song/Archershoot").CreateInstance();
            Axeshoot = Content.Load<SoundEffect>("Song/Archershoot").CreateInstance();
            Spearshoot = Content.Load<SoundEffect>("Song/Spearshoot").CreateInstance();
            Wizardshoot = Content.Load<SoundEffect>("Song/Wizardshoot").CreateInstance();
            WariorDie = Content.Load<SoundEffect>("Song/WariorDie").CreateInstance();
            GetItem = Content.Load<SoundEffect>("Song/GetItem").CreateInstance();


            ChaBoard = Content.Load<Texture2D>("Images/ChaBoard");
            Singleton.Instance.CurrentGameState = Singleton.GameState.GameStart;
            Singleton.Instance.CurrentTurn = Singleton.TurnState.BlueTurn;
            Singleton.Instance.CurrentCharecter = Singleton.SelectCharecter.SelectArcher;
            Singleton.Instance.CurrentWizardshootRed = Singleton.WizardTypeShoot.Bullet;
            Singleton.Instance.CurrentWizardshootBlue = Singleton.WizardTypeShoot.Bullet;
            rnd = new Random();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            Singleton.Instance.PreviousMouse = Singleton.Instance.CurrentMouse;
            Singleton.Instance.CurrentMouse = Mouse.GetState();
            Singleton.Instance.PreviousKey = Singleton.Instance.CurrentKey;
            Singleton.Instance.CurrentKey = Keyboard.GetState();
            switch (Singleton.Instance.CurrentGameState)
            {
                case Singleton.GameState.GameStart:
                    {
                        if (!Singleton.Instance.CurrentKey.Equals(Singleton.Instance.PreviousKey) && Singleton.Instance.CurrentKey.IsKeyDown(Keys.Space))
                        {

                            //Space keys pressed to start
                            Reset();
                            MediaPlayer.Stop();
                            PlaySong = false;
                            Singleton.Instance.CurrentGameState = Singleton.GameState.GamePlaying;
                            Singleton.Instance.BlueHaveItemMeteor = false;
                            Singleton.Instance.RedHaveItemMeteor = false;
                            Singleton.Instance.BlueHaveItemHeal = false;
                            Singleton.Instance.RedHaveItemHeal = false;
                        }
                        if (!Singleton.Instance.CurrentKey.Equals(Singleton.Instance.PreviousKey) && Singleton.Instance.CurrentKey.IsKeyDown(Keys.Escape))
                        {
                            //Space keys pressed to start
                            this.Exit();
                        }
                        //Singleton.Instance.CurrentGameState = Singleton.GameState.SelectCastle;
                        break;
                    }
                case Singleton.GameState.SelectCastle:
                    {

                        Singleton.Instance.CurrentGameState = Singleton.GameState.SelectWarrior;
                        break;
                    }
                case Singleton.GameState.SelectWarrior:
                    {

                        Singleton.Instance.CurrentGameState = Singleton.GameState.GamePlaying;
                        break;
                    }
                case Singleton.GameState.GamePlaying:
                    {
                        Cooldown += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        _numObject = _gameObjects.Count;
                        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                            Exit();
                        mousePosition = new Vector2(Singleton.Instance.CurrentMouse.X, Singleton.Instance.CurrentMouse.Y);


                        // TODO: Add your update logic here
                        tick += gameTime.ElapsedGameTime.Ticks / (float)TimeSpan.TicksPerSecond;
                        time += gameTime.ElapsedGameTime.Ticks;
                        setAnglePower();
                        checkAnglePower();
                        SelectCharec();
                        CheckWin();
                        if (!randWind)
                        {
                            Singleton.Instance.Wind = rnd.Next(11) - 5;
                            randWind = true;
                        }
                        if (Singleton.Instance.RndItemOnMap)
                        {
                            PoXI = rnd.Next(400) + 400;
                            PoYI = rnd.Next(300) + 400;
                            Item DropItem = DItem;
                            DropItem.itemState = Item.ItemState.WAIT;
                            DropItem.Position.X = PoXI;
                            DropItem.Position.Y = PoYI;
                            DropItem.IsActive = true;
                            _gameObjects.Add(DItem);
                            Singleton.Instance.RndItemOnMap = false;
                        }
                        if (ResetAP)
                        {
                            ResetStat();
                            ResetAP = false;
                        }
                        if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && Singleton.Instance.CurrentKey.IsKeyDown(Keys.Z) && Singleton.Instance.BlueHaveItemMeteor)
                        {
                            DItem.itemState = Item.ItemState.METEORACTIVATE;
                            Singleton.Instance.BlueHaveItemMeteor = false;
                            //Singleton.Instance.RndItemOnMap = true;
                        }
                        if (Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && Singleton.Instance.CurrentKey.IsKeyDown(Keys.Z) && Singleton.Instance.RedHaveItemMeteor)
                        {
                            DItem.itemState = Item.ItemState.METEORACTIVATE;
                            Singleton.Instance.RedHaveItemMeteor = false;
                            //Singleton.Instance.RndItemOnMap = true;
                        }
                        if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && Singleton.Instance.CurrentKey.IsKeyDown(Keys.X) && Singleton.Instance.BlueHaveItemHeal)
                        {
                            DItem.itemState = Item.ItemState.HEALACTIVATE;
                            Singleton.Instance.BlueHaveItemHeal = false;
                            //Singleton.Instance.RndItemOnMap = true;
                        }
                        if (Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && Singleton.Instance.CurrentKey.IsKeyDown(Keys.X) && Singleton.Instance.RedHaveItemHeal)
                        {
                            DItem.itemState = Item.ItemState.HEALACTIVATE;
                            Singleton.Instance.RedHaveItemHeal = false;
                            //Singleton.Instance.RndItemOnMap = true;
                        }


                        if ((Singleton.Instance.PreviousMouse.LeftButton == ButtonState.Pressed && Singleton.Instance.CurrentMouse.LeftButton == ButtonState.Released)
                            && mousePosition.X <= 680 && mousePosition.X >= 520 && mousePosition.Y <= 220 && mousePosition.Y >= 140
                            && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
                        {
                            {
                                Archershoot.Volume = 0.75f;
                                Archershoot.Play();
                                Axeshoot.Volume = 0.75f;
                                Axeshoot.Play();
                                Spearshoot.Volume = 0.75f;
                                Spearshoot.Play();
                                Wizardshoot.Volume = 0.75f;
                                Wizardshoot.Play();
                                //blue shot arrow
                                if (BArcher.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
                                {

                                    ArrowBlue BArrow = _BlueArrowshooted;
                                    BArrow.Position = new Vector2(Singleton.Instance.XPositionBArcher, Singleton.Instance.YPositionBArcher + (Singleton.ARCHERHEIGHT / 2));
                                    BArrow.Name = "BlueArrow";
                                    BArrow.arrowStates = ArrowBlue.ArrowState.FIRED;
                                    BArrow.Velocity = new Vector2((2 * Singleton.Instance.BPowerArcher) + 175, Singleton.Instance.BPowerArcher + 100);
                                    BArrow.Angle = (float)((180 - Singleton.Instance.BAngleArcher) * (Math.PI / 180));
                                    BArrow.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                    BArrow.Rotation = 45;
                                    _gameObjects.Add(_BlueArrowshooted);

                                    //after blue shot arrow

                                    _BlueArrowshooted = _BlueNextArrow;
                                    _BlueNextArrow = new ArrowBlue(BlueArrow)
                                    {
                                        IsActive = true,
                                        Name = "NextBlueArrow",
                                        Viewport = new Rectangle(0, 0, Singleton.ARROWWIDTH, Singleton.ARROWHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionBArcher, Singleton.Instance.YPositionBArcher + (Singleton.ARCHERHEIGHT / 2)),
                                    };

                                    _gameObjects.Add(_BlueNextArrow);
                                    Cooldown = 0;
                                }

                                //blue shot axe
                                if (BAxeman.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
                                {
                                    AxeBlue BAxe = _BlueAxeshooted;
                                    BAxe.Position = new Vector2(Singleton.Instance.XPositionBAxeman, Singleton.Instance.YPositionBAxeman);
                                    BAxe.Name = "BlueAxe";
                                    BAxe.axeStates = AxeBlue.AxeState.FIRED;
                                    BAxe.Velocity = new Vector2((2 * Singleton.Instance.BPowerAxeman) + 100, Singleton.Instance.BPowerAxeman + 100);
                                    BAxe.Angle = (float)((180 - Singleton.Instance.BAngleAxeman) * (Math.PI / 180));
                                    BAxe.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                    _gameObjects.Add(_BlueAxeshooted);

                                    //after blue shot axe

                                    _BlueAxeshooted = _BlueNextAxe;

                                    _BlueNextAxe = new AxeBlue(BlueAxe)
                                    {
                                        IsActive = true,
                                        Name = "NextBlueAxe",
                                        Viewport = new Rectangle(0, 0, Singleton.AXEWIDTH, Singleton.AXEHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionBAxeman, Singleton.Instance.YPositionBAxeman),
                                    };

                                    _gameObjects.Add(_BlueNextAxe);
                                    Cooldown = 0;
                                }

                                //blue shot spear
                                if (BSpearman.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
                                {
                                    SpearBlue BSpear = _BlueSpearshooted;
                                    BSpear.Position = new Vector2(Singleton.Instance.XPositionBSpearman, Singleton.Instance.YPositionBSpearman + (Singleton.SPEARMANHEIGHT / 2) - 5);
                                    BSpear.Name = "BlueSpear";
                                    BSpear.spearStates = SpearBlue.SpearState.FIRED;
                                    BSpear.Velocity = new Vector2((2 * Singleton.Instance.BPowerSpearman) + 150, Singleton.Instance.BPowerSpearman + 100);
                                    BSpear.Angle = (float)((180 - Singleton.Instance.BAngleSpearman) * (Math.PI / 180));
                                    BSpear.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                    _gameObjects.Add(_BlueSpearshooted);

                                    //after blue shot spear

                                    _BlueSpearshooted = _BlueNextSpear;
                                    _BlueNextSpear = new SpearBlue(BlueSpear)
                                    {
                                        IsActive = true,
                                        Name = "NextBlueSpear",
                                        Viewport = new Rectangle(0, 0, Singleton.SPEARWIDTH, Singleton.SPEARHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionBSpearman, Singleton.Instance.YPositionBSpearman + (Singleton.SPEARMANHEIGHT / 2) - 5),
                                    };

                                    _gameObjects.Add(_BlueNextSpear);
                                    Cooldown = 0;
                                }

                                //blue shot wizardbullet
                                // กระสุน3แฉกพ่อมด
                                if (BWizard.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Bullet)
                                {
                                    WizardBulletBlue BWizardBullet = _BlueWizardBulletshooted;
                                    BWizardBullet.IsActive = true;
                                    BWizardBullet.Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard);
                                    BWizardBullet.Name = "BlueWizardbullet";
                                    BWizardBullet.wizardbulletStates = WizardBulletBlue.WizardBulletState.BULLETFIRED;
                                    BWizardBullet.Velocity = new Vector2((2 * Singleton.Instance.BPowerWizard) + 130, Singleton.Instance.BPowerWizard + 100);
                                    BWizardBullet.Angle = (float)((180 - Singleton.Instance.BAngleWizard +10) * (Math.PI / 180));
                                    BWizardBullet.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                    _gameObjects.Add(_BlueWizardBulletshooted);

                                    WizardBulletBlue BWizardBullet2 = _BlueWizardBulletshooted2;
                                    BWizardBullet2.IsActive = true;
                                    BWizardBullet2.Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard);
                                    BWizardBullet2.Name = "BlueWizardbullet2";
                                    BWizardBullet2.wizardbulletStates = WizardBulletBlue.WizardBulletState.BULLETFIRED;
                                    BWizardBullet2.Velocity = new Vector2((2 * Singleton.Instance.BPowerWizard) + 135, Singleton.Instance.BPowerWizard + 100);
                                    BWizardBullet2.Angle = (float)((180 - Singleton.Instance.BAngleWizard ) * (Math.PI / 180));
                                    BWizardBullet2.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                    _gameObjects.Add(_BlueWizardBulletshooted2);

                                    WizardBulletBlue BWizardBullet3 = _BlueWizardBulletshooted3;
                                    BWizardBullet3.IsActive = true;
                                    BWizardBullet3.Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard);
                                    BWizardBullet3.Name = "BlueWizardbullet3";
                                    BWizardBullet3.wizardbulletStates = WizardBulletBlue.WizardBulletState.BULLETFIRED;
                                    BWizardBullet3.Velocity = new Vector2((2 * Singleton.Instance.BPowerWizard) + 140, Singleton.Instance.BPowerWizard + 100);
                                    BWizardBullet3.Angle = (float)((180 - Singleton.Instance.BAngleWizard - 10) * (Math.PI / 180));
                                    BWizardBullet3.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                    _gameObjects.Add(_BlueWizardBulletshooted3);

                                    //after blue shot wizardbullet
                                    RndWizardBlue();
                                    if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Bullet)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                        _BlueNextWizardBullet2 = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet2",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet2);
                                        _BlueWizardBulletshooted2 = _BlueNextWizardBullet2;
                                        _BlueNextWizardBullet3 = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet3",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet3);
                                        _BlueWizardBulletshooted3 = _BlueNextWizardBullet3;
                                        Cooldown = 0;
                                    }
                                    else if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Fireball)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BlueFireBall)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.FIREBALLWIDTH, Singleton.FIREBALLHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        Cooldown = 0;
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                    }
                                    else if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Thunder)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BLUEThunder)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.THUNDERWIDTH, Singleton.THUNDERHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        Cooldown = 0;
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                    }
                                }
                                // กระสุนไฟพ่อมด
                                else if (BWizard.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Fireball)
                                {
                                    WizardBulletBlue BWizardBullet = _BlueWizardBulletshooted;
                                    BWizardBullet.IsActive = true;
                                    BWizardBullet.Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard);
                                    BWizardBullet.Name = "BlueWizardbullet";
                                    BWizardBullet.wizardbulletStates = WizardBulletBlue.WizardBulletState.BULLETFIRED;
                                    BWizardBullet.Velocity = new Vector2((2 * Singleton.Instance.BPowerWizard) + 130, Singleton.Instance.BPowerWizard + 100);
                                    BWizardBullet.Angle = (float)((180 - Singleton.Instance.BAngleWizard) * (Math.PI / 180));
                                    BWizardBullet.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                    _gameObjects.Add(_BlueWizardBulletshooted);
                                    //after Blue shot wizardbullet
                                    RndWizardBlue();
                                    if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Bullet)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                        _BlueNextWizardBullet2 = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet2",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet2);
                                        _BlueWizardBulletshooted2 = _BlueNextWizardBullet2;
                                        _BlueNextWizardBullet3 = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet3",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet3);
                                        _BlueWizardBulletshooted3 = _BlueNextWizardBullet3;
                                        Cooldown = 0;
                                    }
                                    else if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Fireball)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BlueFireBall)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.FIREBALLWIDTH, Singleton.FIREBALLHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        Cooldown = 0;
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                    }
                                    else if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Thunder)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BLUEThunder)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.THUNDERWIDTH, Singleton.THUNDERHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        Cooldown = 0;
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                    }
                                }
                                // กระสุนสายฟ้าพ่อมด
                                else if (BWizard.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn && Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Thunder)
                                {
                                    WizardBulletBlue BWizardBullet = _BlueWizardBulletshooted;
                                    BWizardBullet.IsActive = true;
                                    BWizardBullet.Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard);
                                    BWizardBullet.Name = "Wizardbullet";
                                    BWizardBullet.wizardbulletStates = WizardBulletBlue.WizardBulletState.BULLETFIRED;
                                    BWizardBullet.Velocity = new Vector2((2 * Singleton.Instance.BPowerWizard) + 130, Singleton.Instance.BPowerWizard + 100);
                                    BWizardBullet.Angle = (float)((180 - Singleton.Instance.BAngleWizard) * (Math.PI / 180));
                                    BWizardBullet.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                    _gameObjects.Add(_BlueWizardBulletshooted);
                                    //after Blue shot wizardbullet
                                    RndWizardBlue();
                                    if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Bullet)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                        _BlueNextWizardBullet2 = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet2",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet2);
                                        _BlueWizardBulletshooted2 = _BlueNextWizardBullet2;
                                        _BlueNextWizardBullet3 = new WizardBulletBlue(BlueWizardBullet)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet3",
                                            Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet3);
                                        _BlueWizardBulletshooted3 = _BlueNextWizardBullet3;
                                        Cooldown = 0;
                                    }
                                    else if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Fireball)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BlueFireBall)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.FIREBALLWIDTH, Singleton.FIREBALLHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        Cooldown = 0;
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                    }
                                    else if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Thunder)
                                    {
                                        _BlueNextWizardBullet = new WizardBulletBlue(BLUEThunder)
                                        {
                                            IsActive = true,
                                            Name = "NextBlueWizardBullet",
                                            Viewport = new Rectangle(0, 0, Singleton.THUNDERWIDTH, Singleton.THUNDERHEIGHT),
                                            Position = new Vector2(Singleton.Instance.XPositionBWizard +30, Singleton.Instance.YPositionBWizard),
                                        };
                                        _gameObjects.Add(_BlueNextWizardBullet);
                                        Cooldown = 0;
                                        _BlueWizardBulletshooted = _BlueNextWizardBullet;
                                    }
                                }
                                randWind = false;
                                //ResetAP = true;
                                Singleton.Instance.CurrentTurn = Singleton.TurnState.RedTurn;
                                Turn = "RedTurn";
                            }
                        }

                        else if ((Singleton.Instance.PreviousMouse.LeftButton == ButtonState.Pressed && Singleton.Instance.CurrentMouse.LeftButton == ButtonState.Released)
                            && mousePosition.X <= 680 && mousePosition.X >= 520 && mousePosition.Y <= 220 && mousePosition.Y >= 140
                            && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
                        {
                            Archershoot.Volume = 0.75f;
                            Archershoot.Play();
                            Axeshoot.Volume = 0.75f;
                            Axeshoot.Play();
                            Spearshoot.Volume = 0.75f;
                            Spearshoot.Play();
                            Wizardshoot.Volume = 0.75f;
                            Wizardshoot.Play();
                            //red shot arrow
                            if (RArcher.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
                            {

                                ArrowRed RArrow = _RedArrowshooted;
                                RArrow.Position = new Vector2(Singleton.Instance.XPositionRArcher, Singleton.Instance.YPositionRArcher + (Singleton.ARCHERHEIGHT / 2));
                                RArrow.Name = "RedArrow";
                                RArrow.arrowStates = ArrowRed.ArrowState.FIRED;
                                RArrow.Velocity = new Vector2((2 * Singleton.Instance.RPowerArcher) + 175, Singleton.Instance.RPowerArcher + 100);
                                RArrow.Angle = (float)(Singleton.Instance.RAngleArcher * (Math.PI / 180));
                                RArrow.Resistance = new Vector2(0, Singleton.Instance.Gravity);


                                _gameObjects.Add(_RedArrowshooted);

                                //after red shot arrow

                                _RedArrowshooted = _RedNextArrow;

                                _RedNextArrow = new ArrowRed(RedArrow)
                                {
                                    IsActive = true,
                                    Name = "NextRedArrow",
                                    Viewport = new Rectangle(0, 0, Singleton.ARROWWIDTH, Singleton.ARROWHEIGHT),
                                    Position = new Vector2(Singleton.Instance.XPositionRArcher, Singleton.Instance.YPositionRArcher + (Singleton.ARCHERHEIGHT / 2)),
                                };

                                _gameObjects.Add(_RedNextArrow);
                                Cooldown = 0;
                            }

                            //red shot axe
                            if (RAxeman.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
                            {

                                AxeRed RAxe = _RedAxeshooted;
                                RAxe.Position = new Vector2(Singleton.Instance.XPositionRAxeman + 20, Singleton.Instance.YPositionRAxeman);
                                RAxe.Name = "RedAxe";
                                RAxe.axeStates = AxeRed.AxeState.FIRED;
                                RAxe.Velocity = new Vector2((2 * Singleton.Instance.RPowerArcher) + 100, Singleton.Instance.RPowerArcher + 100);
                                RAxe.Angle = (float)(Singleton.Instance.RAngleAxeman * (Math.PI / 180));
                                RAxe.Resistance = new Vector2(0, Singleton.Instance.Gravity);


                                _gameObjects.Add(_RedAxeshooted);

                                //after red shot axe
                                _RedAxeshooted = _RedNextAxe;

                                _RedNextAxe = new AxeRed(RedAxe)
                                {
                                    IsActive = true,
                                    Name = "NextRedAxe",
                                    Viewport = new Rectangle(0, 0, Singleton.AXEWIDTH, Singleton.AXEHEIGHT),
                                    Position = new Vector2(Singleton.Instance.XPositionRAxeman + 20, Singleton.Instance.YPositionRAxeman),
                                };

                                _gameObjects.Add(_RedNextAxe);
                                Cooldown = 0;
                            }

                            //red shot Spear
                            if (RSpearman.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
                            {

                                SpearRed RSpear = _RedSpearshooted;
                                RSpear.Position = new Vector2(Singleton.Instance.XPositionRSpearman, Singleton.Instance.YPositionRSpearman + (Singleton.SPEARMANHEIGHT / 2) - 5);
                                RSpear.Name = "RedSpear";
                                RSpear.spearStates = SpearRed.SpearState.FIRED;
                                RSpear.Velocity = new Vector2((2 * Singleton.Instance.RPowerSpearman) + 150, Singleton.Instance.RPowerSpearman + 100);
                                RSpear.Angle = (float)(Singleton.Instance.RAngleSpearman * (Math.PI / 180));
                                RSpear.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                _gameObjects.Add(_RedSpearshooted);

                                //after red shot spear
                                _RedSpearshooted = _RedNextSpear;

                                _RedNextSpear = new SpearRed(RedSpear)
                                {
                                    IsActive = true,
                                    Name = "NextRedSpear",
                                    Viewport = new Rectangle(0, 0, Singleton.SPEARWIDTH, Singleton.SPEARHEIGHT),
                                    Position = new Vector2(Singleton.Instance.XPositionRSpearman, Singleton.Instance.YPositionRSpearman + (Singleton.SPEARMANHEIGHT / 2) - 5),
                                };

                                _gameObjects.Add(_RedNextSpear);
                                Cooldown = 0;
                            }
                            //--
                            //Red shot wizardbullet
                            // กระสุน3แฉกพ่อมด
                            if (RWizard.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Bullet)
                            {
                                WizardBulletRed RWizardBullet = _RedWizardBulletshooted;
                                RWizardBullet.IsActive = true;
                                RWizardBullet.Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard);
                                RWizardBullet.Name = "RedWizardbullet";
                                RWizardBullet.wizardbulletStates = WizardBulletRed.WizardBulletState.BULLETFIRED;
                                RWizardBullet.Velocity = new Vector2((2 * Singleton.Instance.RPowerWizard) + 130, Singleton.Instance.RPowerWizard + 100);
                                RWizardBullet.Angle = (float)(Singleton.Instance.RAngleWizard * (Math.PI / 180));
                                RWizardBullet.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                _gameObjects.Add(_RedWizardBulletshooted);

                                WizardBulletRed RWizardBullet2 = _RedWizardBulletshooted2;
                                RWizardBullet2.IsActive = true;
                                RWizardBullet2.Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard);
                                RWizardBullet2.Name = "RedWizardbullet";
                                RWizardBullet2.wizardbulletStates = WizardBulletRed.WizardBulletState.BULLETFIRED;
                                RWizardBullet2.Velocity = new Vector2((2 * Singleton.Instance.RPowerWizard) + 135, Singleton.Instance.RPowerWizard + 100);
                                RWizardBullet2.Angle = (float)((Singleton.Instance.RAngleWizard + 10) * (Math.PI / 180));
                                RWizardBullet2.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                _gameObjects.Add(_RedWizardBulletshooted2);

                                WizardBulletRed RWizardBullet3 = _RedWizardBulletshooted3;
                                RWizardBullet3.IsActive = true;
                                RWizardBullet3.Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard);
                                RWizardBullet3.Name = "RedWizardbullet";
                                RWizardBullet3.wizardbulletStates = WizardBulletRed.WizardBulletState.BULLETFIRED;
                                RWizardBullet3.Velocity = new Vector2((2 * Singleton.Instance.RPowerWizard) + 140, Singleton.Instance.RPowerWizard + 100);
                                RWizardBullet3.Angle = (float)(float)((Singleton.Instance.RAngleWizard - 10) * (Math.PI / 180));
                                RWizardBullet3.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                _gameObjects.Add(_RedWizardBulletshooted3);

                                //after red shot wizardbullet
                                RndWizardRed();
                                if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Bullet)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                    _RedNextWizardBullet2 = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet2",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet2);
                                    _RedWizardBulletshooted2 = _RedNextWizardBullet2;
                                    _RedNextWizardBullet3 = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet3",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet3);
                                    _RedWizardBulletshooted3 = _RedNextWizardBullet3;
                                    Cooldown = 0;
                                }
                                else if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Fireball)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(RedFireBall)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.FIREBALLWIDTH, Singleton.FIREBALLHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    Cooldown = 0;
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                }
                                else if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Thunder)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(REDThunder)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.THUNDERWIDTH, Singleton.THUNDERHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 20, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    Cooldown = 0;
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                }


                            }
                            // กระสุนไฟพ่อมด
                            else if (RWizard.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Fireball)
                            {
                                WizardBulletRed RWizardBullet = _RedWizardBulletshooted;
                                RWizardBullet.IsActive = true;
                                RWizardBullet.Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard);
                                RWizardBullet.Name = "RedWizardbullet";
                                RWizardBullet.wizardbulletStates = WizardBulletRed.WizardBulletState.BULLETFIRED;
                                RWizardBullet.Velocity = new Vector2((2 * Singleton.Instance.RPowerWizard) + 130, Singleton.Instance.RPowerWizard + 100);
                                RWizardBullet.Angle = (float)(float)((Singleton.Instance.RAngleWizard) * (Math.PI / 180));
                                RWizardBullet.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                _gameObjects.Add(_RedWizardBulletshooted);
                                //after red shot wizardbullet
                                RndWizardRed();
                                if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Bullet)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                    _RedNextWizardBullet2 = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet2",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet2);
                                    _RedWizardBulletshooted2 = _RedNextWizardBullet2;
                                    _RedNextWizardBullet3 = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet3",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet3);
                                    _RedWizardBulletshooted3 = _RedNextWizardBullet3;
                                    Cooldown = 0;
                                }
                                else if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Fireball)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(RedFireBall)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.FIREBALLWIDTH, Singleton.FIREBALLHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    Cooldown = 0;
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                }
                                else if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Thunder)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(REDThunder)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.THUNDERWIDTH, Singleton.THUNDERHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 20, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    Cooldown = 0;
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                }
                            }
                            // กระสุนสายฟ้าพ่อมด
                            else if (RWizard.IsActive && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn && Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Thunder)
                            {
                                WizardBulletRed RWizardBullet = _RedWizardBulletshooted;
                                RWizardBullet.IsActive = true;
                                RWizardBullet.Position = new Vector2(Singleton.Instance.XPositionRWizard - 20, Singleton.Instance.YPositionRWizard);
                                RWizardBullet.Name = "RedWizardbullet";
                                RWizardBullet.wizardbulletStates = WizardBulletRed.WizardBulletState.BULLETFIRED;
                                RWizardBullet.Velocity = new Vector2((2 * Singleton.Instance.RPowerWizard) + 130, Singleton.Instance.RPowerWizard + 100);
                                RWizardBullet.Angle = (float)((Singleton.Instance.RAngleWizard) * (Math.PI / 180));
                                RWizardBullet.Resistance = new Vector2(0, Singleton.Instance.Gravity);
                                _gameObjects.Add(_RedWizardBulletshooted);
                                //after red shot wizardbullet
                                RndWizardRed();
                                if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Bullet)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                    _RedNextWizardBullet2 = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet2",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet2);
                                    _RedWizardBulletshooted2 = _RedNextWizardBullet2;
                                    _RedNextWizardBullet3 = new WizardBulletRed(RedWizardBullet)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet3",
                                        Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet3);
                                    _RedWizardBulletshooted3 = _RedNextWizardBullet3;
                                    Cooldown = 0;
                                }
                                else if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Fireball)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(RedFireBall)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.FIREBALLWIDTH, Singleton.FIREBALLHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    Cooldown = 0;
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                }
                                else if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Thunder)
                                {
                                    _RedNextWizardBullet = new WizardBulletRed(REDThunder)
                                    {
                                        IsActive = true,
                                        Name = "NextRedWizardBullet",
                                        Viewport = new Rectangle(0, 0, Singleton.THUNDERWIDTH, Singleton.THUNDERHEIGHT),
                                        Position = new Vector2(Singleton.Instance.XPositionRWizard - 20, Singleton.Instance.YPositionRWizard),
                                    };
                                    _gameObjects.Add(_RedNextWizardBullet);
                                    Cooldown = 0;
                                    _RedWizardBulletshooted = _RedNextWizardBullet;
                                }
                            }//--
                            randWind = false;
                            //ResetAP = true;
                            Singleton.Instance.CurrentTurn = Singleton.TurnState.BlueTurn;
                            Turn = "BlueTurn";
                        }

                        for (int i = 0; i < _numObject; i++)
                        {
                            if (_gameObjects[i].IsActive)
                            {
                                _gameObjects[i].Update(gameTime, _gameObjects);
                            }
                        }
                        for (int i = 0; i < _numObject; i++)
                        {
                            if (!_gameObjects[i].IsActive)
                            {
                                _gameObjects.RemoveAt(i);
                                i--;
                                _numObject--;
                            }
                        }

                        break;
                    }
                case Singleton.GameState.GameBlueWin:
                    {
                        MediaPlayer.Stop();
                        PlaySong = false;
                        SongWin.Volume = 0.75f;
                        SongWin.Play();
                        _gameObjects.Clear();
                        if (!Singleton.Instance.CurrentKey.Equals(Singleton.Instance.PreviousKey) && Singleton.Instance.CurrentKey.IsKeyDown(Keys.Space))
                        {

                            Singleton.Instance.CurrentGameState = Singleton.GameState.GameStart;
                        }
                        if (!Singleton.Instance.CurrentKey.Equals(Singleton.Instance.PreviousKey) && Singleton.Instance.CurrentKey.IsKeyDown(Keys.Escape))
                        {
                            //Space keys pressed to start
                            this.Exit();
                        }
                        break;
                    }
                case Singleton.GameState.GameRedWin:
                    {
                        MediaPlayer.Stop();
                        PlaySong = false;
                        SongWin.Volume = 0.75f;
                        SongWin.Play();
                        _gameObjects.Clear();
                        if (!Singleton.Instance.CurrentKey.Equals(Singleton.Instance.PreviousKey) && Singleton.Instance.CurrentKey.IsKeyDown(Keys.Space))
                        {
                            MediaPlayer.Stop();
                            PlaySong = false;
                            Singleton.Instance.CurrentGameState = Singleton.GameState.GameStart;
                        }
                        if (!Singleton.Instance.CurrentKey.Equals(Singleton.Instance.PreviousKey) && Singleton.Instance.CurrentKey.IsKeyDown(Keys.Escape))
                        {
                            //Space keys pressed to start
                            this.Exit();
                        }
                        break;
                    }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {


            GraphicsDevice.Clear(Color.LightBlue);
            spriteBatch.Begin();
            switch (Singleton.Instance.CurrentGameState)
            {
                case Singleton.GameState.GameStart:
                    {
                        if (!PlaySong)
                        {
                            MediaPlayer.Volume = 0.15f;
                            MediaPlayer.Play(_bgm);
                            PlaySong = true;
                        }
                        spriteBatch.Draw(StartPage, new Rectangle(0, 0, Singleton.SCREENWIDTH, Singleton.SCREENHEIGHT), Color.White);
                        break;
                    }
                case Singleton.GameState.GamePlaying:
                    {
                        if (!PlaySong)
                        {
                            MediaPlayer.Volume = 0.3f;
                            MediaPlayer.Play(_bgp);
                            PlaySong = true;
                        }
                        spriteBatch.Draw(background, new Rectangle(0, 0, Singleton.SCREENWIDTH, Singleton.SCREENHEIGHT), Color.White);
                        spriteBatch.Draw(Ground, new Rectangle(0, Singleton.SCREENHEIGHT - 65, Singleton.SCREENWIDTH, 65), Color.White);

                        spriteBatch.Draw(BlueCastle1, new Rectangle(50, (Singleton.SCREENHEIGHT - 314), Singleton.CASTLEWIDTH1, Singleton.CASTLEHEIGHT1), Color.White);
                        spriteBatch.Draw(RedCastle1, new Rectangle(Singleton.SCREENWIDTH - 50 - Singleton.CASTLEWIDTH1, (Singleton.SCREENHEIGHT - 314), Singleton.CASTLEWIDTH1, Singleton.CASTLEHEIGHT1), Color.White);

                        if (Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
                        {
                            spriteBatch.Draw(TextTurnBlue, new Rectangle((Singleton.SCREENWIDTH - Singleton.TextturnWIDTH) / 2, 25, Singleton.TextturnWIDTH, Singleton.TextturnHEIGHT), Color.White);

                        }
                        else if (Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
                        {
                            spriteBatch.Draw(TextTurnRed, new Rectangle((Singleton.SCREENWIDTH - Singleton.TextturnWIDTH) / 2, 25, Singleton.TextturnWIDTH, Singleton.TextturnHEIGHT), Color.White);

                        }


                        fontLength = _spriteFont.MeasureString("Wind" + Singleton.Instance.Wind.ToString());
                        spriteBatch.DrawString(_spriteFont, "Wind" + Singleton.Instance.Wind.ToString(), new Vector2((Singleton.SCREENWIDTH - fontLength.X) / 2, 100), Color.RoyalBlue);

                        //Blue 
                        //ธนู
                        if (BArcher.IsActive)
                        {
                            spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionBArcher, Singleton.Instance.YPositionBArcher - 10, Singleton.minHP, 5), Color.White); // min 
                            spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionBArcher, Singleton.Instance.YPositionBArcher - 10, (BArcher.Hp * Singleton.minHP) / 80, 5), Color.White); // max
                        }

                        //ขวาน
                        if (BAxeman.IsActive)
                        {
                            spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionBAxeman, Singleton.Instance.YPositionBAxeman - 10, Singleton.minHP, 5), Color.White); // min 
                            spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionBAxeman, Singleton.Instance.YPositionBAxeman - 10, (BAxeman.Hp * Singleton.minHP) / 140, 5), Color.White); // max
                        }
                        //หอก
                        if (BSpearman.IsActive)
                        {
                            spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionBSpearman, Singleton.Instance.YPositionBSpearman - 10, Singleton.minHP, 5), Color.White); // min 
                            spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionBSpearman, Singleton.Instance.YPositionBSpearman - 10, (BSpearman.Hp * Singleton.minHP) / 100, 5), Color.White); // max
                        }
                        //เวท
                        if (BWizard.IsActive)
                        {
                            spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionBWizard, Singleton.Instance.YPositionBWizard - 10, Singleton.minHP, 5), Color.White); // min 
                            spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionBWizard, Singleton.Instance.YPositionBWizard - 10, (BWizard.Hp * Singleton.minHP) / 60, 5), Color.White); // max
                        }
                        //ธง
                        spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionBFlag, Singleton.Instance.YPositionBFlag - 10, 70, 5), Color.White); // min 
                        spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionBFlag, Singleton.Instance.YPositionBFlag - 10, (BFlag.Hp * 70) / 200, 5), Color.White); // max

                        //DrawItem
                        if (Singleton.Instance.BlueHaveItemMeteor)
                        {
                            spriteBatch.Draw(ItemMeteor, new Rectangle(5, 5, Singleton.SizeDrawItem, Singleton.SizeDrawItem), Color.White);
                        }
                        if (Singleton.Instance.BlueHaveItemHeal)
                        {
                            spriteBatch.Draw(ItemHeal, new Rectangle(10 + Singleton.SizeDrawItem, 5, Singleton.SizeDrawItem, Singleton.SizeDrawItem), Color.White);
                        }
                        if (Singleton.Instance.RedHaveItemMeteor)
                        {
                            spriteBatch.Draw(ItemMeteor, new Rectangle(Singleton.SCREENWIDTH - 5 - Singleton.SizeDrawItem, 5, Singleton.SizeDrawItem, Singleton.SizeDrawItem), Color.White);
                        }
                        if (Singleton.Instance.RedHaveItemHeal)
                        {
                            spriteBatch.Draw(ItemHeal, new Rectangle(Singleton.SCREENWIDTH - (10 + Singleton.SizeDrawItem * 2), 5, Singleton.SizeDrawItem, Singleton.SizeDrawItem), Color.White);
                        }

                        //Red
                        //ธนู
                        if (RArcher.IsActive)
                        {
                            spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionRArcher, Singleton.Instance.YPositionRArcher - 10, Singleton.minHP, 5), Color.White); // min 
                            spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionRArcher, Singleton.Instance.YPositionRArcher - 10, (RArcher.Hp * Singleton.minHP) / 80, 5), Color.White); // max
                        }
                        //ขวาน
                        if (RAxeman.IsActive)
                        {
                            spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionRAxeman, Singleton.Instance.YPositionRAxeman - 10, Singleton.minHP, 5), Color.White); // min 
                            spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionRAxeman, Singleton.Instance.YPositionRAxeman - 10, (RAxeman.Hp * Singleton.minHP) / 140, 5), Color.White); // max
                        }
                        //หอ
                        if (RSpearman.IsActive)
                        {
                            spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionRSpearman, Singleton.Instance.YPositionRSpearman - 10, Singleton.minHP, 5), Color.White); // min 
                            spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionRSpearman, Singleton.Instance.YPositionRSpearman - 10, (RSpearman.Hp * Singleton.minHP) / 100, 5), Color.White); // max
                        }

                        //เวท
                        if (RWizard.IsActive)
                        {
                            spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionRWizard, Singleton.Instance.YPositionRWizard - 10, Singleton.minHP, 5), Color.White); // min 
                            spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionRWizard, Singleton.Instance.YPositionRWizard - 10, (RWizard.Hp * Singleton.minHP) / 60, 5), Color.White); // max
                        }
                        //ธง

                        spriteBatch.Draw(minHP, new Rectangle(Singleton.Instance.XPositionRFlag, Singleton.Instance.YPositionRFlag - 10, 70, 5), Color.White); // min 
                        spriteBatch.Draw(maxHP, new Rectangle(Singleton.Instance.XPositionRFlag, Singleton.Instance.YPositionRFlag - 10, (RFlag.Hp * 70) / 200, 5), Color.White); // max

                        //***BLUE**//
                        spriteBatch.Draw(ChaBoard, new Rectangle(10, (Singleton.MARKSIZE * 1) + 24, 130, 80), Color.White);
                        spriteBatch.Draw(ChaBoard, new Rectangle(10, (Singleton.MARKSIZE * 2) + 49, 130, 80), Color.White);
                        spriteBatch.Draw(ChaBoard, new Rectangle(10, (Singleton.MARKSIZE * 3) + 74, 130, 80), Color.White);
                        spriteBatch.Draw(ChaBoard, new Rectangle(10, (Singleton.MARKSIZE * 4) + 99, 130, 80), Color.White);


                        spriteBatch.Draw(BLUEArchermark, new Rectangle(10, (Singleton.MARKSIZE * 1) + 25, Singleton.MARKSIZE, Singleton.MARKSIZE), Color.White);
                        spriteBatch.Draw(BLUEAxemanmark, new Rectangle(10, (Singleton.MARKSIZE * 2) + 50, Singleton.MARKSIZE, Singleton.MARKSIZE), Color.White);
                        spriteBatch.Draw(BLUESpearmanmark, new Rectangle(10, (Singleton.MARKSIZE * 3) + 75, Singleton.MARKSIZE, Singleton.MARKSIZE), Color.White);
                        spriteBatch.Draw(BLUEWizardmark, new Rectangle(10, (Singleton.MARKSIZE * 4) + 100, Singleton.MARKSIZE, Singleton.MARKSIZE), Color.White);
                        //***RED**//

                        spriteBatch.Draw(ChaBoard, new Rectangle(Singleton.SCREENWIDTH - 130 - 10, (Singleton.MARKSIZE * 1) + 24, 130, 80), Color.White);
                        spriteBatch.Draw(ChaBoard, new Rectangle(Singleton.SCREENWIDTH - 130 - 10, (Singleton.MARKSIZE * 2) + 49, 130, 80), Color.White);
                        spriteBatch.Draw(ChaBoard, new Rectangle(Singleton.SCREENWIDTH - 130 - 10, (Singleton.MARKSIZE * 3) + 74, 130, 80), Color.White);
                        spriteBatch.Draw(ChaBoard, new Rectangle(Singleton.SCREENWIDTH - 130 - 10, (Singleton.MARKSIZE * 4) + 99, 130, 80), Color.White);


                        spriteBatch.Draw(REDArchermark, new Rectangle(Singleton.SCREENWIDTH - 70, (Singleton.MARKSIZE * 1) + 25, Singleton.MARKSIZE, Singleton.MARKSIZE), Color.White);
                        spriteBatch.Draw(REDAxemanmark, new Rectangle(Singleton.SCREENWIDTH - 70, (Singleton.MARKSIZE * 2) + 50, Singleton.MARKSIZE, Singleton.MARKSIZE), Color.White);
                        spriteBatch.Draw(REDSpearmanmark, new Rectangle(Singleton.SCREENWIDTH - 70, (Singleton.MARKSIZE * 3) + 75, Singleton.MARKSIZE, Singleton.MARKSIZE), Color.White);
                        spriteBatch.Draw(REDWizardmark, new Rectangle(Singleton.SCREENWIDTH - 70, (Singleton.MARKSIZE * 4) + 100, Singleton.MARKSIZE, Singleton.MARKSIZE), Color.White);

                        //blue
                        //ธนู
                        fontLength = _spriteFont.MeasureString("HP " + BArcher.Hp.ToString());
                        spriteBatch.DrawString(TextUI, "HP " + BArcher.Hp.ToString(), new Vector2(72, (Singleton.MARKSIZE * 1) + 40), Color.IndianRed);
                        fontLength = _spriteFont.MeasureString("Power " + Singleton.Instance.BPowerArcher.ToString());
                        spriteBatch.DrawString(TextUI, "Power " + Singleton.Instance.BPowerArcher.ToString(), new Vector2(71, (Singleton.MARKSIZE * 1) + 55), Color.Salmon);
                        fontLength = _spriteFont.MeasureString("Angle " + Singleton.Instance.BAngleArcher.ToString() + "*");
                        spriteBatch.DrawString(TextUI, "Angle " + Singleton.Instance.BAngleArcher.ToString() + "*", new Vector2(70, (Singleton.MARKSIZE * 1) + 70), Color.BlueViolet);
                        //ขวาน
                        fontLength = _spriteFont.MeasureString("HP " + BAxeman.Hp.ToString());
                        spriteBatch.DrawString(TextUI, "HP " + BAxeman.Hp.ToString(), new Vector2(72, (Singleton.MARKSIZE * 2) + 40 + 25), Color.IndianRed);
                        fontLength = _spriteFont.MeasureString("Power " + Singleton.Instance.BPowerAxeman.ToString());
                        spriteBatch.DrawString(TextUI, "Power " + Singleton.Instance.BPowerAxeman.ToString(), new Vector2(71, (Singleton.MARKSIZE * 2) + 55 + 25), Color.Salmon);
                        fontLength = _spriteFont.MeasureString("Angle " + Singleton.Instance.BAngleAxeman.ToString() + "*");
                        spriteBatch.DrawString(TextUI, "Angle " + Singleton.Instance.BAngleAxeman.ToString() + "*", new Vector2(70, (Singleton.MARKSIZE * 2) + 70 + 25), Color.BlueViolet);
                        //หอก
                        fontLength = _spriteFont.MeasureString("HP " + BSpearman.Hp.ToString());
                        spriteBatch.DrawString(TextUI, "HP " + BSpearman.Hp.ToString(), new Vector2(72, (Singleton.MARKSIZE * 3) + 40 + 50), Color.IndianRed);
                        fontLength = _spriteFont.MeasureString("Power " + Singleton.Instance.BPowerSpearman.ToString());
                        spriteBatch.DrawString(TextUI, "Power " + Singleton.Instance.BPowerSpearman.ToString(), new Vector2(71, (Singleton.MARKSIZE * 3) + 55 + 50), Color.Salmon);
                        fontLength = _spriteFont.MeasureString("Angle " + Singleton.Instance.BAngleSpearman.ToString() + "*");
                        spriteBatch.DrawString(TextUI, "Angle " + Singleton.Instance.BAngleSpearman.ToString() + "*", new Vector2(70, (Singleton.MARKSIZE * 3) + 70 + 50), Color.BlueViolet);
                        //เวท
                        fontLength = _spriteFont.MeasureString("HP " + BWizard.Hp.ToString());
                        spriteBatch.DrawString(TextUI, "HP " + BWizard.Hp.ToString(), new Vector2(72, (Singleton.MARKSIZE * 4) + 40 + 75), Color.IndianRed);
                        fontLength = _spriteFont.MeasureString("Power " + Singleton.Instance.BPowerWizard.ToString());
                        spriteBatch.DrawString(TextUI, "Power " + Singleton.Instance.BPowerWizard.ToString(), new Vector2(71, (Singleton.MARKSIZE * 4) + 55 + 75), Color.Salmon);
                        fontLength = _spriteFont.MeasureString("Angle " + Singleton.Instance.BAngleWizard.ToString() + "*");
                        spriteBatch.DrawString(TextUI, "Angle " + Singleton.Instance.BAngleWizard.ToString() + "*", new Vector2(70, (Singleton.MARKSIZE * 4) + 70 + 75), Color.BlueViolet);


                        spriteBatch.Draw(AttackBotton, new Rectangle((Singleton.SCREENWIDTH - 160) / 2, ((Singleton.SCREENWIDTH / 2) + 40) - 500, 160, 80), Color.White);
                        //red
                        //ธนู
                        fontLength = _spriteFont.MeasureString("HP " + RArcher.Hp.ToString());
                        spriteBatch.DrawString(TextUI, "HP " + RArcher.Hp.ToString(), new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 1) + 40), Color.IndianRed);
                        fontLength = _spriteFont.MeasureString("Power " + Singleton.Instance.RPowerArcher.ToString());
                        spriteBatch.DrawString(TextUI, "Power " + Singleton.Instance.RPowerArcher.ToString(), new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 1) + 55), Color.Salmon);
                        fontLength = _spriteFont.MeasureString("Angle " + Singleton.Instance.RAngleArcher.ToString() + "*");
                        spriteBatch.DrawString(TextUI, "Angle " + Singleton.Instance.RAngleArcher.ToString() + "*", new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 1) + 70), Color.BlueViolet);
                        //ขวาน
                        fontLength = _spriteFont.MeasureString("HP " + RAxeman.Hp.ToString());
                        spriteBatch.DrawString(TextUI, "HP " + RAxeman.Hp.ToString(), new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 2) + 40 + 25), Color.IndianRed);
                        fontLength = _spriteFont.MeasureString("Power " + Singleton.Instance.RPowerAxeman.ToString());
                        spriteBatch.DrawString(TextUI, "Power " + Singleton.Instance.RPowerAxeman.ToString(), new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 2) + 55 + 25), Color.Salmon);
                        fontLength = _spriteFont.MeasureString("Angle " + Singleton.Instance.RAngleAxeman.ToString() + "*");
                        spriteBatch.DrawString(TextUI, "Angle " + Singleton.Instance.RAngleAxeman.ToString() + "*", new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 2) + 70 + 25), Color.BlueViolet);
                        //หอก
                        fontLength = _spriteFont.MeasureString("HP " + RSpearman.Hp.ToString());
                        spriteBatch.DrawString(TextUI, "HP " + RSpearman.Hp.ToString(), new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 3) + 40 + 50), Color.IndianRed);
                        fontLength = _spriteFont.MeasureString("Power " + Singleton.Instance.RPowerSpearman.ToString());
                        spriteBatch.DrawString(TextUI, "Power " + Singleton.Instance.RPowerSpearman.ToString(), new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 3) + 55 + 50), Color.Salmon);
                        fontLength = _spriteFont.MeasureString("Angle " + Singleton.Instance.RAngleSpearman.ToString() + "*");
                        spriteBatch.DrawString(TextUI, "Angle " + Singleton.Instance.RAngleSpearman.ToString() + "*", new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 3) + 70 + 50), Color.BlueViolet);
                        //เวท
                        fontLength = _spriteFont.MeasureString("HP " + RWizard.Hp.ToString());
                        spriteBatch.DrawString(TextUI, "HP " + RWizard.Hp.ToString(), new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 4) + 40 + 75), Color.IndianRed);
                        fontLength = _spriteFont.MeasureString("Power " + Singleton.Instance.RPowerWizard.ToString());
                        spriteBatch.DrawString(TextUI, "Power " + Singleton.Instance.RPowerWizard.ToString(), new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 4) + 55 + 75), Color.Salmon);
                        fontLength = _spriteFont.MeasureString("Angle " + Singleton.Instance.RAngleWizard.ToString() + "*");
                        spriteBatch.DrawString(TextUI, "Angle " + Singleton.Instance.RAngleWizard.ToString() + "*", new Vector2(Singleton.SCREENWIDTH - 130, (Singleton.MARKSIZE * 4) + 70 + 75), Color.BlueViolet);
                        break;
                    }
                case Singleton.GameState.GameBlueWin:
                    {
                        spriteBatch.Draw(background, new Rectangle(0, 0, Singleton.SCREENWIDTH, Singleton.SCREENHEIGHT), Color.White);
                        spriteBatch.Draw(PopUpBluewin, new Vector2((Singleton.SCREENWIDTH - 530) / 2, (Singleton.SCREENHEIGHT - 370) / 2), Color.White);
                        break;
                    }
                case Singleton.GameState.GameRedWin:
                    {
                        spriteBatch.Draw(background, new Rectangle(0, 0, Singleton.SCREENWIDTH, Singleton.SCREENHEIGHT), Color.White);
                        spriteBatch.Draw(PopUpRedwin, new Vector2((Singleton.SCREENWIDTH - 530) / 2, (Singleton.SCREENHEIGHT - 370) / 2), Color.White);
                        break;
                    }
            }

            for (int i = 0; i < _gameObjects.Count; i++)
            {

                _gameObjects[i].Draw(spriteBatch);
            }

            spriteBatch.End();
            graphics.BeginDraw();
            base.Draw(gameTime);
        }

        protected void Reset()
        {
            time = 0;
            tick = 0;
            ResetStat();
            _gameObjects.Clear();
            Singleton.Instance.CurrentTurn = Singleton.TurnState.BlueTurn;
            //Item
            DItem = new Item(ItemNaja)
            {
                IsActive = true,
                Name = "ItemNaja",
                Viewport = new Rectangle(0, 0, Singleton.ITEMSIZE, Singleton.ITEMSIZE),
            };
            _gameObjects.Add(DItem);
            Singleton.Instance.RndItemOnMap = true;
            //BlueFlag
            BFlag = new Flag(BlueFlag)
            {
                IsActive = true,
                Name = "BlueFlag",
                Hp = 200,
                Viewport = new Rectangle(0, 0, Singleton.FLAGWIDTH, Singleton.FLAGHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBFlag, Singleton.Instance.YPositionBFlag),

            };
            _gameObjects.Add(BFlag);
            //RedFlag
            RFlag = new Flag(RedFlag)
            {
                IsActive = true,
                Name = "RedFlag",
                Hp = 200,
                Viewport = new Rectangle(0, 0, Singleton.FLAGWIDTH, Singleton.FLAGHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRFlag, Singleton.Instance.YPositionRFlag),

            };
            _gameObjects.Add(RFlag);
            //Archer Blue

            BArcher = new ArcherBlue(BlueArcher)
            {
                IsActive = true,
                Name = "BlueArcher",
                Hp = 80,
                Viewport = new Rectangle(0, 0, Singleton.ARCHERWIDTH, Singleton.ARCHERHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBArcher, Singleton.Instance.YPositionBArcher),

            };
            _gameObjects.Add(BArcher);
            //Archer Red
            RArcher = new ArcherRed(RedArcher)
            {
                IsActive = true,
                Name = "RedArcher",
                Hp = 80,
                Viewport = new Rectangle(0, 0, Singleton.ARCHERWIDTH, Singleton.ARCHERHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRArcher, Singleton.Instance.YPositionRArcher),

            };
            _gameObjects.Add(RArcher);
            //AxeMan Blue
            BAxeman = new AxeManBlue(BlueAxeman)
            {
                IsActive = true,
                Name = "BlueAxeman",
                Hp = 140,
                Viewport = new Rectangle(0, 0, Singleton.AXEMANWIDTH, Singleton.AXEMANHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBAxeman, Singleton.Instance.YPositionBAxeman),
            };
            _gameObjects.Add(BAxeman);
            //AxeMan Red
            RAxeman = new AxeManRed(RedAxeman)
            {
                IsActive = true,
                Name = "RedAxeman",
                Hp = 140,
                Viewport = new Rectangle(0, 0, Singleton.AXEMANWIDTH, Singleton.AXEMANHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRAxeman, Singleton.Instance.YPositionRAxeman),
            };
            _gameObjects.Add(RAxeman);
            //SpearMan Blue
            BSpearman = new SpearManBlue(BlueSpearman)
            {
                IsActive = true,
                Name = "BlueSpearman",
                Hp = 100,
                Viewport = new Rectangle(0, 0, Singleton.SPEARMANWIDTH, Singleton.SPEARMANHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBSpearman, Singleton.Instance.YPositionBSpearman),
            };
            _gameObjects.Add(BSpearman);
            //SpearMan Red
            RSpearman = new SpearManRed(RedSpearman)
            {
                IsActive = true,
                Name = "RedSpearman",
                Hp = 100,
                Viewport = new Rectangle(0, 0, Singleton.SPEARMANWIDTH, Singleton.SPEARMANHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRSpearman, Singleton.Instance.YPositionRSpearman),
            };
            _gameObjects.Add(RSpearman);
            //Wizard Blue
            BWizard = new WizardBlue(BlueWizard)
            {
                IsActive = true,
                Name = "BlueWizard",
                Hp = 60,
                Viewport = new Rectangle(0, 0, Singleton.WIZARDWIDTH, Singleton.WIZARDHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBWizard, Singleton.Instance.YPositionBWizard),
            };
            _gameObjects.Add(BWizard);
            //Wizard Red
            RWizard = new WizardRed(RedWizard)
            {
                IsActive = true,
                Name = "RedWizard",
                Hp = 60,
                Viewport = new Rectangle(0, 0, Singleton.WIZARDWIDTH, Singleton.WIZARDHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRWizard, Singleton.Instance.YPositionRWizard),
            };
            _gameObjects.Add(RWizard);
            //Arrow Blue
            _BlueArrowshooted = new ArrowBlue(BlueArrow)
            {
                IsActive = true,
                Name = "BlueArrow",
                Viewport = new Rectangle(0, 0, Singleton.ARROWWIDTH, Singleton.ARROWHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBArcher, Singleton.Instance.YPositionBArcher + (Singleton.ARCHERHEIGHT / 2)),
                Rotation = 90,
            };

            _gameObjects.Add(_BlueArrowshooted);

            _BlueNextArrow = new ArrowBlue(BlueArrow)
            {
                IsActive = true,
                Name = "NextBlueArrow",
                Viewport = new Rectangle(0, 0, Singleton.ARROWWIDTH, Singleton.ARROWHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBArcher, Singleton.Instance.YPositionBArcher + (Singleton.ARCHERHEIGHT / 2)),
                Rotation = 90,
            };
            _gameObjects.Add(_BlueNextArrow);

            //Axe Blue
            _BlueAxeshooted = new AxeBlue(BlueAxe)
            {
                IsActive = true,
                Name = "BlueAxe",
                Viewport = new Rectangle(0, 0, Singleton.AXEWIDTH, Singleton.AXEHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBAxeman + 20, Singleton.Instance.YPositionBAxeman),

            };

            _gameObjects.Add(_BlueAxeshooted);

            _BlueNextAxe = new AxeBlue(BlueAxe)
            {
                IsActive = true,
                Name = "NextBlueAxe",
                Viewport = new Rectangle(0, 0, Singleton.AXEWIDTH, Singleton.AXEHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBAxeman + 20, Singleton.Instance.YPositionBAxeman),
            };
            _gameObjects.Add(_BlueNextAxe);

            //Spear Blue
            _BlueSpearshooted = new SpearBlue(BlueSpear)
            {
                IsActive = true,
                Name = "BlueSpear",
                Viewport = new Rectangle(0, 0, Singleton.SPEARWIDTH, Singleton.SPEARHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBSpearman, Singleton.Instance.YPositionBSpearman + (Singleton.SPEARMANHEIGHT / 2) - 5),

            };

            _gameObjects.Add(_BlueSpearshooted);

            _BlueNextSpear = new SpearBlue(BlueSpear)
            {
                IsActive = true,
                Name = "NextBlueSpeaR",
                Viewport = new Rectangle(0, 0, Singleton.SPEARWIDTH, Singleton.SPEARHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionBSpearman, Singleton.Instance.YPositionBSpearman + (Singleton.SPEARMANHEIGHT / 2) - 5),
            };
            _gameObjects.Add(_BlueNextSpear);

            //WizardBullet blue
            RndWizardBlue();
            if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Bullet)
            {
                //WizardNormalBullet Blue
                _BlueWizardBulletshooted = new WizardBulletBlue(BlueWizardBullet)
                {
                    IsActive = true,
                    Name = "BlueWizardBullet",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted);

                _BlueWizardBulletshooted2 = new WizardBulletBlue(BlueWizardBullet)
                {
                    IsActive = true,
                    Name = "BlueWizardBullet2",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted2);

                _BlueWizardBulletshooted3 = new WizardBulletBlue(BlueWizardBullet)
                {
                    IsActive = true,
                    Name = "BlueWizardBullet3",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted3);
            }
            else if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Fireball)
            {
                //Fireball Blue
                _BlueWizardBulletshooted = new WizardBulletBlue(BlueFireBall)
                {
                    IsActive = true,
                    Name = "BlueFireBall",
                    Viewport = new Rectangle(0, 0, Singleton.FIREBALLWIDTH, Singleton.FIREBALLHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted);
                /*
                _BlueWizardBulletshooted2 = new WizardBulletBlue(BlueWizardBullet)
                {
                    IsActive = false,
                    Name = "BlueWizardBullet2",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted2);
                _BlueWizardBulletshooted3 = new WizardBulletBlue(BlueWizardBullet)
                {
                    IsActive = false,
                    Name = "BlueWizardBullet3",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted3);
                */
            }
            else if (Singleton.Instance.CurrentWizardshootBlue == Singleton.WizardTypeShoot.Thunder)
            {
                //Thunder Blue
                _BlueWizardBulletshooted = new WizardBulletBlue(BLUEThunder)
                {
                    IsActive = true,
                    Name = "BlueThunder",
                    Viewport = new Rectangle(0, 0, Singleton.THUNDERWIDTH, Singleton.THUNDERHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted);
                /*
                _BlueWizardBulletshooted2 = new WizardBulletBlue(BlueWizardBullet)
                {
                    IsActive = false,
                    Name = "BlueWizardBullet2",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted2);
                _BlueWizardBulletshooted3 = new WizardBulletBlue(BlueWizardBullet)
                {
                    IsActive = false,
                    Name = "BlueWizardBullet3",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionBWizard + 30, Singleton.Instance.YPositionBWizard),

                };
                _gameObjects.Add(_BlueWizardBulletshooted3);
                */
            }

            //Arrow Red
            _RedArrowshooted = new ArrowRed(RedArrow)
            {
                IsActive = true,
                Name = "RedArrow",
                Viewport = new Rectangle(0, 0, Singleton.ARROWWIDTH, Singleton.ARROWHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRArcher, Singleton.Instance.YPositionRArcher + (Singleton.ARCHERHEIGHT / 2)),


            };

            _gameObjects.Add(_RedArrowshooted);

            _RedNextArrow = new ArrowRed(RedArrow)
            {
                IsActive = true,
                Name = "NextRedArrow",
                Viewport = new Rectangle(0, 0, Singleton.ARROWWIDTH, Singleton.ARROWHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRArcher, Singleton.Instance.YPositionRArcher + (Singleton.ARCHERHEIGHT / 2)),
            };
            _gameObjects.Add(_RedNextArrow);

            //Axe Red
            _RedAxeshooted = new AxeRed(RedAxe)
            {
                IsActive = true,
                Name = "RedAxe",
                Viewport = new Rectangle(0, 0, Singleton.AXEWIDTH, Singleton.AXEHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRAxeman, Singleton.Instance.YPositionRAxeman),

            };

            _gameObjects.Add(_RedAxeshooted);

            _RedNextAxe = new AxeRed(RedAxe)
            {
                IsActive = true,
                Name = "NextRedAxe",
                Viewport = new Rectangle(0, 0, Singleton.AXEWIDTH, Singleton.AXEHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRAxeman, Singleton.Instance.YPositionRAxeman),
            };
            _gameObjects.Add(_RedNextAxe);

            //Spear Red
            _RedSpearshooted = new SpearRed(RedSpear)
            {
                IsActive = true,
                Name = "RedSpear",
                Viewport = new Rectangle(0, 0, Singleton.SPEARWIDTH, Singleton.SPEARHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRSpearman, Singleton.Instance.YPositionRSpearman + (Singleton.SPEARMANHEIGHT / 2) - 5),

            };

            _gameObjects.Add(_RedSpearshooted);

            _RedNextSpear = new SpearRed(RedSpear)
            {
                IsActive = true,
                Name = "NextRedSpear",
                Viewport = new Rectangle(0, 0, Singleton.SPEARWIDTH, Singleton.SPEARHEIGHT),
                Position = new Vector2(Singleton.Instance.XPositionRSpearman, Singleton.Instance.YPositionRSpearman + (Singleton.SPEARMANHEIGHT / 2) - 5),
            };
            _gameObjects.Add(_RedNextSpear);

            //WizardBullet red//--
            RndWizardRed();
            if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Bullet)
            {
                //WizardNormalBullet red
                _RedWizardBulletshooted = new WizardBulletRed(RedWizardBullet)
                {
                    IsActive = true,
                    Name = "RedWizardBullet",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted);

                _RedWizardBulletshooted2 = new WizardBulletRed(RedWizardBullet)
                {
                    IsActive = true,
                    Name = "RedWizardBullet2",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted2);

                _RedWizardBulletshooted3 = new WizardBulletRed(RedWizardBullet)
                {
                    IsActive = true,
                    Name = "RedWizardBullet3",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted3);
            }
            else if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Fireball)
            {
                //Fireball Red
                _RedWizardBulletshooted = new WizardBulletRed(RedFireBall)
                {
                    IsActive = true,
                    Name = "RedFireBall",
                    Viewport = new Rectangle(0, 0, Singleton.FIREBALLWIDTH, Singleton.FIREBALLHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted);

                _RedWizardBulletshooted2 = new WizardBulletRed(RedWizardBullet)
                {
                    IsActive = false,
                    Name = "RedWizardBullet2",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted2);

                _RedWizardBulletshooted3 = new WizardBulletRed(RedWizardBullet)
                {
                    IsActive = false,
                    Name = "RedWizardBullet3",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted3);

            }
            else if (Singleton.Instance.CurrentWizardshootRed == Singleton.WizardTypeShoot.Thunder)
            {
                //Thunder Red
                _RedWizardBulletshooted = new WizardBulletRed(REDThunder)
                {
                    IsActive = true,
                    Name = "RedThunder",
                    Viewport = new Rectangle(0, 0, Singleton.THUNDERWIDTH, Singleton.THUNDERHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted);

                _RedWizardBulletshooted2 = new WizardBulletRed(RedWizardBullet)
                {
                    IsActive = false,
                    Name = "RedWizardBullet2",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted2);

                _RedWizardBulletshooted3 = new WizardBulletRed(RedWizardBullet)
                {
                    IsActive = false,
                    Name = "RedWizardBullet3",
                    Viewport = new Rectangle(0, 0, Singleton.WIZARDBULLETWIDTH, Singleton.WIZARDBULLETHEIGHT),
                    Position = new Vector2(Singleton.Instance.XPositionRWizard - 15, Singleton.Instance.YPositionRWizard),

                };
                _gameObjects.Add(_RedWizardBulletshooted3);

            }

            //--
            foreach (GameObject s in _gameObjects)
            {
                s.Reset();
            }

        }

        protected void CheckWin()
        {
            if ((BArcher.Hp <= 0 && BAxeman.Hp <= 0 && BSpearman.Hp <= 0 && BWizard.Hp <= 0) || BFlag.Hp <= 0)
            {
                Singleton.Instance.CurrentGameState = Singleton.GameState.GameRedWin;
            }
            if ((RArcher.Hp <= 0 && RAxeman.Hp <= 0 && RSpearman.Hp <= 0 && RWizard.Hp <= 0) || RFlag.Hp <= 0)
            {
                Singleton.Instance.CurrentGameState = Singleton.GameState.GameBlueWin;
            }
        }
        protected void SelectCharec()
        {
            if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.NumPad1)) Singleton.Instance.CurrentCharecter = Singleton.SelectCharecter.SelectArcher;
            else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.NumPad2)) Singleton.Instance.CurrentCharecter = Singleton.SelectCharecter.SelectAxeman;
            else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.NumPad3)) Singleton.Instance.CurrentCharecter = Singleton.SelectCharecter.SelectSpearman;
            else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.NumPad4)) Singleton.Instance.CurrentCharecter = Singleton.SelectCharecter.SelectWizard;
        }

        protected void ResetStat()
        {
            Singleton.Instance.BAngleArcher = 20;
            Singleton.Instance.BAngleAxeman = 20;
            Singleton.Instance.BAngleSpearman = 20;
            Singleton.Instance.BAngleWizard = 20;
            Singleton.Instance.BPowerArcher = 0;
            Singleton.Instance.BPowerAxeman = 0;
            Singleton.Instance.BPowerSpearman = 0;
            Singleton.Instance.BPowerWizard = 0;

            Singleton.Instance.RAngleArcher = 20;
            Singleton.Instance.RAngleAxeman = 20;
            Singleton.Instance.RAngleSpearman = 20;
            Singleton.Instance.RAngleWizard = 20;
            Singleton.Instance.RPowerArcher = 0;
            Singleton.Instance.RPowerAxeman = 0;
            Singleton.Instance.RPowerSpearman = 0;
            Singleton.Instance.RPowerWizard = 0;
        }

        protected void RndWizardBlue()
        {
            countRndWizard++;

            int r = rnd.Next(6);
            switch (r)
            {
                case 0:
                    {
                        Singleton.Instance.CurrentWizardshootBlue = Singleton.WizardTypeShoot.Bullet;
                        break;
                    }
                case 1:
                    {
                        Singleton.Instance.CurrentWizardshootBlue = Singleton.WizardTypeShoot.Fireball;
                        break;
                    }
                case 2:
                    {
                        Singleton.Instance.CurrentWizardshootBlue = Singleton.WizardTypeShoot.Thunder;
                        break;
                    }
                default:
                    {
                        Singleton.Instance.CurrentWizardshootBlue = Singleton.WizardTypeShoot.Bullet;
                        break;
                    }
            }
        }
        protected void RndWizardRed()
        {
            countRndWizard++;

            int r = rnd.Next(6);
            switch (r)
            {
                case 0:
                    {
                        Singleton.Instance.CurrentWizardshootRed = Singleton.WizardTypeShoot.Bullet;
                        break;
                    }
                case 1:
                    {
                        Singleton.Instance.CurrentWizardshootRed = Singleton.WizardTypeShoot.Fireball;
                        break;
                    }
                case 2:
                    {
                        Singleton.Instance.CurrentWizardshootRed = Singleton.WizardTypeShoot.Thunder;
                        break;
                    }
                default:
                    {
                        Singleton.Instance.CurrentWizardshootRed = Singleton.WizardTypeShoot.Bullet;
                        break;
                    }
            }
        }
        protected void checkAnglePower()
        {
            //BLUE
            // Archer
            if (Singleton.Instance.BAngleArcher < 20)
            {
                Singleton.Instance.BAngleArcher = 20;
            }
            else if (Singleton.Instance.BAngleArcher > 90)
            {
                Singleton.Instance.BAngleArcher = 90;
            }
            if (Singleton.Instance.BPowerArcher < 0)
            {
                Singleton.Instance.BPowerArcher = 0;
            }
            else if (Singleton.Instance.BPowerArcher > 100)
            {
                Singleton.Instance.BPowerArcher = 100;
            }
            // Axeman
            if (Singleton.Instance.BAngleAxeman < 20)
            {
                Singleton.Instance.BAngleAxeman = 20;
            }
            else if (Singleton.Instance.BAngleAxeman > 90)
            {
                Singleton.Instance.BAngleAxeman = 90;
            }
            if (Singleton.Instance.BPowerAxeman < 0)
            {
                Singleton.Instance.BPowerAxeman = 0;
            }
            else if (Singleton.Instance.BPowerAxeman > 100)
            {
                Singleton.Instance.BPowerAxeman = 100;
            }
            // Spearman
            if (Singleton.Instance.BAngleSpearman < 20)
            {
                Singleton.Instance.BAngleSpearman = 20;
            }
            else if (Singleton.Instance.BAngleSpearman > 90)
            {
                Singleton.Instance.BAngleSpearman = 90;
            }
            if (Singleton.Instance.BPowerSpearman < 0)
            {
                Singleton.Instance.BPowerSpearman = 0;
            }
            else if (Singleton.Instance.BPowerSpearman > 100)
            {
                Singleton.Instance.BPowerSpearman = 100;
            }
            // Wizard
            if (Singleton.Instance.BAngleWizard < 20)
            {
                Singleton.Instance.BAngleWizard = 20;
            }
            else if (Singleton.Instance.BAngleWizard > 90)
            {
                Singleton.Instance.BAngleWizard = 90;
            }
            if (Singleton.Instance.BPowerWizard < 0)
            {
                Singleton.Instance.BPowerWizard = 0;
            }
            else if (Singleton.Instance.BPowerWizard > 100)
            {
                Singleton.Instance.BPowerWizard = 100;
            }

            //REd
            // Archer
            if (Singleton.Instance.RAngleArcher < 20)
            {
                Singleton.Instance.RAngleArcher = 20;
            }
            else if (Singleton.Instance.RAngleArcher > 90)
            {
                Singleton.Instance.RAngleArcher = 90;
            }
            if (Singleton.Instance.RPowerArcher < 0)
            {
                Singleton.Instance.RPowerArcher = 0;
            }
            else if (Singleton.Instance.RPowerArcher > 100)
            {
                Singleton.Instance.RPowerArcher = 100;
            }
            // Axeman
            if (Singleton.Instance.RAngleAxeman < 20)
            {
                Singleton.Instance.RAngleAxeman = 20;
            }
            else if (Singleton.Instance.RAngleAxeman > 90)
            {
                Singleton.Instance.RAngleAxeman = 90;
            }
            if (Singleton.Instance.RPowerAxeman < 0)
            {
                Singleton.Instance.RPowerAxeman = 0;
            }
            else if (Singleton.Instance.RPowerAxeman > 100)
            {
                Singleton.Instance.RPowerAxeman = 100;
            }
            // Spearman
            if (Singleton.Instance.RAngleSpearman < 20)
            {
                Singleton.Instance.RAngleSpearman = 20;
            }
            else if (Singleton.Instance.RAngleSpearman > 90)
            {
                Singleton.Instance.RAngleSpearman = 90;
            }
            if (Singleton.Instance.RPowerSpearman < 0)
            {
                Singleton.Instance.RPowerSpearman = 0;
            }
            else if (Singleton.Instance.RPowerSpearman > 100)
            {
                Singleton.Instance.RPowerSpearman = 100;
            }
            // Wizard
            if (Singleton.Instance.RAngleWizard < 20)
            {
                Singleton.Instance.RAngleWizard = 20;
            }
            else if (Singleton.Instance.RAngleWizard > 90)
            {
                Singleton.Instance.RAngleWizard = 90;
            }
            if (Singleton.Instance.RPowerWizard < 0)
            {
                Singleton.Instance.RPowerWizard = 0;
            }
            else if (Singleton.Instance.RPowerWizard > 100)
            {
                Singleton.Instance.RPowerWizard = 100;
            }
        }
        protected void setAnglePower()
        {
            //Blue
            // Archer
            if (Singleton.Instance.CurrentCharecter == Singleton.SelectCharecter.SelectArcher && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
            {
                if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Right))
                {
                    Singleton.Instance.BPowerArcher++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Left))
                {
                    Singleton.Instance.BPowerArcher--;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Up))
                {
                    Singleton.Instance.BAngleArcher++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Down))
                {
                    Singleton.Instance.BAngleArcher--;
                }
            }
            // Axeman
            else if (Singleton.Instance.CurrentCharecter == Singleton.SelectCharecter.SelectAxeman && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
            {
                if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Right))
                {
                    Singleton.Instance.BPowerAxeman++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Left))
                {
                    Singleton.Instance.BPowerAxeman--;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Up))
                {
                    Singleton.Instance.BAngleAxeman++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Down))
                {
                    Singleton.Instance.BAngleAxeman--;
                }
            }
            // Spearman
            else if (Singleton.Instance.CurrentCharecter == Singleton.SelectCharecter.SelectSpearman && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
            {
                if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Right))
                {
                    Singleton.Instance.BPowerSpearman++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Left))
                {
                    Singleton.Instance.BPowerSpearman--;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Up))
                {
                    Singleton.Instance.BAngleSpearman++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Down))
                {
                    Singleton.Instance.BAngleSpearman--;
                }
            }
            // Wizard
            else if (Singleton.Instance.CurrentCharecter == Singleton.SelectCharecter.SelectWizard && Singleton.Instance.CurrentTurn == Singleton.TurnState.BlueTurn)
            {
                if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Right))
                {
                    Singleton.Instance.BPowerWizard++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Left))
                {
                    Singleton.Instance.BPowerWizard--;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Up))
                {
                    Singleton.Instance.BAngleWizard++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Down))
                {
                    Singleton.Instance.BAngleWizard--;
                }
            }

            //Red
            //Archer
            if (Singleton.Instance.CurrentCharecter == Singleton.SelectCharecter.SelectArcher && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
            {
                if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Right))
                {
                    Singleton.Instance.RPowerArcher++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Left))
                {
                    Singleton.Instance.RPowerArcher--;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Up))
                {
                    Singleton.Instance.RAngleArcher++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Down))
                {
                    Singleton.Instance.RAngleArcher--;
                }
            }
            // Axeman
            else if (Singleton.Instance.CurrentCharecter == Singleton.SelectCharecter.SelectAxeman && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
            {
                if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Right))
                {
                    Singleton.Instance.RPowerAxeman++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Left))
                {
                    Singleton.Instance.RPowerAxeman--;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Up))
                {
                    Singleton.Instance.RAngleAxeman++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Down))
                {
                    Singleton.Instance.RAngleAxeman--;
                }
            }
            // Spearman
            else if (Singleton.Instance.CurrentCharecter == Singleton.SelectCharecter.SelectSpearman && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
            {
                if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Right))
                {
                    Singleton.Instance.RPowerSpearman++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Left))
                {
                    Singleton.Instance.RPowerSpearman--;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Up))
                {
                    Singleton.Instance.RAngleSpearman++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Down))
                {
                    Singleton.Instance.RAngleSpearman--;
                }
            }
            // Wizard
            else if (Singleton.Instance.CurrentCharecter == Singleton.SelectCharecter.SelectWizard && Singleton.Instance.CurrentTurn == Singleton.TurnState.RedTurn)
            {
                if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Right))
                {
                    Singleton.Instance.RPowerWizard++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Left))
                {
                    Singleton.Instance.RPowerWizard--;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Up))
                {
                    Singleton.Instance.RAngleWizard++;
                }
                else if (Singleton.Instance.CurrentKey.IsKeyDown(Keys.Down))
                {
                    Singleton.Instance.RAngleWizard--;
                }
            }
        }


    }


}
