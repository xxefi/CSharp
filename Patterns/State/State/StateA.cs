public class StateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Обработка в состояний B");
        context.State = new StateB();
    }

}
