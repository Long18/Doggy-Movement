using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{

    public GameObject m_Boom;
    public GameObject m_Sheep;

    public float minBoomTime = 2;
    public float maxBoomTime = 4;
    private float boomTime = 0;
    private float lastBoomTime = 0;

    private bool isThrowing = false;
    void Start()
    {
        m_Sheep = GameObject.FindGameObjectWithTag("Player");
        updateBoomTime();

    }

    // Update is called once per frame
    void Update()
    {
        if (isThrowing)
        {
            if (Time.time >= lastBoomTime + boomTime)
            {
                throwBoom();
            }
            aimToTheTarget(m_Sheep.transform.position, gameObject);
        }
    }

    void updateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    void throwBoom()
    {
        GameObject BOM = Instantiate(m_Boom, transform.position, Quaternion.identity) as GameObject;
        BOM.GetComponent<BoomController>().target = m_Sheep.transform.position;

        updateBoomTime();

        if (maxBoomTime <= 0)
        {
            maxBoomTime = maxBoomTime - 0.2f;
        }
        if (minBoomTime != 0)
        {
            minBoomTime = minBoomTime - 0.2f;
        }
    }

    void aimToTheTarget(Vector3 target, GameObject obj)
    {
        Vector3 aimDirection = (target - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        obj.transform.eulerAngles = new Vector3(0, 0, angle + 180);
    }

    public void StartThrowingBoom()
    {

        isThrowing = true;

        Debug.Log("wolf Start");
    }
    public void StopThrowingBoom()
    {
        isThrowing = false;
    }
}
