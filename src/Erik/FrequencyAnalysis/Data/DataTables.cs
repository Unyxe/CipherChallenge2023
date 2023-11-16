using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrequencyAnalysis.Analysis;

namespace FrequencyAnalysis.Data
{
    public class DataTables
    {
        public Dictionary<string, char> MorseToChar;
        public Dictionary<char, string> CharToMorse = new Dictionary<char, string>
        {
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."},
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            {'.',".-.-.-." }
        };
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static DataTables _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static DataTables Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataTables();
                return _instance;
            }
        }
        public List<string> FiveLetters;
        public EnglishFrequencyAnalysisResult MonogramAnalysis { get; }
        public EnglishFrequencyAnalysisResult BigramAnalysis { get; }
        public EnglishFrequencyAnalysisResult TrigramAnalysis { get; }
        public EnglishFrequencyAnalysisResult QuadgramAnalysis { get; }

        private Dictionary<string, double> _monogramFrequencies = new Dictionary<string, double>
        {
            { "A", 0.0834 },
            { "B", 0.0154 },
            { "C", 0.0273 },
            { "D", 0.0414 },
            { "E", 0.1260 },
            { "F", 0.0203 },
            { "G", 0.0192 },
            { "H", 0.0611 },
            { "I", 0.0671 },
            { "J", 0.0023 },
            { "K", 0.0087 },
            { "L", 0.0424 },
            { "M", 0.0253 },
            { "N", 0.0680 },
            { "O", 0.0770 },
            { "P", 0.0197 },
            { "Q", 0.0010 },
            { "R", 0.0633 },
            { "S", 0.0673 },
            { "T", 0.0894 },
            { "U", 0.0268 },
            { "V", 0.0106 },
            { "W", 0.0183 },
            { "X", 0.0019 },
            { "Y", 0.0172 },
            { "Z", 0.0011 }
        };
        public DataTables()
        {
            MonogramAnalysis = new EnglishFrequencyAnalysisResult(new FrequencyAnalysisParamters { NGramLength = 1 }, _monogramFrequencies);

            BigramAnalysis = new EnglishFrequencyAnalysisResult(new FrequencyAnalysisParamters { NGramLength = 2 }, loadDict(".\\Data\\Bigram.csv"));
            TrigramAnalysis = new EnglishFrequencyAnalysisResult(new FrequencyAnalysisParamters { NGramLength = 3 }, loadDict(".\\Data\\Trigram.csv"));
            QuadgramAnalysis = new EnglishFrequencyAnalysisResult(new FrequencyAnalysisParamters { NGramLength = 4 }, loadDict(".\\Data\\Quadgram.csv"));

            FiveLetters = _loadLines(".\\Data\\FiveLetters.csv");

            MorseToChar = new Dictionary<string, char>();
            foreach (var pair in CharToMorse)
                MorseToChar[pair.Value] = pair.Key;
        }
        private Dictionary<string, double> loadDict(string filename)
        {
            var newDict = new Dictionary<string, double>();
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();
                    if (line != null)
                    {
                        var data = line.Split(",");
                        if (data.Length == 2)
                            newDict[data[0]] = double.Parse(data[1]);
                    }
                }
            }
            return newDict;
        }
        private List<string> _loadLines(string path)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        lines.Add(line.Replace("\r", "").Replace("\n", "").ToUpper());
                    }
                }
            }
            return lines;
        }
    }
}
