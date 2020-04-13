using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
    Transform bagTranform;
    float moveSpeed = 0.1f;
    float currentTime = 0f;
    float totalTime = 50;
    Vector2 bagPos;
    Vector2 halfPos;
    // Start is called before the first frame update
    void Start()
    {
        bagTranform = GameObject.Find("背包图标").transform;
        bagPos = new Vector2(bagTranform.position.x, bagTranform.position.y);
        halfPos = new Vector2(bagPos.x + Random.Range(-5, 5), bagPos.y + Random.Range(-5, 5));
        //StartCoroutine(MoveTo());
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        print(currentTime / totalTime);
        if (transform.position.x != bagPos.x && transform.position.y != bagPos.y)
        {
            if (halfPos != bagPos)
            {
                halfPos = Vector2.Lerp(halfPos, bagPos, currentTime / totalTime);
            }
            transform.position = Vector2.Lerp(transform.position, bagPos, currentTime/totalTime);
        }
        if (currentTime / totalTime>=0.05)
        {
            GameObject.DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        bagTranform.GetComponent<Animator>().SetTrigger("GetItem");
    }

    //IEnumerator MoveTo()
    //{
    //    yield return new WaitForSeconds(2);

    //}
}
