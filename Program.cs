Console.Title = "Sticks Game";
Console.Clear();
Console.WriteLine("Rules Placeholder");
//set up variables
byte sticksLeft = 20;
byte actPlayer = 1;
byte sticksTake = 0;
while (sticksLeft > 0)
{
    byte maxTake;
    if (sticksLeft >= 3) maxTake = 3;
    else maxTake = sticksLeft;
    while (sticksTake == 0 || sticksTake > maxTake) 
    {
        Console.WriteLine($"Player {actPlayer}, please choose a number of sticks between 1 and {maxTake}.");
        string stringTake = Console.ReadLine();
        sticksTake = Convert.ToByte(stringTake);
        if (sticksTake == 0)
        {
            Console.WriteLine("Error: 0 sticks");
        }
        else if (sticksTake > maxTake)
        {
            Console.WriteLine($"Error: More sticks than {maxTake}");
        }
    }
    Console.WriteLine($"Left: {sticksLeft}");
    Console.WriteLine(sticksTake);
    sticksLeft -= sticksTake;
    Console.WriteLine($"Left: {sticksLeft}");
    if (actPlayer == 1) actPlayer = 2;
    else actPlayer = 1;
    sticksTake = 0;
    Console.WriteLine($"Player: {actPlayer}");
    Console.WriteLine($"Left: {sticksLeft}");
}
Console.WriteLine($"Player {actPlayer} wins!");