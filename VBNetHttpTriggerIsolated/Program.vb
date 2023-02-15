Imports Microsoft.Azure.Functions.Worker
Imports Microsoft.Extensions.Hosting

Namespace VBNetHttpTriggerIsolated
    Friend Class Program
        Public Shared Sub Main(ByVal args As String())
            Call FunctionsDebugger.Enable()

            Dim host = New HostBuilder().ConfigureFunctionsWorkerDefaults().Build()

            host.Run()
        End Sub
    End Class
End Namespace
