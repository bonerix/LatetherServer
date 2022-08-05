using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

class Server
{
	const int PORT = 42069;
    const string serverIP = "192.168.1.61";
	static byte[] data;
	static Socket socket;

	static void Main(string[] args)
	{
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Bind(new IPEndPoint(IPAddress.Parse(serverIP), PORT));

		while (true)
		{
			//Recieving from users
			socket.Listen(1);
			Socket accepteddata = socket.Accept();
			data = new byte[accepteddata.SendBufferSize];
			accepteddata.Receive(data);
			string dat = Encoding.Default.GetString(data);
			Console.WriteLine(dat);

            //Sending to users
            /*IPAddress[] ips = 
            { 
                IPAddress.Parse("192.168.1.98"), 
                IPAddress.Parse("192.168.1.182"), 
                IPAddress.Parse("192.168.1.147") 
            };

            foreach (IPAddress ip in ips)
            {
                try
                {
                    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    s.Connect(ip, 42069);
                    s.Send(data);
                    s.Disconnect(false);
                }
                catch
                {
                    
                }
            }*/
        }
    }
}
