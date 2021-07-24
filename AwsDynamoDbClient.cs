using System;
using System.Threading;
using System.Threading.Tasks;

namespace cancellation_token_source_example_of_usage
{
    public class AwsDynamoDbClient : IAwsDynamoDbClient
    {
        public Task UpdateItemAsync(UpdateItemRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}