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
    /// Логика взаимодействия для AllWarriorsPage.xaml
    /// </summary>
    public partial class AllWarriorsPage : Page
    {
        private CRUD _crud;
        private Warrior _selectedWarrior;

        private CRUD _crudWarrior;
        private ObservableCollection<Warrior> _warriors;

        public AllWarriorsPage(CRUD crud, Warrior selectedWarrior)
        {
            InitializeComponent();
            InitializeMongoDB();
            _crud = crud;

            LoadWarriorsAsync();

            _crudWarrior = crud;
            LoadWarriors();


            _selectedWarrior = selectedWarrior;
        }

        private void InitializeMongoDB()
        {
            _crudWarrior = new CRUD("mongodb://localhost", "GameK", "WarriorCollection");
        }

        //Warriors
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

        private void EditWarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WarriorsListView.SelectedItem != null)
            {
                Warrior selectedWarrior = (Warrior)WarriorsListView.SelectedItem;
                WarriorStats warriorStats = new WarriorStats(_crudWarrior, selectedWarrior);
                warriorStats.ShowDialog();
                LoadWarriors(); // Обновляем список воинов после закрытия окна редактирования
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите воина для редактирования.");
            }
        }
        private void DropWarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WarriorsListView.SelectedItem != null)
            {
                Warrior selectedWarrior = (Warrior)WarriorsListView.SelectedItem;
                _crud.DeleteWarrior(_selectedWarrior);
                LoadWarriors();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите воина для удаления.");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            CRUD crud = new CRUD("mongodb://localhost", "GameK", "WarriorCollection");
            NavigationService.Navigate(new WarriorPage(crud));
        }
    }
}
