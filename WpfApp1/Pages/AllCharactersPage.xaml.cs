﻿using MongoDB.Driver;
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
        private CRUD _crudWarrior;
        private CRUD _crudRogue;
        private CRUD _crudWizard;

        public AllCharactersPage()
        {
            InitializeComponent();
            InitializeMongoDB();
            LoadWarriorsAsync();
            LoadRoguesAsync();
            LoadWizardsAsync();
        }

        private void InitializeMongoDB()
        {
            _crudWarrior = new CRUD("mongodb://localhost", "GameK", "WarriorCollection");
            _crudRogue = new CRUD("mongodb://localhost", "GameK", "RogueCollection");
            _crudWizard = new CRUD("mongodb://localhost", "GameK", "WizardCollection");
        }

        //
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
                MessageBox.Show($"An error occurred while loading warriors: {ex.Message}");
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
                MessageBox.Show($"An error occurred while loading warriors: {ex.Message}");
                return new List<Wizard>();
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Characters());
        }
    }
}