using HtmlAgilityPack;
using System.Text;

namespace Bot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var client = new HttpClient();
            var result = client.GetAsync("https://www.imperialled.com.br/index/categoria/abajures/cristal/").Result;

            Utf8EncodingProvider.Register();
            var html = result.Content.ReadAsStringAsync().Result;

            var totalDePagina = 1;

            var paginas = Enumerable.Range(1, totalDePagina);

            foreach ( var pagina in paginas ) 
            {
                result = client.GetAsync("https://www.imperialled.com.br/index/categoria/abajures/cristal/").Result;
                html = result.Content.ReadAsStringAsync().Result;

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                var produtos = doc.DocumentNode.SelectNodes("//div[contains(@class, 'item-box box-produto')]");

                foreach (var produto in produtos)
                {
                    var elementoA = produto.Descendants("a").First();
                    var link = elementoA.Attributes["href"].Value;

                }
            }

            
        }
    }

    public class Utf8EncodingProvider : EncodingProvider
    {
        public override Encoding GetEncoding(string name)
        {
            return name == "utf8" ? Encoding.UTF8 : null;
        }

        public override Encoding GetEncoding(int codepage)
        {
            return null;
        }

        public static void Register()
        {
            Encoding.RegisterProvider(new Utf8EncodingProvider());
        }
    }
}