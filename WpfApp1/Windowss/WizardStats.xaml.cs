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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для WizardStats.xaml
    /// </summary>
    public partial class WizardStats : Window
    {
        private CRUD _crud;
        private Wizard _selectedWizard;

        public WizardStats(CRUD crud, Wizard selectedWizard)
        {
            InitializeComponent();
            _crud = crud;
            _selectedWizard = selectedWizard;
            NameTB.Text = _selectedWizard.Name;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedWizard.Name = NameTB.Text;
            // Обновите другие характеристики воина в соответствии с элементами управления

            _crud.UpdateWizard(_selectedWizard);
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
                _selectedWizard.Name = NameTB.Text;
                // Обновите другие характеристики воина в соответствии с элементами управления

                _crud.UpdateWizard(_selectedWizard);
                MessageBox.Show("Saved.");

                this.Close();
            }
            else
                MessageBox.Show("Please enter name.");
        }
    }
}
