using System;

public class ColorGameObstacle : BaseObstacle
{
    public static Action ColorMinigameCathed;
    public override void OnCollisionPlayer(PlayerController player)
    {
        base.OnCollisionPlayer(player);
        ColorMinigameCathed?.Invoke();        
    }
}
