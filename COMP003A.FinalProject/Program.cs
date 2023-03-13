/* Author: Anastasia Clements
 * Class: COMP-003
 * Purpose: Create a Simplified D&D Character Sheet!
 */

using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace COMP003A.FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<string> questions = new List<string>();
            List<string> responses = new List<string>();
            Console.WriteLine("What is your character's First Name");
            string firstName = FilterStringSpecial(Console.ReadLine());
     
            QuestionareGen(questions, firstName);
            for (int i = 0; i < questions.Count(); i++)
            {
                Console.WriteLine(questions[i]);
                if (i == 0)
                {
                    responses.Add(FilterStringSpecial(Console.ReadLine()));
                }
                else if (i == 2) 
                {
                    responses.Add(FilterStringDigit(Console.ReadLine()));
                }
                else if (i == 3)
                {
                    responses.Add(FilterStringDigit(Console.ReadLine()));
                }
                else if (i == 11)
                {
                    responses.Add(FilterStringDigit(Console.ReadLine()));
                }
                else if (i == 12)
                {
                    responses.Add(FilterStringDigit(Console.ReadLine()));
                }
                else if (i == questions.Count() - 1)
                {
                    responses.Add(FilterStringDigit(Console.ReadLine()));
                }
                 else 
                {
                    responses.Add(Console.ReadLine());
                    
                }
            }

            Spacer("Response Summary");
            Console.WriteLine("What is your character's First Name");

            Console.WriteLine(firstName);
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i]);
                Console.WriteLine(responses[i]);
            }

            Spacer("Important Information");
            Console.WriteLine($"\nName: {firstName} {responses[0]} ({responses[5]})".PadRight(70, ' ') + $"HP: {responses[12]} / {responses[11]} ({Math.Round(Convert.ToDouble(responses[12]) / Convert.ToDouble(responses[11])*100)}%)");
            Console.WriteLine($"\nClass: Level {responses[14]} {responses[13]}".PadRight(70, ' ') + $"Age: {Convert.ToInt32(responses[3]) - Convert.ToInt32(responses[2])}\n");
            Spacer($"{firstName}'s Biography");
            Console.WriteLine($"\nHeight: {responses[9]}".PadRight(30,' ') + $"Weight: {responses[10]}".PadRight(30, ' ') + $"Birthplace: {responses[1]}\n");
            Console.WriteLine($"Faith: {responses[8]}".PadRight(30, ' ') + $"Bonds: {responses[6]}".PadRight(30, ' ') + $"Flaws: {responses[7]}\n");
            Console.WriteLine($"Gender: {responses[4]}\n");
            Console.WriteLine($"Character created {DateTime.Now.Year - Convert.ToInt32(responses[responses.Count-1])} year(s) ago");
        }

        /// <summary>
        /// Populates a list with the Questionare utilizing Character Name
        /// </summary>
        /// <param name="list">Input list</param>
        /// <param name="name">Input Character Name</param>
        static void QuestionareGen(List<string> list, string name) 
        {
            list.Add($"What is {name}'s Last Name?");
            list.Add($"Where was {name} born?");
            list.Add($"When was {name} born?");
            list.Add($"What year is it in the {name}'s world?");
            list.Add($"What is {name}'s gender?");
            list.Add($"What is {name}'s preferred pronouns");
            list.Add($"What does {name} hold most dear?");
            list.Add($"What is one of {name}'s flaws?");
            list.Add($"What is {name}'s faith?");
            list.Add($"What is {name}'s height?");
            list.Add($"What is {name}'s weight?");
            list.Add($"What is {name}'s maximum HP?");
            list.Add($"What is {name}'s current HP?");
            list.Add($"What is {name}'s class?");
            list.Add($"What level is {name}?");
            list.Add($"What year (In real life) did you create {name}?");
        }

        /// <summary>
        /// Checks a string for special characters or if its empty
        /// </summary>
        /// <param name="test"></param>
        /// <returns> Returns True if contains special character or is empty</returns>
        static bool CheckValueSpecial(string test) 
        {
            bool check = false;
            if (test.Any(character => !char.IsLetter(character)))
            {
                check = true;
            }
            if (test == "")
            { 
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Checks a string for non-digit characters or if its empty
        /// </summary>
        /// <param name="test"></param>
        /// <returns> Returns True if contains non-digit character or is empty</returns>
        static bool CheckValueDigit(string test)
        {
            bool check = false;
            if (test.Any(character => !char.IsDigit(character)))
            {
                check = true;
            }
            if (test == "")
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Filters a string for special characters or empty space
        /// </summary>
        /// <param name="test"></param>
        /// <returns>Exception message if it contains invalid character</returns>
        static string FilterSpecial(string test) 
        {
            if (CheckValueSpecial(test) == true)
            {
                return"This response contains an invalid character!";
            }
            else 
            {
                return test;
            }
        }

        /// <summary>
        /// Filters a string for non-digits or empty space
        /// </summary>
        /// <param name="test"></param>
        /// <returns>Exception message if it contains invalid character</returns>
        static string FilterDigit(string test)
        {
            if (CheckValueDigit(test) == true)
            {
                return "This response contains an invalid character!";
            }
            else
            {
                return test;
            }
        }

        /// <summary>
        /// Filters a string for special characters
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterStringSpecial(string test) 
        {
            if (CheckValueSpecial(test) == true)
            {
                Console.WriteLine(FilterSpecial(test));
                test = Console.ReadLine();
                FilterStringSpecial(test);
                return test;
            }
            else 
            {
                return test;
            }
        }


        /// <summary>
        /// Filters a string for non-digit characters
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterStringDigit(string test)
        {
            if (CheckValueDigit(test) == true)
            {
                Console.WriteLine(FilterDigit(test));
                test = Console.ReadLine();
                FilterStringDigit(test);
                return test;
            }
            else
            {
                return test;
            }
        }

        /// <summary>
        /// Creates a spacer with header in-between
        /// </summary>
        /// <param name="text">header</param>
        static void Spacer(string text) 
        {
            Console.WriteLine("".PadRight(100, '='));
            Console.WriteLine(text.PadLeft(50 + text.Length / 2, ' '));
            Console.WriteLine("".PadRight(100, '='));
        }

    }
}