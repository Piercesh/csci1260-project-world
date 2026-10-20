using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game
{
    /// <summary>
    /// Here is the Interface for Item.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// This will get the name and will allow you to use the potion and weapon.
        /// </summary>
        string Name { get; }
        void Use(Player player);
    }
}
