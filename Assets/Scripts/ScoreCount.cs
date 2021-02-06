using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Transform player;
    public Text score;
    // Update is called once per frame
    void Update()
    {
        float cur = player.position.z;
        score.text = cur.ToString("0");
    }
}
