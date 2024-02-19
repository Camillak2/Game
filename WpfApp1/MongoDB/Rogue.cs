using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Pages;

namespace WpfApp1.MongoDB
{
    public class Rogue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id;

        public string Name { get; set; }
        public int Strength { get; set; }
        public int MaxStrength { get; set; }
        public int Dexterity { get; set; }
        public int MaxDexterity { get; set; }
        public int Inteligence { get; set; }
        public int MaxInteligence { get; set; }
        public int Vitality { get; set; }
        public int MaxVitality { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int PDamage { get; set; }
        public int Armor { get; set; }
        public int MDamage { get; set; }
        public int MDefense { get; set; }
        public int CrtChance { get; set; }
        public int CrtDamage { get; set; }

        public Rogue(string name, int strength, int maxStrength, int dexterity, int maxDexterity, int inteligence, int maxInteligence, int vitality, int maxVitality, int health, int mana, int pDamage, int armor, int mDamage, int mDefense, int crtChance, int crtDamage)
        {
            Name = name;
            Strength = strength;
            MaxStrength = maxStrength;
            Dexterity = dexterity;
            MaxDexterity = maxDexterity;
            Inteligence = inteligence;
            MaxInteligence = maxInteligence;
            Vitality = vitality;
            MaxVitality = maxVitality;
            Health = health;
            Mana = mana;
            PDamage = pDamage;
            Armor = armor;
            MDamage = mDamage;
            MDefense = mDefense;
            CrtChance = crtChance;
            CrtDamage = crtDamage;
        }
    }
}
