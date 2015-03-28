using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MiniGames.Framework.Input
{
    public class Mouse
    {
        protected MouseState PreviousState;
        protected MouseState State;
        public MouseState GetState() { return State; }
        public Vector2 Position
        {
            set
            {
                Microsoft.Xna.Framework.Input.Mouse.SetPosition((int)value.X, (int)value.Y);
            }
            get
            {
                return new Vector2(State.X, State.Y);
            }
        }
        public int X
        {
            get { return State.X; }
        }
        public int Y
        {
            get { return State.Y; }
        }
        public Mouse()
        {
            LeftButton = new Button(new MouseLeftButton());
            RightButton = new Button(new MouseRightButton());
        }


        public Button LeftButton;
        public Button RightButton;

        public bool Contains(Rectangle rect)
        {
            return rect.Contains(X, Y);
        }

        public virtual void Update()
        {
            PreviousState = State;
            State = Microsoft.Xna.Framework.Input.Mouse.GetState();
            LeftButton.Update();
            RightButton.Update();
        }

        static Mouse instance = new Mouse();
        static public Mouse GetInstance() { return instance; }
    }
} 
