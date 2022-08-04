using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

class Server
{
	const int PORT = 42069;

	static byte[] data;
	static Socket socket;

	static void Main(string[] args)
	{
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.102"), PORT));

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
			IPAddress[] IPs =
			{
				IPAddress.Parse("192.168.1.102"),
				IPAddress.Parse("192.168.1.182"),
				IPAddress.Parse("192.168.1.147")
			};

			/* this part is full of problems */
			foreach (IPAddress IP in IPs)
			{
				try
				{
					Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					s.Connect(IP, PORT);
					s.Send(data);
					s.Disconnect(false);
				}
				catch
				{
                    Console.WriteLine("Error: Client on ip {0} unavailable.", IP);
				}
			}
		}
	}
}
