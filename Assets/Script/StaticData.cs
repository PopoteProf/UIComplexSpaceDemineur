using System;

public static class StaticData
{
    public static event EventHandler OnDoorUnlock;
    public static event EventHandler OnPlayerLose;
    public static event EventHandler OnPlayerWin;
    public static event EventHandler OnPlayerLifeChanged;
    public static event EventHandler<int> OnMineExplodeCountChange;
    public static event EventHandler<int> OnMineDeactivatedCountChange;
    
    public static int PlayerLifes=3;
    public static int DeactivatedMineCount;
    public static int ExplodedMineCount;
    public static void PlayerTakeDamage() {
        PlayerLifes--;
        OnPlayerLifeChanged?.Invoke(null, null);
        if (PlayerLifes <= 0) {
            OnPlayerLose?.Invoke(null, EventArgs.Empty);
        }
    }

    public static void MineDeactivated() {
        DeactivatedMineCount++;
        OnMineDeactivatedCountChange?.Invoke(null, DeactivatedMineCount);
    }

    public static void ExplodedMine() {
        ExplodedMineCount++;
        OnMineExplodeCountChange?.Invoke(null, ExplodedMineCount);
    }

    public static void DoPlayerWin() => OnPlayerWin?.Invoke(null, EventArgs.Empty);
    public static void DoDoorUnlock() => OnDoorUnlock?.Invoke(null, EventArgs.Empty);
    
    
    
}