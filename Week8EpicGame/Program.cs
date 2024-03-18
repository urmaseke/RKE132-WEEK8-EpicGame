
string folderpath = @"C:\Users\urmas\OneDrive\Desktop\Proge\";
string heroefile = "heroes.txt";
string villainfile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderpath, heroefile));
string[] villains= File.ReadAllLines(Path.Combine(folderpath, villainfile));



string[] weapons = { "hammer", "magic wand", "sword", "lightsaber","a knife" };


string hero = GetRandomValue(heroes);
string heroWeapon= GetRandomValue(weapons);
int heroHP = GetCharacterHP(hero);
int herostrikestrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the world!");


string villain = GetRandomValue(villains);
string VillainWeapon= GetRandomValue(weapons);
int VillainHP = GetCharacterHP(villain);
int villainstrikestrength = VillainHP;
Console.WriteLine($"Today {villain} ({VillainHP} HP) with {VillainWeapon} tries to take over the world!");

Console.WriteLine($"Hero {hero} HP:{heroHP}");
Console.WriteLine($"Villain {villain} HP:{VillainHP}");

while(heroHP > 0 && VillainHP > 0)
{
    heroHP= heroHP - Hit(villain,villainstrikestrength);
    VillainHP = VillainHP - Hit(hero,herostrikestrength);
}

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (VillainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine($"Draw!");
}


static string GetRandomValue(string[] someArray)
{
    Random rnd = new Random();  
    int randomIndex = rnd.Next(0, someArray.Length);
    string RandomString = someArray[randomIndex];
    return RandomString;
}

static int  GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd= new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP -1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }
   return strike;
}