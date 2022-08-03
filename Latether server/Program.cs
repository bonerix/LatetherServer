using System.Text;
using System.Net;
using System.Net.Sockets;

class main
{
    static byte[] data;  
    static Socket socket;
    static void Main(string[] args)
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.61"), 6666)); 

        socket.Listen(1);
        Socket accepteddata = socket.Accept();
        data = new byte[accepteddata.SendBufferSize]; 
        int j = accepteddata.Receive(data);
        /*byte[] adata = new byte[j];        
        for (int i = 0; i < j; i++)        
            adata[i] = data[i];*/  
        string dat = Encoding.Default.GetString(data); 
        System.Diagnostics.Debug.WriteLine(dat);                         
    }
}
