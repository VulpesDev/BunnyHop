using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP : MonoBehaviour
{
    //tripping + creepy zvuk
    //creepy zvuci na interactibles
    //klatene nagore - nadolu            V

    protected Rigidbody rb;
    protected GameObject cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0).gameObject;
    }
}
