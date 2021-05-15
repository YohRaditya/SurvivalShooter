using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public float speedUp = 4f;
    public float speedUpDur = 5f;
    public int healthUp = 20;

    GameObject player;
    PlayerHealth playerHealth;
    PlayerMovement speed;
    bool isBuffed = false;
    float timerbuff;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        speed = player.GetComponent<PlayerMovement>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            if (gameObject.tag == "BuffSpeed" && isBuffed == false)
            {
                Debug.Log("Masuk buff baru " + isBuffed);
                Buffstat();
                Vector3 temp = new Vector3(500, 500, 500);
                transform.position = temp;
                StartCoroutine(Wait(speedUpDur));

            }
            else
            {
                Debug.Log("Heal");
                Buffstat();
                Destroy(gameObject);
            }
        }
    }

    void resetSpeed()
    {
        isBuffed = false;
        speed.Raise(-speedUp);
    }

    void Buffstat()
    {
        playerHealth.Heal(healthUp);
        speed.Raise(speedUp);
    }

    private IEnumerator Wait(float second)
    {
        isBuffed = true;
        yield return new WaitForSecondsRealtime(second);
        Destroy(gameObject);
        resetSpeed();

    }
}
