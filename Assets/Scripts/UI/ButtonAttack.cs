using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAttack : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Player.Instance.GetComponent<WeaponPlace>().Attack();
    }
}
