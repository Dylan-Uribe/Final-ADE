using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelHeroesAndVillainsTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MarvelTree tree = new MarvelTree();
            tree.Insert("Spider-Man", true);
            tree.Insert("Iron Man", true);
            tree.Insert("Capitán América", true);
            tree.Insert("Doctor Strange", true);
            tree.Insert("Scarlet Witch", true);
            tree.Insert("Black Widow", true);
            tree.Insert("Doctor Doom", false);
            tree.Insert("Profesor X", true);
            tree.Insert("Kitty Pride", true);
            tree.Insert("Storm", true);
            tree.Insert("Thanos", false);
            tree.Insert("She-Hulk", true);
            tree.Insert("Magneto", false);
            tree.Insert("Wolverine", true);
            tree.Insert("Black Panther", true);
            tree.Insert("The Hulk", true);
            tree.Insert("Gamora", true);
            tree.Insert("Starlod", true);
            tree.Insert("Ant-Man", true);
            tree.Insert("Apocalipsis", false);
            tree.Insert("Thor", true);
            tree.Insert("Captain Marvel", true);
            tree.Insert("HawKeye", true);
            tree.Insert("Winter Soldier", true);
            tree.Insert("Falcon", true);
            tree.Insert("Nebula", true);
            tree.Insert("Jessica Jones", false);
            tree.Insert("Daredevil", true);
            tree.Insert("Phoenix", false);
            tree.Insert("Silver Surfer", true);
            tree.Insert("Loki", false);
            tree.Insert("Shang-Chi", false);
            tree.Insert("DeadPool", true);
            tree.Insert("Punisher", false);
            tree.Insert("Vision", true);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nMarvel Heroes and Villains Tree Menu");
                Console.WriteLine("1. List Villains in alphabetical order");
                Console.WriteLine("2. Show all superheroes starting with 'C'");
                Console.WriteLine("3. Count the total number of superheroes in the tree");
                Console.WriteLine("4. Modify 'Doctor Strange' ");
                Console.WriteLine("5. List superheroes in descending order");
                Console.WriteLine("6. Split forest into hero and villain trees and show details");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nVillains in alphabetical order:");
                        foreach (var villain in tree.ListVillains())
                        {
                            Console.WriteLine(villain);
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nSuperheroes starting with 'C':");
                        foreach (var hero in tree.ListHeroesStartingWithC())
                        {
                            Console.WriteLine(hero);
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nTotal number of superheroes in the tree: " + tree.CountHeroes());
                        break;

                    case "4":
                        Console.WriteLine("\nType the new 'Doctor Strange' name: ");
                        string newName = Console.ReadLine();
                        tree.ModifyName("Doctor Strange", newName);
                        Console.WriteLine("\nTree after modifying 'Doctor Strange':");
                        foreach (var name in tree.InOrderTraversal())
                        {
                            Console.WriteLine(name);
                        }
                        break;

                    case "5":
                        Console.WriteLine("\nSuperheroes in descending order:");
                        foreach (var hero in tree.ListHeroesDescending())
                        {
                            Console.WriteLine(hero);
                        }
                        break;

                    case "6":
                        tree.SplitForest(out MarvelTree heroTree, out MarvelTree villainTree);

                        Console.WriteLine("\nNumber of nodes in the hero tree: " + heroTree.CountNodes());
                        Console.WriteLine("Number of nodes in the villain tree: " + villainTree.CountNodes());

                        Console.WriteLine("\nHeroes in alphabetical order:");
                        foreach (var hero in heroTree.InOrderTraversal())
                        {
                            Console.WriteLine(hero);
                        }

                        Console.WriteLine("\nVillains in alphabetical order:");
                        foreach (var villain in villainTree.InOrderTraversal())
                        {
                            Console.WriteLine(villain);
                        }
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
