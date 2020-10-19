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

        public void Run(Team players)
        {
            do
            {
                int total = CharacterCount(players);
                for (int i = 0; i < total; i++)
                {
                    Turn(i, players);
                    
                }
            } while (true);
        }

        public void Turn(int index, Team players)
        {
            CurrentRoom.DrawRoom();
            Character currentCharacter = players.GetCharacter(index);
            currentCharacter.ActionMenu();
        }

        public int CharacterCount(Team players)
        {
            return (Enemies.GetCount() + players.GetCount());
        }
    }
}
