﻿using System;
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
        public WarriorPage()
        {
            InitializeComponent();
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
                CRUD.CreateWarrior(new Warrior(name, strength, 250, dexterity, 80, intelegence, 50, vitality, 100, Convert.ToInt32(2 * vitality + 1 * strength), Convert.ToInt32(1 * intelegence),
                    Convert.ToInt32(1 * strength), 
                    Convert.ToInt32(1 * dexterity), Convert.ToInt32(0.2 * intelegence), Convert.ToInt32(0.5 * intelegence), Convert.ToInt32(0.2 * dexterity), Convert.ToInt32(1 * dexterity)));
                NavigationService.Navigate(new AllWarriorsPage());
            }
        }

        private void AllWarriorsBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllWarriorsPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CharactersPage());
        }
    }
}
