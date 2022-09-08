using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    public Animator anim;

    [SerializeField] private AudioClip fireballSound;

    float timeUntilFire;
    PlayerMovement pm;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pm = gameObject.GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        SoundManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("attack");
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
