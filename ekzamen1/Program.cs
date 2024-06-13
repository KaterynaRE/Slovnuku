using cl1;
using Newtonsoft.Json;
using System.IO;
using ekzamen1.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzamen1
{
	internal class Program
	{	
		static void Main(string[] args)
		{
			//			Завдання 1
			//Створити додаток «Словники».
			//Основне завдання проєкту:
			//зберігати словники різними мовами і дозволяти користувачеві знаходити переклад потрібного слова або фрази.
			//Інтерфейс додатку повинен надавати такі можливості:
			//+ ■ Створювати словник. Під час створення необхідно вказати тип словника.Наприклад, англо - український або укр-англійський.
			//+ ■ Додавати слово і його переклад до вже існуючого словника.
			//+ Оскільки слово може мати декілька перекладів, необхідно дотримуватися можливості створення декількох варіантів перекладу.
			//+ ■ Замінювати слово або його переклад у словнику.
			//+ ■ Видаляти слово або переклад. Якщо слово видаляється, усі його переклади видаляються разом з ним.
			//+ Не можна видалити переклад слова, якщо це останній варіант перекладу.
			//+ ■ Шукати переклад слова.
			//+ ■ Словники повинні зберігатися у файлах.
			//+ ■ Слово і варіанти його перекладів можна експортувати до окремого файлу результату.
			//+ ■ При старті програми потрібно показувати меню для роботи з програмою. Якщо
			//вибір пункту меню відкриває підменю, тоді в ньому потрібно передбачити можливість повернення до попереднього меню

			string pathToDictionary = string.Empty;
			string choiceCreate;

			do
			{
				Console.WriteLine("Do you want to create a dictionary? Y - Yes, N - No");
				choiceCreate = Console.ReadLine();

				if (choiceCreate.ToUpper() == "Y")
				{
					Console.WriteLine("\nSelect the language of the dictionary to translate from: 1 - Ukrainian, 2 - English, 3 - Polish");
					string choiceLanguageBefore = Console.ReadLine();

					switch (choiceLanguageBefore)
					{
						case "1":
							Console.WriteLine("\nSelect the language of the dictionary to translate into: 2 - English, 3 - Polish");
							string choiceLanguageAfter = Console.ReadLine();
							switch (choiceLanguageAfter)
							{
								case "2":
									pathToDictionary = "dictionaryUaUsa.txt";

									break;
								case "3":
									pathToDictionary = "dictionaryUaPolish.txt";
									break;
							}
							break;
						case "2":
							Console.WriteLine("\nSelect the language of the dictionary to translate into: 1 - Ukrainian, 3 - Polish");
							choiceLanguageAfter = Console.ReadLine();
							switch (choiceLanguageAfter)
							{
								case "1":
									pathToDictionary = "dictionaryUsaUa.txt";
									break;
								case "3":
									pathToDictionary = "dictionaryUsaPolish.txt";
									break;
							}
							break;
						case "3":
							Console.WriteLine("\nSelect the language of the dictionary to translate into: 1 - Ukrainian, 2 - English");
							choiceLanguageAfter = Console.ReadLine();
							switch (choiceLanguageAfter)
							{
								case "1":
									pathToDictionary = "dictionaryPolishUa.txt";
									break;
								case "2":
									pathToDictionary = "dictionaryPolishUsa.txt";
									break;
							}
							break;
					}

					// Create a new dictionary file if it doesn't exist
					if (!string.IsNullOrEmpty(pathToDictionary))
					{
						if (!System.IO.File.Exists(pathToDictionary))
						{
							var dictionary = new DictionaryAll(pathToDictionary);
							dictionary.SaveToFile();
						}
						OptionalUser.OptionC(pathToDictionary);
					}
				}
				else if (choiceCreate.ToUpper() == "N")
				{
					Console.WriteLine("Do you want to load an existing dictionary? Y - Yes, N - No");
					string choiceLoad = Console.ReadLine();
					if (choiceLoad.ToUpper() == "Y")
					{
						Console.WriteLine("Enter the path to the dictionary file:");
						pathToDictionary = Console.ReadLine();
						if (System.IO.File.Exists(pathToDictionary))
						{
							OptionalUser.OptionC(pathToDictionary);
						}
						else
						{
							Console.WriteLine("File not found. Exiting.");
						}
					}
					else
					{
						Console.WriteLine("Exit");
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
				}
			} while (choiceCreate.ToUpper() != "Y" && choiceCreate.ToUpper() != "N");


		}
	}
}
