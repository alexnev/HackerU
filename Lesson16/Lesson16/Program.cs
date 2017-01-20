using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp16
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Person(string firstName, string lastName)
        {
            if (firstName == null || firstName.Length < 1)
                throw new ArgumentOutOfRangeException("firstName");
            if (lastName == null || lastName.Length < 1)
                throw new ArgumentOutOfRangeException("lastName");
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Person(string firstName) : this(firstName, "no last name")
        {

        }

        public void answerPhone(string caller)
        {

        }
    }
    //Important Note: Constructors do not past through inheritence
    //So the employee class has to chain the getter and setter of the father class
    //The employee constructor creates 2 variables - firstname and lastname and sends them to the person class
    public class Employee : Person
    {
        public Employee(string firstName, string lastName, int employeeId) : base(firstName, lastName)
        {
            this.employeeId = employeeId;
        }
        public int employeeId { get; set; }


    }
    //Interfaces
    public interface IClosable
    {
        void close();
    }

    class Program
    {
        static void Main(string[] args)
        {
            // String uses and built-in methods
            string s = new string('a', 3);
            Console.WriteLine(s);

            string test = "hello";
            char[] characters = test.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                Console.Write(characters[i]);
            }
            Console.WriteLine();
            int x = (int)characters[0];
            Console.WriteLine(x);
            char h = characters[0];
            char H = char.ToUpper(h);
            string TEST = test.ToUpper();
            char.IsLetter(h);
            bool isLetter = char.IsLetter(h);

            string test2 = test.Replace('h', '@');
            Console.WriteLine(test2);
            //CompareTo compares the string's alphabetic placement to the parameters. Returns -1 if comes before, 0 if identical, 1 if comes after.
            int compare = test.CompareTo("bye");
            Console.WriteLine(compare);
            bool contains = test.Contains("lo"); // returns true on 'hello'
            char[] chars = new char[100];
            test.CopyTo(1, chars, 50, 4);
            Console.WriteLine(chars);
            string s2 = "123.45";
            string s3 = "15";

            Console.WriteLine(s2 + s3);

            StringBuilder sb = new StringBuilder();
            sb.Append("hello");
            sb.Append(" ");
            sb.Append("world");
            Console.WriteLine(sb.ToString());

            //tostring is effecient and it's use is the same as Parse() of other variable types
            x = 8;
            Console.WriteLine(x.ToString());
            s = string.Format("hello{0} wor{1}ld", 4, 8);
            Console.WriteLine(s);

            //Testing Homework

            string testH = "13.12";
            Console.WriteLine(isDecimalNumber(testH));
            Console.WriteLine(stringToFloat(testH));
            s = "   ";
            string[] temp = CutStrings(s, ' ');
            for (int i = 0; i < temp.Length; i++)
            {
                Console.WriteLine(i.ToString() + ")" + temp[i]);
            }
            s = "hello";
            Console.WriteLine(PositionOfSubstring(s, "el"));

            Console.ReadKey();
        }

        static bool isDecimalNumber(string input)
        {
            char[] characters = input.ToCharArray();
            if (characters[0] < 49 || characters[0] > 57)
                return false;
            bool isDot = false;
            for (int i = 1; i < characters.Length; i++)
            {
                if (characters[i] == '.' && !isDot && i < characters.Length - 1)
                    isDot = true;
                else if (characters[i] == '.')
                    return false;
                else if (characters[i] < 48 || characters[i] > 57)
                    return false;
            }
            return true;
        }

        static float charToFloat(char input)
        {
            switch (input)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
            }
            return -1;
        }

        static float stringToFloat(string input)
        {
            char[] characters = input.ToCharArray();
            float result = 0;
            int i = 0;
            int decimalCounter = -10;
            bool beforeDot = true;
            while (i < characters.Length)
            {
                if (characters[i] == '.')
                    beforeDot = false;
                else if (beforeDot)
                    result = result * 10 + charToFloat(characters[i]);
                else if (!beforeDot)
                {
                    result += charToFloat(characters[i]) * decimalCounter;
                    decimalCounter *= 10;
                }
                i++;
            }
            return result;
        }

        static int CompareStrings(string s1, string s2)
        {
            for (int i = 0; s1[i] < s1.Length; i++)
            {
                if (s1[i] > s2[i])
                    return -1;
                else if (s1[i] > s2[i])
                    return 1;
            }
            if (s1.Length == s2.Length)
                return 0;
            else
                return -1;
        }

        static int PositionOfSubstring(string input, string substring)
        {
            int index = 0;
            bool hasSubstring = false;
            while (index < input.Length)
            {
                if (input[index] == substring[0])
                {
                    hasSubstring = true;
                    for (int i = 1; i < substring.Length; i++)
                    {
                        if (index + i == input.Length || input[index + 1] != substring[i])
                        {
                            hasSubstring = false;
                            break;
                        }
                    }
                    if (hasSubstring)
                        return index;
                }
                index++;
            }
            return -1;
        }

        static string[] CutStrings(string input, char separator)
        {
            string[] result = new string[input.Length];
            int stringsIndex = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == separator)
                {
                    result[stringsIndex++] = sb.ToString();
                    sb.Clear();
                    continue;
                }
                sb.Append(input[i]);
            }
            if (input[input.Length - 1] != separator)
                result[stringsIndex] = sb.ToString();
            return result;
        }
    }
}
