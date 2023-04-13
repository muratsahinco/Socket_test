// Bağlantı kurmak için kullanılan Host IP Adresini al
// Bu durumda, localhost'un bir IP adresi olan IP'yi alıyoruz: 127.0.0.1
// Bir ana bilgisayarın birden fazla adresi varsa, bir adres listesi alırsınız
using System.Net.Sockets;
using System.Net;
using System.Text;

IPHostEntry host = Dns.GetHostEntry("localhost");
IPAddress ipAdres = host.AddressList[0];
IPEndPoint localBitisNoktasi = new IPEndPoint(ipAdres, 11000);

try
{
    // Tcp protokolünü kullanacak bir Socket oluşturun
    Socket listener = new Socket(ipAdres.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    // Bir Soket, Bind yöntemi kullanılarak bir uç nokta ile ilişkilendirilmelidir
    listener.Bind(localBitisNoktasi);
    // Bir Socket'in Sunucu meşgul yanıtı vermeden önce kaç istek dinleyebileceğini belirtin.
    // Bir seferde 10 istek dinleyeceğiz
    listener.Listen(10);

    Console.WriteLine("Bağlantı bekleniyor...");
    Socket isleyici = listener.Accept();


    while (true)
    {
        // İstemciden gelen veriler.
        string data = null;
        byte[] bytes = null;

        while (true)
        {
            bytes = new byte[1024];
            int bytesRec = isleyici.Receive(bytes);
            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
            if (data.IndexOf("<EOF>") > -1)
            {
                break;
            }
        }

        Console.WriteLine("Metin Alındı : {0}", data);

        byte[] msg = Encoding.ASCII.GetBytes(data + " - donen cvb");
        isleyici.Send(msg);
    }


    isleyici.Shutdown(SocketShutdown.Both);
    isleyici.Close();
}
catch (Exception e)
{

    Console.WriteLine(e.ToString());
}

Console.WriteLine("\n Devam etmek için herhangi bir tuşa basın...");
Console.ReadKey();