using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ilumisoft.RadarSystem;
public class EnemyMove : MonoBehaviour
{
    public int healthPoint;
    public int damage;
    public float speed;
    private GameObject player;
    public bool isAsteroid;
    public bool isContainPowerUp;
    public GameObject explosionParticle;
    public GameObject powerUp;
    private AudioSource enemyDiedSfx;

    // Start is called before the first frame update
    void Start()
    {
        enemyDiedSfx = GameObject.Find("EnemyDiedSfx").GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * speed * Time.deltaTime;

        if(healthPoint <= 0)
        {
            if(isContainPowerUp)
            {
                StartCoroutine(DeployPowerUp());
            }

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
            enemyDiedSfx.Play();
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

    IEnumerator DeployPowerUp()
    {
        Instantiate(powerUp, transform.position, powerUp.transform.rotation);

        yield return true;
    }
}
