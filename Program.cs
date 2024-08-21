
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

            return normalizedOldString;
        }
    }
}
