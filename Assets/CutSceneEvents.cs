using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEvents : MonoBehaviour
{
    [SerializeField]GameObject player;
    [SerializeField] Transform newSpawnPosTr;
    Vector3 newSpawnPos;
    private void Start()
    {
        newSpawnPos = newSpawnPosTr.position;
    }
    public void MovePlayerToNewMap()
    {
        player.transform.position = newSpawnPos;
    }
}
