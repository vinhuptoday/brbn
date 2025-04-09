using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ionic.Zip;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

public class ScriptExecutor
{{
    public static async Task Run()
    {{
        var exportPath = @"C:\Intel\br";

var chromePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
    "Google", "Chrome", "Application", "chrome.exe");

var url = $"https://example.com/test.txt?check={Guid.NewGuid()}";

using var client = new HttpClient();
try
{
    var content = await client.GetStringAsync(url);
    if (content.Contains("off"))
    {
        Environment.Exit(0);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

    }}
}}
