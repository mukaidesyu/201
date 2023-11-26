using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    private float distance = 1.0f;
    private float move = 5.0f;
    public bool putflag = true;

    bool rot = true;

    private float Rtspeed = 150.0f;

    Spawner spawner;    // �X�|�i�[
    Piece activePiece;  // �������ꂽ�s�[�X 
    GameObject Pice;

    judgment tilemanager;
    judgment1 tilemanager1;
    judgment2 tilemanager2;
    judgment3 tilemanager3;

    public int feald = 0;

    public int putNo = 1;

    public bool Unpossible = true;//����s�\�t���O
    public float UnpossibleTimer = 0;//����s�\�^�C�}�[

    //SE
    SEenter se;

    private void Start()
    {

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

        se = GameObject.Find("playerSE").GetComponent<SEenter>();
    }

    void Update()
    {
        //�ړ�
        if (Input.GetKey(KeyCode.W)||Input.GetAxis("Vertical") >= 1.0f)
        {

            this.transform.position += new Vector3(0, 0, move * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") <= -1.0f)
        {

            this.transform.position += new Vector3(0, 0, -move * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") <= -1.0f)
        {

            this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") >= 1.0f)
        {

            this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
        }

        //��]
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 4"))
        {
            rot = false;
            StartCoroutine(rt());
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 5"))
        {
            rot = false;
            StartCoroutine(rt2());
        }

        //����\�����f
        if (Unpossible == true)
        {
            //�ꏊ��I��
            if (tilemanager.PutFlag() == true && tilemanager1.PutFlag1() == true && tilemanager2.PutFlag2() == true && tilemanager3.PutFlag3() == true)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    // �s�[�X��u���Ƃ����ɓ���
                    if (Pice.GetComponent<Piece>().flagp() == true) // ����P�t���O�������ĂȂ�
                    {
                        se.EnterSE();

                        Destroy(Pice);
                        //this.gameObject.transform.position = new Vector3(0,0,-0.5f);
                        activePiece = spawner.SpawnPiece(this.gameObject);
                        Pice = activePiece.gameObject;


                        // �����œn���s�[�X�𔻒肷��
                        tile tileScript = GameObject.Find("Tile").GetComponent<tile>();
                        GameObject onTile = tileScript.GetOnTile();
                        GameObject farTile = tileScript.GetFarTile(onTile);

                        // �L�ɓn��
                        Neko_NavMesh nekoScript = GameObject.Find("Neko").GetComponent<Neko_NavMesh>();
                        nekoScript.SetTarget(onTile);
                        nekoScript.SetNextTarget(farTile);


                        // �S�t���O������
                        tileScript.EndNowPut();

                        //����s�\���Ԃ̃t���O
                        Unpossible = false; 
                        UnpossibleTimer = 1.0f;
                    }
                }
            }
        }

        if(Unpossible == false)
        {
            UnpossibleTimerCount();
        }
  
    }


    private void MovePlyer(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //�x�C�N
        GameObject.Find("NavMeshSurface").GetComponent<NavMesh_Surface>().Bake();
    }

    public void UnpossibleTimerCount()
    {
        UnpossibleTimer -= Time.deltaTime;
        if(UnpossibleTimer <= 0)
        {
            Unpossible = true;
        }
    }

    public bool GetUnpossible()
    {
        return Unpossible;
    }

    IEnumerator rt()
    {
        float i = 0;
        while (i <= 90)
        {
            i += Rtspeed * Time.deltaTime;
            this.transform.Rotate(0, 0, Rtspeed * Time.deltaTime );
            yield return null;
        }
        rot = true;
    }
 
    IEnumerator rt2()
    {
        float i = 0;
        while (i >= -90)
        {
            i -= Rtspeed * Time.deltaTime;
            this.transform.Rotate(0, 0, -Rtspeed * Time.deltaTime );
            yield return null;
        }
        rot = true;
    }
}
