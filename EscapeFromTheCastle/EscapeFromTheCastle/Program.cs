using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace EscapeFromTheCastle
{
    class Program
    {
        static void Main()
        {
            Door d = new Door(true, "vX72#sf");
            Key k = new Key("vX72#sf");
            Key k2 = new Key("VX72#sf");
            Door.Unlock(d, k);
            Door.Lock(d, k2);
            Item torch = new Item("torch");
            Weapon knife = new Weapon("knife");
            Food chicken = new Food("chicken");
            int playerNumber = 0;
            string teamName = "";

            Console.WriteLine("Please enter a team name");
            teamName = Console.ReadLine();

            do
            {
                try
                {
                    Console.WriteLine("How many people are playing (between 1 and 4)?");
                    playerNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a whole number.");
                }
            } while (playerNumber > 4 || playerNumber < 1);

            Team players = new Team(teamName);

            for (int i = 0; i < playerNumber; i++)
            {
                Console.WriteLine($"What is the name of player {i + 1}?");
                string name = Console.ReadLine();
                Team.AddCharacter(players, name, "human");
                Team.AddToBag(players, i, torch);
                Team.AddToBag(players, i, knife);
                Console.WriteLine();
            }

            Character c = Team.GetCharacter(players, 0);
            Character.ModifyHealth(c, -50);
            Character.AddToBag(c, chicken);
            Character.EatIndex(c, 2);
            Console.WriteLine(Character.GetHealth(c));
            Team.UpdateHealth(players);

            Encounter entrance = new Encounter("entrance");
            Encounter.Run(entrance, players);

            Console.ReadLine();
        }
    }
}