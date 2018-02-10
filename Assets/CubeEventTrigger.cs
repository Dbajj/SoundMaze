using UnityEngine;
using UnityEngine.EventSystems;

public class CubeEventTrigger : EventTrigger {

    public override void OnPointerClick(PointerEventData eventData)
    {
        var player = GameObject.Find("Player");

        player.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
    }

}
