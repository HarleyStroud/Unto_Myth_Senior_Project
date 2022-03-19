using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null)
        {
            return;
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if(d!=null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null)
        {
            return;
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if(d!=null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
            Debug.Log(d.placeholderParent);
        }
    }



    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        ThisCard card = eventData.pointerDrag.GetComponent < ThisCard>();

        if (d != null)
        {

            d.parentToReturnTo = this.transform;

            if(this.name == "Drop Zone")
            {
              
                card.PlayCard();
                card.Discard();
            }
            Debug.Log("Drop transform: :" + this.name);
        }
    }
    
}
