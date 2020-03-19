using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace ProxyPoolConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            KuaiDaiLi();
        }

        static void KuaiDaiLi()
        {
            var url = "https://www.kuaidaili.com/free/intr/1/";

            var client = new WebClient();

            client.Proxy = null;

            client.Headers[HttpRequestHeader.ContentType] = "text/html; Charset=UTF-8";

            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36";

            var html = client.DownloadString(url);

            var regex = new Regex("<td\\sdata-title=\"IP\">(?<ip>.+?)</td>\\s+?<td\\sdata-title=\"PORT\">(?<port>.+?)</td>");

            var matches = regex.Matches(html);

            foreach (Match m in matches)
            {
                var ip = m.Groups["ip"].Value;
                var port = m.Groups["port"].Value;

                CheckIp(ip, port);
            }
        }




        static bool CheckIp(string ip, string port)
        {
            var client = new WebClient();

            client.Headers[HttpRequestHeader.ContentType] = "text/html; Charset=UTF-8";

            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.132 Safari/537.36";

            client.Proxy = new WebProxy(ip, int.Parse(port));

            try
            {
                var html = client.DownloadString("https://2020.ip138.com/");

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
