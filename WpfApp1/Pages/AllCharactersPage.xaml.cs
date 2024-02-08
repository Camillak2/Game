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
        private IMongoCollection<Warrior> _collection;

        public AllCharactersPage()
        {
            InitializeComponent();
            InitializeMongoDB();

            List<Warrior> warrior = GetCharactersFromDatabase();
            CharacterListView.ItemsSource = warrior;
        }

        private void InitializeMongoDB()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            _collection = database.GetCollection<Warrior>("WarriorCollection");
        }

        private List<Warrior> GetCharactersFromDatabase()
        {
            return _collection.Find(_ => true).ToList();
        }
    }
}
