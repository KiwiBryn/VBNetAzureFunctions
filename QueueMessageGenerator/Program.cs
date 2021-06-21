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
using System;
using System.Text;

using Azure.Storage.Queues;

namespace QueueMessageGenerator
{
	class Program
	{
      static void Main(string[] args)
      {
         long messageCounter = 1;

         // Instantiate a QueueClient which will be used to create and manipulate the queue
         QueueClient queueClient = new QueueClient(args[0], args[1]);

         // Create the queue if it doesn't already exist
         queueClient.CreateIfNotExists();

         while (true)
         {
            Console.WriteLine($"Send  {messageCounter}");

            string message = $"{DateTime.UtcNow:HH:mm:ss} : {messageCounter}";
            messageCounter += 1;
            queueClient.SendMessage(Convert.ToBase64String(Encoding.UTF8.GetBytes(message)), visibilityTimeout: TimeSpan.FromMilliseconds(500));
         }
      }
	}
}
