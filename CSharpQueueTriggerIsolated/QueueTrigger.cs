//---------------------------------------------------------------------------------
// Copyright (c) February 2021, devMobile Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
//---------------------------------------------------------------------------------
namespace devMobile.Azure.CSharpQueueTriggerIsolated
{
    using System.Threading;

    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Extensions.Logging;

    public class QueueTrigger
    {
        private readonly ILogger _logger;
        private static int _concurrencyCount = 0;
        private static int _executionCount = 0;

        public QueueTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<QueueTrigger>();
        }

        [Function("Notifications")]
        public void Run([QueueTrigger("notifications", Connection = "QueueEndpoint")] string message)
        {
            Interlocked.Increment(ref _concurrencyCount);
            Interlocked.Increment(ref _executionCount);

            _logger.LogInformation("C# Concurrency:{_concurrencyCount} ExecutionCount:{_executionCount} Message:{message}", _concurrencyCount, _executionCount, message);

            Interlocked.Decrement(ref _concurrencyCount);
        }
    }
}
