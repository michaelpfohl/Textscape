using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using Spectre.Console;

namespace Textscape.Menus
{
    class MainMenu
    {
        public static void WelcomeText()
        {
            AnsiConsole.Render(new FigletText("WELCOME TO TEXTSCAPE")
                .Centered()
                .Color(Color.Aqua));
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static bool HomeMenu(List<Character> Characters)
        {

            var characterNames = new List<string>();
            foreach (var character in Characters)
            {
                characterNames.Add(character.Name);
            }

            Console.Clear();
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[underline]Make A Selection:[/]")
                    .AddChoices(new[]
                    {
                    "1. Create A New Character", "2. Load Character", "3. Delete Character","4. Information", "5. Exit"
                    }));
            var selectionNumber = selection[0];
            switch (selectionNumber)
            {
                case '1':
                    // allow user to create a character
                    Console.Clear();
                    AnsiConsole.MarkupLine("[underline]CREATE A CHARACTER[/]");
                    var name = AnsiConsole.Ask<string>("Enter Name:");
                    Console.Clear();
                    var race = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Select Race:")
                            .AddChoices(new[]
                            { 
                              "Human", "Elf", "Dwarf"  
                            }));
                    Console.Clear();
                    var gender = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Select Gender:")
                            .AddChoices(new[]
                            {
                              "Female", "Male", "Non-Binary"
                            }));
                    Console.Clear();
                    var characterID = Characters.Last().CharacterID + 1;
                    Characters.Add(new Character(name, race, gender, characterID));
                    AnsiConsole.Markup($"Welcome to [aqua]Textscape[/], [lime]{name}[/]");
                    Thread.Sleep(2000);
                    return true;
                case '2':
                    // list characters and allow user to select a character
                    Console.Clear();
                    var characterSelection = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[underline]Select Character:[/]")
                            .AddChoices(characterNames));
                    var selectedCharacter = Characters.Find(character => character.Name == characterSelection);
                    var charMenuRunning = true;
                    while (charMenuRunning)
                    {
                        charMenuRunning = Menus.CharacterMenu.CharMenu(selectedCharacter);
                    }
                    return true;
                case '3':
                    // allow user to delete a character
                    Console.Clear();
                    var characterToDelete = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[underline]Select Character To Delete:[/]")
                            .AddChoices(characterNames));
                    var deletedCharacter = new Character("delete", "delete", "delete", 69);
                    foreach (var character in Characters)
                    {
                        if (characterToDelete == character.Name)
                        {
                            deletedCharacter = character;
                        }
                    }
                    Characters.Remove(deletedCharacter);
                    Console.Clear();
                    AnsiConsole.Markup($"[red]{characterToDelete}'s journey has ended[/]");
                    Thread.Sleep(2000);
                    return true;
                case '4':
                    Console.Clear();
                    // ADD INFORMATION / TUTORIAL
                    AnsiConsole.Markup("INFORMATION");
                    return true;
                case '5':
                    Console.Clear();
                    AnsiConsole.Markup("GOODBYE");
                    Thread.Sleep(1000);
                    return false;
                default:
                    return true;
            }
        }
    }
}
