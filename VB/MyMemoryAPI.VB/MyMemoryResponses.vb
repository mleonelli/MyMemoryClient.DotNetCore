Imports Newtonsoft.Json
Imports System.Collections.Generic

Public Class MyMemorySetResponse
    Public responseData As String
    Public responseDetails As String
    Public responseStatus As String
    Public responderId As String
    Public matches As List(Of Match)
End Class

Public Class MyMemoryGetResponse
    Public responseData As ResponseData
    Public responseDetails As String
    Public responseStatus As Integer
    Public responderId As String
    Public matches As List(Of Match)
End Class


Public Class ResponseData
    Public translatedText As String
End Class

Public Class Match
    Public id As String
    Public segment As String
    Public translation As String
    Public quality As String
    Public reference As String
    <JsonProperty(PropertyName:="usage-count")>
    Public usageCount As Integer
    Public subject As String
    <JsonProperty(PropertyName:="created-by")>
    Public createdBy As String
    <JsonProperty(PropertyName:="last-updated-by")>
    Public lastUpdatedBy As String
    <JsonProperty(PropertyName:="create-date")>
    Public createDate As Date
    <JsonProperty(PropertyName:="last-update-date")>
    Public lastUpdateDate As Date
    Public match As Double
End Class


Public Enum OutputFormat
    Json
    Tmx
    Array
End Enum


