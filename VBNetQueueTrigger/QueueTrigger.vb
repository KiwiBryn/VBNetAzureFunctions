'---------------------------------------------------------------------------------
' Copyright (c) June 2021, devMobile Software
'
' Licensed under the Apache License, Version 2.0 (the "License");
' you may Not use this file except in compliance with the License.
' You may obtain a copy of the License at
'
'     http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law Or agreed to in writing, software
' distributed under the License Is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES Or CONDITIONS OF ANY KIND, either express Or implied.
' See the License for the specific language governing permissions And
' limitations under the License.
'
'---------------------------------------------------------------------------------
Imports System.Threading

Imports Microsoft.Azure.WebJobs
Imports Microsoft.Extensions.Logging


Public Class QueueTrigger
   Shared ConcurrencyCount As Long
   Shared ExecutionCount As Long

   <FunctionName("Alerts")>
   Public Shared Sub ProcessQueueMessage(<QueueTrigger("notifications", Connection:="QueueEndpoint")> message As String, log As ILogger)
      Interlocked.Increment(ConcurrencyCount)
      Interlocked.Increment(ExecutionCount)

      log.LogInformation("VB.Net Concurrency:{0} Message:{1} Execution count:{2}", ConcurrencyCount, message, ExecutionCount)

      ' Wait for a bit to force some consurrency
      Thread.Sleep(5000)

      Interlocked.Decrement(ConcurrencyCount)
   End Sub
End Class

