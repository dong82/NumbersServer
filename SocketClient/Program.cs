using System.Threading;

namespace SocketClient
{

    class Program {
        static void Main(string[] args) {

            new Thread(() => new Client("./Data/a2-2M-A.txt", 0)).Start();
            new Thread(() => new Client("./Data/a2-2M-B.txt", 0)).Start();
            new Thread(() => new Client("./Data/a2-2M-A.txt", 0)).Start();
            new Thread(() => new Client("./Data/a2-2M-B.txt", 0)).Start();
            new Thread(() => new Client("./Data/a2-2M-A.txt", 0)).Start();
            new Thread(() => new Client("./Data/a2-2M-B.txt", 0)).Start();

       }
    }
}
