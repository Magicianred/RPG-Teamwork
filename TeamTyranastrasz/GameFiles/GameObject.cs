﻿using System.Windows.Forms;

namespace RpgGame
{
    public abstract class GameObject
    {
        protected GameObject(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        Position Position { get; set; }
        // image?
    }
}
