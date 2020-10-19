using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    class Encounter
    {
        private readonly Room CurrentRoom;
        private readonly Team Enemies = new Team("enemies");

        public Encounter(string name)
        {
            if (name == "entrance")
            {
                CurrentRoom = new Room("entrance");
            }
        }

        public static void Run(Encounter sender, Team players)
        {
            do
            {
                int total = CharacterCount(sender, players);
                for (int i = 0; i < total; i++)
                {
                    Turn(sender, i);
                    Character.ActionMenu(Team.GetCharacter(players, 0));
                }
            } while (true);
        }

        public static void Turn(Encounter sender, int index)
        {
            Room.DrawRoom(sender.CurrentRoom);
        }

        public static int CharacterCount(Encounter sender, Team players)
        {
            return (Team.GetCount(sender.Enemies) + Team.GetCount(players));
        }
    }
}
