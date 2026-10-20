using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game
{
    /// <summary>
    /// Player will have X,Y, Health, the maxHealth, Weapondamage, MovesRemaining, EquippedWeapon, and
    /// List<Item>Inventory
    /// </summary>
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int Health { get; private set; }
        public int MaxHealth { get; private set; } = 100;
        public int WeaponDamage { get; private set; } = 0;

        public int MovesRemaining { get; private set; }

        public string EquippedWeapon { get; private set; } = "Fists";

        public List<IItem> Inventory { get; } = new List<IItem>();

        /// <summary>
        /// For the public player you have X,Y, MovesRemaining, and Health to show the maxhealth.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="movesRemaining"></param>
        public Player(int x, int y, int movesRemaining)
        {
            X = x;
            Y = y;
            MovesRemaining = movesRemaining;
            Health = MaxHealth;
        }
        /// <summary>
        /// This what will allow you to move.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// UseMove has bool and it will let you know if you have moved or not.
        /// </summary>
        /// <returns></returns>
        public bool UseMove()
        {
            if (MovesRemaining <= 0)
            {
                return false;
            }

            MovesRemaining--;
            return true;
        }
        /// <summary>
        /// This is to tell you how many moves you have left.
        /// </summary>
        /// <param name="moves"></param>
        public void ResetMoves(int moves)
        {
            MovesRemaining = moves;
        }
        /// <summary>
        /// This is to make sure you take damage.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
        }
        /// <summary>
        /// This will give you the name of the weapon and give you damage bonus.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="damagebonus"></param>
        public void EquipWeapon(string name, int damagebonus)
        {
            EquippedWeapon = name;
            WeaponDamage = damagebonus;
        }
        /// <summary>
        /// This will allow you to heal
        /// </summary>
        /// <param name="amount"></param>
        public void Heal(int amount)
        {
            Health = Math.Min(MaxHealth, Health + amount);

        }
        /// <summary>
        /// This will add the item to your inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(IItem item)
        {
            Inventory.Add(item);
        }
        /// <summary>
        /// This will give you bonus damage
        /// </summary>
        /// <returns></returns>
        public int GetAttackDamage()
        {
            return 10 + WeaponDamage;
        }
        /// <summary>
        /// Here this will show the inventory.
        /// </summary>
        public void ShowInventory()
        {
            Console.WriteLine("\n---Inventory---");
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Inventory[i].Name}");
                }

                Console.WriteLine($"Equipped weapon : {EquippedWeapon}");
                Console.WriteLine($"Attack damage: {GetAttackDamage}");
            }
        }
        /// <summary>
        /// This will let you use the items in your inventory.
        /// </summary>
        public void UseInventoryItem()
        {
            ShowInventory();

            if ( Inventory.Count == 0)
            {
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey(true);
                return;
            }

            Console.Write("\nChoose an item number (0 to cancel): ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.ReadKey(true);
                return;
            }
            if (choice == 0)
            {
                return;
            }
            if (choice < 1 || choice > Inventory.Count)
            {
                Console.WriteLine("Invalid choice.");
                Console.ReadKey(true);
                return;
            }

            IItem item = Inventory[choice - 1];

            item.Use(this);
            Inventory.RemoveAt(choice - 1);

            Console.WriteLine($"\nUsed {item.Name}!");

            if (item is Potion)
            {
                Console.WriteLine($"Health: {Health}/{MaxHealth}");
            }
            else if (item is Weapon)
            {
                Console.WriteLine($"Equipped weapon: {EquippedWeapon}");
                Console.WriteLine($"Attack damage: {GetAttackDamage()}");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }
    }


}
