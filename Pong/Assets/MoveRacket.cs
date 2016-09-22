using UnityEngine;
using System.Collections;

public class MoveRacket : MonoBehaviour {
    public float pspeed = 30;
    public string vaxis = "Vertical";
    public string haxis = "Horizontal";
    public int difficulty = 0;
    bool controlled = false;

    void FixedUpdate() {
        
        //Useful stuff
        Rigidbody2D ballobj = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        Vector2 ballvel = ballobj.velocity;
        Vector2 ballcord = ballobj.position;
        float ballx = ballobj.position.x;
        float bally = ballobj.position.y;
        Rigidbody2D me = GetComponent<Rigidbody2D>();
        Debug.Log(ballobj.velocity.y / ballobj.velocity.x * (me.position.x) + ballobj.position.y);
        //Player Input
        float vinput = Input.GetAxisRaw(vaxis);
        float hinput = Input.GetAxisRaw(haxis);
        me.velocity = new Vector2(me.velocity.x, vinput * pspeed);
        //Move sideways???      me.velocity = new Vector2(hinput * speed, me.velocity.y);

        if (vinput != 0)
        {
            controlled = true;
        }

        if (difficulty == 0 && !controlled /*&& ballobj.velocity.x < 0*/)
        {
            float difference = me.position.y - ballobj.position.y;

                if (difference < -0.01)
                {
                    me.velocity = new Vector2(me.velocity.x, -difference * 8 - 3);
                }
                else if (difference > 0.01)
                {
                    me.velocity = new Vector2(me.velocity.x, -difference * 8 + 3);
                }
        }
        if (difficulty == 1 && !controlled)
        {
            if (me.position.y < ballobj.position.y)
            {
                float y = ballobj.velocity.y / ballobj.velocity.x * (ballobj.position.x) + ballobj.position.y;

                me.velocity = new Vector2(me.velocity.x, 1 * pspeed);
            }
            else if (me.position.y > ballobj.position.y)
            {
                me.velocity = new Vector2(me.velocity.x, -1 * pspeed);
            }
        }
    }   
}
