using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public interface IItemState
    {
        IAnimatedSprite Sprite { get; set; }
        void ToLeft();
        void ToRight();
        void Appear();
        void Disappear();
    }
}
