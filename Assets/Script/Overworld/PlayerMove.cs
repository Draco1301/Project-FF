using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] OverworldMovement owMovement;
    private bool moveCheck;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!owMovement.IsMoving() && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))) {
            animator.SetBool("IsMoving", false);
        } else { 
            animator.SetBool("IsMoving",true);

            if (Input.GetKey(KeyCode.S)) {
                animator.SetInteger("Direction", owMovement.MoveDirection());
            } else if (Input.GetKey(KeyCode.A)) {
                animator.SetInteger("Direction", owMovement.MoveDirection());
            } else if (Input.GetKey(KeyCode.D)) {
                animator.SetInteger("Direction", owMovement.MoveDirection());
            } else if (Input.GetKey(KeyCode.W)) {
                animator.SetInteger("Direction", owMovement.MoveDirection());
            }

        }
    }
}
