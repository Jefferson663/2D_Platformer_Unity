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

        public Movement(Rigidbody2D body, float bodyVelocity, int direction)
        {
            this.bodyToMove = body;
            this.bodyVelocity = bodyVelocity;
            this.direction = direction;
            this.timeToStop = 1;
        }
        public Movement(Rigidbody2D body, float bodyVelocity, float jumpPower, int direction)
        {
            this.bodyToMove = body;
            this.bodyVelocity = bodyVelocity;
            this.jumpPower = jumpPower;
            this.direction = direction;
            this.timeToStop = 1;
        }
        public Movement(Rigidbody2D body, float bodyVelocity,float jumpPower, float velocityWhileJumping, int direction)
        {
            this.bodyToMove = body;
            this.bodyVelocity = bodyVelocity;
            this.jumpPower = jumpPower;
            this.velocityWhileJumping = velocityWhileJumping;
            this.direction = direction;
            this.timeToStop = 1;
        }
        public Movement(Rigidbody2D body, float bodyVelocity, float timeToStop, float jumpPower, float velocityWhileJumping, AudioManager audioManager)
        {
            this.bodyToMove = body;
            this.bodyVelocity = bodyVelocity;
            this.jumpPower = jumpPower;
            this.velocityWhileJumping = velocityWhileJumping;
            this.timeToStop = timeToStop;
            this.audioManager = audioManager;
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