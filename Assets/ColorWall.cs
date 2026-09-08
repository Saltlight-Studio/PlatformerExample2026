using UnityEngine;

public class ColorWall : MonoBehaviour
{
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color color = Color.darkRed;
        SpriteRenderer collidingSr = collision.gameObject.GetComponent<SpriteRenderer>();
        if (collidingSr != null)
        {
            color = collidingSr.color;
        }
        sr.color = color;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        sr.color = Color.white;
    }
}
