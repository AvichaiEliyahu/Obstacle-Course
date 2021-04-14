using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Component c = GetComponent<MeshRenderer>();
        
        Debug.Log("Bumped into a wall! ("+c.name+")");
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
        }
        if (collision.gameObject.tag == "Player")
        {
            Invoke("ReloadScene", 1);
            collision.gameObject.GetComponent<Mover>().enabled = false;
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
