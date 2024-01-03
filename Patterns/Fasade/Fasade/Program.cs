/* Создайте свой пример по паттерну фасад. */
using Fasade;

class Program
{
    static void Main()
    {
        MultimediaFasade multimedia = new();

        multimedia.PlayAudio("behruz.mp3");
        multimedia.PlayVideo("46qeza.mp4");

        multimedia.StopAudio();
        multimedia.StopVideo();
    }
}