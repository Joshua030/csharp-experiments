
namespace Domain;

public class Flight(int seatCapacity)
{
    public int RemainingNumberOfSeats { get; private set; } = seatCapacity;
    private int seatCapacity = seatCapacity;

    public object? Book(string v1, int v2)
    {
        if (v2 > RemainingNumberOfSeats) return new OverbookingError();
        RemainingNumberOfSeats -= v2;
        return null;
    }
}