using UnityEngine;

namespace Assets.Scripts.Core
{
    public struct Operand
    {
        public int symbol;
        public string name;
        public Operand(string operand)
        {
            symbol = -1;
            name = operand;
            if (name == "addition") symbol = '+';
            if (name == "subtraction") symbol = '-';
            if (name == "multiplication") symbol = '*';
            if (name == "division") symbol = '/';
        }
    }
    public class Operation
    {
        private Operand operand;
        public double Frequency { get; private set; }
        private Domain domain;
        public Operation(string op, double freq,
        double freq5, double freq3, double freq2, double freqR,
        int domainStart, int domainEnd)
        {
            operand = new Operand(op);
            Frequency = freq;
            domain = new Domain(freq5, freq3, freq2, freqR, domainStart, domainEnd);
        }
        public (string, int) GenerateOperation()
        {
            (int firstTerm, int secondTerm) terms;
            terms.firstTerm = domain.generateNumber();
            terms.secondTerm = domain.generateNumber();

            if (operand.symbol == '-' && terms.secondTerm > terms.firstTerm)
            {
                (terms.firstTerm, terms.secondTerm) = (terms.secondTerm, terms.firstTerm); // Is this the correct way to get close to the C++ std::swap() global function? Or should I do it as below:
                // int temp = terms.firstTerm;
                // terms.firstTerm = terms.secondTerm;
                // terms.secondTerm = temp;
            }
            else if (operand.symbol == '/' && terms.firstTerm % terms.secondTerm != 0)
                terms.firstTerm += terms.secondTerm - (terms.firstTerm % terms.secondTerm);
            
            int answer = 0;
            
            switch (operand.symbol)
            {
                case '+':
                    answer = terms.firstTerm + terms.secondTerm;
                    break;
                case '-':
                    answer = terms.firstTerm - terms.secondTerm;
                    break;
                case '*':
                    answer = terms.firstTerm * terms.secondTerm;
                    break;
                case '/':
                    answer = terms.firstTerm / terms.secondTerm;
                    break;
            }

            string stringOperation = terms.firstTerm.ToString() + " " + ((char)operand.symbol).ToString() + " " + terms.secondTerm.ToString();

            return (stringOperation, answer);
        }
    }
}
