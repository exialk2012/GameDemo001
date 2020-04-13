using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject item;
    public Vector3 createPos;
    public Vector2 offset;
    public Transform bag;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateIcon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CreateIcon()
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
            var offsetx = Random.Range(-Mathf.Abs(offset.x), Mathf.Abs(offset.x));
            var offsety = Random.Range(-Mathf.Abs(offset.y), Mathf.Abs(offset.y));
            Vector3 pos = new Vector3(createPos.x + offsetx, createPos.y + offsety, createPos.z);
            GameObject.Instantiate(item, pos, Quaternion.identity);
        }
        
    }
}
