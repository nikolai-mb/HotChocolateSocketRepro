namespace HotChocolateSocketRepro;

public sealed class Subscription
{
    [Subscribe]
    public Guid GuidGenerated([EventMessage] Guid guid) => guid;
}