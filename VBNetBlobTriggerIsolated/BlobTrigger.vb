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
Imports Microsoft.Azure.Functions.Worker
Imports Microsoft.Extensions.Logging

Namespace devMobile.Azure.VBNetBlobTriggerIsolated
    Public Class BlobTrigger
        Private ReadOnly _logger As ILogger

        Public Sub New(ByVal loggerFactory As ILoggerFactory)
            _logger = loggerFactory.CreateLogger(Of BlobTrigger)()
        End Sub

        <[Function]("vbnetblobtriggerisolated")>
        Public Sub Run(
        <BlobTrigger("vbnetblobtriggerisolated/{name}", Connection:="blobendpoint")> ByVal myBlob As String, ByVal name As String)

            _logger.LogInformation($"VB.Net NET 4.8 Isolated Blob trigger function Processed blob Name: {name}  Data: {myBlob}")
        End Sub
    End Class
End Namespace
