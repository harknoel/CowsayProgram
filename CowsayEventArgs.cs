public class CowsayEventArgs : EventArgs
{
    public CowsayEventArgs(string output) {
        Output = output;
    }

    public string? Output { get; set; }
}