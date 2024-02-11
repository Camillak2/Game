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
using System.Windows.Shapes;
using WpfApp1.MongoDB;
using MongoDB.Driver;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для RogueStats.xaml
    /// </summary>
    public partial class RogueStats : Window
    {
        private CRUD _crud;
        private Rogue _selectedRogue;

        public RogueStats(CRUD crud, Rogue selectedRogue)
        {
            InitializeComponent();
            _crud = crud;
            _selectedRogue = selectedRogue;
            NameTB.Text = _selectedRogue.Name;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedRogue.Name = NameTB.Text;
            // Обновите другие характеристики воина в соответствии с элементами управления

            _crud.UpdateRogue(_selectedRogue);
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
                _selectedRogue.Name = NameTB.Text;
                // Обновите другие характеристики воина в соответствии с элементами управления

                _crud.UpdateRogue(_selectedRogue);
                MessageBox.Show("Saved.");

                this.Close();
            }
            else
                MessageBox.Show("Please enter name.");
        }
    }
}
