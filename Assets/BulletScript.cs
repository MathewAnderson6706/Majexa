using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject playerObject;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler(0, 0, 90);
        GetComponent<Rigidbody2D>().AddForce(transform.up * 150f);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage); Destroy(gameObject); }
        if (collision.gameObject.tag == "Shield") { collision.gameObject.GetComponent<ShieldScript>().TakeDamage(damage); Destroy(gameObject); }
    }
}
