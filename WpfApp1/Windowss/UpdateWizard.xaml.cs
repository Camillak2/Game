using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
using System.Xml.Linq;
using WpfApp1.MongoDB;

namespace WpfApp1.Windowss
{
    /// <summary>
    /// Логика взаимодействия для UpdateWizard.xaml
    /// </summary>
    public partial class UpdateWizard : Window
    {
        public UpdateWizard()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (NameUpdate.Text != "")
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("Characters");
                var collection = database.GetCollection<Character>("CharacterCollection");
                // параметр фильтрации 
                //var filterss = Builders<Character>.Filter.Eq("Name", App.CharacterChange.Name);
                // параметр обновления
                var update = Builders<Character>.Update.Set("Name", NameUpdate.Text);
                //var result = collection.UpdateOneAsync(filterss, update);
                //App.CharacterChange.Name = NameUpdate.Text;

                MessageBox.Show("ok");
                this.Close();
            }
            else
                MessageBox.Show("!!!");
        }
    }
}
