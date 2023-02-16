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
