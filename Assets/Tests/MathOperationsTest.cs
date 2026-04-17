using System.Collections;
using Assets.Scripts.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MathOperationsTest
{
    // Note on this function: since the GenerateNumber() function uses a Random
    // based logic to generate the number, the only 'deterministic' scenario happens when
    // the MultipleFrequencies object configuration restricts all the frequency
    // percentage to a single multiple (either five, three, two or one, but never more
    // than one multiple at a time)
    [Test]
    public void Generate_Number_Follows_Domain_Configuration()
    {
        // Arrange:
        // MultipleFrequencies constructor structure
        // (
        //  Frequency of numbers multiple of five,
        //  Frequency of numbers multiple of three,
        //  Frequency of numbers multiple of two,
        //  Frequency of all the other numbers
        // )
        MultipleFrequencies weighedMultipleFrequencies = new(100, 0, 0, 0);
        Domain domain =
        new(
            weighedMultipleFrequencies.five,
            weighedMultipleFrequencies.three,
            weighedMultipleFrequencies.two,
            weighedMultipleFrequencies.rest,
            10,
            50
        );
        // Act: generating a random number based on the Domain object configuration
        int number = domain.generateNumber();
        // Assert: Under this MultipleFrequency configuration, the domain generator
        // must return a number following the mathematic domain [10, 50]
        Assert.That(number, Is.GreaterThanOrEqualTo(10));
        Assert.That(number, Is.LessThanOrEqualTo(50));
        // and also meeting the condition of always being a multiple of five.
        Assert.That(number % 5, Is.EqualTo(0));
    }
    [Test]
    public void Generate_Addition_Operation_With_Correct_And_Wrong_Answer()
    {
        // Arrange
        MultipleFrequencies mf = new(25, 25, 25, 25);
        Operation addition = new("addition", 100, (float)mf.five, (float)mf.three, (float)mf.two, (float)mf.rest, 50, 100);
        // Act
        (string operationString, int result, int wrongAnswer) question = addition.GenerateOperation();
        // Assert
        string[] operationSections = question.operationString.Split(' ');
        // Assert that there are exactly three operation components on the string that will be displayed:
        Assert.That(operationSections.Length, Is.EqualTo(3));
        // In the strict following structure:
        // 1. First term
        int term1 = int.Parse(operationSections[0]);
        // 2. Operand
        string operand = operationSections[1];
        // 3. Second term
        int term2 = int.Parse(operationSections[2]);
        // Assert that the operation returned is indeed about an addition
        Assert.That(operand, Is.EqualTo("+"));
        // Assert that the returned result is accurate according to the returned string value
        Assert.That(term1 + term2, Is.EqualTo(question.result));
        // Assert that the returned wrongAnswer is different from the addition of both terms
        Assert.AreNotEqual(term1 + term2, question.wrongAnswer);
    }
    [Test]
    public void Generate_Subtraction_Operation_With_Correct_And_Wrong_Answer()
    {
        // Arrange
        MultipleFrequencies mf = new(25, 25, 25, 25);
        Operation subtraction = new("subtraction", 100, (float)mf.five, (float)mf.three, (float)mf.two, (float)mf.rest, 1, 50);
        // Act
        (string operationString, int result, int wrongAnswer) question = subtraction.GenerateOperation();
        // Assert
        string[] operationSections = question.operationString.Split(' ');
        // Assert that there are exactly three operation components on the string that will be displayed:
        Assert.That(operationSections.Length, Is.EqualTo(3));
        // In the strict following structure:
        // 1. First term
        int term1 = int.Parse(operationSections[0]);
        // 2. Operand
        string operand = operationSections[1];
        // 3. Second term
        int term2 = int.Parse(operationSections[2]);
        // Assert that the operation returned is indeed about a subtraction
        Assert.That(operand, Is.EqualTo("-"));
        // Assert that the returned result is accurate according to the returned string value
        Assert.That(term1 - term2, Is.EqualTo(question.result));
        // As a special case for subtractions, the first term must be greater than or equals
        // to the second term to avoid negative results
        Assert.That(term1, Is.GreaterThanOrEqualTo(term2));
        // Assert that the returned wrongAnswer is different from the subtraction of both terms
        Assert.AreNotEqual(term1 - term2, question.wrongAnswer);
    }
    [Test]
    public void Generate_Multiplication_Operation_With_Correct_And_Wrong_Answer()
    {
        // Arrange
        MultipleFrequencies mf = new(25, 25, 25, 25);
        Operation subtraction = new("multiplication", 100, (float)mf.five, (float)mf.three, (float)mf.two, (float)mf.rest, 1, 50);
        // Act
        (string operationString, int result, int wrongAnswer) question = subtraction.GenerateOperation();
        // Assert
        string[] operationSections = question.operationString.Split(' ');
        // Assert that there are exactly three operation components on the string that will be displayed:
        Assert.That(operationSections.Length, Is.EqualTo(3));
        // In the strict following structure:
        // 1. First term
        int term1 = int.Parse(operationSections[0]);
        // 2. Operand
        string operand = operationSections[1];
        // 3. Second term
        int term2 = int.Parse(operationSections[2]);
        // Assert that the operation returned is indeed about a multiplication
        Assert.That(operand, Is.EqualTo("X"));
        // Assert that the returned result is accurate according to the returned string value
        Assert.That(term1 * term2, Is.EqualTo(question.result));
        // Assert that the returned wrongAnswer is different from the multiplication of both terms
        Assert.AreNotEqual(term1 * term2, question.wrongAnswer);
    }
    [Test]
    public void Generate_Division_Operation_With_Correct_And_Wrong_Answer()
    {
        // Arrange
        MultipleFrequencies mf = new(25, 25, 25, 25);
        Operation subtraction = new("division", 100, (float)mf.five, (float)mf.three, (float)mf.two, (float)mf.rest, 1, 50);
        // Act
        (string operationString, int result, int wrongAnswer) question = subtraction.GenerateOperation();
        // Assert
        string[] operationSections = question.operationString.Split(' ');
        // Assert that there are exactly three operation components on the string that will be displayed:
        Assert.That(operationSections.Length, Is.EqualTo(3));
        // In the strict following structure:
        // 1. First term
        int term1 = int.Parse(operationSections[0]);
        // 2. Operand
        string operand = operationSections[1];
        // 3. Second term
        int term2 = int.Parse(operationSections[2]);
        // Assert that the operation returned is indeed about a division
        Assert.That(operand, Is.EqualTo("/"));
        // As a special case for divisions, the first term must be a multiple of the second
        // term to avoid fractional or rational results
        Assert.That(term1 % term2, Is.EqualTo(0));
        // Assert that the returned result is accurate according to the returned string value
        Assert.That(term1 / term2, Is.EqualTo(question.result));
        // Assert that the returned wrongAnswer is different from the division of both terms
        Assert.AreNotEqual(term1 / term2, question.wrongAnswer);
    }
}
