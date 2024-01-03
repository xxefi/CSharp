using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasade;

public class MultimediaFasade
{
    private AudioPlayer audioPlay;
    private VideoPlayer videoPlay;

    public MultimediaFasade()
    {
        audioPlay = new AudioPlayer();
        videoPlay = new VideoPlayer();
    }

    public void PlayAudio(string audio)
    {
        audioPlay.Play(audio);
    }

    public void StopAudio()
    {
        audioPlay.Stop();
    }

    public void PlayVideo(string video)
    {
        videoPlay.Play(video);
    }

    public void StopVideo()
    {
        videoPlay.Stop();
    }
}
