using zhk.BehaviourTree;

namespace zhk.EnemyBehaviorTree
{
    public class IdleStateNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyAnimatorControl enemyAnimatorControl;
        private EnemyIdle enemyIdle;

        public IdleStateNode(EnemyAnimatorControl enemyAnimatorControl, 
            EnemyDetectPlayerInRange detectPlayerInRange, EnemyIdle enemyIdle)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyAnimatorControl = enemyAnimatorControl;
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
                enemyAnimatorControl.SetTrigger("IdleTrigger");
                if (enemyIdle.NormalRest())
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

    public class ChasePlayerNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyChasePlayer enemyChasePlayer;
        private EnemyIdle enemyIdle;

        public ChasePlayerNode(EnemyChasePlayer enemyChasePlayer, EnemyDetectPlayerInRange detectPlayerInRange,
            EnemyIdle enemyIdle)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyChasePlayer = enemyChasePlayer;
            this.enemyIdle = enemyIdle;
        }

        public override NodeState Execute()
        {
            if (detectPlayerInRange.IsPlayerInAttackRange())
            {
                return NodeState.FAILURE;
            }
            if (detectPlayerInRange.IsPlayerInSightRange())
            {
                enemyChasePlayer.ChasePlayer();
                return NodeState.RUNNING;
            } else
            {
                if (enemyIdle.ResetPosition())
                {
                    return NodeState.SUCCESS;
                } else return NodeState.RUNNING;
            }
        }
    }

    public class AttackPlayerNode : Node
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
                return NodeState.SUCCESS;
            }
            else
            {
                return NodeState.FAILURE;
            }
        }
    }

    public class RestAttackNode : Node
    {
        private EnemyDetectPlayerInRange detectPlayerInRange;
        private EnemyAnimatorControl enemyAnimatorControl;
        private EnemyIdle enemyIdle;

        public RestAttackNode(EnemyAnimatorControl enemyAnimatorControl, 
            EnemyDetectPlayerInRange detectPlayerInRange, EnemyIdle enemyIdle)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.enemyAnimatorControl = enemyAnimatorControl;
            this.enemyIdle = enemyIdle;
        }

        public override NodeState Execute()
        {
            if (enemyIdle.RestAfterAttack())
            {
                return NodeState.SUCCESS;
            }
            else
            {
                enemyAnimatorControl.SetTrigger("IdleTrigger");
                return NodeState.RUNNING;
            }
        }
    }
}
