//Jaden Olvera, 9-22-25, Lab 4: Game of Sticks

Console.Title = "Sticks Game";
Console.Clear();

//set up variables
byte sticksLeft = 20;
byte actPlayer = 1;
byte sticksTake = 0;
byte playerOneSticks = 0;
byte playerTwoSticks = 0;
string stringInstructions1 = "Players will take turns removing between 1 and 3 of the remaining sticks";
string stringInstructions2 = "The player that removes the last stick loses!";
int instructions1Length = stringInstructions1.Length;
int instructions2Length = stringInstructions2.Length;
int instructions2Center = (stringInstructions1.Length + 2 - instructions2Length) / 2;

//Main Game Loop
while (sticksLeft > 0)
{
    //Check if we need to lower the max sticks taken
    byte maxTake;
    if (sticksLeft >= 3) maxTake = 3;
    else maxTake = sticksLeft;

    //Collect player's number of sticks to take
    while (sticksTake == 0 || sticksTake > maxTake) 
    {
        //Instructions box
        //Top Line
        Console.Write("\u250F");
        for (int lineDraw = instructions1Length + 2; lineDraw > 0; lineDraw -= 1)
        {
            Console.Write("\u2501");
        }
        Console.Write("\u2513");
        Console.WriteLine();
        //Instruction Line 1
        Console.WriteLine("\u2503 " + stringInstructions1 + " \u2503");
        //Instruction Line 2
        Console.Write("\u2503");
        //Line 2 centering attempt
        for (int instructions2CenterSpace = instructions2Center; instructions2CenterSpace > 0; instructions2CenterSpace -= 1)
        {
            Console.Write(" ");
        }
        Console.Write(stringInstructions2);
        for (int instructions2CenterSpace = instructions2Center; instructions2CenterSpace > -1; instructions2CenterSpace -= 1)
        {
            Console.Write(" ");
        }
        Console.Write("\u2503");
        Console.WriteLine();
        //Bottom Line
        Console.Write("\u2517");
        for (int lineDraw = instructions1Length + 2; lineDraw > 0; lineDraw -= 1)
        {
            Console.Write("\u2501");
        }
        Console.Write("\u251B");
        Console.WriteLine();
        Console.WriteLine();

        //Nice looking stick status display, need to format better
        Console.Write("Sticks Left: ");
        Console.Write($"{sticksLeft,-3}");
        for (byte stickDraw = sticksLeft; stickDraw > 0; stickDraw -= 1) Console.Write("|");
        Console.WriteLine();
        Console.WriteLine();

        //Player 1 stick display
        Console.Write("Player One Sticks:");
        for (byte stickDraw = playerOneSticks; stickDraw > 0; stickDraw -= 1) Console.Write("|");
        Console.Write($"   ({playerOneSticks})");
        //Player 2 stick display
        Console.Write("Player Two Sticks:");
        for (byte stickDraw = playerTwoSticks; stickDraw > 0; stickDraw -= 1) Console.Write("|");
        Console.Write($"   ({playerTwoSticks})");
        Console.WriteLine();
        Console.WriteLine();

        //Take input and convert, need to TryParse
        Console.WriteLine($"Player {actPlayer}, please choose a number of sticks between 1 and {maxTake}.");
        string stringTake = Console.ReadLine();
        bool parseSuccess = byte.TryParse(stringTake, out sticksTake);

        Console.Clear();
        
        //Check input for the right range
        if (parseSuccess == false || sticksTake == 0 || sticksTake > maxTake)
        {
            if (parseSuccess == false) Console.WriteLine("Error: Parse fail");
            else if (sticksTake == 0) Console.WriteLine("Error: 0 sticks");
            else if (sticksTake > maxTake) Console.WriteLine($"Error: More sticks than {maxTake}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }

    //Remove the sticks they choose from the remaining
    sticksLeft -= sticksTake;

    //Player Stick count tracking, for fun
    if (actPlayer == 1) playerOneSticks += sticksTake;
    else if (actPlayer == 2) playerTwoSticks += sticksTake;

    //Switch players
    if (actPlayer == 1) actPlayer = 2;
    else actPlayer = 1;

    //Reset player stick #
    sticksTake = 0;
}

//Whichever player didn't take the last stick
Console.WriteLine($"Player {actPlayer} wins!");