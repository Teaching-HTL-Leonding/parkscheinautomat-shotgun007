double enteredcoin = 0;
double allenteredcoins = 0;
string cardprint = "";
double parkingtime = 0;
double hours = 0;
double minutes = 0;
double maxmoney = 1.5;
double donation = 0;
int helpminutes = 0;

Console.Clear();
PrintWelcome();
EnterCoins();

void PrintWelcome()
{
    Console.WriteLine("Parkscheinautomat");
    Console.WriteLine("=====================");
    Console.WriteLine();
    Console.WriteLine("Mindestparkdauer: 30 Minuten.");
    Console.WriteLine("Maximaleparkdauer: 1:30 Stunden.");
    Console.WriteLine("Zulässige Münzen: 5 Cents, 10 Cents, 20 Cents, 50 Cents, 1 Euro, 2 Euro.");
    Console.WriteLine("Durch Eingabe von d oder D wird ein Parkschein gedruckt.");
    Console.WriteLine();
}
void EnterCoins()
{
    while (cardprint != "d" && cardprint != "D")
    {
        
        if (hours < 1 || minutes < 31)
        {
            PrintParkingTime();
        }
        Console.WriteLine("Werfen Sie Münzen ein um Ihre Parkzeit zu verlängern (0,05 (5 Cents), 0,1 (10 Cents), 0,2 (20 Cents), 0,5 (50 Cents), 1 (1 Euro), 2 (2 Euros)).");
        enteredcoin = double.Parse(Console.ReadLine()!);
        allenteredcoins = allenteredcoins + enteredcoin;
        if (allenteredcoins >= 0.5)
        {
            Console.WriteLine("Drücken Sie d oder D um einen Parkschein zu drucken oder einen anderen Buchstaben um dies nicht zu tun.");
            cardprint = Console.ReadLine()!;
        }
        AddParkingTime();
        if ((hours == 1 && minutes > 30) || hours > 1)
        {
            PrintDonation();
            cardprint = "D";
        }
        if ((hours < 1 || minutes < 31) && (cardprint == "D" || cardprint == "d"))
        {
            PrintParkingTime();
        }
    }
}
void AddParkingTime()
{
    parkingtime = allenteredcoins / 0.05 * 3;
    if (parkingtime >= 60)
    {
        minutes = parkingtime % 60;
        hours = (parkingtime - minutes) / 60;
    }
    else if (parkingtime < 60)
    {
        minutes = parkingtime;
    }
}
void PrintParkingTime()
{
    Console.Write("Ihre erlaubte Parkzeit beträgt:");
    Console.Write(" ");
    if (minutes > 9)
    {
    Console.WriteLine(hours + ":" + minutes);
    }
    else if (minutes < 10)
    {
        Console.WriteLine(hours + ":" + helpminutes + minutes);
    }
}
void PrintDonation()
{
    Console.WriteLine("Sie dürfen 1:30 Stunden parken.");
    donation = allenteredcoins - maxmoney;
    Console.Write("Vielen Dank für Ihre Spende in Höhe von:");
    Console.Write(" ");
    Console.WriteLine(donation + "Euro");
}
