using System;
using System.Threading;
using Spectre.Console;
using System.Collections.Generic;
using Textscape.Menus;

namespace Textscape
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create default characters
            var characters = new List<Character>
            {
                new Character("Cow_Crafter64", "Human", "Male", 1),
                new Character("YachtRockBoy", "Dwarf", "Male", 2),
                new Character("Asleepyfawn", "Elf", "Female", 3),
                new Character("kindfable", "Elf", "Non-binary", 4)
            };

            // Display welcome message
            Menus.MainMenu.WelcomeText();

            // Menu flow
            bool showMainMenu = true;
            while (showMainMenu)
            {
                showMainMenu = Menus.MainMenu.HomeMenu(characters);
            }
        }
    }
}
