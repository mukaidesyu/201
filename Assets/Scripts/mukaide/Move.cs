using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    private float distance = 1.0f;
    public Vector2 move;
    private Vector3 targetPos;
    public bool putflag = true;
    Spawner spawner;    // スポナー
    Piece activePiece;  // 生成されたピース 
    GameObject Pice;
    GameObject old;


    private void Start()
    {
        targetPos = transform.position;

        // スポナーオブジェクトをスポナー変数に格納する
        spawner = GameObject.FindObjectOfType<Spawner>();
        if (!activePiece)
        {
            activePiece = spawner.SpawnPiece(this.gameObject);
            Pice = activePiece.gameObject;
        }
    }

    void Update()
    {
        //move.x = Input.GetAxisRaw("Horizontal");
        //move.y = Input.GetAxisRaw("Vertical");
        //if (move != Vector2.zero && transform.position == targetPos)
        //{
        //    targetPos += new Vector3(move.x, move.y, 0) * distance;
        //}
        RaycastHit hit;
       
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            targetPos += new Vector3(0, 1, 0) * distance;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            targetPos += new Vector3(0, -1, 0) * distance;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            targetPos += new Vector3(-1, 0, 0) * distance;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                {
                    old = hit.collider.gameObject;
                    Debug.Log(old.name);
                }
            }
            targetPos += new Vector3(1, 0, 0) * distance;
        }

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
        {
            if (hit.collider.CompareTag("judgment"))
            {
                //targetPos = new Vector3(0, 0, 0) * distance;
                targetPos = new Vector3(old.transform.position.x, old.transform.position.y, -0.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }
        MovePlyer(targetPos);
        
        //場所を選ぶ
        if (putflag)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Destroy(Pice);
                targetPos = new Vector3(0.0f, 0.0f, -0.5f);
                //this.gameObject.transform.position = new Vector3(0,0,-0.5f);
                activePiece = spawner.SpawnPiece(this.gameObject);
                Pice = activePiece.gameObject;

            }
        }
    }


    private void MovePlyer(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            _speed * Time.deltaTime);
    }
}
