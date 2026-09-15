using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletPoint;
    public void OnAttack()
    {
        //Vector3 worldScaleMod = transform.lossyScale;
        //worldScaleMod.x = Mathf.Sign(worldScaleMod.x); // -1, 1
        float flipX = Mathf.Sign(transform.lossyScale.x);

        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, Quaternion.identity);
        Vector3 newScale = bullet.transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * flipX;
        bullet.transform.localScale = newScale;
    }
}
