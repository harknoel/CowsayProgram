using CowsayProgram;

Console.Clear();
Console.Write("Tell me what you want to say: ");
string? input = Console.ReadLine();

if (!string.IsNullOrEmpty(input))
{
    Cowsay cowsay = new();
    cowsay.CowsayEvent += OnReply;
    cowsay.Say(input);
}

static void OnReply(object? sender, CowsayEventArgs e)
{
    Console.WriteLine(e.Output);
}