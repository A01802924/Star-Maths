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
                                new("addition", 15, 20, 20, 20, 40, 10, 99),
                                new("subtraction", 85, 50, 0, 50, 0, 10, 50)
                            };
                            correctAnswersGoal = 7;
                            break;
                        case 3:
                            operations = new List<Operation>
                            {
                                new("addition", 25, 0, 0, 0, 100, 10, 99),
                                new("subtraction", 75, 10, 10, 10, 70, 10, 99)
                            };
                            correctAnswersGoal = 10;
                            break;
                        case 4:
                            operations = new List<Operation>
                            {
                                new("addition", 30, 40, 10, 40, 10, 10, 200),
                                new("subtraction", 70, 0, 0, 0, 100, 10, 99)
                            };
                            correctAnswersGoal = 15;
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
                                new("addition", 5, 0, 0, 0, 100, 10, 99),
                                new("subtraction", 10, 40, 10, 40, 10, 10, 99),
                                new("multiplication", 85, 0, 0, 0, 100, 1, 10)
                            };
                            correctAnswersGoal = 7;
                            break;
                        case 3:
                            operations = new List<Operation>
                            {
                                new("addition", 12.5f, 0, 0, 0, 100, 50, 149),
                                new("subtraction", 12.5f, 0, 0, 0, 100, 10, 99),
                                new("multiplication", 75, 0, 0, 0, 100, 1, 12)
                            };
                            correctAnswersGoal = 10;
                            break;
                        case 4:
                            operations = new List<Operation>
                            {
                                new("addition", 20, 0, 0, 0, 100, 50, 199),
                                new("subtraction", 20, 0, 0, 0, 100, 50, 149),
                                new("multiplication", 60, 0, 0, 0, 100, 1, 15)
                            };
                            correctAnswersGoal = 15;
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
                                new("multiplication", 15, 0, 0, 0, 100, 1, 10),
                                new("division", 85, 10, 10, 10, 70, 10, 50)
                            };
                            correctAnswersGoal = 7;
                            break;
                        case 3:
                            operations = new List<Operation>
                            {
                                new("addition", 10, 0, 0, 0, 100, 50, 299),
                                new("subtraction", 10, 0, 0, 0, 100, 50, 199),
                                new("multiplication", 10, 0, 0, 0, 100, 1, 12),
                                new("division", 70, 0, 0, 0, 100, 10, 99)
                            };
                            correctAnswersGoal = 10;
                            break;
                        case 4:
                            operations = new List<Operation>
                            {
                                new("addition", 20, 0, 0, 0, 100, 100, 299),
                                new("subtraction", 20, 0, 0, 0, 100, 100, 299),
                                new("multiplication", 25, 0, 0, 0, 100, 1, 15),
                                new("division", 35, 0, 0, 0, 100, 10, 499)
                            };
                            correctAnswersGoal = 15;
                            break;
                    }
                    break;
            }
            return new Level(wID, lvlID, operations, correctAnswersGoal);
        }
    }

}