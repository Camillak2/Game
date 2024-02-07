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
    /// Логика взаимодействия для Rogue.xaml
    /// </summary>
    public partial class Rogue : Page
    {
        public Rogue()
        {
            InitializeComponent();
        }

        private void CreateCharacterBTN_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text;
            int strength = Convert.ToInt32(StrengthResult.Text);
            int intelegence = Convert.ToInt32(InteligenceResult.Text);
            int dexterity = Convert.ToInt32(DexterityResult.Text);
            int vitality = Convert.ToInt32(VitalityResult.Text);
            CRUD.CreateCharacter(new Character(name, strength, 250, dexterity, 80, intelegence, 50, vitality, 100, 100, 100, 0, 0, 0, 0, 0, 0));
            NavigationService.Navigate(new Characters());
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SeeStatsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Windows.RogueStats());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Characters());
        }
    }
}
