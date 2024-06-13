using cl1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzamen1.Helpers
{
	static class OptionalUser	{

		public static void OptionC(string path)
		{
			DictionaryAll dictionary = new DictionaryAll(path);
			while (true)
			{
				Console.WriteLine("Choose an option:");
				Console.WriteLine("2. Load existing dictionary.");
				Console.WriteLine("3. Add word and translation.");
				Console.WriteLine("4. Show dictionary.");
				Console.WriteLine("5. Find and delete word in dictionary.");
				Console.WriteLine("6. Replace the word or its translation in the dictionary.");
				Console.WriteLine("7. Replace the translation in the dictionary.");
				Console.WriteLine("8. Find the translation of a word.");
				Console.WriteLine("9. Save.");
				Console.WriteLine("10. Save and export to file.");
				Console.WriteLine("11. Save and exit.");

				string option = Console.ReadLine();
				switch (option)
				{
					case "2":
						dictionary.LoadFromFile(path);
						break;
					case "3":
						dictionary.AddWords();
						break;
					case "4":
						DictionaryAll.ShowDictionary(path);
						break;
					case "5":
						DictionaryAll.FindAndDelete(dictionary);
						break;
					case "6":
						dictionary.ReplaceWords();
						break;
					case "7":
						dictionary.ReplaceTranslation();
						break;
					case "8":
						DictionaryAll.FindTranslation(dictionary);
						break;
					case "9":
						dictionary.SaveToFile();
						break;
					case "10":
						dictionary.SaveAndExport();
						break;
					case "11":
						dictionary.SaveToFile();
						return;
					default:
						Console.WriteLine("Invalid option. Please try again.");
						break;
				}
			}
		}
	}
}


