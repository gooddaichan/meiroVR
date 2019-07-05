using UnityEngine;
using System.Collections;
//GOALにattach
public class Item : MonoBehaviour
{
    public static int GetStar_ex;
    void start()
    {
        GetStar_ex = 0;
    }
    bool isCalled = false;

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {

            Destroy(gameObject);

            if (Time.time > 0.5f)
            {
                if (isCalled == false)
                {
                    isCalled = true;
                    Get();
                }
            }

        }
    }
    void Get()
    {
        GetStar_ex = GetStar_ex + 10;
    }
}