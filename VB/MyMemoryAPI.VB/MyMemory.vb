Imports System.Globalization
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json

Public Class MyMemory

    Private myMemoryBaseUrl As String = "http://api.mymemory.translated.net"
    Private IsAuthenticated As Boolean = False

    Private key As String = ""
    Private email As String = ""
    Private ip As String = ""


    Public Sub New()
    End Sub


    Public Sub New(ByVal key As String, ByVal email As String)
        Me.key = key
        Me.email = email
    End Sub

    Public Sub New(ByVal key As String, ByVal email As String, ByVal ip As String)
        Me.key = key
        Me.email = email
        Me.ip = ip
    End Sub

    Public Function GetT(ByVal sentence As String, ByVal sourceLanguage As RegionInfo, ByVal destinationLanguage As RegionInfo) As MyMemoryGetResponse
        Dim uri As String = "/get" +
                "?" +
                "q=" + System.Uri.EscapeDataString(sentence) + "&" +
                "langpair=" + sourceLanguage.Name + "|" + destinationLanguage.Name

        If (Me.key <> "") Then
            uri +=
                "&" + "key=" + Me.key +
                "&" + "de=" + Me.email
            If (Me.ip <> "") Then
                uri += "&" + "ip=" + Me.ip
            End If
        End If


        Return GetT(uri, OutputFormat.Json)
    End Function

    Public Function GetT(ByVal sentence As String, ByVal sourceLanguage As RegionInfo, ByVal destinationLanguage As RegionInfo, Optional ByVal outFormat As OutputFormat = OutputFormat.Json, Optional ByVal machineTranslation As Boolean = True, Optional ByVal OnlyPrivateMT As Boolean = False) As MyMemoryGetResponse

        Dim outFormatString As String = OuputFormat(outFormat)

        Dim uri As String = "/get" +
            "?" +
            "q=" + System.Uri.EscapeDataString(sentence) + "&" +
            "langpair=" + sourceLanguage.Name + "|" + destinationLanguage.Name + "&" +
            "mt=" + Convert.ToInt32(machineTranslation) + "&" +
            "of=" + outFormatString


        If (Me.key <> "") Then
            uri +=
                "&" + "key=" + Me.key +
                "&" + "de=" + Me.email
            If (Me.ip <> "") Then
                uri += "&" + "ip=" + Me.ip
            End If
            uri += "&" + "onlyprivate=" + Convert.ToInt32(OnlyPrivateMT)
        End If


        Return GetT(uri, outFormat)
    End Function

    Private Function OuputFormat(ByVal outFormat As OutputFormat) As String

        Select Case outFormat
            Case OutputFormat.Json
                Return "json"
            Case OutputFormat.Tmx
                Return "tmx"
            Case OutputFormat.Array
                Return "array"
            Case Else
                Return "json"
        End Select

    End Function


    Private Function GetT(ByVal uri As String, Optional ByVal outFormat As OutputFormat = OutputFormat.Json) As MyMemoryGetResponse
        Dim client As HttpClient = New HttpClient()
        client.BaseAddress = New Uri(myMemoryBaseUrl)

        Dim response As HttpResponseMessage = client.GetAsync(uri).Result

        If (response.IsSuccessStatusCode) Then
            Dim ajsonObject As MyMemoryGetResponse = JsonConvert.DeserializeObject(Of MyMemoryGetResponse)(response.Content.ReadAsStringAsync().Result)
            Return ajsonObject
        Else
            Throw New Exception("Response Exception")
        End If

    End Function

    Public Function SetT(ByVal segment As String, ByVal translation As String, ByVal sourceLanguage As RegionInfo, ByVal destinationLanguage As RegionInfo) As MyMemorySetResponse

        Dim client As HttpClient = New HttpClient()
        client.BaseAddress = New Uri(myMemoryBaseUrl)


        Dim uri As String = "/set" +
            "?" +
            "seg=" + segment + "&" +
            "tra=" + translation + "&" +
            "langpair=" + sourceLanguage.Name + "|" + destinationLanguage.Name

        If (Me.key <> "") Then
            uri +=
                "&" + "key=" + Me.key +
                "&" + "de=" + Me.email
        End If

        Dim response As HttpResponseMessage = client.GetAsync(uri).Result

        If (response.IsSuccessStatusCode) Then
            Dim ajsonObject As MyMemorySetResponse = JsonConvert.DeserializeObject(Of MyMemorySetResponse)(response.Content.ReadAsStringAsync().Result)
            Return ajsonObject
        Else
            Throw New Exception("Response Exception")
        End If

    End Function


    Public Function Keygen(ByVal username As String, ByVal password As String)
        Dim client As HttpClient = New HttpClient()
        client.BaseAddress = New Uri(myMemoryBaseUrl)

        Dim uri As String = "/keygen" +
            "?" +
            "user=" + System.Uri.EscapeDataString(username) + "&" +
            "pass=" + System.Uri.EscapeDataString(password)

        Dim response As HttpResponseMessage = client.GetAsync(uri).Result

        If (response.IsSuccessStatusCode) Then
            Dim ajsonObject As MyMemoryGetResponse = JsonConvert.DeserializeObject(Of MyMemoryGetResponse)(response.Content.ReadAsStringAsync().Result)
            Return ajsonObject
        Else
            Throw New Exception("Response Exception")
        End If
    End Function

End Class
