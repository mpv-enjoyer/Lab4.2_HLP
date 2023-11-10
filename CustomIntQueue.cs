using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class QueueElement
{ 
    int CurrentElement = 0;
    QueueElement? NextElement = null;
    public QueueElement(int element = 0)
    {
        CurrentElement = element;
    }
    public int Get(int index)
    {
        if (index == 0) return CurrentElement;
        if (NextElement == null) throw new Exception("'get' out of bounds");
        return NextElement.Get(index - 1);
    }
    public void Set(int index, int value)
    {
        if (index == 0)
        {
            CurrentElement = value;
            return;
        }
        if (NextElement == null) throw new Exception("'set' out of bounds");
        NextElement.Set(index - 1, value);
    }
    public bool MoveBack()
    {
        if (NextElement == null) return true;
        CurrentElement = NextElement.Get(0);
        if (NextElement.MoveBack())
        {
            NextElement = null;
        }
        return false;
    }
    public void RemoveAt(int index)
    {
        if (index != 0)
        {
            if (NextElement == null) throw new Exception("'removeat' out of bounds");
            NextElement.RemoveAt(index - 1);
            return;
        }
        if (MoveBack()) NextElement = null;
    }
    public void Generate(int size)
    {
        if (size <= 1) return;
        NextElement = new QueueElement();
        NextElement.Generate(size - 1);
    }
    public int SizeCalc()
    {
        if (NextElement == null) return 1;
        return NextElement.SizeCalc() + 1;
    }
    public void Expand(int value)
    {
        if (NextElement == null)
        {
            NextElement = new QueueElement(value);
            return;
        }
        NextElement.Expand(value);
    }
    public void ClearNext()
    {
        NextElement = null;
    }
}