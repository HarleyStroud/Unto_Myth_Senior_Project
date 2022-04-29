using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject player;
    public Unit playerUnit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        player = GameObject.Find("Player(Clone)");
        playerUnit = (Unit)player.GetComponent("Unit");

        if (eventData.pointerDrag == null)
        {
            return;
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        if(d!=null)
        {
            if(playerUnit.currentFaith > 0)
			{
                d.placeholderParent = this.transform;
            }
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
            if (playerUnit.currentFaith > 0)
            {
                d.parentToReturnTo = this.transform;

                if (this.name == "Drop Zone")
                {
                    card.PlayCard();
                    card.Discard();
                }
                Debug.Log("Drop transform: :" + this.name);
            }
        }
    }
    
}
