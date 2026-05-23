using UnityEngine;
using UnityEngine.UI;

public class PanahTentang : MonoBehaviour
{
    public LayoutElement layout;
    public GameObject isi;

    public float tinggiTutup = 0;
    public float tinggiBuka = 300;

    public void Toggle()
    {
        bool aktif = !isi.activeSelf;
        isi.SetActive(aktif);

        layout.preferredHeight = aktif ? tinggiBuka : tinggiTutup;

        LayoutRebuilder.ForceRebuildLayoutImmediate(
            layout.transform.parent.GetComponent<RectTransform>()
        );
        Canvas.ForceUpdateCanvases();
    }
}

