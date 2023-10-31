// See https://aka.ms/new-console-template for more information
using SubCipher;

string text = "Pride and Prejudice is a novel by Jane Austen that follows the lives of the Bennet sisters, who are in search of suitable husbands. The main plot revolves around the relationship between Elizabeth Bennet, a witty and independent young woman, and Mr. Darcy, a wealthy and proud gentleman who initially judges Elizabeth harshly. Through a series of misunderstandings, miscommunications, and social obstacles, they gradually overcome their pride and prejudice and fall in love. The novel also explores the themes of marriage, class, family, and reputation in the context of the early 19th century England.";

var k = new CipherKey("abcd");
Console.WriteLine(CipherKey.CreateGoodKey(text, k));