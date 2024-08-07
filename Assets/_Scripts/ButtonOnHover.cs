using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ButtonOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method.
{
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Vector4(255, 255, 255, 1);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Vector4(255, 255, 255, 0);
    }
}
