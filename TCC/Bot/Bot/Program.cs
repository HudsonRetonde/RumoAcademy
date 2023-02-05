using HtmlAgilityPack;
using System.Text;

namespace Bot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var urlBase = "https://www.madeinbrazil.com.br/";
            var client = new HttpClient();
            var result = client.GetAsync("https://www.madeinbrazil.com.br/cordas-e-acessorios/contrabaixo?pagina=1").Result;

            Utf8EncodingProvider.Register();
            var html = result.Content.ReadAsStringAsync().Result;

            var totalDePagina = 60;

            var paginas = Enumerable.Range(1, totalDePagina);

            foreach ( var pagina in paginas ) 
            {
                result = client.GetAsync("https://www.madeinbrazil.com.br/cordas-e-acessorios/contrabaixo?pagina=1").Result;
                html = result.Content.ReadAsStringAsync().Result;

                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var produtos = doc.DocumentNode.SelectNodes("//div[contains(@class, 'spotContent')]");

                foreach (var produto in produtos)
                {
                    var elementoPreco = produto.SelectNodes(".//span[contains(@class, 'fbits-spot-boleto-valor')]").FirstOrDefault();
                    if (elementoPreco is null)
                       continue;

                    var preco = elementoPreco.InnerText.Replace("R$ ", "").Replace(",", ".");
                    Console.WriteLine(preco);
                    

                    var elementoA = produto.Descendants("a").First();
                    var linkProduto = elementoA.Attributes["href"].Value;
                    var linkCompleto = urlBase + linkProduto;
                    Console.WriteLine(linkCompleto);

                    var elementoDescricao = produto.Descendants("h3").FirstOrDefault();
                    var descricao = elementoDescricao.InnerText.Replace("\n","").Replace("\r","");
					Console.WriteLine(descricao);
                    Console.WriteLine();


				}

            }
            Console.ReadKey();
            
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