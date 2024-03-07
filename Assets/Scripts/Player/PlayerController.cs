using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    public int hitPoints = 10;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move*Time.deltaTime * moveSpeed);
    }
}
