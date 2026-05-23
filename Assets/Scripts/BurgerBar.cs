using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBar : MonoBehaviour
{
    public RectTransform menuSamping;
    public GameObject areaTutup;

    Vector2 posisiMuncul;
    Vector2 posisiSembunyi;

    void Start()
    {
        posisiMuncul = new Vector2(400, 0);
        posisiSembunyi = new Vector2(-400, 0); // menu di luar kiri

        menuSamping.anchoredPosition = posisiSembunyi;

        areaTutup.SetActive(false);
    }

    public void BukaMenu()
    {
        StopAllCoroutines();
        StartCoroutine(Slide(posisiMuncul));

        areaTutup.SetActive(true);
    }

    public void TutupMenu()
    {
        StopAllCoroutines();
        StartCoroutine(Slide(posisiSembunyi));

        areaTutup.SetActive(false);
    }

    IEnumerator Slide(Vector2 target)
    {
        float waktu = 0;
        Vector2 awal = menuSamping.anchoredPosition;

        while (waktu < 0.25f)
        {
            menuSamping.anchoredPosition =
                Vector2.Lerp(awal, target, waktu / 0.25f);

            waktu += Time.deltaTime;
            yield return null;
        }

        menuSamping.anchoredPosition = target;
    }

    public void OpenGoogleDrive()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1py6ZQzM4jbru5eXC32lKA1vQ3J__Kr-6?usp=sharing");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}