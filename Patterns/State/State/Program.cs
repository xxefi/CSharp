class Program
{
    static void Main()
    {
        Context context = new Context(new StateA());

        context.Request();
        context.Request();
        context.Request();
        context.Request();
        
        //сделал это 4 раза, чтобы заметить изменение состояний объекта(или обьекта) :)
        //выйдет: 1.B 2.A. Потому-что в первом объекте вызывается состояния объекта B, а у объекта B вызывается состояния объекта A.
        //если вызвать допустим 8 раз, выйдет: B,A,B,A,B,A,B, но я думаю, что это и так понятно
    }
}