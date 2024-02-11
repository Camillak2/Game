using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Pages;
using WpfApp1.Windows;
using static WpfApp1.MongoDB.Warrior;
using static WpfApp1.MongoDB.Rogue;
using static WpfApp1.MongoDB.Wizard;
using System.Threading;

namespace WpfApp1.MongoDB
{
    public class CRUD
    {
        public CRUD(string host, string database, string collection)
        {
            var client = new MongoClient(host);
            var db = client.GetDatabase(database);
            _collectionWarrior = db.GetCollection<Warrior>(collection);
            _collectionRogue = db.GetCollection<Rogue>(collection);
            _collectionWizard = db.GetCollection<Wizard>(collection);
        }

        // Warrior
        private IMongoCollection<Warrior> _collectionWarrior;

        public async Task<List<Warrior>> GetWarriors()
        {
            var warriors = await _collectionWarrior.Find(_ => true).ToListAsync();
            return warriors;
        }

        public static Warrior GetWarrior(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Warrior>("WarriorCollection");
            var warrior = collection.Find(x => x.Name == name).FirstOrDefault();
            return warrior;
        }

        public static void CreateWarrior(Warrior warrior)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Warrior>("WarriorCollection");
            collection.InsertOne(warrior);
        }

        public void UpdateWarrior(Warrior warrior)
        {
            var filter = Builders<Warrior>.Filter.Eq("_id", warrior._id); // Находим воина по его ID
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

            _collectionWarrior.UpdateOne(filter, update);
        }

        public void DeleteWarrior(Warrior warrior)
        {
            var filter = Builders<Warrior>.Filter.Eq("_id", warrior._id); // Находим воина по его ID
            _collectionWarrior.DeleteOne(filter);
        }

        // Rogue
        private IMongoCollection<Rogue> _collectionRogue;

        public async Task<List<Rogue>> GetRogues()
        {
            var rogues = await _collectionRogue.Find(_ => true).ToListAsync();
            return rogues;
        }

        public static Rogue GetRogue(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Rogue>("RogueCollection");
            var rogue = collection.Find(x => x.Name == name).FirstOrDefault();
            return rogue;
        }

        public static void CreateRogue(Rogue rogue)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Rogue>("RogueCollection");
            collection.InsertOne(rogue);
        }

        public void UpdateRogue(Rogue rogue)
        {
            var filter = Builders<Rogue>.Filter.Eq("_id", rogue._id); // Находим воина по его ID
            var update = Builders<Rogue>.Update
                .Set("Name", rogue.Name)
                .Set("Strength", rogue.Strength)
                .Set("Dexterity", rogue.Dexterity)
                .Set("Inteligence", rogue.Inteligence)
                .Set("Vitality", rogue.Vitality)
                .Set("Health", rogue.Health)
                .Set("Mana", rogue.Mana)
                .Set("PDamage", rogue.PDamage)
                .Set("Armor", rogue.Armor)
                .Set("MDamage", rogue.MDamage)
                .Set("MDefense", rogue.MDefense)
                .Set("CrtChance", rogue.CrtChance)
                .Set("CrtDamage", rogue.CrtDamage);

            _collectionRogue.UpdateOne(filter, update);
        }


        public void DeleteRogue(Rogue rogue)
        {
            var filter = Builders<Rogue>.Filter.Eq("_id", rogue._id); // Находим воина по его ID
            _collectionRogue.DeleteOne(filter);
        }

        // Wizard
        private IMongoCollection<Wizard> _collectionWizard;

        public async Task<List<Wizard>> GetWizards()
        {
            var wizards = await _collectionWizard.Find(_ => true).ToListAsync();
            return wizards;
        }

        public static Wizard GetWizard(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Wizard>("WizardCollection");
            var wizard = collection.Find(x => x.Name == name).FirstOrDefault();
            return wizard;
        }

        public static void CreateWizard(Wizard wizard)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Wizard>("WizardCollection");
            collection.InsertOne(wizard);
        }

        public void UpdateWizard(Wizard wizard)
        {
            var filter = Builders<Wizard>.Filter.Eq("_id", wizard._id); // Находим воина по его ID
            var update = Builders<Wizard>.Update
                .Set("Name", wizard.Name)
                .Set("Strength", wizard.Strength)
                .Set("Dexterity", wizard.Dexterity)
                .Set("Inteligence", wizard.Inteligence)
                .Set("Vitality", wizard.Vitality)
                .Set("Health", wizard.Health)
                .Set("Mana", wizard.Mana)
                .Set("PDamage", wizard.PDamage)
                .Set("Armor", wizard.Armor)
                .Set("MDamage", wizard.MDamage)
                .Set("MDefense", wizard.MDefense)
                .Set("CrtChance", wizard.CrtChance)
                .Set("CrtDamage", wizard.CrtDamage);

            _collectionWizard.UpdateOne(filter, update);
        }

        public void DeleteWizard(Wizard wizard)
        {
            var filter = Builders<Wizard>.Filter.Eq("_id", wizard._id); // Находим воина по его ID
            _collectionWizard.DeleteOne(filter);
        }
    }
}
