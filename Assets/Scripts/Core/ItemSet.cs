using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Core
{
    public static class RankingUIs
    {
        private static VisualTreeAsset RowTemplate => Resources.Load<VisualTreeAsset>("UI/RankingRowTemplate");
        private static Texture2D FirstPlaceContainer => Resources.Load<Texture2D>("Sprites/Ranking/ranking-1st-extra-large 1");
        private static Texture2D SecondPlaceContainer => Resources.Load<Texture2D>("Sprites/Ranking/ranking-2nd-extra-large 1");
        private static Texture2D ThirdPlaceContainer => Resources.Load<Texture2D>("Sprites/Ranking/ranking-3rd-extra-large 1");
        private static Texture2D OtherPlaceContainer => Resources.Load<Texture2D>("Sprites/Ranking/ranking-4+-extra-large 1");
        public static VisualElement BuildRankingRow(int position, string username, int score)
        {
            VisualElement newRow = RowTemplate.Instantiate();
            newRow.Q<Label>("PositionNumber").text = position.ToString();
            newRow.Q<Label>("UsernameText").text = username;
            newRow.Q<Label>("ScoreNumber").text = score.ToString("N0");
            newRow.Q<VisualElement>("PositionContainer").style.backgroundImage = position switch
            {
                1 => new StyleBackground(FirstPlaceContainer),
                2 => new StyleBackground(SecondPlaceContainer),
                3 => new StyleBackground(ThirdPlaceContainer),
                _ => new StyleBackground(OtherPlaceContainer),
            };
            return newRow;
        }
    }
    public class Item
    {
        public int index;
        public string name;
        public int price;

        public string tipo; // Esto es para saber si es nave, proyectil o estela, y asi guardarlo en la base de datos 
        public Texture2D itemIcon;
        public Item(int i, string n, int p, Texture2D s, string t)
        {
            index = i; name = n; price = p; tipo = t;
            itemIcon = s;
        }
    }
    public static class ItemSet
    {
        public static List<Item> ShipItems { get; private set; } = new()
        {
            new(1, "WILD SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_A_Large"), "S"),
            new(4, "NEO SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_B_Large"), "S"),
            new(7, "AQUA SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_C_Large"), "S"),
            new(10, "PHOENIX SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_D_Large"), "S"),
            new(13, "SUPERNOVA SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_E_Large"), "S"),
            new(16, "WILD SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_A_Large"), "S"),
            new(19, "NEO SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_B_Large"), "S"),
            new(22, "AQUA SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_C_Large"), "S"),
            new(25, "PHOENIX SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_D_Large"), "S"),
            new(28, "SUPERNOVA SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_E_Large"), "S"),
            new(31, "WILD SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_A_Large"), "S"),
            new(34, "NEO SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_B_Large"), "S"),
            new(37, "AQUA SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_C_Large"), "S"),
            new(40, "PHOENIX SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_D_Large"), "S"),
            new(43, "SUPERNOVA SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_E_Large"), "S"),
            new(46, "WILD SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_A_Large"), "S"),
            new(49, "NEO SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_B_Large"), "S"),
            new(52, "AQUA SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_C_Large"), "S"),
            new(55, "PHOENIX SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_D_Large"), "S"),
            new(58, "SUPERNOVA SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_E_Large"), "S"),
            new(61, "WILD SHIP 5", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_A_Large"), "S"),
            new(64, "NEO SHIP 5", 2000, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_B_Large"), "S"),
            new(67, "AQUA SHIP 5", 2000, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_C_Large"), "S"),
            new(70, "PHOENIX SHIP 5", 2000, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_D_Large"), "S"),
            new(73, "SUPERNOVA SHIP 5", 2000, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_E_Large"), "S"),
            new(76, "WILD SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_A_Large"), "S"),
            new(79, "NEO SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_B_Large"), "S"),
            new(82, "AQUA SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_C_Large"), "S"),
            new(85, "PHOENIX SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_D_Large"), "S"),
            new(88, "SUPERNOVA SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_E_Large"), "S"),
            new(91, "WILD SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_A_Large"), "S"),
            new(94, "NEO SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_B_Large"), "S"),
            new(97, "AQUA SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_C_Large"), "S"),
            new(100, "PHOENIX SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_D_Large"), "S"),
            new(103, "SUPERNOVA SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_E_Large"), "S"),
            new(106, "WILD SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_A_Large"), "S"),
            new(107, "NEO SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_B_Large"), "S"),
            new(108, "AQUA SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_C_Large"), "S"),
            new(109, "PHOENIX SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_D_Large"), "S"),
            new(110, "SUPERNOVA SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_E_Large"), "S"),
            new(111, "WILD SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_A_Large"), "S"),
            new(112, "NEO SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_B_Large"), "S"),
            new(113, "AQUA SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_C_Large"), "S"),
            new(114, "PHOENIX SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_D_Large"), "S"),
            new(115, "SUPERNOVA SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_E_Large"), "S"),
            new(116, "WILD SHIP 10", 5000, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_A_Large"), "S"),
            new(117, "NEO SHIP 10", 5000, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_B_Large"), "S"),
            new(118, "AQUA SHIP 10", 5000, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_C_Large"), "S"),
            new(119, "PHOENIX SHIP 10", 5000, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_D_Large"), "S"),
            new(120, "SUPERNOVA SHIP 10", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_E_Large"), "S")
        };
        public static List<Item> ProjectileItems { get; private set; } = new()
        {
            new(2, "WILD MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_1_A_Large"), "P"),
            new(5, "NEO MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_1_B_Large"), "P"),
            new(8, "AQUA MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_1_C_Large"), "P"),
            new(11, "PHOENIX MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_1_D_Large"), "P"),
            new(14, "SUPERNOVA MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_1_E_Large"), "P"),
            new(17, "WILD MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_2_A_Large"), "P"),
            new(20, "NEO MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_2_B_Large"), "P"),
            new(23, "AQUA MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_2_C_Large"), "P"),
            new(26, "PHOENIX MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_2_D_Large"), "P"),
            new(29, "SUPERNOVA MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_2_E_Large"), "P"),
            new(32, "WILD MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_3_A_Large"), "P"),
            new(35, "NEO MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_3_B_Large"), "P"),
            new(38, "AQUA MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_3_C_Large"), "P"),
            new(41, "PHOENIX MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_3_D_Large"), "P"),
            new(44, "SUPERNOVA MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_3_E_Large"), "P"),
            new(47, "WILD MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_4_A_Large"), "P"),
            new(50, "NEO MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_4_B_Large"), "P"),
            new(53, "AQUA MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_4_C_Large"), "P"),
            new(56, "PHOENIX MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_4_D_Large"), "P"),
            new(59, "SUPERNOVA MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_4_E_Large"), "P"),
            new(62, "WILD MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_5_A_Large"), "P"),
            new(65, "NEO MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_5_B_Large"), "P"),
            new(68, "AQUA MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_5_C_Large"), "P"),
            new(71, "PHOENIX MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_5_D_Large"), "P"),
            new(74, "SUPERNOVA MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_5_E_Large"), "P"),
            new(77, "WILD MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_6_A_Large"), "P"),
            new(80, "NEO MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_6_B_Large"), "P"),
            new(83, "AQUA MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_6_C_Large"), "P"),
            new(86, "PHOENIX MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_6_D_Large"), "P"),
            new(89, "SUPERNOVA MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_6_E_Large"), "P"),
            new(92, "WILD MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_7_A_Large"), "P"),
            new(95, "NEO MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_7_B_Large"), "P"),
            new(98, "AQUA MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_7_C_Large"), "P"),
            new(101, "PHOENIX MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_7_D_Large"), "P"),
            new(104, "SUPERNOVA MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_7_E_Large"), "P"),
        };
        public static List<Item> TrailItems { get; private set; } = new()
        {
            new(3, "WILD TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_A"), "T"),
            new(6, "NEO TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_B"), "T"),
            new(9, "AQUA TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_C"), "T"),
            new(12, "PHOENIX TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_D"), "T"),
            new(15, "SUPERNOVA TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_E"), "T"),
            new(18, "WILD TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_A"), "T"),
            new(21, "NEO TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_B"), "T"),
            new(24, "AQUA TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_C"), "T"),
            new(27, "PHOENIX TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_D"), "T"),
            new(30, "SUPERNOVA TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_E"), "T"),
            new(33, "WILD TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_A"), "T"),
            new(36, "NEO TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_B"), "T"),
            new(39, "AQUA TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_C"), "T"),
            new(42, "PHOENIX TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_D"), "T"),
            new(45, "SUPERNOVA TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_E"), "T"),
            new(48, "WILD TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_A"), "T"),
            new(51, "NEO TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_B"), "T"),
            new(54, "AQUA TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_C"), "T"),
            new(57, "PHOENIX TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_D"), "T"),
            new(60, "SUPERNOVA TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_E"), "T"),
            new(63, "WILD TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_A"), "T"),
            new(66, "NEO TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_B"), "T"),
            new(69, "AQUA TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_C"), "T"),
            new(72, "PHOENIX TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_D"), "T"),
            new(75, "SUPERNOVA TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_E"), "T"),
            new(78, "WILD TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_A"), "T"),
            new(81, "NEO TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_B"), "T"),
            new(84, "AQUA TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_C"), "T"),
            new(87, "PHOENIX TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_D"), "T"),
            new(90, "SUPERNOVA TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_E"), "T"),
            new(93, "WILD TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_A"), "T"),
            new(96, "NEO TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_B"), "P"),
            new(99, "AQUA TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_C"), "P"),
            new(102, "PHOENIX TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_D"), "P"),
            new(105, "SUPERNOVA TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_E"), "P")
        };
    }
}