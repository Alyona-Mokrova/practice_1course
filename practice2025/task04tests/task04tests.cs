using Xunit;
using task04;
using System;

public class SpaceshipTests
{
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        ISpaceship cruiser = new Cruiser();
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
    }

    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.Speed > cruiser.Speed);
    }

    [Fact]
    public void Cruiser_FirePower_Greater_Than_Fighter_FirePower()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(cruiser.FirePower > fighter.FirePower);
    }

    [Fact]
    public void Cruiser_MoveForward_Method_Is_Callable()
    {
        var cruiser = new Cruiser();
        var exception = Record.Exception(() => cruiser.MoveForward());
        Assert.Null(exception);
    }

    [Fact]
    public void Fighter_MoveForward_Method_Is_Callable()
    {
        var fighter = new Fighter();
        var exception = Record.Exception(() => fighter.MoveForward());
        Assert.Null(exception);
    }

    [Fact]
    public void Cruiser_Fire_Method_Is_Callable()
    {
        var cruiser = new Cruiser();
        var exception = Record.Exception(() => cruiser.Fire());
        Assert.Null(exception);
    }

    [Fact]
    public void Fighter_Fire_Method_Is_Callable()
    {
        var fighter = new Fighter();
        var exception = Record.Exception(() => fighter.Fire());
        Assert.Null(exception);
    }

    [Fact]
    public void Cruiser_Rotate_Method_Is_Callable()
    {
        var cruiser = new Cruiser();
        var exception = Record.Exception(() =>
        {
            cruiser.Rotate(360);
            cruiser.Rotate(120);
            cruiser.Rotate(-45);
        });
        Assert.Null(exception);
    }

    [Fact]
    public void Fighter_Rotate_Method_Is_Callable()
    {
        var fighter = new Fighter();
        var exception = Record.Exception(() =>
        {
            fighter.Rotate(360);
            fighter.Rotate(120);
            fighter.Rotate(-45);
        });
        Assert.Null(exception);
    }
}
