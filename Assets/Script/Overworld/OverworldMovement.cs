using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] MainMenuScript menu;
    private bool isMoving = false;
    private int moveDirection = 0;

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && !menu.IsOpen) {
            if (Input.GetKey(KeyCode.S)) {
                StartCoroutine(move(Vector3.down));
                moveDirection = 2;
            } else if (Input.GetKey(KeyCode.A)) {
                StartCoroutine(move(Vector3.left));
                moveDirection = 4;

            } else if (Input.GetKey(KeyCode.D)) {
                StartCoroutine(move(Vector3.right));
                moveDirection = 6;

            } else if (Input.GetKey(KeyCode.W)) {
                StartCoroutine(move(Vector3.up));
                moveDirection = 8;

            }
        }

        if (!isMoving && Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private IEnumerator move(Vector3 dir) {
        isMoving = true;
        float time = 0;
        float timeLength = 1 / speed;
        Vector3 start = transform.position;
        Vector3 end = transform.position + dir;

        while (time < timeLength) {

            transform.position = Vector3.Lerp(start, end, time * speed);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = end;
        isMoving = false;
    }

    public bool IsMoving() {
        return isMoving;
    }

    public int MoveDirection() {
        return moveDirection;
    }
}
