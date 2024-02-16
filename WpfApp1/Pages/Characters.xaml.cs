using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.MongoDB;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Characters.xaml
    /// </summary>
    public partial class Characters : Page
    {
        private CRUD _crud;
        private Warrior _selectedWarrior;
        private Rogue _selectedRogue;
        private Wizard _selectedWizard;

        public Characters(CRUD crud, Warrior selectedWarrior, Rogue selectedRogue, Wizard selectedWizard)
        {
            InitializeComponent();
            _crud = crud;
            _selectedWarrior = selectedWarrior;
            _selectedRogue = selectedRogue;
            _selectedWizard = selectedWizard;
        }

        private void WarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WarriorPage(_crud, _selectedWarrior));
        }

        private void RogueBTN_Click(object sender, RoutedEventArgs e)
        { 
            NavigationService.Navigate(new RoguePage(_crud, _selectedRogue));
        }

        private void WizardBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WizardPage(_crud, _selectedWizard));
        }

        //private void AllCharactersBTN_Click(object sender, RoutedEventArgs e)
        //{
        //    CRUD crud = new CRUD("mongodb://localhost", "GameK", "WarriorCollection");
        //    CRUD selectedWarrior = new CRUD("mongodb://localhost", "GameK", "WarriorCollection");
        //    CRUD selectedRogue = new CRUD("mongodb://localhost", "GameK", "RogueCollection");
        //    CRUD selectedWizard = new CRUD("mongodb://localhost", "GameK", "WizardCollection");
        //    NavigationService.Navigate(new AllCharactersPage(new CRUD(crud, selectedWarrior, selectedRogue, selectedWizard)));
        //}
    }
}
