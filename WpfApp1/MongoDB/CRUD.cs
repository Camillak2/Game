﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.MongoDB
{
    internal class CRUD
    {
        public static Character GetCharacter(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("GameK");
            var collection = database.GetCollection<Character>("CharacterCollection");
            var character = collection.Find(x => x.Name == name).FirstOrDefault();
            return character;
        }

        public static void CreateCharacterWarrior(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Characters");
            var collection = database.GetCollection<Character>("CharacterCollection");
            collection.InsertOne(character);
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
