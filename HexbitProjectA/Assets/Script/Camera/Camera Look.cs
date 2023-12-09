using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Animator camAnim;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            camAnim.SetBool("Look1", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        camAnim.SetBool("Look1", false);
    }
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            camAnim.SetBool("Look1", true);

            this.Wait(5f, () =>
            {
                StopCutscene();
            });
    }
    void StopCutscene()
    {
        camAnim.SetBool("cutScene1", false);
    }
    */
}
