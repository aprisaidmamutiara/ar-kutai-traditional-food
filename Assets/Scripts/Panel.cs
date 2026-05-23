using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Panel : MonoBehaviour
{
    public RectTransform infoPanel;
    public GameObject tombolUI;

    public TMP_Text judulTeks;
    public TMP_Text deskripsiTeks;

    public string judulAktif;
    public string deskripsiAktif;

    private string sceneSelanjutnya;

    // AUDIO
    private AudioSource audioSource;
    private AudioClip currentClip;

    // STATUS AUDIO
    private bool audioNyala = false;

    // TOMBOL SUARA
    public GameObject tombolSuaraOn;
    public GameObject tombolSuaraOff;

    public bool panelSedangTerbuka = false;

    Vector2 posisiMuncul;
    Vector2 posisiSembunyi;

    void Start()
    {
        posisiMuncul = new Vector2(0, 0);
        posisiSembunyi = new Vector2(0, -700);

        infoPanel.anchoredPosition = posisiSembunyi;

        // Audio Source otomatis
        audioSource = GetComponent<AudioSource>();

        // Tombol awal
        tombolSuaraOn.SetActive(true);
        tombolSuaraOff.SetActive(false);
    }

    public void BukaInfo()
    {
        panelSedangTerbuka = true;

        judulTeks.text = judulAktif;
        deskripsiTeks.text = deskripsiAktif;

        StopAllCoroutines();
        StartCoroutine(Slide(posisiMuncul));

        tombolUI.SetActive(false);
    }

    public void BukaResep()
    {
        SceneManager.LoadScene(sceneSelanjutnya);
    }

    public void SetInfo(string judul, string deskripsi, string scene)
    {
        // simpan data baru
        judulAktif = judul;
        deskripsiAktif = deskripsi;
        sceneSelanjutnya = scene;

        // langsung update UI
        judulTeks.text = judulAktif;
        deskripsiTeks.text = deskripsiAktif;

        // reset audio lama
        audioSource.Stop();

        audioNyala = false;

        tombolSuaraOn.SetActive(true);
        tombolSuaraOff.SetActive(false);
    }

    // TERIMA AUDIO DARI MARKER
    public void SetAudio(AudioClip clip)
    {
        currentClip = clip;
    }

    // TOGGLE AUDIO
    public void TombolAudio()
    {
        if (currentClip == null)
            return;

        audioNyala = !audioNyala;

        if (audioNyala)
        {
            audioSource.clip = currentClip;
            audioSource.Play();

            tombolSuaraOn.SetActive(false);
            tombolSuaraOff.SetActive(true);
        }
        else
        {
            audioSource.Stop();

            tombolSuaraOn.SetActive(true);
            tombolSuaraOff.SetActive(false);
        }
    }

    public void TutupInfo()
    {
        panelSedangTerbuka = false;

        StopAllCoroutines();
        StartCoroutine(Slide(posisiSembunyi));

        tombolUI.SetActive(true);

        // Stop audio saat panel ditutup
        audioSource.Stop();

        audioNyala = false;

        tombolSuaraOn.SetActive(true);
        tombolSuaraOff.SetActive(false);
    }

    IEnumerator Slide(Vector2 target)
    {
        float waktu = 0;
        Vector2 awal = infoPanel.anchoredPosition;

        while (waktu < 0.25f)
        {
            infoPanel.anchoredPosition =
                Vector2.Lerp(awal, target, waktu / 0.25f);

            waktu += Time.deltaTime;
            yield return null;
        }

        infoPanel.anchoredPosition = target;
    }
}