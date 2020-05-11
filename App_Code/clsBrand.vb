Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class clsBrand
    Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AIDBConnectionString").ConnectionString)
    Dim _BrandID, _BrandName, _EntryBy As String
    Public Property BrandID() As String
        Get
            Return _BrandID
        End Get
        Set(ByVal value As String)
            _BrandID = value
        End Set
    End Property
    Public Property BrandName() As String
        Get
            Return _BrandName
        End Get
        Set(ByVal value As String)
            _BrandName = value
        End Set
    End Property
    Public Property EntryBy() As String
        Get
            Return _EntryBy
        End Get
        Set(ByVal value As String)
            _EntryBy = value
        End Set
    End Property
#Region "Insert"
    Public Function fnInsertBrand(ByVal Brand As clsBrand) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spInsertBrand", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BrandName", Brand.BrandName)
            cmd.Parameters.AddWithValue("@EntryBy", Brand.EntryBy)
            cmd.ExecuteNonQuery()
            result.Success = True
            result.Message = "Successfully Inserted"
            con.Close()
            Return result
        Catch ex As Exception
            result.Success = False
            result.Message = ex.Message
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Return result
        End Try
    End Function
#End Region
#Region "Update"
    Public Function fnUpdateBrand(ByVal Brand As clsBrand) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spUpdateBrand", con)
            con.Open()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BrandID", Brand.BrandID)
            cmd.Parameters.AddWithValue("@BrandName", Brand.BrandName)
            cmd.Parameters.AddWithValue("@EntryBy", Brand.EntryBy)
            cmd.ExecuteNonQuery()
            result.Success = True
            result.Message = "Successfully Updated"
            con.Close()
            Return result
        Catch ex As Exception
            result.Success = False
            result.Message = ex.Message
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Return result
        End Try
    End Function
#End Region
#Region "Fetch"
    Public Function fnGetBrand() As DataSet
        Dim sp As String = "spGetBrand"
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet()
        Try
            con.Open()
            Using cmd = New SqlCommand(sp, con)
                cmd.CommandType = CommandType.StoredProcedure
                da.SelectCommand = cmd
                da.Fill(ds)
                con.Close()
                Return ds
            End Using
        Catch ex As Exception
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Return Nothing
        End Try
    End Function
#End Region
End Class
