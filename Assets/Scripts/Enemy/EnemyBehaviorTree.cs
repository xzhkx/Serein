using zhk.BehaviourTree;

namespace zhk.EnemyBehaviorTree
{
    public class IdleStateNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyIdle enemyIdle;

        public IdleStateNode(EnemyDetectPlayerInRange detectPlayerInRange, EnemyIdle enemyIdle)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyIdle = enemyIdle;
        }

        public override NodeState Execute()
        {
            if (detectPlayerInRange.IsPlayerInSightRange())
            {
                return NodeState.FAILURE;
            }
            else
            {
                if (enemyIdle.Rest())
                {
                    return NodeState.SUCCESS;
                }
                return NodeState.RUNNING;
            }
        }
    }

    public class RandomMovementNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyRandomMovement enemyRandomMovement;

        public RandomMovementNode(EnemyRandomMovement enemyRandomMovement, 
            EnemyDetectPlayerInRange detectPlayerInRange)
        {
            this.enemyRandomMovement = enemyRandomMovement;
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
                if (enemyRandomMovement.RandomMovement())
                {
                    return NodeState.SUCCESS;
                }
                return NodeState.RUNNING;
            }
        }
    }

    public class ChasePlayerNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyChasePlayer enemyChasePlayer;
        private GetTargetTransform getTargetTransform;

        public ChasePlayerNode(EnemyChasePlayer enemyChasePlayer, 
            EnemyDetectPlayerInRange detectPlayerInRange, GetTargetTransform getTargetTransform)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyChasePlayer = enemyChasePlayer;
            this.getTargetTransform = getTargetTransform;
        }

        public override NodeState Execute()
        {
            if (detectPlayerInRange.IsPlayerInAttackRange())
            {
                return NodeState.FAILURE;
            }
            if (detectPlayerInRange.IsPlayerInSightRange())
            {
                if(getTargetTransform.GetTarget() == null) return NodeState.SUCCESS;
                enemyChasePlayer.ChasePlayer(getTargetTransform.GetTarget());
                return NodeState.RUNNING;
            } else
            {
                if (enemyChasePlayer.ResetPosition())
                {
                    return NodeState.SUCCESS;
                } else return NodeState.RUNNING;
            }
        }
    }

    public class AttackPlayerNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyAttack enemyAttack;

        public AttackPlayerNode(EnemyDetectPlayerInRange detectPlayerInRange, EnemyAttack enemyAttack)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyAttack = enemyAttack;
        }

        public override NodeState Execute()
        {
            if (detectPlayerInRange.IsPlayerInAttackRange())
            {
                enemyAttack.AttackPlayer();
                return NodeState.SUCCESS;
            }
            else
            {
                return NodeState.FAILURE;
            }
        }
    }

    public class IdleAttackNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyAttackIdle enemyAttackIdle;
        private GetTargetTransform getTargetTransform;

        public IdleAttackNode(EnemyDetectPlayerInRange detectPlayerInRange, 
            EnemyAttackIdle enemyAttackIdle, GetTargetTransform getTargetTransform)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyAttackIdle = enemyAttackIdle;
            this.getTargetTransform = getTargetTransform;
        }

        public override NodeState Execute()
        {
            if (getTargetTransform.GetTarget() == null) return NodeState.SUCCESS;

            bool rest = enemyAttackIdle.RestAfterAttack(getTargetTransform.GetTarget());
            if (rest)
            {
                return NodeState.SUCCESS;
            }
            else
            {
                return NodeState.RUNNING;
            }
        }
    }
}
