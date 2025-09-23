//Jaden Olvera, 9-22-25, Lab 4: Game of Sticks

Console.Title = "Sticks Game";
Console.Clear();

//set up variables
byte sticksLeft = 20;
byte actPlayer = 1;
byte sticksTake = 0;
byte playerOneSticks = 0;
byte playerTwoSticks = 0;

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
        //Instructions
        Console.WriteLine("Players will take turns removing between 1 and 3 of the remaining sticks.");
        Console.WriteLine("The player that removes the last stick loses.");
        Console.WriteLine();

        //Nice looking stick status display, need to format better
        Console.Write("Sticks Left: ");
        for (byte stickDraw = sticksLeft; stickDraw > 0; stickDraw -= 1) Console.Write("|");
        Console.Write($"   ({sticksLeft})");
        Console.WriteLine();
        Console.Write("Player One Sticks:");
        for (byte stickDraw = playerOneSticks; stickDraw > 0; stickDraw -= 1) Console.Write("|");
        Console.Write($"   ({playerOneSticks})");
        Console.Write("Player Two Sticks:");
        for (byte stickDraw = playerTwoSticks; stickDraw > 0; stickDraw -= 1) Console.Write("|");
        Console.Write($"   ({playerTwoSticks})");
        Console.WriteLine();
        Console.WriteLine();

        //Take input and convert, need to TryParse
        Console.WriteLine($"Player {actPlayer}, please choose a number of sticks between 1 and {maxTake}.");
        string stringTake = Console.ReadLine();
        sticksTake = Convert.ToByte(stringTake);

        Console.Clear();
        
        //Check input for the right range
        if (sticksTake == 0 || sticksTake > maxTake)
        {
            if (sticksTake == 0) Console.WriteLine("Error: 0 sticks");
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