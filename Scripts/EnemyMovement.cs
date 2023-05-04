using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float distanceBetween;
    public float movementSpeed;
    public Transform[] movementPoints;
    public float minDistance;
    private int randomNumber;
    private SpriteRenderer spriteRenderer;
    public bool isAttacking = false;
    public GameObject Bullet;
    public float attackDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, movementPoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        TurnSprite();
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetween = Vector2.Distance(GameObject.Find("Player").transform.position, transform.position);

        if (distanceBetween > 3f)
        {
            PoliceMode();
        }
        else
        {
            AttackMode();
        }
    }

    private void AttackMode()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, movementSpeed * Time.deltaTime);
        Shooting();
    }

    private void Shooting()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay < 0)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            attackDelay = 1;
        }
    }

    private void PoliceMode()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[randomNumber].position, movementSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movementPoints[randomNumber].position) < minDistance)
        {
            randomNumber = Random.Range(0, movementPoints.Length);
            TurnSprite();
        }
    }


    private void TurnSprite()
    {
        if (transform.position.x < movementPoints[randomNumber].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
