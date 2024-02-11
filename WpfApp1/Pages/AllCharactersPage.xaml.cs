using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp1.Windowss;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllCharactersPage.xaml
    /// </summary>
    public partial class AllCharactersPage : Page
    {
        private CRUD _crudWarrior;
        private ObservableCollection<Warrior> _warriors;

        private CRUD _crudRogue;
        private CRUD _crudWizard;

        public AllCharactersPage(CRUD crud)
        {
            InitializeComponent();
            InitializeMongoDB();
            LoadWarriorsAsync();
            LoadRoguesAsync();
            LoadWizardsAsync();

            _crudWarrior = crud;
            LoadWarriors();
        }

        private void InitializeMongoDB()
        {
            _crudWarrior = new CRUD("mongodb://localhost", "GameK", "WarriorCollection");
            _crudRogue = new CRUD("mongodb://localhost", "GameK", "RogueCollection");
            _crudWizard = new CRUD("mongodb://localhost", "GameK", "WizardCollection");
        }

        //
        private async void LoadWarriors()
        {
            _warriors = new ObservableCollection<Warrior>(await _crudWarrior.GetWarriors());
            WarriorsListView.ItemsSource = _warriors;
        }
        private async void LoadWarriorsAsync()
        {
            List<Warrior> warriors = await GetWarriorsAsync();
            WarriorsListView.ItemsSource = warriors;
        }

        private async Task<List<Warrior>> GetWarriorsAsync()
        {
            try
            {
                var warriors = await Task.Run(() =>
                {
                    return _crudWarrior.GetWarriors();
                });

                return warriors;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading warriors: {ex.Message}");
                return new List<Warrior>();
            }
        }

        //
        private async void LoadRoguesAsync()
        {
            List<Rogue> rogues = await GetRoguesAsync();
            RoguesListView.ItemsSource = rogues;
        }

        private async Task<List<Rogue>> GetRoguesAsync()
        {
            try
            {
                var rogues = await Task.Run(() =>
                {
                    return _crudRogue.GetRogues();
                });

                return rogues;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading rogues: {ex.Message}");
                return new List<Rogue>();
            }
        }

        //
        private async void LoadWizardsAsync()
        {
            List<Wizard> wizards = await GetWizardsAsync();
            WizardsListView.ItemsSource = wizards;
        }

        private async Task<List<Wizard>> GetWizardsAsync()
        {
            try
            {
                var wizards = await Task.Run(() =>
                {
                    return _crudWizard.GetWizards();
                });

                return wizards;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading wizards: {ex.Message}");
                return new List<Wizard>();
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Characters());
        }

        //Warrior
        private void EditWarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WarriorsListView.SelectedItem != null)
            {
                Warrior selectedWarrior = (Warrior)WarriorsListView.SelectedItem;
                WarriorStats detailsWindow = new WarriorStats(_crudWarrior, selectedWarrior);
                detailsWindow.ShowDialog();
                LoadWarriors(); // Обновляем список воинов после закрытия окна редактирования
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите воина для редактирования.");
            }
        }
        private void DropWarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WarriorsListView.SelectedItem is Warrior warrior)
            {
                //CRUD.DeleteWarrior(warrior);
            }
        }

        //Rogue
        private void EditRogueBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DropRogueBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        //Wizard
        private void EditWizardBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DropWizardBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
