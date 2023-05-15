using HotChocolate.Subscriptions;

namespace HotChocolateSocketRepro;

public sealed class Publisher : BackgroundService
{
    private readonly ITopicEventSender _topicEventSender;

    public Publisher(ITopicEventSender topicEventSender)
    {
        _topicEventSender = topicEventSender;
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            await _topicEventSender.SendAsync(nameof(Subscription.GuidGenerated), Guid.NewGuid(), ct);
            await Task.Delay(100, ct);
        }
    }
}