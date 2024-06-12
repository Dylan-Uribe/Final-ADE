using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JediManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jedis = LoadJediFromFile("jedis.txt");

            var nameTree = new JediTree();
            var rankingTree = new JediTree();
            var speciesTree = new JediTree();

            foreach (var jedi in jedis)
            {
                nameTree.Insert(jedi, j => j.Name);
                rankingTree.Insert(jedi, j => j.Rankings.First());
                speciesTree.Insert(jedi, j => j.Species);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nJedi Management Menu");
                Console.WriteLine("1. In-order traversal by name");
                Console.WriteLine("2. In-order traversal by ranking");
                Console.WriteLine("3. Level-order traversal by ranking and species");
                Console.WriteLine("4. Show information of Yoda and Luke Skywalker");
                Console.WriteLine("5. Show all Jedi with ranking 'Jedi Master'");
                Console.WriteLine("6. List all Jedi with green lightsabers");
                Console.WriteLine("7. List all Jedi whose masters are in the file");
                Console.WriteLine("8. Show all Jedi of species 'Togruta' or 'Cerean'");
                Console.WriteLine("9. List Jedi starting with 'A' or containing '-'");
                Console.WriteLine("10. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nIn-order traversal by name:");
                        foreach (var jedi in nameTree.InOrderTraversal())
                        {
                            Console.WriteLine(jedi);
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nIn-order traversal by ranking:");
                        foreach (var jedi in rankingTree.InOrderTraversal())
                        {
                            Console.WriteLine(jedi);
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nLevel-order traversal by ranking:");
                        foreach (var jedi in rankingTree.LevelOrderTraversal())
                        {
                            Console.WriteLine(jedi);
                        }
                        Console.WriteLine("\nLevel-order traversal by species:");
                        foreach (var jedi in speciesTree.LevelOrderTraversal())
                        {
                            Console.WriteLine(jedi);
                        }
                        break;

                    case "4":
                        ShowJediInfo(nameTree, "Yoda");
                        ShowJediInfo(nameTree, "Luke Skywalker");
                        break;

                    case "5":
                        Console.WriteLine("\nJedi with ranking 'Jedi Master':");
                        foreach (var jedi in rankingTree.InOrderTraversal().Where(j => j.Rankings.Contains("Jedi Master")))
                        {
                            Console.WriteLine(jedi);
                        }
                        break;

                    case "6":
                        Console.WriteLine("\nJedi with green lightsabers:");
                        foreach (var jedi in nameTree.InOrderTraversal().Where(j => j.LightsaberColors.Contains("green")))
                        {
                            Console.WriteLine(jedi);
                        }
                        break;

                    case "7":
                        Console.WriteLine("\nJedi whose masters are in the file:");
                        var jediNames = new HashSet<string>(jedis.Select(j => j.Name));
                        foreach (var jedi in nameTree.InOrderTraversal().Where(j => j.Masters.Any(m => jediNames.Contains(m))))
                        {
                            Console.WriteLine(jedi);
                        }
                        break;

                    case "8":
                        Console.WriteLine("\nJedi of species 'Togruta' or 'Cerean':");
                        foreach (var jedi in nameTree.InOrderTraversal().Where(j => j.Species == "Togruta" || j.Species == "Cerean"))
                        {
                            Console.WriteLine(jedi);
                        }
                        break;

                    case "9":
                        Console.WriteLine("\nJedi starting with 'A' or containing '-':");
                        foreach (var jedi in nameTree.InOrderTraversal().Where(j => j.Name.StartsWith("A") || j.Name.Contains("-")))
                        {
                            Console.WriteLine(jedi);
                        }
                        break;

                    case "10":
                        return;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static List<Jedi> LoadJediFromFile(string fileName)
        {
            var jedis = new List<Jedi>();
            var lines = File.ReadAllLines(fileName);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                var name = parts[0];
                var species = parts[1];
                var birthYear = int.Parse(parts[2]);
                var lightsaberColors = parts[3].Split(',').ToList();
                var rankings = parts[4].Split(',').ToList();
                var masters = parts[5].Split(',').ToList();

                jedis.Add(new Jedi(name, species, birthYear, lightsaberColors, rankings, masters));
            }

            return jedis;
        }

        static void ShowJediInfo(JediTree tree, string name)
        {
            var jedi = tree.InOrderTraversal().FirstOrDefault(j => j.Name == name);
            if (jedi != null)
            {
                Console.WriteLine(jedi);
            }
            else
            {
                Console.WriteLine($"{name} not found.");
            }
        }
    }
}
