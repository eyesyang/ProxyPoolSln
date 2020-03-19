using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace ProxyPoolConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var d = DateTime.Now.Date;

            var address = "218.22.7.62";

            var port = 53281;

            //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);


            var client = new WebClient();

            client.Headers[HttpRequestHeader.ContentType] = "text/html; Charset=UTF-8";

            //client.Headers[HttpRequestHeader.Cookie] = "ASPSESSIONIDSCCSCASD=BEOCDMMDLOMCBMODHGHFFCIO; PHPSESSID=2s5i0mc3l89runagcr9vaur9sq";

            //client.Headers[HttpRequestHeader.Accept] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";

            //client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, br";

            //client.Headers[HttpRequestHeader.AcceptLanguage] = "zh-CN,zh;q=0.9";

            //client.Headers[HttpRequestHeader.CacheControl] = "max-age=0";

            ////client.Headers[HttpRequestHeader.Connection] = "keep-alive";            

            //client.Headers[HttpRequestHeader.Host] = "2020.ip138.com";

            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36";            

            client.Proxy = new WebProxy("139.159.47.22", 39593);

            var html = client.DownloadString("https://2020.ip138.com/");
        }

        static bool CheckValidationResult(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors errors)
    {   // 总是接受 认证平台 服务器的证书
         return true;
     }
    }
}
