using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public abstract class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    protected Rigidbody2D rb;
    [Header("Attack Infor ")]
    protected Animator animator;
    protected float timeSinceAttack;
    [SerializeField] protected float timeBetweenAttack;
    [SerializeField] protected Transform attackPos;
    [SerializeField] protected private Vector2 SideAttackArea;
    [SerializeField] protected float damage;
    [SerializeField] public LayerMask enemyLayer;
    protected PlayerController player;
    protected StatsHoder statsHoder;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        statsHoder = GetComponent<StatsHoder>();
        Observer.AddListener(CONSTANT.REFRESH_UISTAT, RefershDamgae);

    }
    protected abstract void Start();
    protected abstract void Update();
    protected abstract void Attack();
    protected void RefershDamgae(object[] datas)
    {
        int? temp = StatsHoder.Instance.StatModifiers.FirstOrDefault(i => i.ImpactedStat.attribute == Attributes.Strngth).ModifierValue;
        this.damage = temp.HasValue ? temp.Value : 10;

    }

    protected virtual void FixedUpdate()
    {
    }


    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackPos.position, SideAttackArea);
    }

    protected virtual void Hit(Transform _attackPos, Vector2 _SideAttackArea)
    {

    }
}



