using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isTaken;
    [SerializeField] private GameObject logicManager;
    private CharacterController controller;
    private LogicScript logic;
    private Vector3 motion;
    [SerializeField] private float speed;
    [SerializeField] private float cooldown;

    private void OnMouseDown()
    {
        if (logic.currentMode == logic.EDITION_MODE)
        {
            if (isTaken) isTaken = false;
            else if (!isTaken) isTaken = true;
            Debug.Log(isTaken);
        }
        Debug.Log("clicked");
    }


    private void Start()
    {
        logic = logicManager.GetComponent<LogicScript>();
        controller = gameObject.GetComponent<CharacterController>();
    }


    private void FixedUpdate()
    {
        if (logic.currentMode == logic.EDITION_MODE)
        {
            if (isTaken)
            {
                motion.x = Input.GetAxisRaw("Xaxis");
                motion.z = Input.GetAxisRaw("Zaxis");
                
                if (!controller.isGrounded)
                {
                    motion = Vector3.down;
                    controller.Move(speed * motion); //transform.position += speed*motion * Time.deltaTime;
                }
                else controller.SimpleMove(speed * motion);


            }
        }
        else
        {
            isTaken = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Vector3.Angle(hit.normal, Vector3.up) <= controller.slopeLimit+10f) return;        

        Collider coll = hit.collider;
        transform.position = new Vector3(transform.position.x, hit.transform.position.y + coll.bounds.size.y*0.5f + transform.localScale.y, transform.position.z) + speed*motion*Time.deltaTime;
    }
}
