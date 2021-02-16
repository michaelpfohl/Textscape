using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace Textscape.Menus
{
    class MenuBase
    {
        public static void Caboose()
        {
            AnsiConsole.MarkupLine("[blue]Press Enter To Return To Character Menu[/]");
            var proceed = Console.ReadLine();
        }
    }
}
