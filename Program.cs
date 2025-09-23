//Jaden Olvera, 9-22-25, Lab 4: Game of Sticks


Console.Title = "Sticks Game";
Console.Clear();
Console.WriteLine("Players will take turns removing between 1 and 3 of the remaining sticks.");
Console.WriteLine("The player that removes the last stick loses.");

//set up variables
byte sticksLeft = 20;
byte actPlayer = 1;
byte sticksTake = 0;

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
        Console.WriteLine($"Player {actPlayer}, please choose a number of sticks between 1 and {maxTake}.");
        string stringTake = Console.ReadLine();
        sticksTake = Convert.ToByte(stringTake);
        if (sticksTake == 0) Console.WriteLine("Error: 0 sticks");
        else if (sticksTake > maxTake) Console.WriteLine($"Error: More sticks than {maxTake}");
    }

    //Remove the sticks they choose from the remaining
    sticksLeft -= sticksTake;

    //Nice looking stick status display
    Console.Write("Sticks Left: ");
    for (byte stickDraw = sticksLeft; stickDraw > 0; stickDraw -= 1) Console.Write("|");
    Console.Write($"   ({sticksLeft})");
    Console.WriteLine();

    //Switch players
    if (actPlayer == 1) actPlayer = 2;
    else actPlayer = 1;

    //Reset player stick #
    sticksTake = 0;
}

//Whichever player didn't take the last stick
Console.WriteLine($"Player {actPlayer} wins!");