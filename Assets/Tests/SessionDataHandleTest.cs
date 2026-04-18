using System.Collections;
using Assets.Scripts.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SessionDataHandleTest
{
    [Test]
    public void SessionData_Clear_Game_Data_Test()
    {
        // Arrange: User playing the level 3 from World 4 (divisions)
        SessionData.SelectedWorldID = 4;
        SessionData.SelectedLevelID = 3;
        // Act: User finishes up the game
        SessionData.ClearGameData();
        // Assert: both the SelectedWorldID and SelectedLevelID static attributes
        // must be set back again to zero until the user decides to play another level-gama
        Assert.That(SessionData.SelectedWorldID, Is.EqualTo(0));
        Assert.That(SessionData.SelectedLevelID, Is.EqualTo(0));
    }
}
