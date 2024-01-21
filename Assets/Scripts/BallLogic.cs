using System.Collections;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    // https://www.youtube.com/watch?v=OkfA5BFVq5o&ab_channel=FlutterBros
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    public float Speed {get {return speed;} set{speed=value;}}
    [SerializeField] private Vector2 startPosition = Vector2.zero;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetPos();
    }

    public void ResetPos()
    {
        Vector3 pos = GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(startPosition.x,startPosition.y,pos.z);
        direction = RndDirectionVec();
    }

    protected Vector2 RndDirectionVec()
    {
        int rng = Random.Range(1,4);
        return rng switch
        {
            1 => Vector2.one.normalized,// ( 1 , 1 )
            2 => new Vector2(-1f, -1f).normalized,// (-1 ,-1 )
            3 => new Vector2(1f, -1f).normalized,// ( 1 ,-1 )
            4 => new Vector2(-1f, 1f).normalized,// (-1 , 1 )
            _ => Vector2.one.normalized,// default = ( 1 , 1 )
        };
    }
    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "Player":
                direction.x *= -1f;
                break;
            case "Wall":
                direction.y *= -1f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Score"))
        {
            ResetPos();
        }
    }
}
