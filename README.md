# Number Guessing Game

At 22:30, I created a number guessing game in the terminal; first, I wrote down on paper how the application would work:

## Planning on Paper

#### First Part of the Notes

The computer will generate a random number. User input will be requested. If the entered number is smaller than the random number, it will print 'smaller'; if it is larger, it will print 'larger'. The user will win when they enter the exact same value as the random number.

#### Second Part of the Notes

A `while` loop will be used because the number of attempts the user will make is uncertain. The random number will be stored as an `int` value. The string value entered by the user from the console will be converted to an integer using `TryParse`. Comparisons will be made using `if/else` statements. The generated random number will be between 0-100; if the entered value is outside this range, a warning message will be sent to the user.

## First Version of the Code

C#

``` csharp
namespace SayiTahmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Generates a number between 1 and 100 (inclusive of 1, exclusive of 101)
            int randomValue = random.Next(0, 101);

            // User's integer input. This variables's value will taking from TryParse
            int userIntInput;

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
                    if (userIntInput <= 100 && userIntInput >= 0) // Value must be between 1-100
                    {
                        while (endGame == false) // Second while loop. This will check guess is right or not.
                        {
                            if (userIntInput > randomValue)
                            {
                                Console.WriteLine($"Random number is smaller than {userIntInput}, try again"); // If user input value is below or above of random value, console will inform user. 
                                break; // We will be breaking loop at every condition's end because program fall into infinite loop
                            }
                            else if (userIntInput < randomValue)
                            {
                                Console.WriteLine($"Random number is bigger than {userIntInput}, try again");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Congrats! Your guess is right. Random Value is {randomValue}"); // When users number value and randomValue is equal, we congrat user and program will end
                                endGame = true; // Breaking all loops
                                break;
                            }
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
            }
        }
    }
}
```

## My Mistakes in the Code

1. Using an unnecessary `while` loop. Since I placed a `break` at the end of every `if/else` block, the loop wasn't actually running continuously. I needed to remove the inner `while`.
    
2. Specifying the random number range incorrectly. Because I specified `(1-100)`, it wouldn't include 1. The correct range format is `(0-100)`.
    

## Adding New Features

1. A counter showing how many attempts it took for the user to succeed. I will display this counter using string interpolation when the user wins.
    

C#

``` csharp
namespace SayiTahmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // Generates a number between 1 and 100 (inclusive of 1, exclusive of 101)
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
                    if (userIntInput <= 100 && userIntInput >= 0) // Value must be between 1-100
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
                            endGame = true; // Breaking loop
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
            }
        }
    }
}
```

## RESULT

<img width="1111" height="491" alt="image" src="https://github.com/user-attachments/assets/44a9845d-9472-456e-8da9-d2819e965e11" />

# End of the Day 00:50

We have reached the end of the day. I will upload the project to GitHub. For the first time, I wrote the algorithm and code entirely by myself without any AI or external help. While writing the code, I only looked at my past `TryParse` implementations and checked examples online on how to generate random numbers since I didn't know how. The code I wrote worked perfectly. Afterwards, we consulted with Claude and Gemini to see how I could write cleaner code and add new features. The counter idea came from Claude. In the future, I might write a "do you want to play again" feature.

# The Real End of the Day 02:07

I wanted to add the "play again" option as well. After deep thoughts and considerable effort, I managed to do it. Now it's time to upload it to GitHub.

## Final Version of the Code

C#

```csharp
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
```

# Final Look with the New Feature

<img width="759" height="574" alt="image" src="https://github.com/user-attachments/assets/19549941-eeca-4dce-b802-bc43327a1dc3" />
