
using System.Globalization;
using System.Text;

namespace Normalizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input original text:");

            string oldString = Console.ReadLine();

            string newString = StringNormalizer(oldString);

            Console.WriteLine(newString);
        }

        private static string StringNormalizer(string? oldString)
        {
            // Deconstructs special caracter diacritics (accents). E.g. ã > a~
            string normalizedOldString = oldString.Normalize(NormalizationForm.FormD);

            // Removes diacritics (accents)
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalizedOldString)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                // Appends only the base caracters to the sb string builder.
                // Removes the non-spacing marks. E.g. ´, `, ~, ^.
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Converts the string builder back to string and returns it
            // in a unicode form.
            string newString = sb.ToString().Normalize(NormalizationForm.FormD);

            string[] words = newString.Split(' ');

            return string.Join("",words);
        }
    }
}
