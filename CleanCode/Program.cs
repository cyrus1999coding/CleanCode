using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }

        public void ReadFile(string filePath)
        {

            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine(content);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Access denied: " + ex.message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex.Message);
            }

            // File Not Found
            // Unauthorized Access
            // Any Other Exeption
        }
    }
}
