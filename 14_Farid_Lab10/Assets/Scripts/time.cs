using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class time : MonoBehaviour
{
    int score;
    public Text scoretext;

    private void Start()
    {
        score = 0;
        scoretext.text = "Score : " + score.ToString();
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
