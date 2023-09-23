using UnityEngine;


namespace Behavior.SpriteManager{
public class ManageSprites 
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private string jumpTag;
    private string idleTag;
    private string hurtTag;
    private string runTag;
    public ManageSprites(SpriteRenderer renderer, Animator animator, string jump, string hurt, string run) {
        this.spriteRenderer = renderer;
        this.animator = animator;
        this.jumpTag = jump;
        this.hurtTag = hurt;
        this.runTag = run;
    }
    public void spriteLookRight(){
        spriteRenderer.flipX = false;
    }
    public void spriteLookLeft(){
        spriteRenderer.flipX = true;
    }
    public void JumpAnimation(){
        animator.SetBool(jumpTag, true);
    }
    public void EndJumpAnimation(){
        animator.SetBool(jumpTag, false);
    }
    public void HurtAnimation(){
        animator.SetBool(hurtTag, true);
    }
    public void EndHurtAnimation(){
        animator.SetBool(hurtTag, false);
    }
    public void RunAnimation(){
        animator.SetBool(runTag, true);
    }
    public void EndRunAnimation(){
        animator.SetBool(runTag, false);
    }

    private Sprite idleSprite;
    private Sprite hurtSprite;
    private Sprite jumpSprite;
    public ManageSprites(SpriteRenderer renderer, Sprite idle, Sprite hurt, Sprite jump) {
        this.spriteRenderer = renderer;
        this.idleSprite = idle;
        this.hurtSprite = hurt;
        this.jumpSprite = jump;
        IdleSprite();
    }
    public void IdleSprite(){
        spriteRenderer.sprite = idleSprite;
    }
    public void JumpSprite(){
        spriteRenderer.sprite = jumpSprite;
    }
    public void GetHurtSprite(){
        spriteRenderer.sprite = hurtSprite;
    }
}
}