
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandAttack : PlayerAttack
{
    // Start is called before the first frame update

    [SerializeField] GameObject enegryBall;
    [SerializeField] GameObject effectHit;

    [SerializeField] float timeShoot;
    [SerializeField] Collider2D[] objectsToHit;
    // [SerializeField] IDamageAble isCanTakeDamage;

    bool canShoot = true;
    bool canRecoil;
    protected override void Awake()
    {
        base.Awake();

    }
    protected override void Start()
    {
        // Observer.AddListener(CONSTANT.CHANGE_EQUIP, base.RefershDamgae);
        // Observer.Notify(CONSTANT.CHANGE_EQUIP);
    }
    protected override void Update()
    {

        ShootAttack();
        Attack();

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        timeSinceAttack += Time.deltaTime;
        if (InputManager.Instance.attackInput && timeSinceAttack >= timeBetweenAttack)
        {
            timeSinceAttack = 0;
            Hit(attackPos, SideAttackArea);
            animator.SetTrigger("HandAttacking");
            animator.SetFloat("StateAttack", UnityEngine.Random.Range(0, 3));
        }
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

    }
    void ShootAttack()
    {
        if (InputManager.Instance.inputShoot && canShoot)
        {
            // Spawner();

            StartCoroutine(Shooting());
        }
    }
    IEnumerator Shooting()
    {

        canShoot = false;
        animator.SetTrigger("IsShooting");
        // Spawner();
        yield return new WaitForSeconds(timeShoot);
        canShoot = true;

    }


    void Spawner()
    {
        GameObject ojEnegryBall = BulletSpawner.Instance.Spawn(BulletSpawner.bulletName, attackPos.position, Quaternion.identity);
        if (ojEnegryBall == null)
        {
            return;
        }

        if (player.pState.lookingRight)
        {
            ojEnegryBall.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            ojEnegryBall.transform.eulerAngles = new Vector2(ojEnegryBall.transform.eulerAngles.x, 180);
        }
        ojEnegryBall.SetActive(true);
    }

    protected override void Hit(Transform _attackPos, Vector2 _SideAttackArea)
    {
        try
        {
            objectsToHit = Physics2D.OverlapBoxAll(attackPos.position, SideAttackArea, 0, enemyLayer);

            if (objectsToHit.Length > 0)
            {
                for (int i = 0; i < objectsToHit.Length; i++)
                {
                    IDamageAble isCanTakeDamage = objectsToHit[i].GetComponent<IDamageAble>();
                    if (isCanTakeDamage != null)
                    {
                        // GameObject ObjEffect = EffectSpawner.Instance.Spawn(objectsToHit[i].gameObject.transform.position, Quaternion.identity);
                        // ObjEffect.SetActive(true);
                        isCanTakeDamage.TakeDamage(damage);
                        GameObject newObj = EffectSpawner.Instance.Spawn(EffectSpawner.effectHit, objectsToHit[i].gameObject.transform.position, Quaternion.identity);
                        newObj.SetActive(true);
                    }

                }
            }
            else
            {
                return;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }







}



