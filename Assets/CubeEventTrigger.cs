using UnityEngine;
using UnityEngine.EventSystems;

public class CubeEventTrigger : EventTrigger {

    public override void OnPointerClick(PointerEventData eventData)

    {
        string name = this.gameObject.name;

        switch(name)
        {
            case ("Front"):
                MakeFloor.controller.moveForward();
                break;
            case ("Back"):
                MakeFloor.controller.moveBackward();
                break;
            case ("Right"):
                MakeFloor.controller.moveRight();
                break;
            case ("Left"):
                MakeFloor.controller.moveLeft();
                break;
        }

    }


    

}
