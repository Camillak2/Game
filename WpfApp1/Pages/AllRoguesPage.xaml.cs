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
        private CRUD _crud;
        private Rogue _selectedRogue;

        private CRUD _crudRogue;
        private ObservableCollection<Rogue> _rogue;

        public AllRoguesPage(CRUD crud, Rogue selectedRogue)
        {
            InitializeComponent();
            InitializeMongoDB();
            _crud = crud;

            LoadRoguesAsync();

            _crudRogue = crud;
            LoadRogues();

            _selectedRogue = selectedRogue;

        }

        private void InitializeMongoDB()
        {
            _crudRogue = new CRUD("mongodb://localhost", "GameK", "RogueCollection");
        }

        private async void LoadRogues()
        {
            _rogue = new ObservableCollection<Rogue>(await _crudRogue.GetRogues());
            RoguesListView.ItemsSource = _rogue;
        }
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
            if (RoguesListView.SelectedItem != null)
            {
                Rogue selectedRogue = (Rogue)RoguesListView.SelectedItem;
                _crud.DeleteRogue(_selectedRogue);
                LoadRogues();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите воина для удаления.");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoguePage(_crud, _selectedRogue));
        }
    }
}
