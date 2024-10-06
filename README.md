# Command Example

Цей репозиторій містить приклад патерну проектування "Команда".

## Патерн Команда (Command)

Патерн "Команда" дозволяє інкапсулювати запити як об'єкти, що дозволяє параметризувати методи, ставити в чергу або логувати запити, а також підтримувати операції скасування.

### Приклад коду:

```csharp
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
        _light.On();
    }
}

// Конкретна команда
public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }
}

// Отримувач
public class Light
{
    public void On()
    {
        Console.WriteLine("Світло ввімкнено.");
    }

    public void Off()
    {
        Console.WriteLine("Світло вимкнено.");
    }
}

// Виконавець команд
public class RemoteControl
{
    private readonly List<ICommand> _commands = new List<ICommand>();

    public void SetCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void PressButton()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }
}

// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        var light = new Light();
        var lightOn = new LightOnCommand(light);
        var lightOff = new LightOffCommand(light);

        var remote = new RemoteControl();
        remote.SetCommand(lightOn);
        remote.SetCommand(lightOff);

        remote.PressButton();
    }
}
