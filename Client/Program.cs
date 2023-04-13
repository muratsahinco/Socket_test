using System.Net.Sockets;
using System.Net;
using System.Text;

byte[] bytes = new byte[1024];

try
{
    // Uzak sunucuya bağlan
    // Bağlantı kurmak için kullanılan Host IP Adresini al
    // Bu durumda, localhost'un bir IP adresi olan IP'yi alıyoruz: 127.0.0.1
    // Bir ana bilgisayarın birden fazla adresi varsa, bir adres listesi alırsınız
    IPHostEntry host = Dns.GetHostEntry("localhost");
    IPAddress ipAdres = host.AddressList[0];
    IPEndPoint uzakEP = new IPEndPoint(ipAdres, 11000);

    // Bir TCP/IP soketi oluşturun.
    Socket sender = new Socket(ipAdres.AddressFamily,
        SocketType.Stream, ProtocolType.Tcp);

    // Soketi uzak uç noktaya bağlayın. Herhangi bir hatayı yakalayın.
    try
    {
        // Uzak Uç Noktaya Bağlan
        sender.Connect(uzakEP);

        for (int i = 0; i < 500; i++)
        {
            Console.WriteLine("Soket Bağlandı {0}", sender.RemoteEndPoint.ToString());

            // Veri dizesini bir bayt dizi olarak kodlayın.
            byte[] mesaj = Encoding.ASCII.GetBytes("Bu mesaj <EOF>");

            // Verileri soket üzerinden gönderin.
            int bytesSent = sender.Send(mesaj);

            // Uzak cihazdan yanıtı alın.
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Test = {0}-{1}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec), i);
        }

        // Soket bağlantısını bırak
        sender.Shutdown(SocketShutdown.Both);
        sender.Close();

    }
    catch (ArgumentNullException ane)
    {
        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
    }
    catch (SocketException se)
    {
        Console.WriteLine("SocketException : {0}", se.ToString());
    }
    catch (Exception e)
    {
        Console.WriteLine("Unexpected exception : {0}", e.ToString());
    }

}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

Console.ReadLine();