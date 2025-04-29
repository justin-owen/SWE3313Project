namespace Luckys_Cars;

public class CartStateService
{
    public bool HasCart { get; private set; }

    public event Action? OnChange;

    public void SetCartStatus(bool hasCart)
    {
        Console.WriteLine($"[DEBUG] SetCartStatus called with hasCart = {hasCart}");
        HasCart = hasCart;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
