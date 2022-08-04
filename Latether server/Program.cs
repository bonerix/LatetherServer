using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

class Server
{
	static byte[] data;
	static Socket socket;

	static void Main(string[] args)
	{
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 42069));

		while (true)
		{
			//Recieving from users
			socket.Listen(1);
			Socket accepteddata = socket.Accept();
			data = new byte[accepteddata.SendBufferSize];
			accepteddata.Receive(data);
			string dat = Encoding.Default.GetString(data);

			//Sending to users
			IPAddress[] ips =
			{
				IPAddress.Parse("192.168.1.100"),
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
                    Console.WriteLine("Error: Client on ip {0} unavailable.", ip);
				}
			}
		}
	}
}
