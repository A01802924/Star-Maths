using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Core
{
    public static class ConfigurationPreferences
    {
        public static float ScreenBrightness { get; set; } = 100f;
        public static float MusicVolume { get; set; } = 60f;
        public static float SFXVolume { get; set; } = 80f;
        public static KeyCode KeyLeft { get; set; } = KeyCode.A;
        public static KeyCode KeyRight { get; set; } = KeyCode.D;
        public static KeyCode KeyUp { get; set; } = KeyCode.W;
        public static KeyCode KeyDown { get; set; } = KeyCode.S;
        public static KeyCode KeyShoot { get; set; } = KeyCode.Q;
        public static KeyCode KeyPause { get; set; } = KeyCode.Escape;
        public static VisualElement DarkScreenLayer { get; set; } = new()
        {
            style = {
                backgroundColor = Color.black,
                position = Position.Absolute,
                opacity = 0.0085f * (100 - ScreenBrightness),
                width = Length.Percent(100),
                height = Length.Percent(100)
            },
            name = "BrightnessAdjuster",
            pickingMode = PickingMode.Ignore
        };
        public static void UpdateDarkScreenLayer()
        {
            DarkScreenLayer.style.opacity = 0.0085f * (100 - SessionData.ScreenBrightness);
       
        }
        

    }
    public static class SessionData
    {
        public static int SelectedWorldID { get; set; } = 4; // Set as a test value, when test finished, set back to 0
        public static int SelectedLevelID { get; set; } = 3; // Set as a test value, when test finished, set back to 0

        public static bool JuegoJefe { get; set; } = false; // Aqui es para la base
        public static bool Victoria { get; set; } = false; // Aqui es para la base

        public static int SFXVolumen { get; set; } = 80; // Set as a test value, when test finished, set back to 0

        public static int MusicVolumen { get; set; } = 80; // Set as a test value, when test finished, set back to 0

        public static int ScreenBrightness { get; set; } = 100; // Set as a test value, when test finished, set back to 0

        public static int coins { get; set; } = 50000; // Set as a test value, when test finished, set back to 0

        public static List<Item> OwnedItems { get; set; } = new()
        {
            ItemSet.ShipItems[0],
            ItemSet.ShipItems[1],
            ItemSet.ShipItems[2],
            ItemSet.ShipItems[33],
            ItemSet.ShipItems[47],
            ItemSet.ProjectileItems[0],
            ItemSet.ProjectileItems[1],
            ItemSet.ProjectileItems[2],
            ItemSet.ProjectileItems[9],
            ItemSet.ProjectileItems[16],
            ItemSet.TrailItems[0],
            ItemSet.TrailItems[1],
            ItemSet.TrailItems[2],
            ItemSet.TrailItems[21],
            ItemSet.TrailItems[25],
        }; // TODO: Handle List<Item> through DB query. Notice that the base case is a List<Item> containing the very first items of each category (Ship, Projectile, and Trail). For testing pruposes, this List<Item> object is used to test accurate blocking and owned item appearance on the scenes
        public static Item CurrentShipItem { get; set; } = ItemSet.ShipItems[0];// By default, a new user will always have at least the very first ship item as owned
        public static Item CurrentProjectileItem { get; set; } = ItemSet.ProjectileItems[0]; // By default, a new user will always have at least the very first projectile item as owned
        public static Item CurrentTrailItem { get; set; } = ItemSet.TrailItems[0]; // By default, a new user will always have at least the very first trail item as owned
        public static int meteoritoCorrecto { get; set; } = 1;

        public static void ClearGameData()
        {
            SelectedWorldID = 0;
            SelectedLevelID = 0;
            JuegoJefe = false; // Aqui es para la base
            Victoria = false; // Aqui es para la base
            SFXVolumen = 80;
            MusicVolumen = 80;
            ScreenBrightness = 100;
        }
    }
}
