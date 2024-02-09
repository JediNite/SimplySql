﻿<Cmdlet(VerbsCommon.Get, "SqlTransaction", SupportsShouldProcess:=True)>
Public Class GetSqlTransaction
    Inherits PSCmdlet
#Region "Parameters"
    <Parameter(ValueFromPipelineByPropertyName:=True, ValueFromPipeline:=True)>
    <[Alias]("cn")>
    <ValidateNotNullOrEmpty()>
    <PSDefaultValue(Value:="default")>
    Public Property ConnectionName As String = "default"
#End Region

    Protected Overrides Sub ProcessRecord()
        If ValidateConnection(ConnectionName) Then
            If Me.ShouldProcess(ConnectionName, "Get Sql Transaction") Then
                Try
                    WriteObject(Engine.Logic.GetConnection(ConnectionName).Transaction)
                Catch ex As Exception
                    ErrorOperationFailed(ex, ConnectionName)
                End Try
            End If
        End If
    End Sub
End Class
