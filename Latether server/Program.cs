using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

class main
{
    static byte[] data;  
    static Socket socket;
     
    static void Main(string[] args)
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 42069));

        while (true)
        {
            socket.Listen(1);
            Socket accepteddata = socket.Accept();
            data = new byte[accepteddata.SendBufferSize];
            int j = accepteddata.Receive(data);
            string dat = Encoding.Default.GetString(data);
            Console.WriteLine(dat);
        }
    }
}
