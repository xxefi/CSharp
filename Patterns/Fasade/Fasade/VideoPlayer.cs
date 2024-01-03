using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasade;

public class VideoPlayer
{
    public void Play(string videos)
    {
        Console.WriteLine($"Началось воспроизведение видео: {videos}");
    }

    public void Stop()
    {
        Console.WriteLine("Останавливается воспроизведение видео...");
    }
}
