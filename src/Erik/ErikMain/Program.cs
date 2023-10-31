using FrequencyAnalysis;

string path = @"C:\Erik\CMS\CipherChallenge2023\src\Erik\FrequencyAnalysis\ExampleText.txt";
string text = @"Here is an essay on the benefits of renewable energy sources:

Renewable energy sources are those that can be replenished naturally and do not contribute to greenhouse gas emissions or environmental pollution. Some examples of renewable energy sources are solar, wind, hydro, biomass, geothermal and tidal energy. These sources have many advantages over fossil fuels, such as coal, oil and natural gas, which are finite, polluting and contribute to global warming.

One of the main benefits of renewable energy sources is that they can reduce the dependence on fossil fuels and enhance energy security. Fossil fuels are subject to geopolitical conflicts, price fluctuations and supply disruptions, which can affect the stability and affordability of energy. Renewable energy sources, on the other hand, are abundant, diverse and distributed across the globe, which can reduce the risk of energy crises and increase the resilience of energy systems.

Another benefit of renewable energy sources is that they can create economic opportunities and social benefits. Renewable energy sources can generate employment, income and innovation in various sectors, such as manufacturing, installation, operation and maintenance. Renewable energy sources can also improve access to electricity and clean cooking for millions of people who lack these services, especially in rural and remote areas. Renewable energy sources can also enhance public health and environmental quality by reducing air pollution and greenhouse gas emissions, which can cause respiratory diseases, premature deaths and climate change impacts.

In conclusion, renewable energy sources are a viable alternative to fossil fuels that can provide multiple benefits for society and the environment. Renewable energy sources can increase energy security, create economic opportunities and social benefits, and reduce greenhouse gas emissions and environmental pollution. Therefore, it is important to promote the development and deployment of renewable energy sources through supportive policies, incentives and investments.";

if (File.Exists(path))
    text = File.ReadAllText(path);

text = Common.FormatString(text);

// See https://aka.ms/new-console-template for more information
//Console.WriteLine(text);
//Console.WriteLine();
Console.WriteLine(FrequencyAnalyser.AnalyseText(text, new FrequencyAnalysisParamters { NGramLength=2}));
