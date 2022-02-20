using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public player player;
     public float respawanTime = 3.0f;
     public int lives = 3;

    private void playerDied()
    {
        this.lives--;
         if (this.lives < 0) {
             Gameover();
         } else {
             Invoke(nameof(Respawn), this.respawanTime);
         }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
        }
        private void Gameover() {

        }
    }

    

