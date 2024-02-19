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
    /// Логика взаимодействия для AllRoguesPage.xaml
    /// </summary>
    public partial class AllRoguesPage : Page
    {
        private CRUD _crudRogue;
        private ObservableCollection<Rogue> _rogues;

        public AllRoguesPage()
        {
            InitializeComponent();
            InitializeMongoDB();
            //_crudRogue = new CRUD("mongodb://localhost", "GameCamilla");
            LoadRogues();
            List<Rogue> rogues = _crudRogue.GetAllRogues();
            RoguesListView.ItemsSource = rogues;
        }

        private void InitializeMongoDB()
        {
            _crudRogue = new CRUD("mongodb://localhost", "GameK");
        }

        private async void LoadRogues()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            database.GetCollection<Rogue>("RoguesCollection");
            _rogues = new ObservableCollection<Rogue>(await _crudRogue.GetRoguesAsync());
            RoguesListView.ItemsSource = _rogues;
        }

        private void EditRogueBTN_Click(object sender, RoutedEventArgs e)
        {
            if (RoguesListView.SelectedItem != null)
            {
                Rogue selectedRogue = (Rogue)RoguesListView.SelectedItem;
                RogueStats rogueStats = new RogueStats(_crudRogue, selectedRogue);
                rogueStats.ShowDialog();
                LoadRogues(); // Обновляем список воинов после закрытия окна редактирования
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите воина для редактирования.");
            }
        }
        private void DropRogueBTN_Click(object sender, RoutedEventArgs e)
        {
            if (RoguesListView.SelectedItem is Rogue selectedRogue)
            {
                _crudRogue.DeleteRogue(selectedRogue);
                _rogues.Remove(selectedRogue);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите воина для удаления.");
            }
        }
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoguePage());
        }
    }
}
