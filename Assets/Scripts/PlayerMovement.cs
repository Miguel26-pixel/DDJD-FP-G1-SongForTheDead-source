using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 _speed = new Vector2(10, 10);
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_speed.x * inputX, _speed.y * inputY, 0);

        bool isRunning = movement.x != 0 || movement.y != 0;
        _animator.SetBool("isRunning", isRunning);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
}
