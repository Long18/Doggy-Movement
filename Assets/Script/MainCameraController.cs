using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    GameObject obj;
    Vector3 mousePOS;
    public GameObject gameController;
    public GameObject m_Sheep;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -10);
        obj.transform.position = Vector3.Lerp(obj.transform.position, m_Sheep.transform.position, 0.1f);
    }
}
