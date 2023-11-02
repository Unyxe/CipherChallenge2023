using FrequencyAnalysis;

string path = @"C:\Erik\School\CipherChallenge2023\src\Erik\FrequencyAnalysis\ExampleText.txt";
List<string> texts = new List<string>{ };

if (File.Exists(path))
    texts.Add(Common.FormatString(File.ReadAllText(path)));


var two = DataTables.Instance.OneGramAnalysis;

foreach (string text in texts)
{
    var result1 = FrequencyAnalyser.AnalyseText(Common.FormatString(text), new FrequencyAnalysisParamters { NGramLength = 1 });
    Console.WriteLine(two.Compare(result1));
}
var result2 = FrequencyAnalyser.AnalyseText(texts[0], new FrequencyAnalysisParamters { NGramLength = 1 });
Console.WriteLine(result2);
Console.WriteLine(two.Compare(result2));

