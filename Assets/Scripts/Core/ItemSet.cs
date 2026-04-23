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
            new(1, "WILD SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_A_Large.png")),
            new(4, "NEO SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_B_Large.png")),
            new(7, "AQUA SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_C_Large.png")),
            new(10, "PHOENIX SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_D_Large.png")),
            new(13, "SUPERNOVA SHIP 1", 850, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_1_E_Large.png")),
            new(16, "WILD SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_A_Large.png")),
            new(19, "NEO SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_B_Large.png")),
            new(22, "AQUA SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_C_Large.png")),
            new(25, "PHOENIX SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_D_Large.png")),
            new(28, "SUPERNOVA SHIP 2", 1200, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_2_E_Large.png")),
            new(31, "WILD SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_A_Large.png")),
            new(34, "NEO SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_B_Large.png")),
            new(37, "AQUA SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_C_Large.png")),
            new(40, "PHOENIX SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_D_Large.png")),
            new(43, "SUPERNOVA SHIP 3", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_3_E_Large.png")),
            new(46, "WILD SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_A_Large.png")),
            new(49, "NEO SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_B_Large.png")),
            new(52, "AQUA SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_C_Large.png")),
            new(55, "PHOENIX SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_D_Large.png")),
            new(58, "SUPERNOVA SHIP 4", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_4_E_Large.png")),
            new(61, "WILD SHIP 5", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_A_Large.png")),
            new(64, "NEO SHIP 5", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_B_Large.png")),
            new(67, "AQUA SHIP 5", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_C_Large.png")),
            new(70, "PHOENIX SHIP 5", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_D_Large.png")),
            new(73, "SUPERNOVA SHIP 5", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_5_E_Large.png")),
            new(76, "WILD SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_A_Large.png")),
            new(79, "NEO SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_B_Large.png")),
            new(82, "AQUA SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_C_Large.png")),
            new(85, "PHOENIX SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_D_Large.png")),
            new(88, "SUPERNOVA SHIP 6", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_6_E_Large.png")),
            new(91, "WILD SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_A_Large.png")),
            new(94, "NEO SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_B_Large.png")),
            new(97, "AQUA SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_C_Large.png")),
            new(100, "PHOENIX SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_D_Large.png")),
            new(103, "SUPERNOVA SHIP 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_7_E_Large.png")),
            new(106, "WILD SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_A_Large.png")),
            new(109, "NEO SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_B_Large.png")),
            new(112, "AQUA SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_C_Large.png")),
            new(115, "PHOENIX SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_D_Large.png")),
            new(118, "SUPERNOVA SHIP 8", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_8_E_Large.png")),
            new(121, "WILD SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_A_Large.png")),
            new(124, "NEO SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_B_Large.png")),
            new(127, "AQUA SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_C_Large.png")),
            new(130, "PHOENIX SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_D_Large.png")),
            new(133, "SUPERNOVA SHIP 9", 4000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_9_E_Large.png")),
            new(136, "WILD SHIP 10", 5000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_A_Large.png")),
            new(139, "NEO SHIP 10", 5000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_B_Large.png")),
            new(142, "AQUA SHIP 10", 5000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_C_Large.png")),
            new(145, "PHOENIX SHIP 10", 5000, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_D_Large.png")),
            new(148, "SUPERNOVA SHIP 10", 3500, AssetDatabase.LoadAssetAtPath<Texture2D>(shipDir + "Ship_10_E_Large.png"))
        };
        public static List<Item> ProjectileItems { get; private set; } = new()
        {
            new(2, "WILD MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_A_Large.png")),
            new(5, "NEO MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_B_Large.png")),
            new(8, "AQUA MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_C_Large.png")),
            new(11, "PHOENIX MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_D_Large.png")),
            new(14, "SUPERNOVA MISSILE 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_1_E_Large.png")),
            new(17, "WILD MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_A_Large.png")),
            new(20, "NEO MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_B_Large.png")),
            new(23, "AQUA MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_C_Large.png")),
            new(26, "PHOENIX MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_D_Large.png")),
            new(29, "SUPERNOVA MISSILE 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_2_E_Large.png")),
            new(32, "WILD MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_A_Large.png")),
            new(35, "NEO MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_B_Large.png")),
            new(38, "AQUA MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_C_Large.png")),
            new(41, "PHOENIX MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_D_Large.png")),
            new(44, "SUPERNOVA MISSILE 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_3_E_Large.png")),
            new(47, "WILD MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_A_Large.png")),
            new(50, "NEO MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_B_Large.png")),
            new(53, "AQUA MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_C_Large.png")),
            new(56, "PHOENIX MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_D_Large.png")),
            new(59, "SUPERNOVA MISSILE 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_4_E_Large.png")),
            new(62, "WILD MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_A_Large.png")),
            new(65, "NEO MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_B_Large.png")),
            new(68, "AQUA MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_C_Large.png")),
            new(71, "PHOENIX MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_D_Large.png")),
            new(74, "SUPERNOVA MISSILE 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_5_E_Large.png")),
            new(77, "WILD MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_A_Large.png")),
            new(80, "NEO MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_B_Large.png")),
            new(83, "AQUA MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_C_Large.png")),
            new(86, "PHOENIX MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_D_Large.png")),
            new(89, "SUPERNOVA MISSILE 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_6_E_Large.png")),
            new(92, "WILD MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_A_Large.png")),
            new(95, "NEO MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_B_Large.png")),
            new(98, "AQUA MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_C_Large.png")),
            new(101, "PHOENIX MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_D_Large.png")),
            new(104, "SUPERNOVA MISSILE 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(shootDir + "Missile_7_E_Large.png")),
        };
        public static List<Item> TrailItems { get; private set; } = new()
        {
            new(3, "WILD TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_A.png")),
            new(6, "NEO TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_B.png")),
            new(9, "AQUA TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_C.png")),
            new(12, "PHOENIX TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_D.png")),
            new(15, "SUPERNOVA TRAIL 1", 1000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_1_E.png")),
            new(18, "WILD TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_A.png")),
            new(21, "NEO TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_B.png")),
            new(24, "AQUA TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_C.png")),
            new(27, "PHOENIX TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_D.png")),
            new(30, "SUPERNOVA TRAIL 2", 1500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_2_E.png")),
            new(33, "WILD TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_A.png")),
            new(36, "NEO TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_B.png")),
            new(39, "AQUA TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_C.png")),
            new(42, "PHOENIX TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_D.png")),
            new(45, "SUPERNOVA TRAIL 3", 1750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_3_E.png")),
            new(48, "WILD TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_A.png")),
            new(51, "NEO TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_B.png")),
            new(54, "AQUA TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_C.png")),
            new(57, "PHOENIX TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_D.png")),
            new(60, "SUPERNOVA TRAIL 4", 2000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_4_E.png")),
            new(63, "WILD TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_A.png")),
            new(66, "NEO TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_B.png")),
            new(69, "AQUA TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_C.png")),
            new(72, "PHOENIX TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_D.png")),
            new(75, "SUPERNOVA TRAIL 5", 2500, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_5_E.png")),
            new(78, "WILD TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_A.png")),
            new(81, "NEO TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_B.png")),
            new(84, "AQUA TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_C.png")),
            new(87, "PHOENIX TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_D.png")),
            new(90, "SUPERNOVA TRAIL 6", 2750, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_6_E.png")),
            new(93, "WILD TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_A.png")),
            new(96, "NEO TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_B.png")),
            new(99, "AQUA TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_C.png")),
            new(102, "PHOENIX TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_D.png")),
            new(105, "SUPERNOVA TRAIL 7", 3000, AssetDatabase.LoadAssetAtPath<Texture2D>(trailDir + "Projectile_7_E.png"))
        };
    }
}