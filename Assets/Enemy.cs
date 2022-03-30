using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public TextMesh healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0) {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("bullet")) {
            health = health - 27;
            healthText.text = health.ToString();
        }
    }

}
