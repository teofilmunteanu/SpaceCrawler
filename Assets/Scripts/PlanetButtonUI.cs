using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image img;

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.rectTransform.localScale = new Vector3(1.3f, 1.3f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.rectTransform.localScale = new Vector3(1, 1, 1);
    }
}
