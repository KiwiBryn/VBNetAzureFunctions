'---------------------------------------------------------------------------------
' Copyright (c) February 2021, devMobile Software
'
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
'
'     http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions and
' limitations under the License.
'
'---------------------------------------------------------------------------------
Imports System.Threading

Imports Microsoft.Azure.Functions.Worker
Imports Microsoft.Extensions.Logging

Namespace devMobile.Azure.VBNetQueueTriggerIsolated

    Public Class QueueTrigger
        Private Shared _logger As ILogger
        Private Shared _concurrencyCount As Integer = 0
        Private Shared _executionCount As Integer = 0

        Public Sub New(ByVal loggerFactory As ILoggerFactory)
            _logger = loggerFactory.CreateLogger(Of QueueTrigger)()
        End Sub

        <[Function]("Notifications")>
        Public Sub Run(
        <QueueTrigger("notifications", Connection:="QueueEndpoint")> ByVal message As String)
            Interlocked.Increment(_concurrencyCount)
            Interlocked.Increment(_executionCount)

            _logger.LogInformation("VB.Net Concurrency:{_concurrencyCount} ExecutionCount:{_executionCount} Message:{message}", _concurrencyCount, _executionCount, message)

            Interlocked.Decrement(_concurrencyCount)
        End Sub
    End Class
End Namespace
