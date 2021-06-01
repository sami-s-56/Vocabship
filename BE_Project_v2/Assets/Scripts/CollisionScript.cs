using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{

    public AudioClip bLast = null;
    public GameObject GameMngr = null;

    private void Start()
    {
        GameMngr = GameObject.Find("GameManager");
        //Debug.Log(GameMngr.name);
    }

    //for this to work both need colliders, one must have rigid body (spaceship) the other must have is trigger checked.
    void OnTriggerEnter(Collider col)
    {
        
        
        GameObject explosion = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
        explosion.transform.position = transform.position;
        GetComponent<AudioSource>().PlayOneShot(clip: bLast);

        //Check Answer
        string currans = col.GetComponentInChildren<TextMesh>().text;
        GameMngr.GetComponent<ManagerScript>().AnswerCheck(currans);

        Destroy(col.gameObject);
        Destroy(explosion, 2);
        StartCoroutine(SceneReload());
        
    }

    IEnumerator SceneReload()
    {
        yield return new WaitForSeconds(bLast.length);
        SceneManager.LoadScene(1);
    }
}