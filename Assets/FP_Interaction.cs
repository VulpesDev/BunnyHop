using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Interaction : FP
{
    [SerializeField] Transform rayTr;
    [SerializeField] float distance;
    [SerializeField] LayerMask layerCode;
    void Start()
    {

    }
    void Update()
    {
        RaycastHit ray;
        bool hit = Physics.Raycast(rayTr.position, rayTr.forward, out ray, distance, layerCode.value);
        if (hit)
        {
            GameObject target = ray.collider.gameObject;
            Transform targetTr = target.transform;
            for (int i = 0; i < targetTr.childCount; i++)
            {
                GameObject currentChild = targetTr.GetChild(i).gameObject;
                if (currentChild.tag == "InteractionUI")
                {
                    if (currentChild.GetComponent<MeshRenderer>().enabled == false)
                        currentChild.GetComponent<MeshRenderer>().enabled = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ray.collider.CompareTag("Door"))
                {
                    ray.collider.gameObject.GetComponent<DoorBehaviour>().OpenDoor();
                }
            }
        }
        else
        {
            GameObject[] interactables = GameObject.FindGameObjectsWithTag("InteractionUI");
            for (int i = 0; i < interactables.Length; i++)
            {
                if (interactables[i].GetComponent<MeshRenderer>().enabled != false)
                    interactables[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        Debug.DrawRay(rayTr.position, rayTr.forward * distance, Color.red);
    }
}
