using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Linq;

namespace EscapeFromTheCastle
{
    public class Room
    {
        private List<List<Tile>> Tiles = new List<List<Tile>>();

        public Room(List<List<Tile>> tiles)
        {
            Tiles = tiles;
        }

        public Room(string name)
        {
            string path = $"{name}.txt";

            using (StreamReader sr = new StreamReader(@"rooms\" + path))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    Tiles.Add(new List<Tile>());
                    for (int i2 = 0; i2 < line.Length; i2++)
                    {
                        Tile t = new Tile(line[i2]);
                        Tiles[i].Add(t);
                    }
                    i = i + 1;
                }
            }
        }

        public void DrawRoom()
        {
            foreach (List<Tile> row in Tiles)
            {
                foreach (Tile til in row)
                {
                    Console.ForegroundColor = til.GetColour();
                    Console.Write(til.GetChar());
                }
                Console.WriteLine();
            }
        }

        public void RoomCreator(string name)
        {
            do
            {
                try
                {
                    Console.WriteLine("Please enter the number of rows you want");
                    int row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the number of columns you want");
                    int col = Convert.ToInt32(Console.ReadLine());
                    string path = $"{name}.txt";

                    using StreamWriter sw = new StreamWriter(@"rooms\" + path);
                    for (int r = 0; r < row - 1; r++)
                    {
                        for (int c = 0; c < col; c++)
                        {
                            sw.Write(Console.ReadKey().KeyChar);
                        }
                        Console.WriteLine();
                        sw.WriteLine();
                    }
                    sw.Close();

                    for (int c = 0; c < col; c++)
                    {
                        sw.Write(Console.ReadKey().KeyChar);
                    }
                    Console.WriteLine();
                    break;
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Please try again");
                }
            } while (true);
        }
    }
}

/*Room.room_creator("dungeon");
Room r = new Room("dungeon");
Room.draw_room(r);*/