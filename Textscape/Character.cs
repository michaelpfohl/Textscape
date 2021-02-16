using System;
using System.Collections.Generic;
using System.Text;

namespace Textscape.Menus
{
    class Character
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public int Level { get; set; }
        public int CharacterID { get; set;}
        public List<Item> Inventory { get; set; } = new List<Item>();

        public Character(string name, string race, string gender, int characterID)
        {
            Name = name;
            Race = race;
            Gender = gender;
            CharacterID = characterID;
            Level = 1;
        }
     }
}
