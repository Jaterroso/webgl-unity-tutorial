/* CollectibleComponent.cs
 * Gameobject:      <Collectible>
 * Brief:           This is the behaviour script for a collectible component
 * Author:          Drew Massey
 * Date Created:    05/19/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleComponent : MonoBehaviour
{
    public CollectibleEntity collectible_template;

    private CollectibleEntity collectible;

    // Awake is called before Start
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Collect()
    {
        Recycle();
    }

    private void Recycle()
    {
        Destroy(gameObject);
    }
}
