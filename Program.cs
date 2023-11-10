QueueElement queue = new();
string? input = " ";
Console.WriteLine("push pop front size clear exit");
while (true)
{
    Console.Write("> ");
    input = Console.ReadLine();
    if (input == null) continue;
    string[] split = input.Split();
    string command = split[0];
    int argument = split.Length > 1 ? int.Parse(split[1]) : 0;
    switch (command)
    {
        case "push":
            Push(queue, argument);
            Console.WriteLine("ok");
            break;
        case "pop":
            Console.WriteLine(Pop(queue));
            break;
        case "front":
            Console.WriteLine(Front(queue));
            break;
        case "size":
            Console.WriteLine(Size(queue));
            break;
        case "clear":
            Clear(queue);
            Console.WriteLine("ok");
            break;
        case "exit":
            Console.WriteLine("bye");
            return;
    }
}

//1st element is unaccessible
void Push(QueueElement entity, int value)
{
    entity.Expand(value);
}
int Size(QueueElement entity)
{
    return entity.SizeCalc() - 1;
}
int Front(QueueElement entity)
{
    if (Size(entity) == 0) throw new Exception("front from null");
    return entity.Get(1);
}
int Pop(QueueElement entity)
{
    if (Size(entity) == 0) throw new Exception("pop from null");
    int value = Front(entity);
    entity.RemoveAt(0);
    return value;
}
void Clear(QueueElement entity)
{
    entity.ClearNext();
}