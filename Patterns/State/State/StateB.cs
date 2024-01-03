public class StateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Обработка в состояний A");
        context.State = new StateA();
    }
}