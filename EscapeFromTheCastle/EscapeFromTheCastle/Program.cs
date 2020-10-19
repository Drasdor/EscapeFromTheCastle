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
            d.Unlock(k);
            d.Lock(k2);
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
                players.AddCharacter(name, "human");
                players.AddToBag(i, torch);
                players.AddToBag(i, knife);
                Console.WriteLine();
            }

            Character c = players.GetCharacter(0);
            c.ModifyHealth(-50);
            c.AddToBag(chicken);
            c.EatIndex(2);
            Console.WriteLine(c.GetHealth());
            players.UpdateHealth();

            Encounter entrance = new Encounter("entrance");
            entrance.Run(players);

            Console.ReadLine();
        }
    }
}