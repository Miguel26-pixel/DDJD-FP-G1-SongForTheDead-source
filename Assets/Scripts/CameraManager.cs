using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform target;
    private Transform player;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        MoveCam();
    }

    public void MoveCam()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
    }
}
