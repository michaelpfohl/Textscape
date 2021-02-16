using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Spectre.Console;

namespace Textscape.Menus
{
    class TaskMenu : MenuBase
    {
        public static bool Menu(Character character)
        {
            Console.Clear();
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[underline]Choose Task:[/]")
                    .AddChoices(new[]
                    {
                    "Woodcutting", "Fishing", "Mining", "Exit"
                    }));
            Console.Clear();
            switch(selection){
                case "Woodcutting":
                    Console.Clear();
                    var log = new Item("Log", 5, 10);
                    character.Inventory.Add(log);
                    AnsiConsole.MarkupLine("After swinging your arm in the same motion you somehow receive logs!");
                    Caboose();
                    return true;
                case "Fishing":
                    Console.Clear();
                    var shrimp = new Item("Shrimp", 1, 15);
                    character.Inventory.Add(shrimp);
                    AnsiConsole.MarkupLine("After dipping a net into the same spot just off the shore you somehow receive shrimp!");
                    Caboose();
                    return true;
                case "Mining":
                    Console.Clear();
                    var copperOre = new Item("Copper Ore", 5, 25);
                    character.Inventory.Add(copperOre);
                    AnsiConsole.MarkupLine("After swinging your pickaxe at the same rock you somehow receive copper ore!");
                    Caboose();
                    return true;
                case "Exit":
                    return false;
                default:
                    return true;
            }
        }
    }
}
