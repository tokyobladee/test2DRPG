using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{

    private BoxCollider2D collider;
    public float speed;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        //inputs
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        //rotate player sprite
        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        
        //move
        transform.Translate(moveDelta * Time.deltaTime * speed);
        
        //collider

        hit = Physics2D.BoxCast(transform.position, collider.size, 0, new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(0,moveDelta.y * Time.deltaTime, 0);
        }
        
        
        hit = Physics2D.BoxCast(transform.position, collider.size, 0, new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime,0, 0);
        }
    }
}
