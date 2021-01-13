using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ListOfObjects.Things;

namespace ListOfObjects
{


    class Program
    {
        static void Main(string[] args)
        {
            //List<Monster> monsters = new List<Monster>();

            //Monster suzy = new Monster("Suzy", 89);
            //Monster fred = new Monster("Fred", 77);
            //monsters.Add(suzy);
            //monsters.Add(fred);

            List<Monster> monsters = new List<Monster>()
            {
                new Monster()
                {
                    Name = "Fred",
                    Age = 66,
                    Attitude = Monster.Mood.angry
                },

                new Monster("Suzy", 76, Monster.Mood.happy)
            };

            AddMonsters(monsters);
            DisplayMonsters(monsters);
            SaveMonsters(monsters);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void SaveMonsters(List<Monster> monsters)
        {
            string dataPath = @"Data\monsters.txt";
            string monsterString;

            foreach (Monster monster in monsters)
            {
                monsterString = monster.Name + "," + monster.Age + "," + monster.Attitude + Environment.NewLine;
                File.AppendAllText(dataPath, monsterString);
            }
        }

        private static void DisplayMonsters(List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tDisplay Monsters");
            Console.WriteLine();

            //
            // display headers
            //
            Console.WriteLine(
                "Name".PadLeft(15) +
                "Age".PadLeft(10) +
                "Attitude".PadLeft(15)
                );
            Console.WriteLine(
                "----".PadLeft(15) +
                "---".PadLeft(10) +
                "--------".PadLeft(15)
                );

            foreach (Monster monster in monsters)
            {
                Console.WriteLine(
                monster.Name.PadLeft(15) +
                monster.Age.ToString().PadLeft(10) +
                monster.Attitude.ToString().PadLeft(15)
                );
            }

        }

       
        private static void AddMonsters(List<Monster> monsters)
        {
            bool validResponse;

            Console.WriteLine();
            Console.WriteLine("\t\tAdd Monsters");
            Console.WriteLine();

            bool doneAdding = false;
            do
            {
                Monster monster = new Monster();

                //
                // get name
                //
                Console.Write("Name: ");
                monster.Name = Console.ReadLine();

                //
                // get age
                //
                do
                {
                    validResponse = true;
                    Console.Write("Age:");

                    if (int.TryParse(Console.ReadLine(), out int age))
                    {
                        monster.Age = age;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a proper integer.");
                        validResponse = false;
                    }

                } while (!validResponse);

                //
                // add attitude
                //
                do
                {
                    validResponse = true;
                    Console.Write("Attitude:");

                    if (Enum.TryParse(Console.ReadLine().ToLower().Trim(), out Monster.Mood attitude))
                    {
                        monster.Attitude = attitude;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a proper attitude.");
                        foreach (Monster.Mood name in Enum.GetValues(typeof(Monster.Mood)))
                        {
                            Console.Write(" | " + name);
                        }
                        Console.WriteLine();

                        validResponse = false;
                    }

                } while (!validResponse);

                //
                // add monster to list
                //
                monsters.Add(monster);

                Console.Write("Add Another:");
                string userRespsone = Console.ReadLine().ToLower();
                if (userRespsone == "no")
                {
                    doneAdding = true;
                }

            } while (!doneAdding);
        }
    }
}
