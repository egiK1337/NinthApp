
namespace NinthApp
{
    internal class Program
    {
        static void Main()
        {
            var imageDownloader = new ImageDownloader();
            var url = "https://photojournal.jpl.nasa.gov/jpeg/PIA26019.jpg";

            void DisplayMessage(string message) => Console.WriteLine(message);

            imageDownloader.ImageStarted += DisplayMessage;
            imageDownloader.ImageCompleted += DisplayMessage;

            var dictionaryStatus = new Dictionary<int, bool>();
            var taskList = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var task = imageDownloader.Download(url, (i.ToString() + ".jpg"));
                taskList.Add(task);
            }

            while (true)
            {
                Console.WriteLine("Нажмите клавишу <A> для выхода или любую другую клавишу для проверки статуса скачивания");
                var text = Console.ReadKey().Key;
                Console.WriteLine();

                if (text == ConsoleKey.A)
                {
                    break;
                }
                if (text != ConsoleKey.A)
                {
                    var count = 0;
                    var status = "не скачен";
                    foreach (var item in taskList)
                    {
                        if(item.IsCompleted == true)
                        {
                            status = "скачен";
                        }
                        Console.WriteLine($"фото {count}.jpg в статусе {status}");
                        count++;
                    }
                }
            }
        }
    }
}