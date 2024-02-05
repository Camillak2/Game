using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.MongoDB
{
    public class Team
    {
        public Team()
        {
            TeamName = "TestTeam";
            TeamList = CreateUsers();
        }

        public string TeamName { get; set; }
        public List<Character> TeamList;


        static List<Character> CreateUsers()
        {
            List<Character> characters = new List<Character>();
            characters.Add(new Character("Warrior", 30, 250, 15, 80, 10, 50, 25, 100, 80, 10, 30, 15, 2, 5, 3, 15));
            characters.Add(new Character("Rogue", 20, 65, 30, 250, 15, 70, 20, 80, 40, 18, 25, 45, 3, 8, 6, 30));
            characters.Add(new Character("Wizard", 15, 45, 20, 80, 35, 250, 15, 70, 28, 53, 8, 20, 35, 35, 4, 20));
            return characters;
        }
    }
}
