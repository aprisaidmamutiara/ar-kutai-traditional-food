using UnityEngine;
using TMPro;

public class AutoNumbering : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform item = transform.GetChild(i);

            TMP_Text numberText = item.Find("No").GetComponent<TMP_Text>();
            numberText.text = (i + 1) + ".";
        }
    }
}