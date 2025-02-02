using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularDoorEngine : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform door;
    [SerializeField] float distance;
    Animator doorAnimation;


    // Start is called before the first frame update
    void Start()
    {
        doorAnimation = GetComponent<Animator>();
        distance = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        OpenRegularDoor();
    }

    public void OpenRegularDoor()
    {
        float distanceToDoor = Vector3.Distance(player.position, door.position);

        doorAnimation.SetBool("character_nearby", distanceToDoor <= distance);
    }

}