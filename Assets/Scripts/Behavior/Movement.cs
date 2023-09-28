using UnityEngine;

namespace Behavior.Movement
{
    public class Movement
    {
        private Rigidbody2D bodyToMove;
        private int direction;
        private float bodyVelocity;
        private float jumpPower;
        private float velocityWhileJumping;
        private float timeToStop;
        private AudioManager audioManager;

        public Movement(BasicEnemy enemy){
            this.bodyToMove = enemy.enemyBody;
            this.bodyVelocity = enemy.runSpeed;
            this.direction = enemy.direction;
        }
        public Movement(JumpingEnemy enemy){
            this.bodyToMove = enemy.enemyBody;
            this.bodyVelocity = enemy.runSpeed;
            this.direction = enemy.direction;
            this.jumpPower = enemy.jumpPower;
        }
        public Movement(PlayerStateManager player)
        {
            this.bodyToMove = player.playerBody;
            this.bodyVelocity = player.velocity;
            this.jumpPower = player.jumpingPower;
            this.velocityWhileJumping = player.velocityWhenJumping;
            this.timeToStop = player.abruptStop;
            this.audioManager = player.audioManager;
        }

        public void MoveBody(int direction)
        {
            bodyToMove.velocity = new Vector3(direction * bodyVelocity, bodyToMove.velocity.y);
        }
        public void MoveBody()
        {
            bodyToMove.velocity = new Vector3(direction * bodyVelocity, bodyToMove.velocity.y);
        }
        public void Stop()
        {
            bodyToMove.velocity *= timeToStop;
        }
        public void MoveBodyWhileJumping(int direction)
        {
            bodyToMove.velocity = new Vector3(direction * bodyVelocity * velocityWhileJumping, bodyToMove.velocity.y);
        }
        public void Jump()
        {
            bodyToMove.velocity = new Vector3(bodyToMove.velocity.x, jumpPower);
        }
        public int Jump(int jumps)
        {
            if(jumps > 0)
            {
                bodyToMove.velocity = new Vector3(bodyToMove.velocity.x, jumpPower);
                this.audioManager.PlaySound("Jump");
            }
            return --jumps;
        }
        public void TurnAround()
        {
            direction *= -1;
        }
        public int CheckDirection()
        {
            return direction;
        }
    }
}
