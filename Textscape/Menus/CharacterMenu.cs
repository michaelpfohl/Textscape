using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Spectre.Console;

namespace Textscape.Menus
{
    class CharacterMenu
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
                    var table = new Table();
                    table.AddColumn("");
                    table.AddColumn("");
                    table.AddRow("Name:", $"{character.Name}");
                    table.AddRow("Race:", $"{character.Race}");
                    table.AddRow("Gender:", $"{character.Gender}");
                    table.AddRow("Level:", $"{character.Level}");
                    table.Border(TableBorder.DoubleEdge);
                    table.HideHeaders();
                    table.Centered();
                    AnsiConsole.Render(table);
                    AnsiConsole.MarkupLine("[blue]Press Enter To Return To Character Menu[/]");
                    var proceed = Console.ReadLine();
                    return true;
                case '2':
                    return true;
                case '3':
                    return true;
                case '4':
                    return false;
                default:
                    return true;
            }
        }
    }
}
