using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ManController : MonoBehaviour
{
    public GameObject overScreen;
    private MiniMap miniMap;
    private GameObject[] mapBoxes;
    private List<bool> mapIsCreate = new List<bool>();
    private bool isCreate= true;
    private List<Image> images = new List<Image>();


    public int numStick = 6;

    public bool isStick = false;
    public AudioClip FireClip;
    public float soundVol = 1.0f;
    AudioSource audioSource;

    public Box nearBox;
    public GameObject stickPrefab;

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int maxBag = 2;
    public bool isEnd = false;
    public int bag { get { return currentBag; } }
    int currentBag;

    public int health { get { return currentHealth; } }
    int currentHealth;
    public int gasTime = 3;
    private float curGasTime;
    
    bool isInvincible;
    float invincibleTimer;

    public Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 0.1f;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    Vector2 move;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        curGasTime = gasTime;
        audioSource = GetComponent<AudioSource>();
        miniMap = GameObject.Find("MiniMap").GetComponent<MiniMap>();
        mapBoxes = GameObject.FindGameObjectsWithTag("Box");
        overScreen.SetActive(false);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        /*
        不能用float表示横纵坐标的位置，走动会卡。
        if (horizontal!=0 || vertical != 0)
        {
            Vector3 dir = new Vector3(horizontal, 0, vertical);
            transform.LookAt(transform.position + dir);
            transform.Translate(Vector3.forward*Time.deltaTime*5);
        }
        */

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        //if (Input.GetKeyDown(KeyCode.F)||Input.GetAxis("Fire1")!=0 )
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
                NPC character = hit.collider.GetComponent<NPC>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPlayAnimation();
            if (nearBox != null)
            {
                nearBox.Open();
            }
            else
            {
                
            }
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;

        }

        if (curGasTime > 0)
        {
            curGasTime -= Time.deltaTime;
        }
        else
        {
            //人物进入结局不受到伤害
            if (!isEnd)
            {
                if (isStick)
                {
                    ChangeHealth(-5);
                }
                else
                {
                    ChangeHealth(-1);
                }
            }

            curGasTime = gasTime;
        }

        //地图显示检测
        Monitor();

    }



    void FixedUpdate()
    {

        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.position = position;

    }

    public void ChangeHealth(int amount)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        if (amount < 0)
        {
            if (isInvincible)
                return;


            else if (amount == -3)
            {
                isInvincible = true;
                invincibleTimer = timeInvincible;
                animator.SetTrigger("Hit");
            }

            else
            {
                isInvincible = true;
                invincibleTimer = timeInvincible;
            }
            
            
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"当前生命值：" + currentHealth + "/" + maxHealth);

        if (currentHealth == 0)
        {
            Debug.Log("当前角色死亡");

            overScreen.SetActive(true);
        }

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

    }

    public void ChangeBag(int paper)
    {
        currentBag = Mathf.Clamp(bag + paper, 0, maxBag);
        Debug.Log($"当前碎片收集程度：" + bag + "/" + maxBag);
    }

    void Fire()
    {

        isStick = true;

        stickPrefab.SetActive(true);
        
        animator.SetTrigger("Fire");

        PlaySound(FireClip, soundVol);

        numStick = numStick - 1;
    }

    void PlayerPlayAnimation()
    {
        animator.SetTrigger("Open");
    }

    public void PlaySound(AudioClip audioclip,float soundVol)
    {
        audioSource.PlayOneShot(audioclip, soundVol);
    }



    private void Monitor()
    {
        for (int i = 0; i < mapBoxes.Length; i++)
        {
            float distance=Vector3.Distance(transform.position, mapBoxes[i].transform.position);
            float x = (mapBoxes[i].transform.position.x - transform.position.x)/7;
            float y = (mapBoxes[i].transform.position.y - transform.position.y)/7;

            if (i + 1 > mapIsCreate.Count)
            {
                mapIsCreate.Add(false);
            }

            if (!mapIsCreate[i])
            {
                images.Add(MiniMap.create());
                mapIsCreate[i] = true;
            }
            else
            {
                if (distance <= 3)
                {
                    images[i].gameObject.SetActive(true);
                    miniMap.ShowBox(images[i],x,y);
                }
                else
                {
                    images[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
