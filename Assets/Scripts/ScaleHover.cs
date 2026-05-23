using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 normalScale = Vector3.one;
    public Vector3 hoverScale = new Vector3(1.05f, 1.05f, 1f);
    public float speed = 10f;

    private Vector3 targetScale;

    void Start()
    {
        targetScale = normalScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = normalScale;
    }
}