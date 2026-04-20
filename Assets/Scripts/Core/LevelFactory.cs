using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    public class LevelFactory
    {
        public static Level BuildLevel(int wID, int lvlID)
        {
            List<Operation> operations = new();
            int correctAnswersGoal = -1;
            switch (wID)
            {
                case 1:
                    switch (lvlID)
                    {
                        case 1:
                            operations = new List<Operation> {
                                new("addition", 100, 10, 10, 10, 70, 1, 10)
                            };
                            correctAnswersGoal = 5;
                            break;
                        case 2:
                            operations = new List<Operation>
                            {
                                new("addition", 100, 40, 0, 40, 20, 10, 20)
                            };
                            correctAnswersGoal = 7;
                            break;
                        case 3:
                            operations = new List<Operation>
                            {
                                new("addition", 100, 20, 20, 20, 40, 20, 50)
                            };
                            correctAnswersGoal = 10;
                            break;
                        case 4:
                            operations = new List<Operation>
                            {
                                new("addition", 100, 0, 0, 0, 100, 10, 99)
                            };
                            correctAnswersGoal = 15;
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (lvlID)
                    {
                        case 1:
                            operations = new List<Operation>
                            {
                                new("subtraction", 100, 10, 10, 10, 70, 1, 15)
                            };
                            correctAnswersGoal = 5;
                            break;
                        case 2:
                            operations = new List<Operation>
                            {
                                new("subtraction", 100, 50, 0, 50, 0, 10, 50)
                            };
                            correctAnswersGoal = 7;
                            break;
                        case 3:
                            operations = new List<Operation>
                            {
                                new("subtraction", 100, 10, 10, 10, 70, 10, 99)
                            };
                            correctAnswersGoal = 10;
                            break;
                        case 4:
                            operations = new List<Operation>
                            {
                                new("subtraction", 100, 0, 0, 0, 100, 10, 99)
                            };
                            correctAnswersGoal = 15;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (lvlID)
                    {
                        case 1:
                            operations = new List<Operation>
                            {
                                new("multiplication", 100, 50, 0, 50, 0, 2, 10)
                            };
                            correctAnswersGoal = 5;
                            break;
                        case 2:
                            operations = new List<Operation>
                            {
                                new("multiplication", 100, 0, 0, 0, 100, 1, 10)
                            };
                            correctAnswersGoal = 7;
                            break;
                        case 3:
                            operations = new List<Operation>
                            {
                                new("multiplication", 100, 0, 0, 0, 100, 1, 12)
                            };
                            correctAnswersGoal = 10;
                            break;
                        case 4:
                            operations = new List<Operation>
                            {
                                new("multiplication", 100, 0, 0, 0, 100, 1, 15)
                            };
                            correctAnswersGoal = 15;
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    switch (lvlID)
                    {
                        case 1:
                            operations = new List<Operation>
                            {
                                new("division", 100, 50, 0, 50, 0, 2, 20)
                            };
                            correctAnswersGoal = 5;
                            break;
                        case 2:
                            operations = new List<Operation>
                            {
                                new("division", 100, 10, 10, 10, 70, 10, 50)
                            };
                            correctAnswersGoal = 7;
                            break;
                        case 3:
                            operations = new List<Operation>
                            {
                                new("division", 100, 0, 0, 0, 100, 10, 99)
                            };
                            correctAnswersGoal = 10;
                            break;
                        case 4:
                            operations = new List<Operation>
                            {
                                new("division", 100, 0, 0, 0, 100, 10, 499)
                            };
                            correctAnswersGoal = 15;
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    switch(lvlID)
                    {
                        case 1:
                            operations = new()
                            {
                                new("addition", 25, 0, 0, 0, 100, 10, 50),
                                new("subtraction", 25, 0, 0, 0, 100, 1, 50),
                                new("multiplication", 25, 0, 0, 0, 100, 1, 10),
                                new("division", 25, 0, 0, 0, 100, 1, 50)
                            };
                            correctAnswersGoal = 5;
                            break;
                        case 2:
                            operations = new()
                            {
                                new("addition", 25, 0, 0, 0, 100, 50, 99),
                                new("subtraction", 25, 0, 0, 0, 100, 20, 75),
                                new("multiplication", 25, 0, 0, 0, 100, 3, 12),
                                new("division", 25, 0, 0, 0, 100, 50, 150)
                            };
                            correctAnswersGoal = 7;
                            break;
                        case 3:
                            operations = new()
                            {
                                new("addition", 25, 0, 0, 0, 100, 100, 500),
                                new("subtraction", 25, 0, 0, 0, 100, 100, 350),
                                new("multiplication", 25, 0, 0, 0, 100, 6, 14),
                                new("division", 25, 0, 0, 0, 100, 75, 250)
                            };
                            correctAnswersGoal = 10;
                            break;
                        case 4:
                            operations = new()
                            {
                                new("addition", 25, 0, 0, 0, 100, 200, 750),
                                new("subtraction", 25, 0, 0, 0, 100, 150, 500),
                                new("multiplication", 25, 0, 0, 0, 100, 4, 16),
                                new("division", 25, 0, 0, 0, 100, 150, 500)
                            };
                            correctAnswersGoal = 15;
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return new Level(wID, lvlID, operations, correctAnswersGoal);
        }
    }

}