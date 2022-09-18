﻿try
{
    Square evt = new Square();
    SquareDelegate deleg = evt.Perimeter;
    deleg += evt.Sqr;
    deleg += evt.TriangleSide;

    evt.Notify += new SquareDelegate(evt.Perimeter);
    evt.Notify += new SquareDelegate(evt.Sqr);
    evt.Notify += new SquareDelegate(evt.TriangleSide);

    Console.Write("Введите сторону квадрата: ");
    int side = Convert.ToInt32(Console.ReadLine());

    evt.Start(side);
    evt.DelegateInit(deleg, side);
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

delegate void SquareDelegate(int side);
class Square
{
    public event SquareDelegate? Notify;

    public void Start(int side)
    {
        Notify?.Invoke(side);
    }

    public void Perimeter(int side)
    {
        int per = side * 4;
        Console.WriteLine(per);
    }

    public void Sqr(int side)
    {
        int sqr = side * side;
        Console.WriteLine(sqr);
    }

    public void TriangleSide(int side)
    {
        Console.WriteLine(side);
    }

    public void DelegateInit(SquareDelegate deleg, int side)
    {
        deleg(side);
    }
}