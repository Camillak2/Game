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
    /// Логика взаимодействия для AllWizardsPage.xaml
    /// </summary>
    public partial class AllWizardsPage : Page
    {
        private CRUD _crudWizard;
        private ObservableCollection<Wizard> _wizards;

        public AllWizardsPage()
        {
            InitializeComponent();
            InitializeMongoDB();
            //_crudWizard = new CRUD("mongodb://localhost", "GameCamilla");
            LoadWizards();
            List<Wizard> wizards = _crudWizard.GetAllWizards();
            WizardsListView.ItemsSource = wizards;
        }

        private void InitializeMongoDB()
        {
            _crudWizard = new CRUD("mongodb://localhost", "GameCamilla");
        }

        private async void LoadWizards()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            database.GetCollection<Warrior>("WizardsCollection");
            _wizards = new ObservableCollection<Wizard>(await _crudWizard.GetWizardsAsync());
            WizardsListView.ItemsSource = _wizards;
        }

        private void EditWizardBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WizardsListView.SelectedItem != null)
            {
                Wizard selectedWizard = (Wizard)WizardsListView.SelectedItem;
                WizardStats detailsWindow = new WizardStats(_crudWizard, selectedWizard);
                detailsWindow.ShowDialog();
                LoadWizards();
            }
            else
            {
                MessageBox.Show("Please select a Warrior to edit.");
            }
        }

        private void DropWizardBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WizardsListView.SelectedItem is Wizard selectedWizard)
            {
                _crudWizard.DeleteWizard(selectedWizard);
                _wizards.Remove(selectedWizard);
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
