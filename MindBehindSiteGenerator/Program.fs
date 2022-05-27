open System
open System.Text
open System.IO

open MindBehindSiteGenerator

let createIndex () =
    let sb = StringBuilder()

    sb.AppendLine("<!DOCTYPE html>") |> ignore
    sb.AppendLine("<html lang=\"en\">") |> ignore
    sb.AppendLine("<meta charset=\"UTF-8\">") |> ignore
    sb.AppendLine("<title>Mind Behind</title>") |> ignore
    sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">") |> ignore
    sb.AppendLine("<link rel=\"icon\" type=\"image/x-icon\" href=\"favicon.ico\">") |> ignore
    sb.AppendLine("<link rel=\"stylesheet\" href=\"app.css\">") |> ignore
    sb.AppendLine("<body>") |> ignore

    sb.AppendLine("<h1>Mind Behind</h1>") |> ignore

    sb.AppendLine("<ul>") |> ignore
    for entry in Data.Entries do
        sb.AppendLine("<li>") |> ignore
        sb.AppendLine($"<p>{entry.Id}</p>") |> ignore
        sb.AppendLine("<ol>") |> ignore
        for name in entry.Names do
            sb.AppendLine("<li>") |> ignore
            sb.AppendLine($"<a href=\"{entry.Id}_{name}.html\" target=\"_blank\">{name}</a>") |> ignore
            sb.AppendLine("</li>") |> ignore
        sb.AppendLine("</ol>") |> ignore
        sb.AppendLine("</li>") |> ignore
    sb.AppendLine("</ul>") |> ignore

    sb.AppendLine("</body>") |> ignore
    sb.AppendLine("</html>") |> ignore

    File.WriteAllText(@"C:\Users\ca190\Desktop\output\index.html", sb.ToString())

let createPages () =
    let sb = StringBuilder()

    for entry in Data.Entries do
        for name in entry.Names do
            sb.AppendLine("<!DOCTYPE html>") |> ignore
            sb.AppendLine("<html lang=\"en\">") |> ignore
            sb.AppendLine("<meta charset=\"UTF-8\">") |> ignore
            sb.AppendLine("<title>Mind Behind</title>") |> ignore
            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">") |> ignore
            sb.AppendLine("<link rel=\"icon\" type=\"image/x-icon\" href=\"favicon.ico\">") |> ignore
            sb.AppendLine("<link rel=\"stylesheet\" href=\"app.css\">") |> ignore
            sb.AppendLine("<body>") |> ignore

            sb.AppendLine($"<h1>{entry.Id} {name}</h1>") |> ignore

            sb.AppendLine("<video width=\"720\" height=\"480\" controls>") |> ignore
            sb.AppendLine($"<source src=\"https://github.com/MindBehind2021/{entry.Id}/blob/main/{entry.Id}_{name}.mp4?raw=true\" type=\"video/mp4\">") |> ignore
            sb.AppendLine("</video>") |> ignore

            sb.AppendLine("</body>") |> ignore
            sb.AppendLine("</html>") |> ignore

            File.WriteAllText($"C:\Users\ca190\Desktop\output\{entry.Id}_{name}.html", sb.ToString())
            sb.Clear() |> ignore

[<EntryPoint>]
let main argv =
    createIndex ()
    createPages ()
    0
