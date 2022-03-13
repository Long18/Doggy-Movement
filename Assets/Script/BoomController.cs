using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 1;
    public float destroyTime = 2;
    public GameObject Explosion;

    private GameObject GameController;

    void Start()
    {
        // construct value
        GameController = GameObject.FindGameObjectWithTag("GameController");

        //destroy this obj 
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);
    }

    private void OnDestroy()
    {
        GameController.GetComponent<GameController>().AddScore();

        // ganerate an explosion at boom postion after the Boom is destroy
        GameObject expl = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;

        // destroy after 0.5 second
        Destroy(expl, 0.1f);
    }

}
