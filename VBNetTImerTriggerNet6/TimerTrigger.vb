'---------------------------------------------------------------------------------
' Copyright (c) November 2022 2021, devMobile Software
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


Public Class TimerTrigger
    Shared executionCount As Int32

    <FunctionName("Timer")>
    Public Shared Sub Run(<TimerTrigger("0 */1 * * * *")> myTimer As TimerInfo, log As ILogger)
        Interlocked.Increment(executionCount)

        log.LogInformation("VB.Net TimerTrigger next trigger:{0} Execution count:{1}", myTimer.ScheduleStatus.Next, executionCount)

    End Sub
End Class
