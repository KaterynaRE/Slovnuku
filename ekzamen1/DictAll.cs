using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace cl1
{
	public class DictionaryAll
	{

		public Dictionary<string, List<string>> dictionary;

		public string dictionaryPath;
		public DictionaryAll() { }
		public DictionaryAll(string dictionaryPath)
		{
			dictionary = new Dictionary<string, List<string>>();
			this.dictionaryPath = dictionaryPath;
			LoadFromFile(dictionaryPath);
		}

		public void LoadFromFile(string dictionaryPath)
		{
			if (File.Exists(dictionaryPath))
			{
				using (StreamReader st1 = new StreamReader(dictionaryPath))
				{
					string json = st1.ReadToEnd();
					dictionary = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
				}
			}
		}
		public void SaveToFile()
		{
			using (StreamWriter sw1 = new StreamWriter(dictionaryPath, false))
			{
				string jSonP = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
				sw1.WriteLine(jSonP);
			}
		}

		public void SaveAndExport()
		{

			if (File.Exists(dictionaryPath))
			{
				using (StreamReader st1 = new StreamReader(dictionaryPath))
				{
					string json = st1.ReadToEnd();
					dictionary = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
				}
			}
			Console.WriteLine("Enter path to new file: 'dict.txt'");
			string dictionaryPathNew = Console.ReadLine();
			using (StreamWriter sw1 = new StreamWriter(dictionaryPathNew, false))
			{
				string jSonP = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
				sw1.WriteLine(jSonP);
			}
		}

		public void AddWords()
		{
			Console.WriteLine("Enter word");
			string word = Console.ReadLine();
			Console.WriteLine("Enter translate for word split coma:");
			string translate = Console.ReadLine();

			string[] translationArray = translate.Split(',');
			if (!dictionary.ContainsKey(word))
			{
				dictionary[word] = new List<string>();
			}
			foreach (var item in translationArray)
			{
				dictionary[word].Add(item.Trim());
			}
			Console.WriteLine("Word and his translate, was sucesful add at Dictionary");
		}

		public Dictionary<string, List<string>> GetWords()
		{
			return dictionary;
		}

		public void DeleteWord(string word)
		{
			if (dictionary.ContainsKey(word))
			{
				dictionary.Remove(word);
				SaveToFile();
			}
			else
			{
				Console.WriteLine($"Word '{word}' not found in the dictionary.");
			}
		}


		public void DeleteTranslation(string word, string translation)
		{
			if (dictionary.ContainsKey(word))
			{
				if (dictionary[word].Contains(translation))
				{
					if (dictionary[word].Count == 1)
					{
						Console.WriteLine("Error");
						
					}
                    else
                    {
						dictionary[word].Remove(translation);
						dictionary.Remove(word);
						SaveToFile();
					}

                }
				else
				{
					Console.WriteLine($"Translation '{translation}' not found for word '{word}'.");
				}
			}
			else
			{
				Console.WriteLine($"Word '{word}' not found in the dictionary.");
			}
		}
		public static void FindAndDelete(DictionaryAll dictionary)
		{
			var words = dictionary.GetWords();

			Console.WriteLine("\nEnter word to find and delete: ");
			string wordFind = Console.ReadLine().ToLower();

			if (words.ContainsKey(wordFind))
			{

				Console.WriteLine($"Word '{wordFind}' found with translations: {string.Join(", ", words[wordFind])}");
				Console.WriteLine("Do you want to delete the word or a translation? (W/T)");
				string choice = Console.ReadLine().ToUpper();

				if (choice == "W")
				{
					dictionary.DeleteWord(wordFind);
					Console.WriteLine($"Word '{wordFind}' deleted.");
				}
				else if (choice == "T")
				{
					if (words[wordFind].Count > 1)
					{
						Console.WriteLine("Enter translation to delete:");
						string translation = Console.ReadLine().ToLower();
						dictionary.DeleteTranslation(wordFind, translation);
					}
					else
					{
						Console.WriteLine("Error, word has one translations");
					}
				}               
            }
			else
			{
				Console.WriteLine($"Word '{wordFind}' not found.");
			}
		}
		public void ReplaceWords()
		{
			LoadFromFile(dictionaryPath);

			Console.WriteLine("Enter word to find: ");
			string wordUserSearch = Console.ReadLine().ToLower();

			Console.WriteLine("Enter word for replacement: ");
			string wordUserReplace = Console.ReadLine().ToLower();

			if (dictionary.ContainsKey(wordUserSearch))
			{
				List<string> translations = dictionary[wordUserSearch];
				dictionary.Remove(wordUserSearch);
				dictionary[wordUserReplace] = translations;

				SaveToFile();
				Console.WriteLine($"Word '{wordUserSearch}' has been replaced with '{wordUserReplace}'.");
			}
			else
			{
				Console.WriteLine($"Word '{wordUserSearch}' not found in the dictionary.");
			}
		}

		public void ReplaceTranslation()
		{
			LoadFromFile(dictionaryPath);

			Console.WriteLine("Enter word to find: ");
			string wordUserSearch = Console.ReadLine().ToLower();

			Console.WriteLine("Enter translation to find: ");
			string translationUserSearch = Console.ReadLine().ToLower();

			Console.WriteLine("Enter word for replacement translation: ");
			string translationUserReplace = Console.ReadLine().ToLower();

			if (dictionary.ContainsKey(wordUserSearch))
			{
				if (dictionary[wordUserSearch].Contains(translationUserSearch))
				{
					dictionary[wordUserSearch].Remove(translationUserSearch);
					dictionary[wordUserSearch].Add(translationUserReplace);
				}
				SaveToFile();
			}
		}
		
		public static void ShowDictionary(string path)
		{
			if (File.Exists(path))
			{
				string line;
				using (StreamReader sr = new StreamReader(path))
				{
					line = sr.ReadToEnd();
				}
				var lineNew = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(line);
				foreach (var item in lineNew)
				{
					Console.WriteLine($"Word: {item.Key}");
					Console.WriteLine("Translations: " + string.Join(", ", item.Value));
					Console.WriteLine();
				}
			}
			else
			{
				Console.WriteLine($"Error! File Not exists");
			}
		}

		public static void FindTranslation(DictionaryAll dictionary)
		{
			var words = dictionary.GetWords();
			Console.WriteLine("\nEnter word to find his translation: ");
			string wordFind = Console.ReadLine().ToLower();
			if (words.ContainsKey(wordFind))
			{
				Console.WriteLine($"Word '{wordFind}' found with translations: {string.Join(", ", words[wordFind])}");
			}
		}

		

	}
}
