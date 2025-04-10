using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Base script of all projectile behaviours
/// </summary>
public class ProjectileWeaponBehavior : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    //Current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCoolDownDuration;
    protected int currentPierce;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCoolDownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector2 dir)
    {
        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        float rotationZ = 0f;

        // Rotation based on direction

        if (dirX < 0 && dirY == 0) // left
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else if (dirX == 0 && dirY < 0) // down
        {
            scale.y = Mathf.Abs(scale.y) * -1;
            rotationZ = -90f; // Rotate counterclockwise 90 degrees when moving down
        }
        else if (dirX == 0 && dirY > 0) // up
        {
            scale.y = Mathf.Abs(scale.y);
            rotationZ = 90f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); //currentDamage instead of weaponData.damage in case of future damage modifiers
            ReducePierce();

        }else if (col.CompareTag("Prop"))
        {

            if(col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
                ReducePierce();
            }
        }
    }

    void ReducePierce()//Destroy once pierce reaches 0
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
