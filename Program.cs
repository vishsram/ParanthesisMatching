using System;
using System.Collections;
using System.Collections.Generic;

namespace ParanthesisMatching
{
    public class ParanthesisMatching
    {
        public bool MatchParanthesis(String expression) {
            if (String.IsNullOrEmpty(expression)) {
                return true;
            }

            // If the length is not even, paranthesis won't match
            if (expression.Length % 2 != 0) {
                return false;
            }

            Dictionary<char, char> paranthesis = new Dictionary<char, char>() {
                {'}', '{'},
                {')', '('},
                {']', '['}
            };

            Stack<char> paranthesisStack = new Stack<char>();

            // Iterate through the string by pushing chars to a stack if the char is open paranthesis,
            // If the char is close paranthesis, pop the stack and check for matching open paranthesis
            // in the dictionary. If it doesn't match, return false.
            for(int i = 0; i < expression.Length; i++) {
                if (expression[i] == '}' || expression[i] == ']' || expression[i] == ')') {
                    if (paranthesisStack.TryPeek(out char current)) {
                        if(paranthesisStack.Pop() != paranthesis[expression[i]]) {
                            return false;
                        }
                    }
                    else { // Stack is empty
                        throw new StackOverflowException();
                    }
                }
                else if (paranthesis.ContainsValue(expression[i])) {
                    paranthesisStack.Push(expression[i]);
                } else {// Wrong char
                    throw new ArgumentException();
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ParanthesisMatching pm = new ParanthesisMatching();
            bool result = pm.MatchParanthesis("{[]()}");
            Console.WriteLine(result);
        }
    }
}
