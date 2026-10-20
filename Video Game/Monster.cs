using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game
{
    /// <summary>
    /// In this code, there is X and Y, There is the Health and damage that will show up on the monster.
    /// There is a bool to let you know if the monster is alive or not.
    /// </summary>
    public class Monster
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int Health { get; private set; }
        public int Damage { get; private set; }

        public bool IsAlive => Health > 0;

        /// <summary>
        /// Here you have the public monster that also has X,Y,Health, and damage
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="damage"></param>
        /// <param name="health"></param>
        public Monster(int x, int y, int damage, int health) 
        { 
            X = x;
            Y = y;
            Damage = damage;
            Health = health;
        }
        /// <summary>
        /// In this part of the code this should allow the monster to move around and get the player.
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="player"></param>
        public void MoveTowardsPlayer(char[,] maze, Player player)
        {
            if (!IsAlive)
                return;

            if (X != player.X)
            {
                int nextX = X + (player.X > X ? 1 : -1);
                if (maze[Y, nextX] != '#') // Assuming '#' represents a wall
                {
                    X = nextX;
                    return;
                }
            }

            if (Y != player.Y)
            {
                int nextY = Y + (player.Y > Y ? 1 : -1);
                if (maze[Y, nextY] != '#') // Assuming '#' represents a wall
                {
                    X = nextY;
                    
                }
            }
        }
        /// <summary>
        /// This is going to allow the monster to do damage to the player.
        /// </summary>
        /// <param name="player"></param>
        public void Attack(Player player)
        {
            if (IsAlive)
                player.TakeDamage(Damage);
        }
        /// <summary>
        /// This will let the monster take damage so it isn't immortal.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
        }

    }
}
