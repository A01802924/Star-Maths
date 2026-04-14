using UnityEngine;

namespace Assets.Scripts.Core
{
    public static class SessionData
    {
        public static int SelectedWorldID { get; set; } = 0;
        public static int SelectedLevelID { get; set; } = 0;
        public static int coins { get; set; } = 0; // Set as a test value, when test finished, set back to 0
        public static int meteoritoCorrecto { get; set;} = 1;

        public static void ClearGameData()
        {
            SelectedWorldID = 0;
            SelectedLevelID = 0;
        }
    }
}
