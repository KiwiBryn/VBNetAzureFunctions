Imports System.Threading

Imports Microsoft.Azure.WebJobs
Imports Microsoft.Extensions.Logging


Public Class TimerTrigger
    Shared executionCount As Int32

    <FunctionName("Timer")>
    Public Shared Sub Run(<TimerTrigger("0 */1 * * * *")> myTimer As TimerInfo, log As ILogger)

        log.LogInformation("VB.Net .NET V6 TimerTrigger next trigger:{0}", myTimer.ScheduleStatus.Next)

    End Sub
End Class
