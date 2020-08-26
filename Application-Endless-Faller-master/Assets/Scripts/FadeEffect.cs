using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public Image img;
    public float time = 0.7f;
    public bool isFading;

    public void Fade(bool fadeIn)
    {
        StartCoroutine(FadeImage(fadeIn));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        isFading = true;
        img.gameObject.SetActive(true);

        if (fadeAway)
        {

            img.color = new Color(0, 0, 0, 255);

            for (float i = time; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }

        else
        {

            img.color = new Color(0, 0, 0, 0);

            for (float i = 0; i <= time; i += Time.deltaTime)
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }

        isFading = false;
        img.gameObject.SetActive(false);
    }
}
