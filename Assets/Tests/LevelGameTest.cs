using System.Collections;
using Assets.Scripts.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelGameTest
{
    [Test]
    public void Level_Game_Try_Decrease_Lives_Success_Case_Test()
    {
        // Arrange: Level 4 from World 2 (Subtractions)
        Level anyLevel = LevelFactory.BuildLevel(2, 4);
        LevelGame levelTest = new(anyLevel);
        // Act
        levelTest.TryDecreaseLives();
        // Assert
        // For every TryDecreaseLives() function call, the object levelTest
        // must decrease its CurrentLives property in one when succeed
        Assert.That(levelTest.CurrentLives, Is.EqualTo(levelTest.InitialLives - 1));
    }
    [Test]
    public void Level_Game_Try_Decrease_Lives_Fail_Case_Test()
    {
        // Arrange: Level 1 from World 3 (Multiplications)
        Level anyLevel = LevelFactory.BuildLevel(3, 1);
        LevelGame levelGameTest = new(anyLevel);
        // Act
        for (int i = 0; i < 10; ++i)
        {
            levelGameTest.TryDecreaseLives();
        }
        // Assert
        // By definition, all LevelGame game object will always start with five lives
        // and the game will be over whenever the user subtracts five times its lives
        // Therefore, whenever the function tries to decrease the lives when CurrentLives
        // has already reached the limit, the function will not exert the subtraction
        Assert.That(levelGameTest.CurrentLives, Is.EqualTo(0));
    }
    [Test]
    public void Level_Game_Game_Over_Trigger_Test()
    {
        // Arrange: Level 3 from World 4 (Divisions)
        Level anyLevel = LevelFactory.BuildLevel(4, 3);
        LevelGame levelGameTest = new(anyLevel);
        // Act
        int wrongAnswers = 0;
        while (levelGameTest.TryDecreaseLives())
        {
            ++wrongAnswers;
        }
        // Assert:
        // Whenever the TryDecreaseLives() function 'fails' at decreasing lives,
        // the system must set the IsVictory attribute as false immediately
        Assert.That(levelGameTest.IsVictory, Is.False);
        // And so setting the IsFinished attribute as true
        Assert.That(levelGameTest.IsFinished, Is.True);
        // Assert as well that in real level-games the number of wrong answers
        // must be equal to the InitialLives attribute
        Assert.That(wrongAnswers, Is.EqualTo(levelGameTest.InitialLives));
        // Finally, assert that the final CurrentLives status is set to 0
        Assert.That(levelGameTest.CurrentLives, Is.EqualTo(0));
    }
}
