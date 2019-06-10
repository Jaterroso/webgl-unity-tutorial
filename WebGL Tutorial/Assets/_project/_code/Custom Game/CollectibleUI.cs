/* CollectibleUI.cs
 * Gameobject:      <object to spin>
 * Brief:           This script causes whatever object it is attached to to spin.
 * Author:          Drew Massey
 * Date Created:    05/19/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleUI : MonoBehaviour
{
    public TextMeshProUGUI coin_text;

    // Start is called before the first frame update
    void Start()
    {
        coin_text.text = "0";
    }

    public void UpdateCollectedText(int amt)
    {
        coin_text.text = amt.ToString();
    }
}
