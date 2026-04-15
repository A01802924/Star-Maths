using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{

    public static class SessionData
    {
        public static int SelectedWorldID { get; set; } = 4; // Set as a test value, when test finished, set back to 0
        public static int SelectedLevelID { get; set; } = 3; // Set as a test value, when test finished, set back to 0
        public static int coins { get; set; } = 50000; // Set as a test value, when test finished, set back to 0
        public static List<Item> OwnedItems { get; set; } = new()
        {
            ItemSet.GetShipItem(0),
            ItemSet.GetShipItem(1),
            ItemSet.GetShipItem(2),
            ItemSet.GetProjectileItem(0),
            ItemSet.GetProjectileItem(1),
            ItemSet.GetProjectileItem(2),
            ItemSet.GetTrailItem(0),
            ItemSet.GetTrailItem(2)
        }; // TODO: Handle List<Item> through DB query. Notice that the base case is a List<Item> containing the very first items of each category (Ship, Projectile, and Trail)
        public static Item CurrentShipItem { get; set; } = ItemSet.GetShipItem(1);// By default, a new user will always have at least the very first ship item as owned
        public static Item CurrentProjectileItem { get; set; } = ItemSet.GetProjectileItem(0); // By default, a new user will always have at least the very first projectile item as owned
        public static Item CurrentTrailItem { get; set; } = ItemSet.GetTrailItem(0); // By default, a new user will always have at least the very first trail item as owned
        public static int meteoritoCorrecto { get; set;} = 1;

        public static void ClearGameData()
        {
            SelectedWorldID = 0;
            SelectedLevelID = 0;
        }
    }
}
