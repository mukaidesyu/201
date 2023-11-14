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

    Spawner spawner;    // �X�|�i�[
    Piece activePiece;  // �������ꂽ�s�[�X 
    GameObject Pice;
    GameObject old;

    judgment tilemanager;
    judgment1 tilemanager1;
    judgment2 tilemanager2;
    judgment3 tilemanager3;

    public int feald = 0;

    public int putNo = 1;

    private void Start()
    {
        targetPos = transform.position;

        // �X�|�i�[�I�u�W�F�N�g���X�|�i�[�ϐ��Ɋi�[����
        spawner = GameObject.FindObjectOfType<Spawner>();
        if (!activePiece)
        {
            activePiece = spawner.SpawnPiece(this.gameObject);
            Pice = activePiece.gameObject;
        }

        tilemanager = GameObject.Find("judgment1").GetComponent<judgment>(); // �E
        tilemanager1 = GameObject.Find("judgment2").GetComponent<judgment1>(); // ��
        tilemanager2 = GameObject.Find("judgment3").GetComponent<judgment2>(); // ��
        tilemanager3 = GameObject.Find("judgment4").GetComponent<judgment3>(); // ��
    }

    void Update()
    {
        RaycastHit hit;

        //�ړ�
        if (Input.GetKeyDown(KeyCode.W)||Input.GetAxis("Vertical") >= 1.0f)
        {
            Debug.Log(Input.GetAxis("Vertical"));
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            targetPos += new Vector3(0, 0, 1) * distance;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetAxis("Vertical") <= -1.0f)
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
            {
                if (hit.collider.CompareTag("tile"))
                    old = hit.collider.gameObject;
            }
            targetPos += new Vector3(0, 0, -1) * distance;
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
                }
            }
            targetPos += new Vector3(1, 0, 0) * distance;
        }

        //��]
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }

        MovePlyer(targetPos);


        //�ꏊ��I��
        if (tilemanager.PutFlag() == true && tilemanager1.PutFlag1() == true && tilemanager2.PutFlag2() == true && tilemanager3.PutFlag3() == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // �s�[�X��u���Ƃ����ɓ���
                if(Pice.GetComponent<Piece>().flagp() == true) // ����P�t���O�������ĂȂ�
                {
                    Destroy(Pice);
                    targetPos = new Vector3(0.0f, 0.1f, 0.0f);
                    //this.gameObject.transform.position = new Vector3(0,0,-0.5f);
                    activePiece = spawner.SpawnPiece(this.gameObject);
                    Pice = activePiece.gameObject;
                }
            }
        }
    }


    private void MovePlyer(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            _speed * Time.deltaTime);
    }
}
