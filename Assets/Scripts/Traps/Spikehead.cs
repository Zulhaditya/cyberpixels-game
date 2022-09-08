using UnityEngine;

public class Spikehead : Enemy_Damage
{
    [Header("Spikehead Attribute")] 
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private float checkTimer;
    private Vector3 destination;
    private bool attacking;

    [Header("SFX")]
    [SerializeField] private AudioClip spikeSound;

    private void OnEnable()
    {
        Stop();
    }
    private void Update()
    {
        // spike akan bergerak ke tempat yang disett jika menyerang
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();

        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirections()
    {
        directions[0] = transform.right * range; // arah kanan
        directions[1] = -transform.right * range; // arah kiri
        directions[2] = transform.up * range; // arah atas
        directions[3] = -transform.up * range; // arah bawah
    }

    private void Stop()
    {
        destination = transform.position; // setting destinasi spikehead
        attacking = false;
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySound(spikeSound);
        base.OnTriggerEnter2D(collision);
        Stop(); // Stop spikehead disaat ngehit player atau object
    }
}
