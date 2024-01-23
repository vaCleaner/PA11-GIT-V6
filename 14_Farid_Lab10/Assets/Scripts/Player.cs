using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private float objectWidth;
    private float objectHeight;
    public float speed;
    public Camera MainCamera;
    private Vector2 screenbound;
    private float ObjectW;
    private float ObjectH;
    int score;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        screenbound = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        ObjectW = transform.GetComponent<MeshRenderer>().bounds.extents.x; 
        ObjectH = transform.GetComponent<MeshRenderer>().bounds.extents.y;
        score = 0;
        scoretext.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

      

    }
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenbound.y * -1 + ObjectH, screenbound.y - ObjectH);

        transform.position = viewPos;
    }



    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");



        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {

            score += 1;
            scoretext.text = "Score : " + score.ToString();
           


        }
    }






}
