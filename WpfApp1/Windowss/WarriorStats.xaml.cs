using MongoDB.Driver;
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
using System.Xml.Linq;
using WpfApp1.MongoDB;
using WpfApp1.Pages;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для WarriorStats.xaml
    /// </summary>
    public partial class WarriorStats : Window
    {
        private CRUD _crud;
        private Warrior _selectedWarrior;

        public WarriorStats(CRUD crud, Warrior selectedWarrior)
        {
            InitializeComponent();
            _crud = crud;
            _selectedWarrior = selectedWarrior;
            NameTB.Text = _selectedWarrior.Name;
            StrengthTB.Text = _selectedWarrior?.Strength.ToString();
            MaxStrengthTB.Text = _selectedWarrior.MaxStrength.ToString();
            InteligenceTB.Text = _selectedWarrior.Inteligence.ToString();
            MaxInteligenceTB.Text = _selectedWarrior.MaxInteligence.ToString();
            DexterityTB.Text = _selectedWarrior.Dexterity.ToString();
            MaxDexterityTB.Text = _selectedWarrior.MaxDexterity.ToString();
            VitalityTB.Text = _selectedWarrior.Vitality.ToString();
            MaxVitalityTB.Text = _selectedWarrior.MaxVitality.ToString();
            ManaTB.Text = _selectedWarrior.Mana.ToString();
            HealthTB.Text = _selectedWarrior.Health.ToString();
            PDamageTB.Text = _selectedWarrior.PDamage.ToString();

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedWarrior.Name = NameTB.Text;
            // Обновите другие характеристики воина в соответствии с элементами управления

            _crud.UpdateWarrior(_selectedWarrior);
            MessageBox.Show("Saved.");

            this.Close();
        }

        //Strength
        private void PlusStrengthBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinusStrengthBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        //Inteligence
        private void PlusInteligenceBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinusInteligenceBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        //Dexterity
        private void PlusDexterityBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinusDexterityBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        //Vitality
        private void PlusVitalityBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinusVitalityBTN_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NameTB.Text != "")
            {
                _selectedWarrior.Name = NameTB.Text;
                // Обновите другие характеристики воина в соответствии с элементами управления

                _crud.UpdateWarrior(_selectedWarrior);
                MessageBox.Show("Saved.");

                this.Close();
            }
            else
                MessageBox.Show("Please enter name.");
        }
    }
}
