using UnityEngine;

using zhk.BehaviourTree;
using zhk.EnemyBehaviorTree;

public class SwordAI : MonoBehaviour
{
    [Header("Idle")]

    [SerializeField]
    private float restTimer;

    //-----------------------//

    [Header("Random Movement")]

    [SerializeField]
    private float activeRangeRadius;

    [SerializeField]
    private float runSpeed;

    //-----------------------//

    [Header("Chase")]

    [SerializeField]
    private float chaseSpeed;

    //-----------------------//

    [Header("Attack")]

    [SerializeField]
    private float attackDamage;

    //-----------------------//

    [Header("Detect")]

    [SerializeField]
    private LayerMask playerLayerMask;

    [SerializeField]
    private float sightRangeRadius;

    [SerializeField]
    private float attackRangeRadius;

    //-----------------------//

    [Header("Attack Idle")]

    [SerializeField]
    private float restAfterAttackTimer;

    //-----------------------//

    private FallbackNode rootNode;

    private void Awake()
    {
        EnemyAnimatorControl enemyAnimatorControl = GetComponent<EnemyAnimatorControl>();
        GetTargetTransform getTargetTransform = GetComponent<GetTargetTransform>();

        Transform currentTransform = transform;
        Rigidbody enemyRigidbody = GetComponent<Rigidbody>();

        //-----------------------//

        EnemyDetectPlayerInRange detectInRange = new EnemyDetectPlayerInRange(currentTransform,
            playerLayerMask, sightRangeRadius, attackRangeRadius);

        EnemyIdle idle = new EnemyIdle(enemyAnimatorControl, currentTransform, enemyRigidbody, restTimer);
        IdleStateNode idleStateNode = new IdleStateNode(detectInRange, idle);

        EnemyRandomMovement randomMovement = new EnemyRandomMovement(enemyAnimatorControl, currentTransform,
            enemyRigidbody, activeRangeRadius, runSpeed);
        RandomMovementNode randomMovementNode = new RandomMovementNode(randomMovement, detectInRange);

        EnemyChasePlayer chasePlayer = new EnemyChasePlayer(currentTransform, enemyRigidbody,
            runSpeed, chaseSpeed);
        ChasePlayerNode chasePlayerNode = new ChasePlayerNode(chasePlayer, detectInRange, getTargetTransform);

        EnemyAttack attack = new EnemyAttack(enemyAnimatorControl, attackDamage);
        AttackPlayerNode attackPlayerNode = new AttackPlayerNode(detectInRange, attack);

        EnemyAttackIdle attackIdle = new EnemyAttackIdle(enemyAnimatorControl, currentTransform,
            enemyRigidbody, restAfterAttackTimer);
        IdleAttackNode idleAttackNode = new IdleAttackNode(detectInRange, attackIdle, getTargetTransform);

        //-----------------------//

        rootNode = new FallbackNode(3);

        SequenceNode enemyMovementSequence = new SequenceNode(2);
        enemyMovementSequence.AttachNode(idleStateNode);
        enemyMovementSequence.AttachNode(randomMovementNode);

        SequenceNode enemyAttackSequence = new SequenceNode(2);
        enemyAttackSequence.AttachNode(attackPlayerNode);
        enemyAttackSequence.AttachNode(idleAttackNode);

        rootNode.AttachNode(enemyMovementSequence);
        rootNode.AttachNode(chasePlayerNode);
        rootNode.AttachNode(enemyAttackSequence);
    }

    private void Update()
    {
        rootNode.Execute();
    }
}
