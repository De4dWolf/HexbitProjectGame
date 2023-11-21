using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    protected GameObject playerObject;
    protected PlayerManager player;


    protected bool IsCollected = false;
    public GameObject target;

    [SerializeField] private float shrinkSpeed = 0.2f;

    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerManager>();

        target = GameObject.FindWithTag("PickupTarget");

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    protected virtual void Update()
    {
        if (IsCollected)
        {
            StartCoroutine(ShrinkOverTime());
            transform.position = Vector3.Lerp(transform.position, target.transform.position, 8f * Time.deltaTime);
        }
    }

    protected IEnumerator ShrinkOverTime()
    {
        while (transform.localScale.x > 0.1f) 
        {
            transform.localScale -= new Vector3(shrinkSpeed * Time.deltaTime, shrinkSpeed * Time.deltaTime, 0);
            yield return null;
        }
        Destroy(gameObject);
    }
}
