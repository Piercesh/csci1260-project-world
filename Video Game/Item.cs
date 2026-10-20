using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game
{
    /// <summary>
    /// This is the abstract class for item
    /// It will be connected to potion and weapon
    /// </summary>
    public abstract class Item : IItem
    {
        public string Name { get; protected set; }
        /// <summary>
        /// this will be the only protected item there is and is only going to be for names
        /// </summary>
        /// <param name="name"></param>
        protected Item(string name)
        {
            Name = name;
        }
        /// <summary>
        /// abstract void will be here for Use Player player
        /// </summary>
        /// <param name="player"></param>
        public abstract void Use(Player player);
    }

}