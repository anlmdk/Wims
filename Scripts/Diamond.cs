using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
            player.DiamondTotal += 1;
            DestroyObject(this.gameObject);
        }
    }
}
