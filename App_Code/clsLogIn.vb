Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class clsLogIn
    Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AIDBConnectionString").ConnectionString)
    Dim _UserName, _Password As String
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    Public Function fnValidateUsers(ByVal login As clsLogIn) As clsResult
        Dim result As New clsResult()
        Dim r As Integer
        Try
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand("spValidateUsers", con)
            cmd.Parameters.AddWithValue("@UserID", login.UserName)
            cmd.Parameters.AddWithValue("@Password", login.Password)
            cmd.Parameters.Add("@r", SqlDbType.Int)
            cmd.Parameters("@r").Direction = ParameterDirection.Output
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            r = cmd.Parameters("@r").Value
            If (r = 1) Then
                result.Success = True
                result.Message = "Successfully Logged In"
                con.Close()
                Return result
            Else
                result.Success = False
                result.Message = "Invalid Username or Password"
                con.Close()
                Return result
            End If
        Catch ex As Exception
            result.Success = False
            result.Message = ex.Message
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Return result
        End Try
    End Function
End Class
