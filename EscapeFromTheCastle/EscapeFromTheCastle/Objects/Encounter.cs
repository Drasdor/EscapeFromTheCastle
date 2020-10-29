using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheCastle
{
    class Encounter
    {
        private readonly Room CurrentRoom;
        private readonly Team Enemies = new Team("enemies");
        private readonly Dictionary<int, Character> CharacterDictionary = new Dictionary<int, Character>();
        private readonly Team Players;

        public Encounter(string name, Team players)
        {
            if (name == "entrance")
            {
                CurrentRoom = new Room("entrance");
            }
            Players = players;
            AddCharacters();
        }

        public void Run()
        {
            do
            {
                int total = CharacterCount(Players);
                for (int i = 0; i < total; i++)
                {
                    Turn(i, Players);
                    
                }
            } while (true);

        }

        public void AddCharacters()
        {
            for (int i = 0; i < Players.GetCount(); i++)
            {
                CharacterDictionary.Add(i, Players.GetCharacter(i));
            }
            for (int i = 4; i < Enemies.GetCount() + 4; i++)
            {
                CharacterDictionary.Add(i, Enemies.GetCharacter(i));
            }
            CurrentRoom.AddPlayers(Players);
        }

        public void Turn(int index, Team players)
        {
            CurrentRoom.DrawRoom();            
            Character currentCharacter = players.GetCharacter(index);
            int choice = currentCharacter.ActionMenu();
            if (choice == 1)
            {

            }
            else if (choice == 5)
            {
                WriteKey();
            }
        }

        public void WriteKey()
        {
            Console.WriteLine("Key:");
            Console.WriteLine("X - Empty space");
            Console.WriteLine("| - Wall");
            Console.WriteLine("D - Door");
            Console.WriteLine("C - Chest");
            foreach(KeyValuePair<int, Character> character in CharacterDictionary)
            {
                Console.WriteLine($"{character.Key} - {character.Value.GetName()}");
            }
        }

        public int CharacterCount(Team players)
        {
            return Enemies.GetCount() + players.GetCount();
        }
    }
}
