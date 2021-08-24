using System.IO;
using System.Net.Sockets;

public class CustomSocket
{
    private readonly TcpClient client;
    private readonly StreamReader reader;
    private readonly StreamWriter writer;
    public CustomSocket(string url, int port = -1)
    {
        client = new TcpClient(url, port);
        reader = new StreamReader(client.GetStream());
        writer = new StreamWriter(client.GetStream());
    }
    public bool Available() { return (client.Available > 0); }
    public void WriteLine(string line)
    {
        writer.WriteLine(line);
    }
    public void FlushWriter()
    {
        writer.Flush();
    }
    public string ReadLine()
    {
        return reader.ReadLine();
    }
}
