using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public Animator camAnim;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            camAnim.SetBool("cutScene1", true);
            this.Wait(5f, () =>
            {
                StopCutscene();
            });
        }
    }

    void StopCutscene()
    {
        camAnim.SetBool("cutScene1", false);
    }
}
