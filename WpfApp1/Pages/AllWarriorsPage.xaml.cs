using MongoDB.Driver;
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
        private CRUD _crudWarrior;
        private ObservableCollection<Warrior> _warriors;

        public AllWarriorsPage()
        {
            InitializeComponent();
            InitializeMongoDB();
            //_crudWarrior = new CRUD("mongodb://localhost", "GameCamilla");
            LoadWarriors();
            List<Warrior> warriors = _crudWarrior.GetAllWarriors();
            WarriorsListView.ItemsSource = warriors;
        }

        private void InitializeMongoDB()
        {
            _crudWarrior = new CRUD("mongodb://localhost", "GameCamilla");
        }

        private async void LoadWarriors()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            database.GetCollection<Warrior>("WarriorsCollection");
            _warriors = new ObservableCollection<Warrior>(await _crudWarrior.GetWarriorsAsync());
            WarriorsListView.ItemsSource = _warriors;
        }

        private void EditWarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WarriorsListView.SelectedItem != null)
            {
                Warrior selectedWarrior = (Warrior)WarriorsListView.SelectedItem;
                WarriorStats detailsWindow = new WarriorStats(_crudWarrior, selectedWarrior);
                detailsWindow.ShowDialog();
                LoadWarriors();
            }
            else
            {
                MessageBox.Show("Please select a Warrior to edit.");
            }
        }

        private void DropWarriorBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WarriorsListView.SelectedItem is Warrior selectedWarrior)
            {
                _crudWarrior.DeleteWarrior(selectedWarrior);
                _warriors.Remove(selectedWarrior);
            }
            else
            {
                MessageBox.Show("Please select a Warrior to drop.");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WarriorPage());
        }
    }
}
