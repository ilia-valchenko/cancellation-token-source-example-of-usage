using System.Threading;
using System.Threading.Tasks;

namespace cancellation_token_source_example_of_usage
{
    class Program
    {
        // TODO: The value should be taken from a config.
        private const int DefaultMillisecondsTimeout = 1000;

        private readonly IAwsDynamoDbClient awsDynamoDbClient = new AwsDynamoDbClient();

        static void Main(string[] args)
        {
        }

        private async Task UpdateItem(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await this.awsDynamoDbClient.UpdateItemAsync(request, this.CreateLinkedTokenSource(cancellationToken));
        }

        private CancellationToken CreateLinkedTokenSource(CancellationToken parentCancellationToken)
        {
            // Note: a cancellation on the child source would cancel the parent as well.
            var childCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(parentCancellationToken);
            childCancellationTokenSource.CancelAfter(DefaultMillisecondsTimeout);

            return childCancellationTokenSource.Token;
        }
    }
}