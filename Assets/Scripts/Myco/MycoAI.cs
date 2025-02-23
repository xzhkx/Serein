using UnityEngine;
using zhk.BehaviourTree;
using zhk.EnemyBehaviorTree;

public class MycoAI : MonoBehaviour
{
    private EnemyDetectPlayerInRange enemyDetectPlayerInRange;
    private EnemyAnimatorControl enemyAnimatorControl;
    private EnemyChasePlayer enemyChasePlayer;
    private EnemyIdle enemyIdle;

    private FallbackNode MycoAIRootNode;

    private void Awake()
    {
        enemyDetectPlayerInRange = GetComponent<EnemyDetectPlayerInRange>();
        enemyAnimatorControl = GetComponent<EnemyAnimatorControl>();
        enemyChasePlayer = GetComponent<EnemyChasePlayer>();
        enemyIdle = GetComponent<EnemyIdle>();

        IdleStateNode idleStateNode = new IdleStateNode(enemyAnimatorControl, enemyDetectPlayerInRange, enemyIdle);
        RandomMovementNode randomMovementNode = new RandomMovementNode(enemyIdle, enemyDetectPlayerInRange);
        ChasePlayerNode chasePlayerNode = new ChasePlayerNode(enemyChasePlayer, enemyDetectPlayerInRange);
        AttackPlayerNode attackPlayerNode = new AttackPlayerNode(enemyAnimatorControl, enemyDetectPlayerInRange);
        RestAttackNode restAttackNode = new RestAttackNode(enemyAnimatorControl, enemyDetectPlayerInRange, enemyIdle);

        MycoAIRootNode = new FallbackNode(3);
        SequenceNode EnemyMovementNode = new SequenceNode(2);
        SequenceNode EnemyAttackNode = new SequenceNode(2);

        EnemyMovementNode.AttachNode(idleStateNode);
        EnemyMovementNode.AttachNode(randomMovementNode);
        EnemyAttackNode.AttachNode(attackPlayerNode);
        EnemyAttackNode.AttachNode(restAttackNode);

        MycoAIRootNode.AttachNode(EnemyMovementNode);
        MycoAIRootNode.AttachNode(chasePlayerNode);
        MycoAIRootNode.AttachNode(EnemyAttackNode);
    }

    private void Update()
    {
        MycoAIRootNode.Execute();
    }
}
