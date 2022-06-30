using HtmlAgilityPack;

var client = new HttpClient();
string response = await client.GetStringAsync("https://g1.globo.com/ultimas-noticias/");

var htmlDoc = new HtmlAgilityPack.HtmlDocument();
htmlDoc.LoadHtml(response);

string news = string.Empty;
string link = string.Empty;

foreach (HtmlNode node in htmlDoc.DocumentNode.SelectNodes("//div[@class='_evt']/a"))
{
    if (node.Attributes.Count > 0)
    {
        news = node.InnerText.Trim();
        link = node.Attributes["href"].Value;

        if (!string.IsNullOrEmpty(news))
            Console.WriteLine(news + " - " + link);
    }
}