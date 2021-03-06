//---------------------------------------------------------------------------------
// Copyright (c) June 2021, devMobile Software
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
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;


namespace devMobile.Azure.CSharpTimerTrigger
{
	public static class Timer
	{
		private static int executionCount = 0;

		[FunctionName("Timer")]
		public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
		{
			executionCount += 1;

			log.LogInformation("C# Timertrigger next trigger:{0} execution count:{1}", myTimer.ScheduleStatus.Next, executionCount);
		}
	}
}
