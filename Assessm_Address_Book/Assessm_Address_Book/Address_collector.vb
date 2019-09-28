Public Class Address_collector
    Private name As String
    Private address As String
    Private phone As String

    'Name getter and setter
    Public Property get_name() As String
        Get
            Return name
        End Get
        Set(value As String)
            name = value
        End Set
    End Property

    'Address getter and setter
    Public Property get_address() As String
        Get
            Return address
        End Get
        Set(value As String)
            address = value
        End Set
    End Property


End Class
