using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        Debug.Log(materialName);

        if(materialName == "safe (Instance)")
        {

        } else if (materialName == "unsafe (Instance)")
        {
            GameManager.gameOver = true;
            FindObjectOfType<AudioManager>().Play("game over");

        } else if (materialName == "LastRing (Instance)")
        {
            GameManager.levelCompleted = true;
            audioManager.Play("win level");
        }
    }
}
