using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SayiTahmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Generates a number between 1 and 100 (inclusive of 0, exclusive of 101)
            int randomValue = random.Next(0, 101);

            // User's integer input. This variables's value will taking from TryParse
            int userIntInput;

            int userAttempt = 0;

            // If user can find number we finish game and break all loops
            bool endGame = false;

            // Taking string number input from user
            Console.WriteLine("Please guess a number between 0-100");

            // We are using while because its uncertain user how many tries enter input attempt
            while (endGame == false)
            {
                // At the beggining of loop we read user's input value
                string userStrInput = Console.ReadLine();

                if (int.TryParse(userStrInput, out userIntInput))  // Converting string value to input and identify to userIntInput
                {
                    if (userIntInput <= 100 && userIntInput >= 0) // Value must be between 0-100
                    {
                        userAttempt++; // Increasing count. Its place at the top because when user guess random number loop ends and counter dont count right guessing attempt. So its count before if/else checks.

                        if (userIntInput > randomValue)
                        {
                            Console.WriteLine($"Random number is smaller than {userIntInput}, try again"); // If user input value is below or above of random value, console will inform user. 
                        }
                        else if (userIntInput < randomValue)
                        {
                            Console.WriteLine($"Random number is bigger than {userIntInput}, try again");
                        }
                        else
                        {
                            Console.WriteLine($"Congrats! Your guess is right. Random Value is {randomValue}. Your total guess attempt is {userAttempt}"); // When users number value and randomValue is equal, we congrat user and program will end
                            endGame = true;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Please enter a number between 0-100");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }

                if (endGame == true) // End of the loop we check user wants play again or not
                {
                    Console.WriteLine("Do you want play again? Y/N (Yes/No)");
                    bool isRightInput = false; // Protection for right input

                    while (isRightInput == false)
                    {
                        string playAgain = Console.ReadLine();

                        if (string.Equals(playAgain, "y", StringComparison.OrdinalIgnoreCase)) // Ignoring case using (Y/y - N/n)
                        {
                            randomValue = random.Next(0, 101);
                            userAttempt = 0;
                            Console.WriteLine("Please guess a number between 0-100");
                            endGame = false;
                            isRightInput = true;
                        }
                        else if (string.Equals(playAgain, "n", StringComparison.OrdinalIgnoreCase))
                        {
                            isRightInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter Y or N words");
                        }
                    }
                }
            }
        }
    }
}