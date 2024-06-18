using System.Diagnostics;

namespace CowsayClass;
public class Cowsay
{
    public event EventHandler<CowsayEventArgs>? CowsayEvent;

    private static Process InitCowsay() => new()
    {
        StartInfo = new ProcessStartInfo()
        {
            FileName = "cowsay",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        }
    };

    public void Say(string message)
    {
        Process cowsay = InitCowsay();
        cowsay.Start();

        cowsay.StandardInput.WriteLine(message);
        cowsay.StandardInput.Close();

        string output = cowsay.StandardOutput.ReadToEnd();
        
        cowsay.WaitForExit();

        CowsayEvent?.Invoke(this, new CowsayEventArgs(output));
    }
}