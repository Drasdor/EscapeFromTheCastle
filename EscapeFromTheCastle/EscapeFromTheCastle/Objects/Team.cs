using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    public class Team
    {
        private readonly List<Character> Members = new List<Character>();
        private readonly string Name;
        private int Health;

        public Team(string name)
        {
            Name = name;
        }

        public void AddCharacter(string name, string type)
        {
            Character c = new Character(type, name);
            Members.Add(c);
            Health += c.GetHealth();
        }

        public void Speak(int index)
        {
            Members[index].Speak();
        }

        public void GetHealth(int index)
        {
            Members[index].GetHealth();
        }

        public void GetCol(int index)
        {
            Members[index].GetCol();
        }

        public void GetRow(int index)
        {
            Members[index].GetRow();
        }

        public void Move(int index, int col, int row)
        {
            Members[index].Move(col, row);
        }

        public void AddToBag(int index, Item i)
        {
            Members[index].AddToBag(i);
        }

        public void Describe(int index)
        {
            Members[index].DescribeBackpack();
        }

        public void UseIndex(int charIndex, int itemIndex)
        {
            Members[charIndex].UseIndex(itemIndex);
            UpdateHealth();
        }

        public void ModifyHealth(int index, int change)
        {
            int health = Members[index].GetHealth();
            int maxHealth = Members[index].GetMaxHealth();

            // Picks the appropriate change of health (accounting for max and 0).
            if (health + change < 1)
            {
                Health -= health;
            }
            else if (health + change > maxHealth)
            {
                Health += (maxHealth - health);
            }
            else
            {
                Health += change;
            }

            Members[index].ModifyHealth(change);
        }

        public void UpdateHealth()
        {
            Health = 0;
            foreach (Character c in Members)
            {                
                Health += c.GetHealth();
            }
        }

        public void Transfer(int fromPlayer, int toPlayer, int index)
        {
            Members[toPlayer].AddToBag(Members[fromPlayer].GetItem(index));
            Members[fromPlayer].DropIndex(index);
        }

        public bool CanLeave()
        {
            foreach (Character c in Members)
            {
                if (c.OnDoor() == false)
                {
                    return false;
                }
            }
            return true;
        }

        public Character GetCharacter(int index)
        {
            return Members[index];
        }

        public bool IsAlive()
        {
            if (Health < 1)
            {
                return false;
            }
            return true;
        }

        public int GetCount()
        {
            return Members.Count;
        }
    }
}

/*Team.speak(players, 0);
Team.describe(players, 0);
Team.add_to_bag(players, 0, torch);
Team.use_item(players, 0, knife);
Team.move(players, 0, 3, 3);*/