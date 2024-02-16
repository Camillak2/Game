using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Windows;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для WarriorPage.xaml
    /// </summary>
    public partial class WarriorPage : Page
    {
        private CRUD _crud;
        private Warrior _selectedWarrior;
        public WarriorPage(CRUD crud, Warrior selectedWarrior)
        {
            InitializeComponent();
            _crud = crud;
            _selectedWarrior = selectedWarrior;
        }
        private void CreateWarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text;
            int strength = Convert.ToInt32(StrengthResult.Text);
            int intelegence = Convert.ToInt32(InteligenceResult.Text);
            int dexterity = Convert.ToInt32(DexterityResult.Text);
            int vitality = Convert.ToInt32(VitalityResult.Text);
            if (NameTB.Text == "")
            {
                MessageBox.Show("Please enter name.");
            }
            else
            {
                CRUD.CreateWarrior(new Warrior(name, strength, 65, dexterity, 250, intelegence, 70, vitality, 80, Convert.ToInt32(1.5 * vitality + 0.5 * strength), Convert.ToInt32(1.2 * intelegence),
                    Convert.ToInt32(0.5 * strength + 0.5 * dexterity), Convert.ToInt32(1.5 * dexterity), Convert.ToInt32(0.2 * intelegence), Convert.ToInt32(0.5 * intelegence), Convert.ToInt32(0.2 * dexterity), Convert.ToInt32(1 * dexterity)));
                NavigationService.Navigate(new AllWarriorsPage(_crud, _selectedWarrior));
            }
        }

        private void AllWarriorsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWarriorsPage(_crud, _selectedWarrior));
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
