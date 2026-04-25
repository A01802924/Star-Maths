using System.Collections.Generic;
using Mono.Cecil;
using UnityEditor;
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
            switch (position)
            {
                case 1:
                    newRow.Q<VisualElement>("PositionContainer").style.backgroundImage = new StyleBackground(FirstPlaceContainer);
                    break;
                case 2:
                    newRow.Q<VisualElement>("PositionContainer").style.backgroundImage = new StyleBackground(SecondPlaceContainer);
                    break;
                case 3:
                    newRow.Q<VisualElement>("PositionContainer").style.backgroundImage = new StyleBackground(ThirdPlaceContainer);
                    break;
                default:
                    newRow.Q<VisualElement>("PositionContainer").style.backgroundImage = new StyleBackground(OtherPlaceContainer);
                    break;
            }
            return newRow;
        }
    }
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
        public static List<Item> ShipItems { get; private set; } = new()
        {
            new(1, "WILD SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_A_Large")),
            new(4, "NEO SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_B_Large")),
            new(7, "AQUA SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_C_Large")),
            new(10, "PHOENIX SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_D_Large")),
            new(13, "SUPERNOVA SHIP 1", 850, Resources.Load<Texture2D>("Sprites/Ships/Ship_1_E_Large")),
            new(16, "WILD SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_A_Large")),
            new(19, "NEO SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_B_Large")),
            new(22, "AQUA SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_C_Large")),
            new(25, "PHOENIX SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_D_Large")),
            new(28, "SUPERNOVA SHIP 2", 1200, Resources.Load<Texture2D>("Sprites/Ships/Ship_2_E_Large")),
            new(31, "WILD SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_A_Large")),
            new(34, "NEO SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_B_Large")),
            new(37, "AQUA SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_C_Large")),
            new(40, "PHOENIX SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_D_Large")),
            new(43, "SUPERNOVA SHIP 3", 1500, Resources.Load<Texture2D>("Sprites/Ships/Ship_3_E_Large")),
            new(46, "WILD SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_A_Large")),
            new(49, "NEO SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_B_Large")),
            new(52, "AQUA SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_C_Large")),
            new(55, "PHOENIX SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_D_Large")),
            new(58, "SUPERNOVA SHIP 4", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_4_E_Large")),
            new(61, "WILD SHIP 5", 1750, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_A_Large")),
            new(64, "NEO SHIP 5", 2000, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_B_Large")),
            new(67, "AQUA SHIP 5", 2000, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_C_Large")),
            new(70, "PHOENIX SHIP 5", 2000, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_D_Large")),
            new(73, "SUPERNOVA SHIP 5", 2000, Resources.Load<Texture2D>("Sprites/Ships/Ship_5_E_Large")),
            new(76, "WILD SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_A_Large")),
            new(79, "NEO SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_B_Large")),
            new(82, "AQUA SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_C_Large")),
            new(85, "PHOENIX SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_D_Large")),
            new(88, "SUPERNOVA SHIP 6", 2500, Resources.Load<Texture2D>("Sprites/Ships/Ship_6_E_Large")),
            new(91, "WILD SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_A_Large")),
            new(94, "NEO SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_B_Large")),
            new(97, "AQUA SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_C_Large")),
            new(100, "PHOENIX SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_D_Large")),
            new(103, "SUPERNOVA SHIP 7", 3000, Resources.Load<Texture2D>("Sprites/Ships/Ship_7_E_Large")),
            new(106, "WILD SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_A_Large")),
            new(107, "NEO SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_B_Large")),
            new(108, "AQUA SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_C_Large")),
            new(109, "PHOENIX SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_D_Large")),
            new(110, "SUPERNOVA SHIP 8", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_8_E_Large")),
            new(111, "WILD SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_A_Large")),
            new(112, "NEO SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_B_Large")),
            new(113, "AQUA SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_C_Large")),
            new(114, "PHOENIX SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_D_Large")),
            new(115, "SUPERNOVA SHIP 9", 4000, Resources.Load<Texture2D>("Sprites/Ships/Ship_9_E_Large")),
            new(116, "WILD SHIP 10", 5000, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_A_Large")),
            new(117, "NEO SHIP 10", 5000, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_B_Large")),
            new(118, "AQUA SHIP 10", 5000, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_C_Large")),
            new(119, "PHOENIX SHIP 10", 5000, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_D_Large")),
            new(120, "SUPERNOVA SHIP 10", 3500, Resources.Load<Texture2D>("Sprites/Ships/Ship_10_E_Large"))
        };
        public static List<Item> ProjectileItems { get; private set; } = new()
        {
            new(2, "WILD MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_1_A_Large")),
            new(5, "NEO MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_1_B_Large")),
            new(8, "AQUA MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_1_C_Large")),
            new(11, "PHOENIX MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_1_D_Large")),
            new(14, "SUPERNOVA MISSILE 1", 1000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_1_E_Large")),
            new(17, "WILD MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_2_A_Large")),
            new(20, "NEO MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_2_B_Large")),
            new(23, "AQUA MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_2_C_Large")),
            new(26, "PHOENIX MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_2_D_Large")),
            new(29, "SUPERNOVA MISSILE 2", 1500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_2_E_Large")),
            new(32, "WILD MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_3_A_Large")),
            new(35, "NEO MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_3_B_Large")),
            new(38, "AQUA MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_3_C_Large")),
            new(41, "PHOENIX MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_3_D_Large")),
            new(44, "SUPERNOVA MISSILE 3", 1750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_3_E_Large")),
            new(47, "WILD MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_4_A_Large")),
            new(50, "NEO MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_4_B_Large")),
            new(53, "AQUA MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_4_C_Large")),
            new(56, "PHOENIX MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_4_D_Large")),
            new(59, "SUPERNOVA MISSILE 4", 2000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_4_E_Large")),
            new(62, "WILD MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_5_A_Large")),
            new(65, "NEO MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_5_B_Large")),
            new(68, "AQUA MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_5_C_Large")),
            new(71, "PHOENIX MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_5_D_Large")),
            new(74, "SUPERNOVA MISSILE 5", 2500, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_5_E_Large")),
            new(77, "WILD MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_6_A_Large")),
            new(80, "NEO MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_6_B_Large")),
            new(83, "AQUA MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_6_C_Large")),
            new(86, "PHOENIX MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_6_D_Large")),
            new(89, "SUPERNOVA MISSILE 6", 2750, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_6_E_Large")),
            new(92, "WILD MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_7_A_Large")),
            new(95, "NEO MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_7_B_Large")),
            new(98, "AQUA MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_7_C_Large")),
            new(101, "PHOENIX MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/ProjectilesMissile_7_D_Large")),
            new(104, "SUPERNOVA MISSILE 7", 3000, Resources.Load<Texture2D>("Sprites/Projectiles/Missile_7_E_Large")),
        };
        public static List<Item> TrailItems { get; private set; } = new()
        {
            new(3, "WILD TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_A")),
            new(6, "NEO TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_B")),
            new(9, "AQUA TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_C")),
            new(12, "PHOENIX TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_D")),
            new(15, "SUPERNOVA TRAIL 1", 1000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_1_E")),
            new(18, "WILD TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_A")),
            new(21, "NEO TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_B")),
            new(24, "AQUA TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_C")),
            new(27, "PHOENIX TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_D")),
            new(30, "SUPERNOVA TRAIL 2", 1500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_2_E")),
            new(33, "WILD TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_A")),
            new(36, "NEO TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_B")),
            new(39, "AQUA TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_C")),
            new(42, "PHOENIX TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_D")),
            new(45, "SUPERNOVA TRAIL 3", 1750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_3_E")),
            new(48, "WILD TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_A")),
            new(51, "NEO TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_B")),
            new(54, "AQUA TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_C")),
            new(57, "PHOENIX TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_D")),
            new(60, "SUPERNOVA TRAIL 4", 2000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_4_E")),
            new(63, "WILD TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_A")),
            new(66, "NEO TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_B")),
            new(69, "AQUA TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_C")),
            new(72, "PHOENIX TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_D")),
            new(75, "SUPERNOVA TRAIL 5", 2500, Resources.Load<Texture2D>("Sprites/Trails/Projectile_5_E")),
            new(78, "WILD TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_A")),
            new(81, "NEO TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_B")),
            new(84, "AQUA TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_C")),
            new(87, "PHOENIX TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_D")),
            new(90, "SUPERNOVA TRAIL 6", 2750, Resources.Load<Texture2D>("Sprites/Trails/Projectile_6_E")),
            new(93, "WILD TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_A")),
            new(96, "NEO TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_B")),
            new(99, "AQUA TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_C")),
            new(102, "PHOENIX TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_D")),
            new(105, "SUPERNOVA TRAIL 7", 3000, Resources.Load<Texture2D>("Sprites/Trails/Projectile_7_E"))
        };
    }
}