using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    // public GameObject target; -- Test
    Vector3 mousePos;
    public float moveSpeed = 5; // tốc độ chạy của cừu
    public float minX = -5.5f; // Giới hạn của cừu trong background
    public float maxX = 5.5f;  //
    public float minY = -3;    //
    public float maxY = 3;     // Giới hạn của cừu trong background
    private GameObject gameController;

    void Start()
    {
        // mousePos bằng toạ độ 0,0,0 ( toạ độ mặc định )
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {

        //GetMouseButton là chỉ cần ấn giữ chuột cừu sẽ di chuyển theo chuột
        //GetMouseButtonDown là phải click chuột nhiều lần
        if (Input.GetMouseButton(0))
        {
            // vị trí con cừu = thời gian di chuyển * thời gian
            // Lerp là thay đổi vị trí vecter xyz từ toạ độ ban đầu tới điểm cuối theo tỉ lệ của vị trí mới đã được thay đổi
            // deltaTime là con số cực nhỏ
            /*
             
            transform.position = Vector3.Lerp(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

            */

            // toạ độ của con cừu sẽ bằng toạ độ con trỏ chuột so với camera chính của chương trình
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // giới hạn toạ độ với hàm toán học, không cho cừu vượt quá toạ độ
            mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), Mathf.Clamp(mousePos.y, minY, maxY), 0);
        }
        // ứng dụng ở trên ta có vị trí của chuột
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        gameController.GetComponent<GameController>().EndGame();
    }
}
