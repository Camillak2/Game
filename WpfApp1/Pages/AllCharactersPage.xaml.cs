using MongoDB.Driver;
using System;
using System.Collections.Generic;
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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllCharactersPage.xaml
    /// </summary>
    public partial class AllCharactersPage : Page
    {
        private CRUD _crud;

        public AllCharactersPage()
        {
            InitializeComponent();
            InitializeMongoDB();
            LoadWarriorsAsync();
        }

        private void InitializeMongoDB()
        {
            _crud = new CRUD("mongodb://localhost", "GameK", "WarriorCollection");
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
                    return _crud.GetWarriors();
                });

                return warriors;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading warriors: {ex.Message}");
                return new List<Warrior>();
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Characters());
        }
    }
}
