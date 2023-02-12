'---------------------------------------------------------------------------------
' Copyright (c) February 2023, devMobile Software
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
Imports Microsoft.VisualBasic.Logging

Namespace devMobile.Azure.VBNetTimerTriggerIsolated
    Public Class TimerTrigger
        Private Shared _logger As ILogger
        Private Shared _executionCount As Integer = 0

        Public Sub New(ByVal loggerFactory As ILoggerFactory)
            _logger = loggerFactory.CreateLogger(Of TimerTrigger)()
        End Sub

        <[Function]("Timer")>
        Public Sub Run(
        <TimerTrigger("0 */1 * * * *")> ByVal myTimer As MyInfo)

            Interlocked.Increment(_executionCount)
            _logger.LogInformation("VB.Net Isolated TimerTrigger next trigger:{0} Execution count:{1}", myTimer.ScheduleStatus.Next, _executionCount)
        End Sub
    End Class

    Public Class MyInfo
        Public Property ScheduleStatus As MyScheduleStatus

        Public Property IsPastDue As Boolean
    End Class

    Public Class MyScheduleStatus
        Public Property Last As Date

        Public Property [Next] As Date

        Public Property LastUpdated As Date
    End Class
End Namespace
