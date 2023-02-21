using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseBreak : MonoBehaviour
{
    public Camera camera;
    public GameObject coinCount;
    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        coinCount.GetComponent<TextMeshProUGUI>().text = "Coins\n" + coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.CompareTag("BreakBrickButton"))
                {
                    Destroy(hitInfo.collider.gameObject);
                }
                else if (hitInfo.collider.gameObject.CompareTag("QuestionMarkButton"))
                {
                    Debug.Log("Question Mark Block been tapped :D");
                    coins++;
                    coinCount.GetComponent<TextMeshProUGUI>().text = "Coins\n" + coins.ToString();
                }
            }
        }
    }
}
