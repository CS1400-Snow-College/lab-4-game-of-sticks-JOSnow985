//Jaden Olvera, 9-22-25, Lab 4: Game of Sticks

Console.Title = "The Game of Sticks";
Console.Clear();

//set up variables
byte sticksRemaining = 20;
byte activePlayer = 1;
byte sticksToTake = 0;
string stringWelcome = "Welcome to the Game of Sticks!";
string stringInstructions1 = "Players will take turns removing between 1 and 3 of the remaining sticks";
string stringInstructions2 = "The player that removes the last stick loses!";
string stringWinner = $"Player {activePlayer} wins!";

//Main Game Loop
while (sticksRemaining > 0)
{
    //Check if we need to lower the max sticks taken
    byte maxToTake;
    if (sticksRemaining >= 3) maxToTake = 3;
    else maxToTake = sticksRemaining;

    //Collect player's number of sticks to take
    while (sticksToTake == 0 || sticksToTake > maxToTake)
    {
        //Welcome Box
        Console.Write(string.Format("{0, 21}", "\u250F"));
        for (int lineDraw = stringWelcome.Length + 2; lineDraw > 0; lineDraw -= 1)
        {
            Console.Write("\u2501");
        }
        Console.WriteLine("\u2513");
        Console.WriteLine(string.Format("{0, 54}", "\u2503 " + stringWelcome + " \u2503"));
        Console.Write(string.Format("{0, 21}", "\u2517"));
        for (int lineDraw = stringWelcome.Length + 2; lineDraw > 0; lineDraw -= 1)
        {
            Console.Write("\u2501");
        }
        Console.WriteLine("\u251B");

        //Instructions box
        //Top Line
        Console.Write("\u250F");
        for (int lineDraw = stringInstructions1.Length + 2; lineDraw > 0; lineDraw -= 1)
        {
            Console.Write("\u2501");
        }
        Console.WriteLine("\u2513");
        //Instruction Line 1
        Console.WriteLine("\u2503 " + stringInstructions1 + " \u2503");
        //Instruction Line 2
        Console.Write("\u2503");
        //Line 2 centering attempt check extra +1
        for (int instructions2CenterSpace = (stringInstructions1.Length + 1 - stringInstructions2.Length) / 2 + 1; instructions2CenterSpace > 0; instructions2CenterSpace -= 1)
        {
            Console.Write(" ");
        }
        Console.Write(stringInstructions2);
        for (int instructions2CenterSpace = (stringInstructions1.Length + 1 - stringInstructions2.Length) / 2; instructions2CenterSpace > 0; instructions2CenterSpace -= 1)
        {
            Console.Write(" ");
        }
        Console.Write("\u2503");
        Console.WriteLine();
        //Bottom Line
        Console.Write("\u2517");
        for (int lineDraw = stringInstructions1.Length + 2; lineDraw > 0; lineDraw -= 1)
        {
            Console.Write("\u2501");
        }
        Console.Write("\u251B");
        Console.WriteLine();
        Console.WriteLine();

        //Nice looking stick status display
        Console.Write(string.Format("{0, 34}", "Sticks Remaining: "));
        Console.Write($"{sticksRemaining,-3}");
        for (byte stickDraw = sticksRemaining; stickDraw > 0; stickDraw -= 1) Console.Write("|");
        Console.WriteLine();
        Console.WriteLine();

        //Take input and parse
        Console.Write(string.Format("{0, 67}", $"Player {activePlayer}, please choose a number of sticks between 1 and {maxToTake}: "));
        string stringTake = Console.ReadLine()!;
        bool parseSuccess = byte.TryParse(stringTake, out sticksToTake);

        Console.WriteLine();
        //Check input for parsing and correct range
        if (parseSuccess == false || sticksToTake == 0 || sticksToTake > maxToTake)
        {
            if (parseSuccess == false) Console.Write($"I'm sorry, Player {activePlayer}, but the game couldn't understand that input, please try again with a number between 1 and {maxToTake}.");
            else if (sticksToTake == 0 && maxToTake == 1) Console.Write($"I'm sorry, Player {activePlayer}, but you have to take the last stick...");
            else if (sticksToTake == 0) Console.Write($"I'm sorry, Player {activePlayer}, but you must take at least one stick.");
            else if (sticksToTake > maxToTake && maxToTake == 1) Console.Write($"I'm sorry, Player {activePlayer}, but there's only one last stick to take...");
            else if (sticksToTake > maxToTake) Console.Write($"I'm sorry, Player {activePlayer}, but you can't take more than {maxToTake} sticks.");
            Thread.Sleep(2500);
        }
        Console.Clear();
    }

    //Remove the sticks they choose from the remaining
    sticksRemaining -= sticksToTake;

    //Switch players
    if (activePlayer == 1) activePlayer = 2;
    else activePlayer = 1;

    //Reset player stick #
    sticksToTake = 0;
}

//Whichever player didn't take the last stick
Console.Write(string.Format("{0, 23}", "\u250F"));
for (int lineDraw = stringWinner.Length + 2; lineDraw > 0; lineDraw -= 1)
    {
        Console.Write("\u2501");
    }
Console.WriteLine("\u2513");
Console.WriteLine(string.Format("{0, 40}","\u2503 " + stringWinner + " \u2503"));
Console.Write(string.Format("{0, 23}","\u2517"));
for (int lineDraw = stringWinner.Length + 2; lineDraw > 0; lineDraw -= 1)
    {
        Console.Write("\u2501");
    }
Console.WriteLine("\u251B");