Imports System.Net
Imports Microsoft.Azure.Functions.Worker
Imports Microsoft.Azure.Functions.Worker.Http
Imports Microsoft.Extensions.Logging

Namespace VBNetHttpTriggerIsolated
    Public Class Function1
        Private ReadOnly _logger As ILogger

        Public Sub New(ByVal loggerFactory As ILoggerFactory)
            _logger = loggerFactory.CreateLogger(Of Function1)()
        End Sub

        <[Function]("Notifications")>
        Public Function Run(
        <HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")> ByVal req As HttpRequestData) As HttpResponseData
            _logger.LogInformation("C# HTTP trigger function processed a request.")

            Dim response = req.CreateResponse(HttpStatusCode.OK)
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8")

            response.WriteString("Welcome to Azure Functions!")

            Return response
        End Function
    End Class
End Namespace
