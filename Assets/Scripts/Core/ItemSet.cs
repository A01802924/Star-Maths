using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Item
    {
        public int index;
        public string name;
        public int price;
        public Texture2D itemIcon;
        public bool isAlreadyOwned;
        public Item(int i, string n, int p, Texture2D s, bool o)
        {
            index = i; name = n; price = p;
            itemIcon = s; isAlreadyOwned = o;
        }
    }
    public static class ItemSet
    {
        public const string rootDir = "Assets/Sprites/Stylized 2D Space Shooter/Sprites";
        public const string shipDir = rootDir + "/Large/Ships/";
        public const string shootDir = rootDir + "/Large/Missiles/";
        public const string trailDir = rootDir + "/Projectiles/";
        public static List<Item> ShipItems { get; private set; } = new()
        {
            new(0, "AQUA", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_C_Large.png"), false),
            new(1, "PHOENIX", 1600, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_D_Large.png"), false),
            new(2, "SUPERNOVA", 2200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_E_Large.png"), false)
        };
        public static List<Item> ProjectileItems { get; private set; } = new()
        {
            new(0, "HOLLOW ADDER", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_D_Large.png"), false),
            new(1, "CARRION FEAST", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_B_Large.png"), false),
            new(2, "SILENT LOCUST", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_C_Large.png"), false)
        };
        public static List<Item> TrailItems { get; private set; } = new()
        {
            new(0, "SUPERSONIC", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_E.png"), false),
            new(1, "ELECTRIC", 1600, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_A.png"), false),
            new(2, "HARLEM", 1600, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_B.png"), false)
        };

        public static Item GetShipItem(int index)
        {
            foreach (Item item in ShipItems)
            {
                if (item.index == index)
                {
                    return item;
                }
            }
            return ShipItems[0];
        }
        public static Item GetProjectileItem(int index)
        {
            foreach (Item item in ProjectileItems)
            {
                if (item.index == index)
                {
                    return item;
                }
            }
            return ProjectileItems[0];
        }
        public static Item GetTrailItem(int index)
        {
            foreach (Item item in TrailItems)
            {
                if (item.index == index)
                {
                    return item;
                }
            }
            return TrailItems[0];
        }
    }
}