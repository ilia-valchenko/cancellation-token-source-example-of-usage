using System.Threading;
using System.Threading.Tasks;

namespace cancellation_token_source_example_of_usage
{
    interface IAwsDynamoDbClient
    {
        Task UpdateItemAsync(UpdateItemRequest request, CancellationToken token);
    }
}