/*Spinner.cs
 * Gameobject:      <object to spin>
 * Brief:           This script causes whatever object it is attached to to spin.
 * Author:          Drew Massey
 * Date Created:    05/19/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public bool freeRotate = false;

    private float spinSpeed = 8;
    private Vector3 spinRotation = new Vector3(15, 30, 45);

    // Start is called before the first frame update
    private void Start()
    {
        if(!freeRotate)
        {
            //this is y-axis spinning
            spinRotation = new Vector3(0, 30, 0);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Spin(spinRotation);
    }

    //Spins randomly
    private void Spin(Vector3 rot)
    {
        transform.Rotate(rot * spinSpeed * Time.deltaTime);
    }
}
