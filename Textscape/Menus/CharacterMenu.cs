using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Spectre.Console;

namespace Textscape.Menus
{
    class CharacterMenu : MenuBase
    {
       public static bool CharMenu(Character character)
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"Welcome {character.Name}");
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[underline]Make A Selection:[/]")
                    .AddChoices(new[]
                    {
                    "1. Show Character Info", "2. Check Inventory", "3. Perform Task", "4. Exit"
                    }));
            var selectionNumber = selection[0];
            Console.Clear();
            switch (selectionNumber) {
                case '1':
                    var infoTable = new Table();
                    infoTable.AddColumn("");
                    infoTable.AddColumn("");
                    infoTable.AddRow("Name:", $"{character.Name}");
                    infoTable.AddRow("Race:", $"{character.Race}");
                    infoTable.AddRow("Gender:", $"{character.Gender}");
                    infoTable.AddRow("Level:", $"{character.Level}");
                    infoTable.Border(TableBorder.DoubleEdge);
                    infoTable.HideHeaders();
                    infoTable.Centered();
                    AnsiConsole.Render(infoTable);
                    Caboose();
                    return true;
                case '2':
                    var inventoryTable = new Table();
                    inventoryTable.AddColumn("Name:");
                    inventoryTable.AddColumn("Weight:");
                    inventoryTable.AddColumn("Value:");
                    inventoryTable.Centered();
                    var totalWeight = 0;
                    var totalValue = 0;
                    foreach (var item in character.Inventory)
                    {
                        inventoryTable.AddRow($"{item.Name}", $"{item.Weight}lbs", $"{item.Value}gp");
                        totalWeight += item.Weight;
                        totalValue += item.Value;
                    }
                    var totalTable = new Table();
                    totalTable.AddColumn("");
                    totalTable.AddColumn("");
                    totalTable.AddColumn("");
                    totalTable.HideHeaders();
                    totalTable.Centered();
                    totalTable.AddRow("Total", $"{totalWeight}lbs", $"{totalValue}gp");
                    if (character.Inventory.Capacity > 0)
                    {
                        AnsiConsole.Render(inventoryTable);
                        AnsiConsole.Render(totalTable);
                    } else
                    {
                        AnsiConsole.MarkupLine("Inventory Empty, Do Tasks To Earn Items");
                    }
                    Caboose();
                    return true;
                case '3':
                    // put Task Menu here
                    var taskMenuRunning = true;
                    while (taskMenuRunning)
                    {
                        taskMenuRunning = Menus.TaskMenu.Menu(character);
                    }
                    return true;
                case '4':
                    return false;
                default:
                    return true;
            }
        }
    }
}
