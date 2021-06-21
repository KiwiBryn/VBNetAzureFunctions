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
using System.IO;
using System.Threading;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;


namespace devMobile.Azure.CSharpBlobTrigger
{
	public static class BlobTrigger
	{
		private static int ExecutionCount = 0;

		[FunctionName("Notifications")]
		public static void Run([BlobTrigger("notifications/{name}", Connection = "BlobEndpoint")] Stream myBlob, string name, ILogger log)
		{
			Interlocked.Increment(ref ExecutionCount);

			log.LogInformation("C# BlobTrigger processed blob Name:{0} Size:{1} bytes Execution count:{2}", name, myBlob.Length, ExecutionCount);
		}
	}
}
