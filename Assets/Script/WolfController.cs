using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{

    public GameObject boom;
    public float minBoomTime = 2;
    public float maxBoomTime = 4;
    private float boomTime = 0;
    private float lastBoomTime = 0;
    public float throughBoomTime = 0.5f;
    private GameObject Sheep;
    private Animator anim;
    private GameObject gameController;
    void Start()
    {
        UpdateBoomTime();
        Sheep = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBoom", false);
        gameController = GameObject.FindGameObjectWithTag("GameController");


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastBoomTime + boomTime - throughBoomTime)
        {
            anim.SetBool("isBoom", true);
        }
        if (Time.time >= lastBoomTime + boomTime)
        {
            ThroughBooom();
        }
    }

    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    void ThroughBooom()
    {
        GameObject bom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;

        bom.GetComponent<BoomController>().target = Sheep.transform.position;

        UpdateBoomTime();
        anim.SetBool("isBoom", false);
        gameController.GetComponent<GameController>().GetPoint();
    }
}
