using UnityEngine;
using zhk.BehaviourTree;
public class PlayerAttack : MonoBehaviour
{  
    private PlayerAnimatorControl playerAnimatorControl;
    private PlayerInput playerInput;

    private SequenceNode ComboAttackRootNode;
    private Rigidbody playerRigidbody;

    private Vector3 combo01 = new Vector3(-38.152f, -118.921f, 593.672f);

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();
        playerInput = GetComponent<PlayerInput>();

        AttackNode Attack = new AttackNode(playerAnimatorControl, playerInput);

        ComboAttackRootNode = new SequenceNode(3);
        ComboAttackRootNode.AttachNode(Attack);
        ComboAttackRootNode.AttachNode(Attack);
        ComboAttackRootNode.AttachNode(Attack);
    }

    private void Update()
    {
        if (playerRigidbody.velocity.y > 0)
        {
            return;
        }
        ComboAttackRootNode.Execute();
    }

    public void ResetComboAttack()
    {
        ComboAttackRootNode.ResetNode();
    }

    private class AttackNode : Node
    {
        private PlayerAnimatorControl playerAnimatorControl;
        private PlayerInput playerInput;

        public AttackNode(PlayerAnimatorControl playerAnimatorControl, PlayerInput playerInput){ 
            this.playerAnimatorControl = playerAnimatorControl;
            this.playerInput = playerInput;
        }

        public override NodeState Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimatorControl.SetTrigger("NextCombo");
                return NodeState.SUCCESS;
            }
            if (playerInput.GetPlayerMovementInput() != Vector2.zero) 
            {
                playerAnimatorControl.SetTrigger("RunTrigger");
                return NodeState.FAILURE;
            }

            return NodeState.RUNNING;
        }
    }
}

