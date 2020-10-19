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

        public static void AddCharacter(Team sender, string name, string type)
        {
            Character c = new Character(type, name);
            sender.Members.Add(c);
            sender.Health += Character.GetHealth(c);
        }

        public static void Speak(Team sender, int index)
        {
            Character.Speak(sender.Members[index]);
        }

        public static void GetHealth(Team sender, int index)
        {
            Character.GetHealth(sender.Members[index]);
        }

        public static void GetCol(Team sender, int index)
        {
            Character.GetCol(sender.Members[index]);
        }

        public static void GetRow(Team sender, int index)
        {
            Character.GetRow(sender.Members[index]);
        }

        public static void Move(Team sender, int index, int col, int row)
        {
            Character.Move(sender.Members[index], col, row);
        }

        public static void AddToBag(Team sender, int index, Item i)
        {
            Character.AddToBag(sender.Members[index], i);
        }

        public static void Describe(Team sender, int index)
        {
            Character.DescribeBackpack(sender.Members[index]);
        }

        public static void UseIndex(Team sender, int charIndex, int itemIndex)
        {
            Character.UseIndex(sender.Members[charIndex], itemIndex);
            UpdateHealth(sender);
        }

        public static void ModifyHealth(Team sender, int index, int change)
        {
            int health = Character.GetHealth(sender.Members[index]);
            int max_health = Character.GetMaxHealth(sender.Members[index]);

            // Picks the appropriate change of health (accounting for max and 0).
            if (health + change < 1)
            {
                sender.Health -= health;
            }
            else if (health + change > max_health)
            {
                sender.Health += (max_health - health);
            }
            else
            {
                sender.Health += change;
            }

            Character.ModifyHealth(sender.Members[index], change);
        }

        public static void UpdateHealth(Team sender)
        {
            sender.Health = 0;
            foreach (Character c in sender.Members)
            {
                Character.GetHealth(c);
                sender.Health += 0;
            }
        }

        public static void Transfer(Team sender, int from_player, int to_player, int index)
        {
            Character.AddToBag(sender.Members[to_player], Character.GetItem(sender.Members[from_player], index));
            Character.DropIndex(sender.Members[from_player], index);
        }

        public static bool CanLeave(Team sender)
        {
            foreach (Character c in sender.Members)
            {
                if (Character.OnDoor(c) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static Character GetCharacter(Team sender, int index)
        {
            return sender.Members[index];
        }

        public static bool IsAlive(Team sender)
        {
            if (sender.Health < 1)
            {
                return false;
            }
            return true;
        }

        public static int GetCount(Team sender)
        {
            return sender.Members.Count;
        }
    }
}

/*Team.speak(players, 0);
Team.describe(players, 0);
Team.add_to_bag(players, 0, torch);
Team.use_item(players, 0, knife);
Team.move(players, 0, 3, 3);*/