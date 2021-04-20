using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 5;
    public float destroyTime = 2;
    public GameObject Explosion;


    void Start()
    {
        // huỷ một vật thể sau thời gian đã định sẵn
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);
    }

    private void OnDestroy()
    {
       GameObject exp = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
       Destroy(exp, 0.5f);
    }

}
