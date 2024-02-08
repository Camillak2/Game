using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Windows.Navigation;
using WpfApp1.Pages;

namespace WpfApp1.MongoDB
{
    public class Character
    {
        //public Character(string name, int strength, int maxStrength, int dexterity, int maxDexterity, int inteligence, int maxInteligence, int vitality, int maxVitality, int health, int mana, int pDamage, int armor, int mDamage, int mDefense, int crtChance, int crtDamage, int diplomNumber) : 
        //    this(name, strength, maxStrength, dexterity, maxDexterity, inteligence, maxInteligence, vitality, maxVitality, health, mana, pDamage, armor, mDamage, mDefense, crtChance, crtDamage)
        //{
        //    DiplomNumber = diplomNumber;
        //}
        //[BsonIgnore]
        //public ObjectId _id;
        //public string Name { get; set; }
        //public int Strength { get; set; }
        //public int MaxStrength { get; set; }
        //public int Dexterity { get; set; }
        //public int MaxDexterity { get; set; }
        //public int Inteligence { get; set; }
        //public int MaxInteligence { get; set; }
        //public int Vitality { get; set; }
        //public int MaxVitality { get; set; }
        //public int Health { get; set; }
        //public int Mana { get; set; }
        //public int PDamage { get; set; }
        //public int Armor { get; set; }
        //public int MDamage { get; set; }
        //public int MDefense { get; set; }
        //public int CrtChance { get; set; }
        //public int CrtDamage { get; set; }
        //[BsonIgnoreIfDefault]
        //public int DiplomNumber { get; set; }

        //public Character(string name, int strength, int maxStrength, int dexterity, int maxDexterity, int inteligence, int maxInteligence, int vitality, int maxVitality, int health, int mana, int pDamage, int armor, int mDamage, int mDefense, int crtChance, int crtDamage)
        //{
        //    Name = name;
        //    Strength = strength;
        //    MaxStrength = maxStrength;
        //    Dexterity = dexterity;
        //    MaxDexterity = maxDexterity;
        //    Inteligence = inteligence;
        //    MaxInteligence = maxInteligence;
        //    Vitality = vitality;
        //    MaxVitality = maxVitality;
        //    Health = health;
        //    Mana = mana;
        //    PDamage = pDamage;
        //    Armor = armor;
        //    MDamage = mDamage;
        //    MDefense = mDefense;
        //    CrtChance = crtChance;
        //    CrtDamage = crtDamage;
        //}

        //public class Warrior : Character
        //{
        //    public Warrior(string name, int strength, int maxStrength, int dexterity, int maxDexterity, int inteligence, int maxInteligence, int vitality, int maxVitality, int health, int mana, int pDamage, int armor, int mDamage, int mDefense, int crtChance, int crtDamage) :
        //        base(name, strength, maxStrength, dexterity, maxDexterity, inteligence, maxInteligence, vitality, maxVitality, health, mana, pDamage, armor, mDamage, mDefense, crtChance, crtDamage)
        //    {
        //        Name = name;
        //        Strength = 30;
        //        MaxStrength = 250;
        //        Dexterity = 15;
        //        MaxDexterity = 80;
        //        Inteligence = 10;
        //        MaxInteligence = 50;
        //        Vitality = 25;
        //        MaxVitality = 100;
        //        Health = Convert.ToInt32(2 * vitality + 1 * strength);
        //        Mana = Convert.ToInt32(1 * inteligence);
        //        PDamage = Convert.ToInt32(1 * strength);
        //        Armor = Convert.ToInt32(1 * dexterity);
        //        MDamage = Convert.ToInt32(0.2 * inteligence);
        //        MDefense = Convert.ToInt32(0.5 * inteligence);
        //        CrtChance = Convert.ToInt32(0.2 * dexterity);
        //        CrtDamage = Convert.ToInt32(1 * dexterity);
        //    }
        //}
    }
}
