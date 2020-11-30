using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;

    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 1 ){
            Die();
        }
    }

    public void takeDamage(int damage){
        HP = HP - damage;
    }

    public void Die()
    {
        string tag = gameObject.tag;
        GameObject sfxPlayer = GameObject.FindGameObjectWithTag("SFX_Player");
        SFX_Player player = sfxPlayer.GetComponent<SFX_Player>();
        player.Play(tag);
        Explode();
        Destroy(gameObject);
    }

    public void Explode()
    {
        if (explosionPrefab == null)
        {
            Debug.Log(gameObject + " has no explosion prefab.");
        }
        Vector2 pos = transform.position;
        pos.y = pos.y + 0.5f;
        //Vector2 tf = gameObject.GetComponent<Rigidbody2D>().velocity;
        GameObject explosion = Instantiate(explosionPrefab, pos, Quaternion.identity);
        Rigidbody2D explosion_rb = explosion.GetComponent<Rigidbody2D>();
        //Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        explosion_rb.velocity = new Vector2(-1, 0);
    }
}
