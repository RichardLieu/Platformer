using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MarioHitbox : MonoBehaviour
{
    public float hitboxRange;
    public float sideRange;
    public int addScore = 00000;
    public int addCoin = 00;

    public GameObject scoreText;
    public GameObject coinCounterText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray headRay = new Ray(transform.position, Vector3.up);
        Ray leftSideRay = new Ray(transform.position, Vector3.right);
        Ray rightSideRay = new Ray(transform.position, Vector3.left);

        if (Physics.Raycast(headRay, out hit, hitboxRange) && Input.GetKeyDown(KeyCode.Space))
        {
            if (hit.collider.gameObject.CompareTag("BreakBrickButton"))
            {
                Destroy(hit.collider.gameObject);
                addScore += 100;
                scoreText.GetComponent<TextMeshProUGUI>().text = addScore.ToString();
            }
            if (hit.collider.gameObject.CompareTag("QuestionMarkButton"))
            {
                Destroy(hit.collider.gameObject);
                addScore += 100;
                addCoin += 1;
                scoreText.GetComponent<TextMeshProUGUI>().text = addScore.ToString();
                coinCounterText.GetComponent<TextMeshProUGUI>().text = addCoin.ToString();
            }
        }
    }

}