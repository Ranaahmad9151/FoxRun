using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPos;


    public void Respawn()
    {
        transform.position = respawnPos;
    }
}
