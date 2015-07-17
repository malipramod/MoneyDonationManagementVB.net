Module testModule
    Public DonorID As String
    Public rid As Integer
    Public uid As Integer
    Public DonorFlag As Boolean = False
    Public sel As Boolean = True
    Public UserType As String
    Public item As String
    Public rptID As String
    Public ConStr As String = Configuration.ConfigurationManager.ConnectionStrings("Connect").ConnectionString
    Public var As String
End Module
