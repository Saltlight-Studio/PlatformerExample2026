using UnityEngine;
using UnityEngine.Events;

public class ColorWall : MonoBehaviour
{
    public UnityEvent somethingTouchedWall;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Factions type = Factions.Orcs;
        int index = 1;
        switch (index)
        {
            case 0:

                break;
            case 2:

                break;


            /*case Factions.Orcs:
                sr.color = Color.darkGreen;
                break;
            case Factions.Ninjas:
                //sr.color = Color.purple;
                break;
            case Factions.Robots:
                sr.color = Color.gray;
                break;
            default:
                sr.color = Color.red;
                break;
        }*/

        Color color = Color.darkRed;
        SpriteRenderer collidingSr = collision.gameObject.GetComponent<SpriteRenderer>();
        if (collidingSr != null)
        {
            color = collidingSr.color;
        }
        sr.color = color;
        somethingTouchedWall.Invoke();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        sr.color = Color.white;
    }
}
