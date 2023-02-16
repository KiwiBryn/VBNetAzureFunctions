'---------------------------------------------------------------------------------
' Copyright (c) February 2023, devMobile Software
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
Imports System.Threading
Imports Microsoft.Azure.Functions.Worker
Imports Microsoft.Azure.Functions.Worker.Http
Imports Microsoft.Extensions.Logging
Imports Microsoft.VisualBasic.Logging

Namespace VBNetHttpTriggerIsolated
    Public Class HttpTrigger
        Private Shared executionCount As Int32
        Private ReadOnly _logger As ILogger

        Public Sub New(ByVal loggerFactory As ILoggerFactory)
            _logger = loggerFactory.CreateLogger(Of HttpTrigger)()
        End Sub

        <[Function]("Notifications")>
        Public Function Run(
        <HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")> ByVal req As HttpRequestData) As HttpResponseData
            Interlocked.Increment(executionCount)

            _logger.LogInformation("VB.Net NET 4.8 Isolated HTTP trigger Execution count:{executionCount} Method:{req.Method}", executionCount, req.Method)

            Dim response = req.CreateResponse(HttpStatusCode.OK)
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8")

            Return response
        End Function
    End Class
End Namespace
