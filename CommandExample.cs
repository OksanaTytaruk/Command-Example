using System;
using System.Collections.Generic;

// Інтерфейс команди
public interface ICommand
{
    void Execute();
}

// Конкретна команда
public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

// Конкретна команда
public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light
