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
Imports System.Net
Imports System.Net.Http
Imports System.Threading

Imports Microsoft.Azure.WebJobs
Imports Microsoft.Azure.WebJobs.Extensions.Http
Imports Microsoft.Extensions.Logging


Public Class HttpTrigger
   Shared executionCount As Int32

   <FunctionName("Notifications")>
   Public Shared Async Function Run(<HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route:=Nothing)> req As HttpRequestMessage, log As ILogger) As Task(Of HttpResponseMessage)
      Interlocked.Increment(executionCount)

      log.LogInformation($"VB.Net HTTP trigger Execution count:{0} Method:{1}", executionCount, req.Method)

      Return New HttpResponseMessage(HttpStatusCode.OK)
   End Function
End Class
