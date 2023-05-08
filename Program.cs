// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


string docPath =Directory.GetCurrentDirectory();
var fileRead = System.IO.File.ReadAllText(Path.Combine(docPath,"produce.txt"));

var splitFile = fileRead.Split("\n");

List<string> listProduce = new List<string>();

for( var i=0; i < splitFile.Count(); i++ ) {
    // splitFile[i]
    string produce = "";
    string brand = "";
    bool isSecond = false;
    foreach(var character in splitFile[i]) {
        // Console.WriteLine(character);
        if(isSecond && character == '(')
        {
            brand += " ";
        }
        if(isSecond && character != '(' && character != ')'){ 
            brand += character;
        }
        if( character == ' ' || character == '(') {
            isSecond = true;
        } 
        if( isSecond == false ) {
            produce += character;

        }
    }
    Console.WriteLine(produce + "," + brand);
    if(produce == "Göbek") {
        Console.WriteLine(brand);
        if(brand == "")
        {
            
        } else
        {
            var split = brand.Split(" ");
            if(split.Length > 2)
            {
                split = brand.Split("  ");
            }
            Console.WriteLine(split.Length);
            if(split.Length > 1) {
                produce += " " + split[0];
                brand = split[1];
            } else {
                produce += " " + split[0];
                brand = "";
            }
            Console.WriteLine(brand);
        }
    }

    Console.WriteLine(produce + "," + brand);

    listProduce.Add(produce  + "," + brand.Trim());
    
}



Console.WriteLine(docPath);
// Write the string array to a new file named "WriteLines.txt".
using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Produce2.csv")))
{
    foreach (string line in listProduce)
        // Console.WriteLine(line);
        outputFile.WriteLine(line);
}




// Process process = new Process();
// ProcessStartInfo startInfo = new ProcessStartInfo();
// startInfo.FileName = @"C:\Python311\python.exe"; // the name of the script to run :TODO: unbundle full path
// startInfo.Arguments = @"nlpParser.py";
// startInfo.UseShellExecute = false; // don't use the shell to execute the command
// startInfo.RedirectStandardOutput = true; // redirect the output to a stream
// process.StartInfo = startInfo;
// process.Start();

// // read the output of the command
// string output = process.StandardOutput.ReadToEnd();

// // wait for the command to finish
// process.WaitForExit();

var sayac = 0;
var sayac2 = 0;
var isCheckChild=false;
var degisken = "Acur";
var degisken2 = "Ahududu";

var codeRead = System.IO.File.ReadAllText(Path.Combine(docPath,"Code.csv"));
var produces = System.IO.File.ReadAllText(Path.Combine(docPath,"translatedFile.txt")); // 
// var producesParsedByComma = System.IO.File.ReadAllText("produce.csv");
var produceRaw = System.IO.File.ReadAllText(Path.Combine(docPath,"produce.txt"));


var codeSplitFile = codeRead.Split("\n");
var producesSplitFile = produces.Split("\n");
var produceRawSplitFile = produceRaw.Split("\n");
var producesParsedSplitFile = produces.Split("\n");

var list = new List<ABC>();

for(var i=0 ; i< codeSplitFile.Count()-1 ; i++)
{
    // Console.WriteLine("--"+i+"\n");

    var model = new ABC()
    {
        Name =  produceRawSplitFile[i],
        Code = (codeSplitFile[i][codeSplitFile[i].Length-1] == '_') ? codeSplitFile[i].Substring(0,codeSplitFile[i].Length-1): codeSplitFile[i],
        ParentProductCode = producesParsedSplitFile[i].Split(',')[0].ToUpper(),
        Description = ""
    };
    list.Add(model);
    //foreach(var item in list)
    //{
    //    if(item.Name == )
    //}
    degisken2 = splitFile[i + 2];
    isCheckChild=false;


}
JsonSerializerSettings _settings = new()
{
    Formatting = Formatting.Indented,
    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
};

var serializer = JsonSerializer.Create(_settings);
var stringBuilder = new StringBuilder();
using (var writer = new JsonTextWriter(new StringWriter(stringBuilder)))
{
    serializer.Serialize(writer, list);
}


using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Produce.json")))
{
    outputFile.Write(stringBuilder.ToString());
}

public class ABC
{
public string Name { get; set; }
public string Code { get; set; }
public string ParentProductCode { get; set; }
public string Description { get; set; }
}