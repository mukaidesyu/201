using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 7.0f;
    private float distance = 1.0f;
    public int move = 2;
    public bool putflag = true;

    private Vector3 targetPos;

    public  bool rot = true;

    public float Rtspeed = 3.0f;

    Spawner spawner;    // �X�|�i�[
    Piece activePiece;  // �������ꂽ�s�[�X 
    GameObject Pice;

    judgment tilemanager;
    judgment1 tilemanager1;
    judgment2 tilemanager2;
    judgment3 tilemanager3;
    TurnScript turnScript;

    public int feald = 0;

    public int putNo = 1;

    public bool Unpossible = true;//����s�\�t���O
    public float UnpossibleTimer = 0;//����s�\�^�C�}�[

    public bool Hit = true;//����s�\�t���O
    public float HitsTimer = 0;//����s�\�^�C�}�[

    // �`���[�g���A�����ǂ���
    string sceneName;
    TutorialData tutorialData;
    bool tutorialBool = true;

    //SE
    AudioSource audio;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        // �X�|�i�[�I�u�W�F�N�g���X�|�i�[�ϐ��Ɋi�[����
        spawner = GameObject.FindObjectOfType<Spawner>();

        // �����`���[�g���A���V�[����������A�`���[�g���A��
        if (sceneName == "tutorial")
        {
            if (!activePiece)
            {
                // �`���[�g���A���̍ŏ��̃s�[�X�͌��܂����s�[�X
                activePiece = spawner.SpawnPiece(this.gameObject,1);
                Pice = activePiece.gameObject;
            }
            tutorialData = GameObject.Find("TutorialState").GetComponent<TutorialData>();
            tutorialBool = false;
        }
        else // ���̃V�[��
        {
            if (!activePiece)
            {
                activePiece = spawner.SpawnPiece(this.gameObject);
                Pice = activePiece.gameObject;
            }
            tutorialBool = true;
        }

        turnScript = GameObject.Find("TurnNumber").GetComponent<TurnScript>();

        tilemanager = GameObject.Find("judgment1").GetComponent<judgment>(); // �E
        tilemanager1 = GameObject.Find("judgment2").GetComponent<judgment1>(); // ��
        tilemanager2 = GameObject.Find("judgment3").GetComponent<judgment2>(); // ��
        tilemanager3 = GameObject.Find("judgment4").GetComponent<judgment3>(); // ��

        targetPos = transform.position;

        audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        bool isMove = true;
        if (sceneName == "tutorial")
        {
            isMove = tutorialData.GetIsMove();
        }
        if (isMove == true)
        {
            //�ړ�
            if (Input.GetAxis("Vertical") >= 0.3f && transform.position == targetPos)
            {
                targetPos += new Vector3(0, 0, move) * distance;
                //this.transform.position += new Vector3(0, 0, move * Time.deltaTime);
            }
            else if (Input.GetAxis("Vertical") <= -0.3f && transform.position == targetPos)
            {
                targetPos += new Vector3(0, 0, -move) * distance;
                //this.transform.position += new Vector3(0, 0, -move * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") <= -0.3f && transform.position == targetPos)
            {
                targetPos += new Vector3(-move, 0, 0) * distance;
                // this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
            }
            else if (Input.GetAxis("Horizontal") >= 0.3f && transform.position == targetPos)
            {
                targetPos += new Vector3(move, 0, 0) * distance;
                //this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
            }

            MovePlyer(targetPos);

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
        }

        //��ʊO����
        if (tilemanager.PutFlag() == false && transform.position == targetPos)
        {
            Debug.Log("a");
            targetPos -= new Vector3(-move, 0, 0) * distance;

            //this.transform.position += new Vector3(0, 0, move * Time.deltaTime);
        }
        if (tilemanager1.PutFlag1() == false && transform.position == targetPos)
        {
            Debug.Log("b");
            targetPos -= new Vector3(0, 0, move) * distance;

            //this.transform.position += new Vector3(0, 0, -move * Time.deltaTime);
        }
        if (tilemanager2.PutFlag2() == false && transform.position == targetPos)
        {
            Debug.Log("c");
            targetPos -= new Vector3(0, 0, -move) * distance;
  
            // this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
        }
        if (tilemanager3.PutFlag3() == false && transform.position == targetPos)
        {
            Debug.Log("d");
            targetPos -= new Vector3(move, 0, 0) * distance;

            //this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
        }


        //����\�����f
        if (Unpossible == true )
        {
            //�ꏊ��I��
            if (tilemanager.PutFlag() == true && tilemanager1.PutFlag1() == true && tilemanager2.PutFlag2() == true && tilemanager3.PutFlag3() == true)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
                {
                    // �s�[�X��u���Ƃ����ɓ���
                    if (Pice.GetComponent<Piece>().flagp() == true && Pice.GetComponent<Piece>().flage() == false && rot == true) // ����P�t���O�������ĂȂ�
                    {
                        //Debug.Log("���[�u");
                        audio.PlayOneShot(audio.clip);
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
                        nekoScript.SetNyanFlag(false);

                        // �^�[����1�^�[���o�߂�����
                        turnScript.TurnPlus();

                        // �S�t���O������
                        tileScript.EndNowPut();

                        //����s�\���Ԃ̃t���O
                        Unpossible = false;
                        UnpossibleTimer = 1.0f;

                        
                    }
                }
            }
        }

        if (Unpossible == false)
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
        while (i < 90/ Rtspeed)
        {
            i++;
            this.transform.Rotate(0, 0, Rtspeed /* Time.deltaTime*/ );
            yield return null;
        }
        rot = true;
    }
 
    IEnumerator rt2()
    {
        float i = 0;
        while (i > -90 / Rtspeed)
        {
            i--;
            this.transform.Rotate(0, 0, -Rtspeed /* Time.deltaTime */);
            yield return null;
        }
        rot = true;
    }

    public bool Rotflag()
    {
        return rot;
    }

}
