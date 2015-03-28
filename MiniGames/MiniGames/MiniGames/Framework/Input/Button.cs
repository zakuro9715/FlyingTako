using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniGames.Framework.Input
{
    public class Button
    {
        IDigitalInput Source
        {
            get;
            set;
        }

        bool previous;

        public Button(IDigitalInput Source)
        {
            this.Source = Source;
        }


        public bool IsPressed
        {
            get
            {
                return Source.IsPressed();
            }
        }

        public bool IsBeingPressed
        {
            get
            {
                return !previous && Source.IsPressed();
            }
        }

        public bool IsBeingReleased
        {
            get
            {
                return previous && !Source.IsPressed();
            }
        }

        public void Update()
        {
            previous = Source.IsPressed();
            Source.Update();
        }
    }
}
