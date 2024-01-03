using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasade;

public class AudioPlayer
{
    public void Play(string audio)
    {
        Console.WriteLine($"Началось воспроизведение звука: {audio}");
    }

    public void Stop()
    {
        Console.WriteLine("Останавливается воспроизведение звука...");
    }
}
