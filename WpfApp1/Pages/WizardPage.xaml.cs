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
using WpfApp1.Windows;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для WizardPage.xaml
    /// </summary>
    public partial class WizardPage : Page
    {
        public WizardPage()
        {
            InitializeComponent();
        }

        private void CreateWizardBTN_Click(object sender, RoutedEventArgs e)
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
                CRUD.CreateWizard(new Wizard(name, strength, 45, dexterity, 80, intelegence, 250, vitality, 70, Convert.ToInt32(1.4 * vitality + 0.2 * strength), Convert.ToInt32(1.5 * intelegence),
                    Convert.ToInt32(0.5 * strength), Convert.ToInt32(1 * dexterity), Convert.ToInt32(1 * intelegence), Convert.ToInt32(1 * intelegence), Convert.ToInt32(0.2 * dexterity), Convert.ToInt32(1 * dexterity)));
                NavigationService.Navigate(new AllWizardsPage());
            }
        }

        private void AllWizardsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWizardsPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CharactersPage());
        }
    }
}
