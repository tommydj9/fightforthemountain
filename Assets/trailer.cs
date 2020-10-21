using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class trailer : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer VideoPlayer;
    public AudioSource audioSource;
    void Start()
    {
        StartCoroutine(PlayVideo());
    }
    IEnumerator PlayVideo()
    {

        VideoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!VideoPlayer.isPrepared)
        {

            yield return waitForSeconds;
            break;

        }
        rawImage.texture = VideoPlayer.texture;
        VideoPlayer.Play();
        audioSource.Play();

    }

}
