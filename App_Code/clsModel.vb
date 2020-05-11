Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class clsModel
    Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AIDBConnectionString").ConnectionString)
    Dim _ModelID, _ModelName, _BrandID, _EntryBy As String
    Public Property ModelID() As String
        Get
            Return _ModelID
        End Get
        Set(ByVal value As String)
            _ModelID = value
        End Set
    End Property
    Public Property ModelName() As String
        Get
            Return _ModelName
        End Get
        Set(ByVal value As String)
            _ModelName = value
        End Set
    End Property
    Public Property BrandID() As String
        Get
            Return _BrandID
        End Get
        Set(ByVal value As String)
            _BrandID = value
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
    Public Function fnInsertModel(ByVal Model As clsModel) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spInsertModel", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ModelName", Model.ModelName)
            cmd.Parameters.AddWithValue("@BrandID", Model.BrandID)
            cmd.Parameters.AddWithValue("@EntryBy", Model.EntryBy)
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
    Public Function fnUpdateModel(ByVal Model As clsModel) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spUpdateModel", con)
            con.Open()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ModelID", Model.ModelID)
            cmd.Parameters.AddWithValue("@ModelName", Model.ModelName)
            cmd.Parameters.AddWithValue("@BrandID", Model.BrandID)
            cmd.Parameters.AddWithValue("@EntryBy", Model.EntryBy)
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
    Public Function fnGetModel() As DataSet
        Dim sp As String = "spGetModel"
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
    Public Function fnGetBrandModel() As DataSet
        Dim sp As String = "spGetBrandModel"
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
