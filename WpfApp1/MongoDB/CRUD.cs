using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Pages;
using WpfApp1.MongoDB;
using MongoDB.Driver.Core.Configuration;
using WpfApp1.Windows;
using System.Collections.ObjectModel;
using System.Threading;

namespace WpfApp1.MongoDB
{
    public class CRUD
    {
        private IMongoCollection<Warrior> _warriorsCollection;
        private IMongoCollection<Rogue> _roguesCollection;
        private IMongoCollection<Wizard> _wizardsCollection;
        public CRUD(string host, string database)
        {
            var client = new MongoClient(host);
            var db = client.GetDatabase(database);
            _warriorsCollection = db.GetCollection<Warrior>("WarriorsCollection");
            _roguesCollection = db.GetCollection<Rogue>("RoguesCollection");
            _wizardsCollection = db.GetCollection<Wizard>("WizardsCollection");
        }

        public List<Warrior> GetAllWarriors()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Warrior>("WarriorsCollection");
            return _warriorsCollection.Find(w => true).ToList();
        }

        public static void CreateWarrior(Warrior warrior)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Warrior>("WarriorsCollection");
            collection.InsertOne(warrior);
        }

        public async Task<List<Warrior>> GetWarriorsAsync()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Warrior>("WarriorsCollection");
            var warriors = await _warriorsCollection.Find(_ => true).ToListAsync();
            return warriors;
        }

        public void UpdateWarrior(Warrior warrior)
        {
            var filter = Builders<Warrior>.Filter.Eq("_id", warrior.Id); // Находим воина по его ID
            var update = Builders<Warrior>.Update
                .Set("Name", warrior.Name)
                .Set("Strength", warrior.Strength)
                .Set("Dexterity", warrior.Dexterity)
                .Set("Inteligence", warrior.Inteligence)
                .Set("Vitality", warrior.Vitality)
                .Set("Health", warrior.Health)
                .Set("Mana", warrior.Mana)
                .Set("PDamage", warrior.PDamage)
                .Set("Armor", warrior.Armor)
                .Set("MDamage", warrior.MDamage)
                .Set("MDefense", warrior.MDefense)
                .Set("CrtChance", warrior.CrtChance)
                .Set("CrtDamage", warrior.CrtDamage);

            _warriorsCollection.UpdateOne(filter, update);
        }

        public void DeleteWarrior(Warrior warrior)
        {
            var filter = Builders<Warrior>.Filter.Eq("Id", warrior.Id); // Находим воина по его ID
            _warriorsCollection.DeleteOne(filter);
        }

        // Rogue
        public List<Rogue> GetAllRogues()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Rogue>("RoguesCollection");
            return _roguesCollection.Find(w => true).ToList();
        }

        public static void CreateRogue(Rogue rogue)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Rogue>("RoguesCollection");
            collection.InsertOne(rogue);
        }

        public async Task<List<Rogue>> GetRoguesAsync()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Rogue>("RoguesCollection");
            var rogues = await _roguesCollection.Find(_ => true).ToListAsync();
            return rogues;
        }

        public void UpdateRogue(Rogue updateRogue)
        {
            var filter = Builders<Rogue>.Filter.Eq("_id", updateRogue.Id); // Находим воина по его ID
            var update = Builders<Rogue>.Update
                .Set("Name", updateRogue.Name)
                .Set("Strength", updateRogue.Strength)
                .Set("Dexterity", updateRogue.Dexterity)
                .Set("Inteligence", updateRogue.Inteligence)
                .Set("Vitality", updateRogue.Vitality)
                .Set("Health", updateRogue.Health)
                .Set("Mana", updateRogue.Mana)
                .Set("PDamage", updateRogue.PDamage)
                .Set("Armor", updateRogue.Armor)
                .Set("MDamage", updateRogue.MDamage)
                .Set("MDefense", updateRogue.MDefense)
                .Set("CrtChance", updateRogue.CrtChance)
                .Set("CrtDamage", updateRogue.CrtDamage);

            _roguesCollection.UpdateOne(filter, update);
        }

        public void DeleteRogue(Rogue rogue)
        {
            var filter = Builders<Rogue>.Filter.Eq("Id", rogue.Id); // Находим воина по его ID
            _roguesCollection.DeleteOne(filter);
        }

        // Wizard
        public List<Wizard> GetAllWizards()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Wizard>("WizardsCollection");
            return _wizardsCollection.Find(w => true).ToList();
        }

        public static void CreateWizard(Wizard wizard)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Wizard>("WizardsCollection");
            collection.InsertOne(wizard);
        }

        public async Task<List<Wizard>> GetWizardsAsync()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameCamilla");
            var collection = database.GetCollection<Wizard>("WizardsCollection");
            var wizards = await _wizardsCollection.Find(_ => true).ToListAsync();
            return wizards;
        }

        public void UpdateWizard(Wizard updatedWizard)
        {
            var filter = Builders<Wizard>.Filter.Eq("_id", updatedWizard.Id); // Находим воина по его ID
            var update = Builders<Wizard>.Update
                .Set("Name", updatedWizard.Name)
                .Set("Strength", updatedWizard.Strength)
                .Set("Dexterity", updatedWizard.Dexterity)
                .Set("Inteligence", updatedWizard.Inteligence)
                .Set("Vitality", updatedWizard.Vitality)
                .Set("Health", updatedWizard.Health)
                .Set("Mana", updatedWizard.Mana)
                .Set("PDamage", updatedWizard.PDamage)
                .Set("Armor", updatedWizard.Armor)
                .Set("MDamage", updatedWizard.MDamage)
                .Set("MDefense", updatedWizard.MDefense)
                .Set("CrtChance", updatedWizard.CrtChance)
                .Set("CrtDamage", updatedWizard.CrtDamage);

            _wizardsCollection.UpdateOne(filter, update);
        }

        public void DeleteWizard(Warrior warrior)
        {
            var filter = Builders<Warrior>.Filter.Eq("Id", warrior.Id); // Находим воина по его ID
            _warriorsCollection.DeleteOne(filter);
        }
    }
}
