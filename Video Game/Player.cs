using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Game
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public int Health { get; private set; }
        public int MaxHealth { get; private set; } = 100;

        
        public int MovesRemaining { get; private set; }

        public Player(int startX, int startY, int maxMoves)
        {
            Reset(startX, startY, maxMoves);
        }

        public void Move(int newX, int newY)
        {
            X = newX;
            Y = newY;
            MovesRemaining--;
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0)
                return;
            Health -= amount;
            if (Health < 0)
                Health = 0;
        }

        public void Heal(int amount)
        {
            if (amount <= 0)
                return;
            Health += amount;

            if (Health > MaxHealth)
                Health = MaxHealth;
        }
        public void Reset(int startX, int startY, int maxMoves)
        {
            X = startX;
            Y = startY;
            MovesRemaining = maxMoves;
            Health = MaxHealth;
        }
    }


}
