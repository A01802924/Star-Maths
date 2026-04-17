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
        public Item(int i, string n, int p, Texture2D s)
        {
            index = i; name = n; price = p;
            itemIcon = s;
        }
    }
    public static class ItemSet
    {
        private const string rootDir = "Assets/Sprites/Stylized 2D Space Shooter/Sprites";
        private const string shipDir = rootDir + "/Large/Ships/";
        private const string shootDir = rootDir + "/Large/Missiles/";
        private const string trailDir = rootDir + "/Projectiles/";
        private const string bundleDir = rootDir + "/Large/Pickups/";
        public static List<Item> ShipItems { get; private set; } = new()
        {
            new(0, "WILD SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_A_Large.png")),
            new(1, "NEO SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_B_Large.png")),
            new(2, "AQUA SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_C_Large.png")),
            new(3, "PHOENIX SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_D_Large.png")),
            new(4, "SUPERNOVA SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_E_Large.png")),
            new(5, "WILD SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_A_Large.png")),
            new(6, "NEO SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_B_Large.png")),
            new(7, "AQUA SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_C_Large.png")),
            new(8, "PHOENIX SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_D_Large.png")),
            new(9, "SUPERNOVA SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_E_Large.png")),
            new(10, "WILD SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_A_Large.png")),
            new(11, "NEO SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_B_Large.png")),
            new(12, "AQUA SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_C_Large.png")),
            new(13, "PHOENIX SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_D_Large.png")),
            new(14, "SUPERNOVA SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_E_Large.png")),
            new(15, "WILD SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_A_Large.png")),
            new(16, "NEO SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_B_Large.png")),
            new(17, "AQUA SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_C_Large.png")),
            new(18, "PHOENIX SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_D_Large.png")),
            new(19, "SUPERNOVA SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_E_Large.png")),
            new(20, "WILD SHIP 5", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_A_Large.png")),
            new(21, "NEO SHIP 5", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_B_Large.png")),
            new(22, "AQUA SHIP 5", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_C_Large.png")),
            new(23, "PHOENIX SHIP 5", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_D_Large.png")),
            new(24, "SUPERNOVA SHIP 5", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_E_Large.png")),
            new(25, "WILD SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_A_Large.png")),
            new(26, "NEO SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_B_Large.png")),
            new(27, "AQUA SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_C_Large.png")),
            new(28, "PHOENIX SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_D_Large.png")),
            new(29, "SUPERNOVA SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_E_Large.png")),
            new(30, "WILD SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_A_Large.png")),
            new(31, "NEO SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_B_Large.png")),
            new(32, "AQUA SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_C_Large.png")),
            new(33, "PHOENIX SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_D_Large.png")),
            new(34, "SUPERNOVA SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_E_Large.png")),
            new(35, "WILD SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_A_Large.png")),
            new(36, "NEO SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_B_Large.png")),
            new(37, "AQUA SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_C_Large.png")),
            new(38, "PHOENIX SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_D_Large.png")),
            new(39, "SUPERNOVA SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_E_Large.png")),
            new(40, "WILD SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_A_Large.png")),
            new(41, "NEO SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_B_Large.png")),
            new(42, "AQUA SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_C_Large.png")),
            new(43, "PHOENIX SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_D_Large.png")),
            new(44, "SUPERNOVA SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_E_Large.png")),
            new(45, "WILD SHIP 10", 5000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_A_Large.png")),
            new(46, "NEO SHIP 10", 5000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_B_Large.png")),
            new(47, "AQUA SHIP 10", 5000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_C_Large.png")),
            new(48, "PHOENIX SHIP 10", 5000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_D_Large.png")),
            new(49, "SUPERNOVA SHIP 10", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_E_Large.png"))
        };
        public static List<Item> ProjectileItems { get; private set; } = new()
        {
            new(0, "WILD MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_A_Large.png")),
            new(1, "NEO MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_B_Large.png")),
            new(2, "AQUA MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_C_Large.png")),
            new(3, "PHOENIX MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_D_Large.png")),
            new(4, "SUPERNOVA MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_E_Large.png")),
            new(5, "WILD MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_A_Large.png")),
            new(6, "NEO MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_B_Large.png")),
            new(7, "AQUA MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_C_Large.png")),
            new(8, "PHOENIX MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_D_Large.png")),
            new(9, "SUPERNOVA MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_E_Large.png")),
            new(10, "WILD MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_A_Large.png")),
            new(11, "NEO MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_B_Large.png")),
            new(12, "AQUA MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_C_Large.png")),
            new(13, "PHOENIX MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_D_Large.png")),
            new(14, "SUPERNOVA MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_E_Large.png")),
            new(15, "WILD MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_A_Large.png")),
            new(16, "NEO MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_B_Large.png")),
            new(17, "AQUA MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_C_Large.png")),
            new(18, "PHOENIX MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_D_Large.png")),
            new(19, "SUPERNOVA MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_E_Large.png")),
            new(20, "WILD MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_A_Large.png")),
            new(21, "NEO MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_B_Large.png")),
            new(22, "AQUA MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_C_Large.png")),
            new(23, "PHOENIX MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_D_Large.png")),
            new(24, "SUPERNOVA MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_E_Large.png")),
            new(25, "WILD MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_A_Large.png")),
            new(26, "NEO MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_B_Large.png")),
            new(27, "AQUA MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_C_Large.png")),
            new(28, "PHOENIX MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_D_Large.png")),
            new(29, "SUPERNOVA MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_E_Large.png")),
            new(30, "WILD MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_A_Large.png")),
            new(31, "NEO MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_B_Large.png")),
            new(32, "AQUA MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_C_Large.png")),
            new(33, "PHOENIX MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_D_Large.png")),
            new(34, "SUPERNOVA MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_E_Large.png")),
        };
        public static List<Item> TrailItems { get; private set; } = new()
        {
            new(0, "WILD TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_A.png")),
            new(1, "NEO TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_B.png")),
            new(2, "AQUA TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_C.png")),
            new(3, "PHOENIX TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_D.png")),
            new(4, "SUPERNOVA TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_E.png")),
            new(5, "WILD TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_A.png")),
            new(6, "NEO TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_B.png")),
            new(7, "AQUA TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_C.png")),
            new(8, "PHOENIX TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_D.png")),
            new(9, "SUPERNOVA TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_E.png")),
            new(10, "WILD TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_A.png")),
            new(11, "NEO TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_B.png")),
            new(12, "AQUA TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_C.png")),
            new(13, "PHOENIX TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_D.png")),
            new(14, "SUPERNOVA TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_E.png")),
            new(15, "WILD TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_A.png")),
            new(16, "NEO TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_B.png")),
            new(17, "AQUA TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_C.png")),
            new(18, "PHOENIX TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_D.png")),
            new(19, "SUPERNOVA TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_E.png")),
            new(20, "WILD TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_A.png")),
            new(21, "NEO TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_B.png")),
            new(22, "AQUA TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_C.png")),
            new(23, "PHOENIX TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_D.png")),
            new(24, "SUPERNOVA TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_E.png")),
            new(25, "WILD TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_A.png")),
            new(26, "NEO TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_B.png")),
            new(27, "AQUA TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_C.png")),
            new(28, "PHOENIX TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_D.png")),
            new(29, "SUPERNOVA TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_E.png")),
            new(30, "WILD TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_A.png")),
            new(31, "NEO TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_B.png")),
            new(32, "AQUA TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_C.png")),
            new(33, "PHOENIX TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_D.png")),
            new(34, "SUPERNOVA TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_E.png"))
        };
        public static List<Item> BundleItems { get; private set; } = new()
        {
            new(0, "AQUA SET", 20000, AssetDatabase.LoadAssetAtPath<Texture2D>(bundleDir + "Pickup_Crate_1_Large.png")),
            new(1, "PHOENIX SET", 20000, AssetDatabase.LoadAssetAtPath<Texture2D>(bundleDir + "Pickup_Crate_2_Large.png")),
            new(2, "WILD SET", 20000, AssetDatabase.LoadAssetAtPath<Texture2D>(bundleDir + "Pickup_Crate_3_Large.png")),
            new(3, "SUPERNOVA SET", 20000, AssetDatabase.LoadAssetAtPath<Texture2D>(bundleDir + "Pickup_Crate_4_Large.png"))
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