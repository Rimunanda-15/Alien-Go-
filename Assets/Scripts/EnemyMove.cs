using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ilumisoft.RadarSystem;
public class EnemyMove : MonoBehaviour
{
    public int healthPoint;
    public int damage;
    private GameObject player;
    public bool isAsteroid;
    public GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * 1f * Time.deltaTime;

        if(healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyEnemyCoroutine());
            other.GetComponent<Player>().decreaseHp(damage);
        }
    }

    IEnumerator DestroyEnemyCoroutine()
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        GetComponent<Locatable>().ClampOnRadar = false;
        Destroy(gameObject);

        yield return true;
    }
}
