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
using System.Xml.Linq;
using WpfApp1.MongoDB;
using WpfApp1.Windows;
using WpfApp1.Windowss;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Warrior.xaml
    /// </summary>
    public partial class Warrior : Page
    {
        public Warrior()
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
            CRUD.CreateCharacterRogue(new Character(name, strength, 250, dexterity, 80, intelegence, 50, vitality, 100, Convert.ToInt32(2 * vitality + 1 * strength), Convert.ToInt32(1 * intelegence),
                Convert.ToInt32(1 * strength), Convert.ToInt32(1 * dexterity), Convert.ToInt32(0.2 * intelegence), Convert.ToInt32(0.5 * intelegence), Convert.ToInt32(0.2 * dexterity), Convert.ToInt32(1 * dexterity)));
            NavigationService.Navigate(new Characters());
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            Window updateWarrior = new UpdateWarrior();
            updateWarrior.Show();
        }

        private void SeeStatsBTN_Click(object sender, RoutedEventArgs e)
        {
            Window warriorStats = new WarriorStats();
            warriorStats.Show();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Characters());
        }
    }
}
