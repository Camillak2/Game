using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Pages;
using static WpfApp1.MongoDB.Character;

namespace WpfApp1.MongoDB
{
    internal class CRUD
    {
        //public static Character GetCharacter(string name)
        //{
        //    var client = new MongoClient("mongodb://localhost");
        //    var database = client.GetDatabase("GameK");
        //    var collection = database.GetCollection<Character>("CharacterCollection");
        //    var character = collection.Find(x => x.Name == name).FirstOrDefault();
        //    return character;
        //}

        public static Warrior GetWarrior(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Warrior>("WarriorCollection");
            var warrior = collection.Find(x => x.Name == name).FirstOrDefault();
            return warrior;
        }

        public static void CreateCharacterWarrior(Warrior warrior)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Warrior>("WarriorCollection");
            collection.InsertOne(warrior);
        }

        public static void CreateCharacterRogue(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }

        public static void CreateCharacterWizard(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }
    }
}
