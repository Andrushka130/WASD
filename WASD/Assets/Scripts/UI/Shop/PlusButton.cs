using UnityEngine;
using UnityEngine.EventSystems;

public class PlusButton : MonoBehaviour, IPointerClickHandler
{
    private Attribute attribute;
    private Transform attributeUI;

    [SerializeField] private Shop shop;



    public Attribute Attribute
    {
        set { attribute = value; }
    }

    public Transform AttributeUI
    {
        set { attributeUI = value; }
    }

     public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("GameManager").GetComponent<ShopManager>().SkillAttribute(attribute);
        shop.UpdateShop();
    }
}
