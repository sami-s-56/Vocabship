using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour {

    Gyroscope gyro;
    Quaternion rott;
    GameObject cameraContainer;
    WebCamTexture webCamTexture;
    public GameObject projectionPlane;
    public Transform CrossHair;
    
        
    public Button fireButton;
    public GameObject bull;
    

	// Use this for initialization
	void Start () {


        for(int i=0; i < WebCamTexture.devices.Length; i++)
        {
            if (WebCamTexture.devices[i].isFrontFacing)
            {
                webCamTexture = new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
            
        }


        cameraContainer = new GameObject("CameraContainer");
        transform.SetParent(cameraContainer.transform);
        gyro = Input.gyro;
        gyro.enabled = true;

        cameraContainer.transform.rotation = Quaternion.Euler(90f, 0, 0);
        rott = new Quaternion(0, 0, 1, 0);

        webCamTexture.Play();
        projectionPlane.GetComponent<Renderer>().material.mainTexture = webCamTexture;
        
        
        fireButton.onClick.AddListener(OnFire);
	}
    
    void OnFire()
    {
        GameObject bullet = Instantiate(bull) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = Camera.main.transform.rotation;
        bullet.transform.position = CrossHair.position;
        rb.AddForce(Camera.main.transform.forward * 4000f);
        Destroy(bullet, 5);

        GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update () {
        
        transform.localRotation = gyro.attitude * rott;

    }
}
