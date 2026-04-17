using System.Collections;
using Assets.Scripts.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void Game_Question_Counter_Test()
    {
        // Arrange: Level 3 from World 1 (Additions)
        Level level = LevelFactory.BuildLevel(1, 3);
        Game gameTest = new LevelGame(level);
        // Act:
        for (int i = 0; i < 15; ++i)
        {
            gameTest.GenerateQuestion();
        }
        // Assert: correctly or uncorrectly answered each question within a game,
        // the Game class must increase in one the QuestionCounter each time the
        // GenerateQuestion function is called
        Assert.That(gameTest.QuestionCounter, Is.EqualTo(15));
    }
}
