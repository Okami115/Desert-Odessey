using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Variables")]
    [SerializeField] private string id;
    [SerializeField] private int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] private float speed;
    [SerializeField] protected int damegeScale;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;
    [SerializeField] private Animator animator;

    [Header("Player Config")]
    [SerializeField] protected PlayerConfig playerConfig;

    public string ID { get => id; set => id = value; }
    public int HP { get => hp; set => hp = value; }
    public Transform Player { get => target; set => target = value; }

    private void Start()
    {
        hp = maxHP;
        target = FindAnyObjectByType<PlayerController>().gameObject.transform;
    }
    void Update()
    {
        if (!playerConfig.isPause) 
        { 
            Vector3 direccion = target.position - transform.position;
            direccion.Normalize();

            rb.AddForce(direccion * speed * Time.deltaTime, ForceMode2D.Force);
            animator.StopPlayback();
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.StartPlayback();
        }
    }

}
