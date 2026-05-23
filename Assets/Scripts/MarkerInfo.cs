using UnityEngine;
using UnityEngine.SceneManagement; 

public class MarkerInfo : MonoBehaviour
{
    public string judul;

    [TextArea]
    public string deskripsi;

    public string namaScene;

    public AudioClip suaraMakanan;

    public Panel panel;

    public void AktifkanInfo()
    {
        panel.SetInfo(judul, deskripsi, namaScene);
        panel.SetAudio(suaraMakanan);
        // HANYA refresh kalau panel sedang terbuka
        if (panel.panelSedangTerbuka)
        {
            panel.BukaInfo();
        }
    }
}