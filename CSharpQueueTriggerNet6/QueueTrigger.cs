//---------------------------------------------------------------------------------
// Copyright (c) November 2022, devMobile Software
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
using System.Threading;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;


namespace devMobile.Azure.CSharpQueueTriggerNet6
{
    public class QueueTrigger
    {
        private static int ConcurrencyCount = 0;
        private static int ExecutionCount = 0;

        [FunctionName("Notifications")]
        public static void Run([QueueTrigger("notifications", Connection = "QueueEndpoint")] string message, ILogger log)
        {
            Interlocked.Increment(ref ConcurrencyCount);
            Interlocked.Increment(ref ExecutionCount);

            log.LogInformation($"C# Concurrency:{0} ExecutionCount:{1} Message:{2}", ConcurrencyCount, ExecutionCount, message);

            Interlocked.Decrement(ref ConcurrencyCount);
        }
    }
}
