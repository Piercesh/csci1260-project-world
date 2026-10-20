using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game
{
    /// <summary>
    /// Potion will be an extension of Item
    /// </summary>
    public class Potion : Item
    {
        /// <summary>
        /// Here is the heal amount that has a get
        /// </summary>
        public int HealAmount { get; }

        /// <summary>
        /// The heal amount is to give the player health.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="healAmount"></param>
        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }
        /// <summary>
        /// this is to make sure the player will be healed.
        /// </summary>
        /// <param name="player"></param>
        public override void Use(Player player)
        {
            player.Heal(HealAmount);
        }
    }
}
