using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalGame.GameObjects;

namespace FinalGame
{
    class Singleton
    {
        public const int SCREENWIDTH = 1200;
        public const int SCREENHEIGHT = 800;
        public const int ARCHERWIDTH = 30;
        public const int ARCHERHEIGHT = 40;
        public const int ARROWWIDTH = 30;
        public const int ARROWHEIGHT = 5;
        public const int AXEMANWIDTH = 30;
        public const int AXEMANHEIGHT = 30;
        public const int AXEWIDTH = 10;
        public const int AXEHEIGHT = 20;
        public const int SPEARMANWIDTH = 30;
        public const int SPEARMANHEIGHT = 40;
        public const int SPEARWIDTH = 40;
        public const int SPEARHEIGHT = 5;
        public const int WIZARDWIDTH = 30;
        public const int WIZARDHEIGHT = 40;
        public const int WIZARDBULLETWIDTH = 15;
        public const int WIZARDBULLETHEIGHT = 15;
        public const int FIREBALLWIDTH = 20;
        public const int FIREBALLHEIGHT = 10;
        public const int THUNDERWIDTH = 30;
        public const int THUNDERHEIGHT = 15;
        public const int FLAGWIDTH = 57;
        public const int FLAGHEIGHT = 122;
        public const int ITEMSIZE = 30;

        public const int minHP = 50;

        public int XPositionBArcher = 110;
        public int YPositionBArcher = 550;
        public int XPositionRArcher = 1060;
        public int YPositionRArcher = 550;

        public int XPositionBAxeman = 305;
        public int YPositionBAxeman = 615;
        public int XPositionRAxeman = 865;
        public int YPositionRAxeman = 615;

        public int XPositionBSpearman = 300;
        public int YPositionBSpearman = 515;
        public int XPositionRSpearman = 870;
        public int YPositionRSpearman = 515;

        public int XPositionBWizard = 190;
        public int YPositionBWizard = 555;
        public int XPositionRWizard = 980;
        public int YPositionRWizard = 555;

        public int XPositionRFlag = 1043;
        public int YPositionRFlag = 613;
        public int XPositionBFlag = 100;
        public int YPositionBFlag = 613;


        public const int CASTLEWIDTH1 = 300;
        public const int CASTLEHEIGHT1 = 250;
        public const int TextturnWIDTH = 150;
        public const int TextturnHEIGHT = 50;
        public const int SizeDrawItem = 60;

        public const int MARKSIZE = 60;
        public float MasterBGMVolume;
        public float MasterSFXVolume;
        public float CooldownCombo = 0;

        public int Wind, arrowleft;
        public float BAngleArcher, BAngleAxeman, BAngleSpearman, BAngleWizard;
        public float BPowerArcher, BPowerAxeman, BPowerSpearman, BPowerWizard;
        public float RAngleArcher, RAngleAxeman, RAngleSpearman, RAngleWizard;
        public float RPowerArcher, RPowerAxeman, RPowerSpearman, RPowerWizard;
        public int Gravity = 10;

        public Boolean RedHaveItemHeal = false;
        public Boolean RedHaveItemMeteor = false;
        public Boolean BlueHaveItemHeal = false;
        public Boolean BlueHaveItemMeteor = false;
        public Boolean RndItemOnMap = false;

        //TODO: Game State Machine
        public enum GameState
        {
            GameMain,
            GameStart,
            SelectCastle,
            SelectWarrior,
            GamePlaying,
            GameRedWin,
            GameBlueWin,
            GameEnded,
        }
        public enum TurnState
        {
            BlueTurn,
            RedTurn,
        }
        public enum SelectCharecter
        {
            SelectArcher,
            SelectAxeman,
            SelectSpearman,
            SelectWizard
        }

        public enum WizardTypeShoot
        {
            Bullet,
            Fireball,
            Thunder
        }
        public GameState CurrentGameState;
        public TurnState CurrentTurn;
        public SelectCharecter CurrentCharecter;
        public WizardTypeShoot CurrentWizardshootRed;
        public WizardTypeShoot CurrentWizardshootBlue;


        public enum GameResult
        {
            Win,
            Lose
        }



        public GameResult CurrentGameResult;
        public KeyboardState PreviousKey, CurrentKey;
        public MouseState CurrentMouse;
        public MouseState PreviousMouse;


        private static Singleton instance;

        private Singleton()
        {

        }
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

    }
}

