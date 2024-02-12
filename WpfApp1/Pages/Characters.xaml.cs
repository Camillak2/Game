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
        private CRUD _selectedWarrior;
        private CRUD _selectedWRogue;
        private CRUD _selectedWizard;

        public Characters(CRUD crud, CRUD selectedWarrior)
        {
            InitializeComponent();
            _crud = crud;
            _selectedWarrior = selectedWarrior;
            _selectedWRogue = crud;
            _selectedWizard = crud;
    }

        private void WarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WarriorPage());
        }

        private void RogueBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoguePage());
        }

        private void WizardBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WizardPage());
        }

        private void AllCharactersBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllCharactersPage(crud, selectedWarrior, selectedRogue, selectedWizard));
        }
    }
}
