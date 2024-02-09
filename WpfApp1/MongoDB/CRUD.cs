using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Pages;
using static WpfApp1.MongoDB.Warrior;
using static WpfApp1.MongoDB.Rogue;
using static WpfApp1.MongoDB.Wizard;

namespace WpfApp1.MongoDB
{
    internal class CRUD
    {
        public CRUD(string host, string database, string collection)
        {
            var client = new MongoClient(host);
            var db = client.GetDatabase(database);
            _collectionWarrior = db.GetCollection<Warrior>(collection);
            _collectionRogue = db.GetCollection<Rogue>(collection);
            _collectionWizard = db.GetCollection<Wizard>(collection);
        }

        //
        private IMongoCollection<Warrior> _collectionWarrior;

        public List<Warrior> GetWarriors()
        {
            return _collectionWarrior.Find(_ => true).ToList();
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

        //
        private IMongoCollection<Rogue> _collectionRogue;

        public List<Rogue> GetRogues()
        {
            return _collectionRogue.Find(_ => true).ToList();
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

        //
        private IMongoCollection<Wizard> _collectionWizard;

        public List<Wizard> GetWizards()
        {
            return _collectionWizard.Find(_ => true).ToList();
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
    }
}
