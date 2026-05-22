namespace calculator;

using Domain;
using FluentAssertions;

public class CalculatorTests
{
    [Theory]
    [InlineData(3, 1, 2)]
    [InlineData(5, 2, 3)]
    public void Booking_reduces_remaining_seats(int seatCapacity, int seatsToBook, int expectedRemainingSeats)
    {
        var flight = new Flight(seatCapacity);
        flight.Book("jannick@tutorialeu.com", seatsToBook);
        flight.RemainingNumberOfSeats.Should().Be(expectedRemainingSeats);
    }
    //NOTE - You can run the tests with dotnet test or dotnet test --filter "Name=<nameofthe test>"
    [Fact]
    public void Sum_of_2_and_2_should_be_4()
    {
        Calculator calculator = new();
        int result = calculator.Sum(2, 2);
        // if (result != 4) throw new Exception($"The Sum(2,2) was exprected to be 4 but it's {result}.");
        result.Should().Be(4);

    }

    [Fact]

    public void Booking_a_seat_should_reduce_remaining_seats()
    {
        var flight = new Flight(seatCapacity: 3);
        flight.Book("jannick@tutorialeu.com", 1);
        flight.RemainingNumberOfSeats.Should().Be(2);
    }

    [Fact]
    public void Avoids_overbooking()
    {
        // Given
        var flight = new Flight(3);

        // When
        var error = flight.Book("jannick@tutorialeu.com", 4);
        // Then

        error.Should().BeOfType<OverbookingError>();
    }

    [Fact]
    public void Books_flights_succesfully()
    {
        var flight = new Flight(3);
        var error = flight.Book("jannick@tutorialeu.com", 2);
        error.Should().BeNull();
        flight.RemainingNumberOfSeats.Should().Be(1);
    }


}
