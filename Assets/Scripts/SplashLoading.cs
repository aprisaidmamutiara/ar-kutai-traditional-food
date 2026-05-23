using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashLoading : MonoBehaviour
{
    public Slider loadingBar;
    public Image fadeImage;

    public string sceneTujuan = "HomeScreen";

    void Start()
    {
        StartCoroutine(LoadingFlow());
    }

    IEnumerator LoadingFlow()
    {
        // Fade masuk
        yield return StartCoroutine(Fade(1, 0, .5f));

        AsyncOperation operasi = SceneManager.LoadSceneAsync(sceneTujuan);
        operasi.allowSceneActivation = false;

        float progress = 0f;

        while (progress < 1f)
        {
            float target = Mathf.Clamp01(operasi.progress / 0.9f);

            // Dibikin lebih lambat
            progress = Mathf.MoveTowards(
                progress,
                target,
                Time.deltaTime * 0.25f
            );

            // Loading bar
            if (loadingBar != null)
                loadingBar.value = progress;

            // Kalau hampir selesai
            if (progress >= 0.95f)
            {
                progress = 1f;

                if (loadingBar != null)
                    loadingBar.value = 1f;

                break;
            }

            yield return null;
        }

        // Tunggu sebentar
        yield return new WaitForSeconds(1f);

        // Fade keluar
        yield return StartCoroutine(Fade(0, 1, 0.5f));

        // Pindah scene
        operasi.allowSceneActivation = true;
    }

    IEnumerator Fade(float dari, float ke, float durasi)
    {
        float t = 0;
        Color warna = fadeImage.color;

        while (t < durasi)
        {
            t += Time.deltaTime;

            float alpha = Mathf.Lerp(
                dari,
                ke,
                t / durasi
            );

            fadeImage.color = new Color(
                warna.r,
                warna.g,
                warna.b,
                alpha
            );

            yield return null;
        }

        fadeImage.color = new Color(
            warna.r,
            warna.g,
            warna.b,
            ke
        );
    }
}