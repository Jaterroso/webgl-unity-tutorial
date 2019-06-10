using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CollectibleUI collectible_ui;

    private int collected_amount;

    // Start is called before the first frame update
    void Start()
    {
        collected_amount = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            RaycastClick();
        }
    }

    private void Collect()
    {
        collected_amount += 1;
        UpateCollectedText();
    }

    private void UpateCollectedText()
    {
        collectible_ui.UpdateCollectedText(collected_amount);
    }

    private void RaycastClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "collectible")
            {
                Collect();
                hit.transform.gameObject.GetComponent<CollectibleComponent>().Collect();
            }
        }
    }
}
