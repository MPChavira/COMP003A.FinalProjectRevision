/*
 * Author: Michael Perez Chavira
 * Course: COMP003A
 * Purpose: Revised New Patient Health Form
 */

using System.Text.RegularExpressions;

namespace COMP003A.FinalProjectRevision
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SectionSeparator("New Patients Health History Form");

            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name: ");
            string lastName = Console.ReadLine();
            if (IsValidateName(firstName, lastName))
            {
                Console.WriteLine("Name is valid.");
            }
            else
            {
                Console.WriteLine("Please enter a valid name.");
            }

            int birthYear;
            while (true)
            {
                Console.WriteLine("Enter your birth year: ");
                if (!int.TryParse(Console.ReadLine(), out birthYear))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }
                if (birthYear < 1900 || birthYear > 2023)
                {
                    Console.WriteLine("Invalid year.");
                    continue;
                }
                break;
            }
            Console.WriteLine("Enter your gender (M/F/O): ");
            string genderInput = Console.ReadLine();
            if (genderInput == "M")
            {
                genderInput = "Male";
            }
            else if (genderInput == "F")
            {
                genderInput = "Female";
            }
            else if (genderInput == "O")
            {
                genderInput = "Other";
            }
            else
            {
                genderInput = "Unknown";
            }
            SectionSeparator("Please answer the following questions below: ");

            
            List<string> questionnaire = patientResponse();
            SectionSeparator("Patient Form Summary: ");
            Console.WriteLine($"Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {genderInput}");
            Console.WriteLine("Questionnaire Responses:");

            for (int i = 0; i < questionnaire.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questionnaire[i]}");
               
            }
        }

        static void SectionSeparator(string sectionName)
        {
            Console.WriteLine("".PadRight(50, '*'));
            Console.WriteLine($"\t{sectionName}");
            Console.WriteLine("".PadRight(50, '*'));
        }

        /// <summary>
        /// Gets the user response for the questions
        /// </summary>
        /// <param name="patient response">response</param>>
        /// <returns>The patients responses</returns>
        static List<string> patientResponse()
        {
            List<string> response = new List<string>();
            string[] questions = new string[]
            {
                "What brings you in today?: ",
                "When was your last doctor visit?: ",
                "What was the reason for your visit?: ",
                "Do you consume alcohol?: ",
                "Do you smoke?: ",
                "Do you exercise regularly?: ",
                "Are you allergic to any medications?:",
                "Are you taking any medications?: ",
                "What is your family health history?: ",
                "Did you have any past surgical procedures?: ",
            };
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"{questions[i]}");

                
                string userResponse = Console.ReadLine();
                response.Add(userResponse);
            }
            return response;
        }
        /// <summary>
        /// Gets the users input for first name and last name and checks if its valid
        /// </summary>
        /// <param name="firstName">The patients first name</param>
        /// <param name="lastName">The patients last name</param>
        /// <returns>The patients valid first and last name</returns>
        static bool IsValidateName(string firstName, string lastName)
        {
            string pattern = @"^[a-zA-Z]+$";
            if (!string.IsNullOrEmpty(firstName) && Regex.IsMatch(firstName, pattern) && !string.IsNullOrEmpty(lastName) && Regex.IsMatch(lastName, pattern))
               
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the users gender then validates it
        /// </summary>
        /// <returns>Validates then gives a full description of the users gender</returns>
        private static char ValidateGenderInput()
        {
            char genderInput;
            do
            {
                Console.WriteLine("Enter your gender (M/F/O): ");
                try
                {
                    genderInput = Console.ReadLine().ToUpper().FirstOrDefault();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    genderInput = '\0';
                }
            } while (genderInput != 'M' && genderInput != 'F' && genderInput != 'O');

            string gender;
            if (genderInput == 'M')
            {
                gender = "Male";
            }
            else if (genderInput == 'F')
            {
                gender = "Female";
            }
            else if (genderInput == '0')
            {
                gender = "Other";
            }
            else
            {
                gender = "";
            }
            return genderInput;
        }
    }




    
}





      