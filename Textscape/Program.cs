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
            var characters = new List<Character>
            {
                new Character("Cow_Crafter64", "Human", "Male", 1),
                new Character("YachtRockBoy", "Dwarf", "Male", 2),
                new Character("Asleepyfawn", "Elf", "Female", 3),
                new Character("kindfable", "Elf", "Non-binary", 4)
            };

            Menus.MainMenu.WelcomeText();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menus.MainMenu.HomeMenu(characters);
            }
        }
    }
}
