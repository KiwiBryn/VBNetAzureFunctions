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
Imports System.IO
Imports System.Threading

Imports Microsoft.Azure.WebJobs
Imports Microsoft.Extensions.Logging


Public Class BlobTrigger
    Shared executionCount As Int32

    ' This function will get triggered/executed when a new message is written on an Azure Queue called events.
    <FunctionName("vbnetblobtrigger")>
    Public Shared Sub Run(<BlobTrigger("vbnetblobtrigger/{name}", Connection:="BlobEndPoint")> payload As Stream, name As String, log As ILogger)
        Interlocked.Increment(executionCount)

        log.LogInformation("VB.Net .NET 4.8 BlobTrigger processed blob name:{0} Size:{1} bytes Execution count:{2}", name, payload.Length, executionCount)
    End Sub
End Class

