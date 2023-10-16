using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveokajima : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    private float distance = 1.0f;
    private Vector2 move;
    private Vector3 targetPos;

    private void Start()
    {
        targetPos = transform.position;
    }
    void Update()
    {
        
        GameObject Player = GameObject.Find("player");
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if (move != Vector2.zero && transform.position == targetPos)
        {
            targetPos += new Vector3(move.x, move.y, 0) * distance;
        }
        MovePlyer(targetPos);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            
        }
    }

    private void MovePlyer(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            _speed * Time.deltaTime);
    }
}
