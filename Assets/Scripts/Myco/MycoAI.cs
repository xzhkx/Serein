using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhk.BehaviourTree;

public class MycoAI : MonoBehaviour
{
    private DetectPlayerInRange detectPlayerInRange;
    private MycoAnimatorControl mycoAnimatorControl;
    private MycoChasePlayer mycoChasePlayer;

    private FallbackNode MycoAIRootNode;

    private void Awake()
    {
        detectPlayerInRange = GetComponent<DetectPlayerInRange>();
        mycoAnimatorControl = GetComponent<MycoAnimatorControl>();
        mycoChasePlayer = GetComponent<MycoChasePlayer>();


        NormalStateNode normalStateNode = new NormalStateNode(mycoAnimatorControl, detectPlayerInRange);
        ChasePlayerNode chasePlayerNode = new ChasePlayerNode(mycoChasePlayer, detectPlayerInRange);
        AttackPlayerNode attackPlayerNode = new AttackPlayerNode(mycoAnimatorControl, detectPlayerInRange);

        MycoAIRootNode = new FallbackNode(3);
        MycoAIRootNode.AttachNode(normalStateNode);
        MycoAIRootNode.AttachNode(chasePlayerNode);
        MycoAIRootNode.AttachNode(attackPlayerNode);
    }

    private void Update()
    {
        MycoAIRootNode.Execute();
    }

    private class NormalStateNode : Node
    {
        private DetectPlayerInRange detectPlayerInRange;
        private MycoAnimatorControl mycoAnimatorControl;

        public NormalStateNode(MycoAnimatorControl mycoAnimatorControl, DetectPlayerInRange detectPlayerInRange)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.mycoAnimatorControl = mycoAnimatorControl;
        }

        public override NodeState Execute()
        {
            if (detectPlayerInRange.IsPlayerInSightRange())
            {
                return NodeState.FAILURE;
            }
            else
            {
                mycoAnimatorControl.SetTrigger("IdleTrigger");
                return NodeState.RUNNING;
            }
        }
    } 

    private class ChasePlayerNode : Node
    {
        private DetectPlayerInRange detectPlayerInRange;
        private MycoChasePlayer mycoChasePlayer;

        public ChasePlayerNode(MycoChasePlayer mycoChasePlayer, DetectPlayerInRange detectPlayerInRange)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.mycoChasePlayer = mycoChasePlayer; 
        }

        public override NodeState Execute()
        {
            if(detectPlayerInRange.IsPlayerInAttackRange())
            {
                return NodeState.FAILURE;
            }
            if (detectPlayerInRange.IsPlayerInSightRange())
            {
                mycoChasePlayer.ChasePlayer();
                return NodeState.RUNNING;
            } 
            return NodeState.SUCCESS;
        }
    }

    private class AttackPlayerNode : Node
    {
        private DetectPlayerInRange detectPlayerInRange;
        private MycoAnimatorControl mycoAnimatorControl;

        public AttackPlayerNode(MycoAnimatorControl mycoAnimatorControl, DetectPlayerInRange detectPlayerInRange)
        {
            this.detectPlayerInRange = detectPlayerInRange;
            this.mycoAnimatorControl = mycoAnimatorControl;
        }

        public override NodeState Execute()
        {
            if (detectPlayerInRange.IsPlayerInAttackRange())
            {
                mycoAnimatorControl.SetTrigger("AttackTrigger");
                return NodeState.RUNNING;
            }
            else
            {
                return NodeState.FAILURE;
            }
        }
    }
}
