public class EnemyCloseCombat : Enemy
{
    protected override void Attack()
    {
        Tower.Instance.TakeDamage(_attackDamage);
    }
}
