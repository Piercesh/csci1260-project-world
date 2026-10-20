using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game
{
    public class Weapon : Item
    {
        /// <summary>
        /// This will make you do more damage once a weapon has been picked up
        /// </summary>
        public int DamageBonus { get; }
        /// <summary>
        /// This will get the name, damagebonus and also has a base to it.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damageBonus"></param>
        public Weapon(string name, int damageBonus) : base(name)
        {
            DamageBonus = damageBonus;
        }
        /// <summary>
        /// Much like in potion this will also have an override Use.
        /// This time it will allow the player to equip the weapon and show the name and the extra damage
        /// it does.
        /// </summary>
        /// <param name="player"></param>
        public override void Use(Player player)
        {
            player.EquipWeapon(Name,DamageBonus);
        }
    }
}
