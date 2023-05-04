using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMovement : MonoBehaviour
{
    Transform inHead;

    // Start is called before the first frame update
    void Start()
    {
        inHead = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, inHead.position, 2f * Time.deltaTime);
        Destroy(gameObject, 1);
    }
}
