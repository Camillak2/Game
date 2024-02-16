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
        private CRUD _crud;
        private Wizard _selectedWizard;

        private CRUD _crudWizard;
        private ObservableCollection<Wizard> _wizard;

        public AllWizardsPage(CRUD crud, Wizard selectedWizard)
        {
            InitializeComponent();
            InitializeMongoDB();
            _crud = crud;
            LoadWizardsAsync();

            _crudWizard = crud;
            LoadWizards();

            _selectedWizard = selectedWizard;
        }

        private void InitializeMongoDB()
        {
            _crudWizard = new CRUD("mongodb://localhost", "GameK", "WizardCollection");
        }

        private async void LoadWizards()
        {
            _wizard = new ObservableCollection<Wizard>(await _crudWizard.GetWizards());
            WizardsListView.ItemsSource = _wizard;
        }
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

        private void EditWizardBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WizardsListView.SelectedItem != null)
            {
                Wizard selectedWizard = (Wizard)WizardsListView.SelectedItem;
                WizardStats wizardStats = new WizardStats(_crudWizard, selectedWizard);
                wizardStats.ShowDialog();
                LoadWizards(); // Обновляем список воинов после закрытия окна редактирования
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите воина для редактирования.");
            }
        }

        private void DropWizardBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WizardsListView.SelectedItem != null)
            {
                Wizard selectedWizard = (Wizard)WizardsListView.SelectedItem;
                _crud.DeleteWizard(_selectedWizard);
                LoadWizards();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите воина для удаления.");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WizardPage(_crud, _selectedWizard));
        }
    }
}
