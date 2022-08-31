using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(ReloadScene());
        }
    }
 
    IEnumerator ReloadScene() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

}
