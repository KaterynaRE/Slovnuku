using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekzamen1.Helpers
{
	static class LanguageHelper
	{
		public static void ChoiceLanguege(string choiceLanguageBefore, string choiceLanguageAfter)
		{
			const string LangUkrainian = "Ukrainian";
			const string LangEnglish = "English";
			const string LangPolish = "Polish";

			string selectedLangBefore = "";
			string selectedLangAfter = "";

			switch (choiceLanguageBefore)
			{
				case "1":
					selectedLangBefore = LangUkrainian;
					break;
				case "2":
					selectedLangBefore = LangEnglish;
					break;
				case "3":
					selectedLangBefore = LangPolish;
					break;
				default:
					Console.WriteLine("Invalid input for choiceLanguageBefore.");
					return;
			}

			switch (choiceLanguageAfter)
			{
				case "1":
					selectedLangAfter = LangUkrainian;
					break;
				case "2":
					selectedLangAfter = LangEnglish;
					break;
				case "3":
					selectedLangAfter = LangPolish;
					break;
				default:
					Console.WriteLine("Invalid input for choiceLanguageAfter.");
					return;
			}

			Console.WriteLine($"\nYou have selected the {selectedLangBefore}-{selectedLangAfter} dictionary.");
		}

	}
}
