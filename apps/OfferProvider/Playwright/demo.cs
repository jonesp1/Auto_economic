using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

class Demo
{
    public static async Task Foo()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Height = 600,
                Width = 800,
            },
        });

        var page = await context.NewPageAsync();

        await page.GotoAsync("https://www.nordea.dk/privat/produkter/boliglaan/hvad-koster-det-at-laane-til-koeb-af-bolig.html");

        await page.GetByRole(AriaRole.Button, new() { Name = "Accepter alle" }).ClickAsync();
        await Task.Delay(3000);

        

        
        await page.TypeAsync("#propertyPriceInput", "2.000.000");
        await page.TypeAsync("#downPaymentInput", "100.000");

        await page.GetByRole(AriaRole.Button, new() { Name = "Beregn lån" }).ClickAsync();
        await page.GetByRole(AriaRole.Cell, new() { Name = "Pr. måned før skat" }).First.ClickAsync();
        var values = await page.Locator("td", new() {Has= page.Locator("text=\"Pr. måned før skat\"")}).Locator("+ td").First.AllInnerTextsAsync();
        foreach(var value in values) {
            Console.WriteLine("VALUE: " + value);
        }

        Console.WriteLine("COUNT: " + values.Count);


        
    }
}
