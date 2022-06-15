using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject bossExplosion;
    private Vector3 pos1, pos2;

    public GameObject point;
    public Slider healthBar;

    public int health;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody boss = GetComponent<Rigidbody>();
        healthBar.value = health;
        //Animator anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.gameObject.SetActive(true);


        pos1 = transform.position;
        pos2 = point.transform.position;
        transform.position = Vector3.MoveTowards(pos1, pos2, Time.deltaTime * moveSpeed);

        if (gameObject.transform.position.z <= point.transform.position.z)
        {
            gameObject.GetComponent<BossFollowPath>().enabled = true;
            gameObject.GetComponent<UbhShotCtrl>().enabled = true;
            gameObject.GetComponent<BossController>().enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lazer")
        {
            if (health != 0)
            {
                health --;
                anim.SetTrigger("isDamaged");
                healthBar.value = health;
                Destroy(other.gameObject);
            }
            else
            {
                Instantiate(bossExplosion, transform.position, Quaternion.identity);

                GameController.bossFight = false;
                GameController.stageComplete = true;
                GameController.increaseScore(500);

                healthBar.gameObject.SetActive(false);
                
                gameObject.SetActive(false);
            }

        }
        
    }

    // private void decreaseHealth()
    // {
    //     health -= 1;
    // }

}
