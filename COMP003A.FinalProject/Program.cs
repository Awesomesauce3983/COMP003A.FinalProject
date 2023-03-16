/* Author: Anastasia Clements
 * Class: COMP-003
 * Purpose: Create a Simplified D&D Character Sheet!
 */


namespace COMP003A.FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> questions = new List<string>();
            List<string> responses = new List<string>();
            Console.WriteLine("What is your character's First Name");
            string firstName = FilterSpecial(Console.ReadLine());

            QuestionareGen(questions, firstName);
            FilterSelector(questions, responses);


            Spacer("Response Summary");
            Console.WriteLine("What is your character's First Name");
            Console.WriteLine(firstName);
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i]);
                Console.WriteLine(responses[i]);
            }

            Spacer("Important Information");
            Console.WriteLine($"\nName: {firstName} {responses[0]} ({responses[5]})".PadRight(70, ' ') + $"HP: {responses[12]} / {responses[11]} ({Health(responses[12], responses[11])}%)");
            Console.WriteLine($"\nClass: Level {responses[14]} {responses[13]}".PadRight(70, ' ') + $"Age: {CalculateAge(responses[2], responses[3])}\n");
            Spacer($"{firstName}'s Biography");
            Console.WriteLine($"\nHeight: {responses[9]}".PadRight(30, ' ') + $"Weight: {responses[10]}".PadRight(30, ' ') + $"Birthplace: {responses[1]}\n");
            Console.WriteLine($"Faith: {responses[8]}".PadRight(30, ' ') + $"Bonds: {responses[6]}".PadRight(30, ' ') + $"Flaws: {responses[7]}\n");
            Console.WriteLine($"Gender: {TranslateChar(responses[4])}\n");
            Console.WriteLine($"Character created {CalculateAge(responses[responses.Count - 1])} year(s) ago");
        }

        static void FilterSelector(List<string> question, List<string> response)
        {
            for (int i = 0; i < question.Count(); i++)
            {
                Console.WriteLine(question[i]);
                if (i == 0)
                {
                    response.Add(FilterSpecial(Console.ReadLine()));
                }
                else if (i == 2 || i == 14)
                {
                    response.Add(FilterDigit(Console.ReadLine()));
                }
                else if (i == 4)
                {
                    response.Add(FilterChar(Console.ReadLine()));
                }
                else if (i == 3)
                {
                    response.Add(FilterDate(Console.ReadLine(), response[2]));
                }
                else if (i == 11 || i == 12)
                {
                    response.Add(FilterPositive(Console.ReadLine()));
                }
                else if (i == question.Count - 1)
                {
                    response.Add(FilterDateCurrent(Console.ReadLine()));
                }
                else
                {
                    response.Add(FilterEmpty(Console.ReadLine()));

                }
            }
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
        static bool CheckSpecial(string test)
        {
            bool check = false;
            if (test.Any(character => !char.IsLetter(character)) || test == "")
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Filters a string for special characters
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterSpecial(string test)
        {
            if (CheckSpecial(test) == true)
            {
                Console.WriteLine("This response contains an invalid character!");
                test = Console.ReadLine();
                FilterSpecial(test);
                return test;
            }
            else
            {
                return test;
            }
        }

        /// <summary>
        /// Filters a string for null or White Space
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static bool CheckEmpty(string test)
        {
            bool check = false;
            if (string.IsNullOrWhiteSpace(test))
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Filters a string for non-digit characters
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterEmpty(string test)
        {
            if (CheckEmpty(test) == true)
            {
                Console.WriteLine("This response contains an invalid character!");
                test = Console.ReadLine();
                FilterEmpty(test);
                return test;
            }
            else
            {
                return test;
            }
        }

        /// <summary>
        /// Checks a string for non-digit characters or if its empty
        /// </summary>
        /// <param name="test"></param>
        /// <returns> Returns True if contains non-digit character or is empty</returns>
        static bool CheckDigit(string test)
        {
            bool check = false;
            if (test.Any(character => !char.IsDigit(character)) || test == "")
            {
                check = true;
            }
            return check;
        }





        /// <summary>
        /// Filters a string for non-digit characters
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterDigit(string test)
        {
            if (CheckDigit(test) == true)
            {
                Console.WriteLine("This response contains an invalid character!");
                test = Console.ReadLine();
                FilterDigit(test);
                return test;
            }
            else
            {
                return test;
            }
        }

        /// <summary>
        /// Checks a string for non-digit characters or if its empty
        /// </summary>
        /// <param name="test"></param>
        /// <returns> Returns True if contains non-digit character or is empty</returns>
        static bool CheckPositive(string test)
        {
            double num = Convert.ToDouble(test);
            bool check = false;
            if (test.Any(character => !char.IsDigit(character)) || num <= 0)
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Filters a string number for negatives
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterPositive(string test)
        {
            if (CheckPositive(test) == true)
            {
                Console.WriteLine("This response contains an invalid character!");
                test = Console.ReadLine();
                FilterPositive(test);
                return test;
            }
            else
            {
                return test;
            }
        }

        /// <summary>
        /// Checks a string for non-digit characters or if its empty
        /// </summary>
        /// <param name="test"></param>
        /// <returns> Returns True if contains non-digit character or is empty</returns>
        static bool CheckDateCurrent(string test)
        {
            int date = Convert.ToInt16(test);
            bool check = false;
            if (test.Any(character => !char.IsDigit(character)) || date < 1900 || date > DateTime.Now.Year)
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Filters a date for years outside of 1900 to current year
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterDateCurrent(string test)
        {
            if (CheckDateCurrent(test) == true)
            {
                Console.WriteLine("This response contains an invalid character!");
                test = Console.ReadLine();
                FilterDateCurrent(test);
                return test;
            }
            else
            {
                return test;
            }
        }

        /// <summary>
        /// Checks a string for non-digit characters or if its empty
        /// </summary>
        /// <param name="test"></param>
        /// <returns> Returns True if contains non-digit character or is empty</returns>
        static bool CheckDate(string test, string compare)
        {
            int date = Convert.ToInt16(test);
            int comp = Convert.ToInt16(compare);
            bool check = false;
            if (test.Any(character => !char.IsDigit(character)) || date <= comp)
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Filters a date for years outside of 1900 to current year
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterDate(string test, string compare)
        {
            if (CheckDate(test, compare) == true)
            {
                Console.WriteLine("This response contains an invalid character!");
                test = Console.ReadLine();
                FilterDate(test, compare);
                return test;
            }
            else
            {
                return test;
            }
        }

        /// <summary>
        /// Checks a string for not containing f, m, or o
        /// </summary>
        /// <param name="test"></param>
        /// <returns> Returns True if contains non-digit character or is empty</returns>
        static bool CheckChar(string test)
        {
            test = test.ToLower();
            bool check = false;
            if (test != "f" && test != "m" && test != "o")
            {
                check = true;
            }
            return check;
        }

        static string TranslateChar(string test)
        {
            switch (test)
            {
                case "f":
                    return "Female";
                case "m":
                    return "Male";
                case "o":
                    return "Other";
                default:
                    return test;
            }
        }


        /// <summary>
        /// Filters a string character to only allow F, M, or O
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        static string FilterChar(string test)
        {
            if (CheckChar(test) == true)
            {
                Console.WriteLine("This response contains an invalid character! Please input 'F', 'M', or 'O'!");
                test = Console.ReadLine();
                FilterChar(test);
                return test;
            }
            else
            {
                return test.ToLower();
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

        /// <summary>
        /// Takes a two string values and returns a divided string value
        /// </summary>
        /// <param name="min">Current Health as String</param>
        /// <param name="max">Maximum Health as String</param>
        /// <returns>Rounded Percent as a String</returns>
        static string Health(string min, string max)
        {
            double minD = Convert.ToDouble(min);
            double maxD = Convert.ToDouble(max);
            string health = Convert.ToString(Math.Round(minD / maxD * 100));
            return health;
        }

        static string CalculateAge(string year)
        {
            int input = Convert.ToInt16(year);
            return Convert.ToString(DateTime.Now.Year - input);
        }

        static string CalculateAge(string birthdate, string year)
        {
            int current = Convert.ToInt16(year);
            int birth = Convert.ToInt16(birthdate);
            return Convert.ToString(current - birth);
        }

    }
}