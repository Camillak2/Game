using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.MongoDB;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Warrior WarriorChange { get; set; }
        public static Rogue RogueChange { get; set; }
        public static Wizard WizardChange { get; set; }
    }
}
