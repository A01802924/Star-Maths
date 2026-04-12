using UnityEngine;

namespace Assets.Scripts.Core
{
    public static class SessionData
    {
        public static int SelectedWorldID { get; set; } = 0;
        public static int SelectedLevelID { get; set; } = 0;

        public static void ClearGameData()
        {
            SelectedWorldID = 0;
            SelectedLevelID = 0;
        }
    }
}
