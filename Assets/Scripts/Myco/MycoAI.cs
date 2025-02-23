using UnityEngine;
using zhk.BehaviourTree;

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

        MycoAIRootNode = new FallbackNode(3);
        SequenceNode EnemyMovementNode = new SequenceNode(2);

        EnemyMovementNode.AttachNode(idleStateNode);
        EnemyMovementNode.AttachNode(randomMovementNode);
        MycoAIRootNode.AttachNode(EnemyMovementNode);
        MycoAIRootNode.AttachNode(chasePlayerNode);
        MycoAIRootNode.AttachNode(attackPlayerNode);
    }

    private void Update()
    {
        MycoAIRootNode.Execute();
    }

    private class IdleStateNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyAnimatorControl enemyAnimatorControl;
        private EnemyIdle enemyIdle;

        public IdleStateNode(EnemyAnimatorControl enemyAnimatorControl, EnemyDetectPlayerInRange detectPlayerInRange
            ,EnemyIdle enemyIdle)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyAnimatorControl = enemyAnimatorControl;
            this.enemyIdle = enemyIdle;
        }

        public override NodeState Execute()
        {
            Debug.Log("IdleState");
            if (detectPlayerInRange.IsPlayerInSightRange())
            {
                return NodeState.FAILURE;
            }
            else
            {
                enemyAnimatorControl.SetTrigger("IdleTrigger");
                if (enemyIdle.Rest())
                {
                    return NodeState.SUCCESS;
                }
                return NodeState.RUNNING;
            }
        }
    } 

    private class RandomMovementNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyIdle enemyIdle;

        public RandomMovementNode(EnemyIdle enemyIdle, EnemyDetectPlayerInRange detectPlayerInRange)
        {
            this.enemyIdle = enemyIdle;
            this.detectPlayerInRange = detectPlayerInRange;
        }

        public override NodeState Execute()
        {
            if (detectPlayerInRange.IsPlayerInSightRange())
            {
                return NodeState.FAILURE;
            }
            else
            {
                if (enemyIdle.RandomMovement())
                {
                    return NodeState.SUCCESS;
                }
                return NodeState.RUNNING;
            }
        }
    }

    private class ChasePlayerNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyChasePlayer enemyChasePlayer;

        public ChasePlayerNode(EnemyChasePlayer enemyChasePlayer, EnemyDetectPlayerInRange detectPlayerInRange)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyChasePlayer = enemyChasePlayer; 
        }

        public override NodeState Execute()
        {
            if(detectPlayerInRange.IsPlayerInAttackRange())
            {
                return NodeState.FAILURE;
            }
            if (detectPlayerInRange.IsPlayerInSightRange())
            {
                enemyChasePlayer.ChasePlayer();
                return NodeState.RUNNING;
            } 
            return NodeState.SUCCESS;
        }
    }

    private class AttackPlayerNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyAnimatorControl enemyAnimatorControl;

        public AttackPlayerNode(EnemyAnimatorControl enemyAnimatorControl, EnemyDetectPlayerInRange detectPlayerInRange)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyAnimatorControl = enemyAnimatorControl;
        }

        public override NodeState Execute()
        {
            if (detectPlayerInRange.IsPlayerInAttackRange())
            {
                enemyAnimatorControl.SetTrigger("AttackTrigger");
                return NodeState.RUNNING; //-> sequence rest
            }
            else
            {
                return NodeState.FAILURE;
            }
        }
    }
}
