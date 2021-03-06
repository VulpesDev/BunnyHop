using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Interaction : FP
{
    [SerializeField] Transform rayTr;
    [SerializeField] float distance;
    [SerializeField] LayerMask layerCode;
    [SerializeField] GameObject cage, cagefake, notepadUI, notepad;
    void Start()
    {

    }

    void ActivateDelay()
    {
        MusicManager.Page();
        notepadUI.SetActive(false);
        notepad.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (notepadUI.activeSelf)
            {
                Invoke("ActivateDelay", 0.2f);
            }
        }

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

            if (target.CompareTag("Wardrobe"))
            {
                target.GetComponent<Animator>().SetBool("Open", true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (target.CompareTag("Door"))
                {
                    target.GetComponent<DoorBehaviour>().OpenDoor();
                }
                if (target.CompareTag("Cage"))
                {
                    cage.SetActive(false); cagefake.SetActive(true);
                    GameObject.Find("Cutscenes").transform.GetChild(0).gameObject.SetActive(true);
                }
                if (target.CompareTag("Boombox"))
                {

                    for (int i = 0; i < 3; i++)
                    {
                        if (targetTr.GetChild(i).gameObject.activeSelf)
                        {
                            targetTr.GetChild(i).gameObject.SetActive(false);
                        }
                        else
                        {
                            targetTr.GetChild(i).gameObject.SetActive(true);
                        }
                    }
                    MusicManager.ButtonPush();
                }
                if (target.CompareTag("Bunny"))
                {
                    GameObject.Find("Cutscenes").transform.GetChild(1).gameObject.SetActive(true);
                }
                if (target.CompareTag("Ritual"))
                {
                    target.transform.GetChild(2).gameObject.SetActive(true);

                    Invoke("EndGame", 3f);
                    //END GAME
                }
                if (target.CompareTag("Notepad"))
                {
                    MusicManager.Page();
                    notepadUI.SetActive(true);
                    notepad.SetActive(false);
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

    void EndGame()
    {
        MenuManager.LoadScene(2);
    }
}
