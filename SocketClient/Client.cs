using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace SocketClient
{
    class Client{
       private int port = 4000;

        public Client() {
            Console.Write("File Nam: ");            
            string fileName = Console.ReadLine();   // ./a1.txt   ./b1.txt
            Connect("127.0.0.1", fileName);
        }

        void Connect(String server, string fileName) {
            try {
                StreamReader file = new StreamReader(fileName);
                string message;
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();
                stream.ReadTimeout = 5000;

                while ((message = file.ReadLine()) != null) {
                    // var message = Console.ReadLine();
                    if (message.Length == 0)
                        continue;

                    // Translate the Message into ASCII.
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);   
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent: {0}", message);         
                    // Bytes Array to receive Server Response.
                    data = new Byte[256];
                    String response = String.Empty;
                    // Read the Tcp Server Response Bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", response);      
                    Thread.Sleep(2000);   
                }
                client.Close();
                stream.Close();
            }
            catch (IOException) {
                Console.WriteLine("Connection closed by the server.");
            }
            catch (Exception e) {
                Console.WriteLine("Exception: {0}", e);
            }
            finally {                
            }
        }

    }
}
