using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.MongoDB
{
    internal class CRUD
    {
        public static void CreateCharacter(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
        }

        public static void GetCharacter(int number)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var character = collection.Find(x => x.DiplomNumber == number).FirstOrDefault();
            if (character == null)
                Console.WriteLine("Not Found");
            else
                Console.WriteLine($"{character.Name} {character.Health}");
        }

        public static void CreateTestTeam(Team team)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Team>("CharacterCollection");
            collection.InsertOne(team);
        }
    }
}
