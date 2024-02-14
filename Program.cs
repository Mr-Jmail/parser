namespace Parser;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

class Program {
    private static readonly HttpClient client = new HttpClient();
    public async Task<string> SendRequest(string url) 
    {
        Dictionary<string, string> keyValues = new() 
        {
            {"fak", "ФГиИБ"},
            {"kurs", "1"},
            {"grup", "2023-ФГиИБ-ИСиТ-2б"}
        };
        HttpContent content = new FormUrlEncodedContent(keyValues);
        var response = await client.PostAsync(url, content);
        return await response.Content.ReadAsStringAsync();
    }

    static async Task Main(string[] args)
    {
        Program program = new();
        string htmlString = await program.SendRequest("http://studydep.miigaik.ru/semestr/index.php");
        HtmlParser parser = new HtmlParser();
        var document = await parser.ParseDocumentAsync(htmlString);
        IHtmlCollection<IElement> rows = document.QuerySelectorAll("body > table > tbody > tr > td:nth-child(2) > table > tbody > tr:nth-child(4) > td > table > tbody > tr > td:nth-child(2) > table > tbody > tr > td > table.t > tbody > tr");
        
        Week upperWeek = new();
        Week lowerWeek = new();

        foreach (var row in rows)
        {
            IHtmlCollection<IElement> columns = row.QuerySelectorAll("td");
            if(columns.Length < 9) continue;
            var (dayOfWeek, numberOfLesson, week, subGroup, subjectName, teachersName, audience, typeOfLesson, comment) = (columns[0], columns[1], columns[2], columns[3], columns[4], columns[5], columns[6], columns[7], columns[8]);
            Week currentWeek = week.TextContent == "верхняя" ? upperWeek : lowerWeek;
            Lesson lesson = new (numberOfLesson.TextContent, subGroup.InnerHtml, subjectName.TextContent, teachersName.TextContent, audience.TextContent, typeOfLesson.TextContent, comment.InnerHtml);
            Day currentDay = currentWeek.GetDay(dayOfWeek.TextContent);
            currentDay.AddLesson(lesson);
        }

        Console.Write(upperWeek);
    }
}