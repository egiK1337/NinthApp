using System.Net;

namespace NinthApp
{
    public class ImageDownloader
    {
        public delegate void ImageProcess(string message);
        public event ImageProcess? ImageStarted;
        public event ImageProcess? ImageCompleted;

        public async Task Download(string remoteUri, string photoName)
        {
            var myWebClient = new WebClient();
            ImageStarted?.Invoke("Скачивание файла началось");
            await myWebClient.DownloadFileTaskAsync(remoteUri, photoName);
            ImageCompleted?.Invoke("Скачивание файла закончилось");   
        }
    }
}
