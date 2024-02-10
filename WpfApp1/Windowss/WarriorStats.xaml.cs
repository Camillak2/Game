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
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedWarrior.Name = NameTB.Text;
            // Обновите другие характеристики воина в соответствии с элементами управления

            _crud.UpdateWarrior(_selectedWarrior);
            MessageBox.Show("Изменения сохранены.");

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
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("Characters");
                var collection = database.GetCollection<Warrior>("CharacterCollection");

                // параметр фильтрации 
                var filterss = Builders<Warrior>.Filter.Eq("Name", App.WarriorChange.Name);
                // параметр обновления
                var update = Builders<Warrior>.Update.Set("Name", NameTB.Text);
                var result = collection.UpdateOneAsync(filterss, update);
                App.WarriorChange.Name = NameTB.Text;

                MessageBox.Show("Saved.");
                Close();
            }
            else
                MessageBox.Show("Please enter name.");

            _selectedWarrior.Name = NameTB.Text;
            // Обновите другие характеристики воина в соответствии с элементами управления

            _crud.UpdateWarrior(_selectedWarrior);
            MessageBox.Show("Изменения сохранены.");

            this.Close();
        }
    }
}
