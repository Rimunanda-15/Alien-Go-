using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int healthPoint;
    public int damage;
    private bool exploded = false;
    private GameObject player;
    public GameObject explosionFx;
    private GameObject instantiatedFx;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!exploded)
            {
                exploded = true;
                StartCoroutine(ExplodeCoroutine());
            }
            other.GetComponent<Player>().decreaseHp(damage);
        }
    }

    IEnumerator ExplodeCoroutine()
    {
        instantiatedFx = Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Destroy(instantiatedFx);
        Destroy(gameObject);
    }
}
