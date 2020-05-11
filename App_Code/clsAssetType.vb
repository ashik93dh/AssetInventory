Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Public Class clsAssetType
    Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AIDBConnectionString").ConnectionString)
    Dim _AssetTypeID, _AssetType, _EntryBy As String
    Public Property AssetTypeID() As String
        Get
            Return _AssetTypeID
        End Get
        Set(ByVal value As String)
            _AssetTypeID = value
        End Set
    End Property
    Public Property AssetType() As String
        Get
            Return _AssetType
        End Get
        Set(ByVal value As String)
            _AssetType = value
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
    Public Function fnInsertAssetType(ByVal AssetType As clsAssetType) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spInsertAssetType", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AssetType", AssetType.AssetType)
            cmd.Parameters.AddWithValue("@EntryBy", AssetType.EntryBy)
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
    Public Function fnUpdateAssetType(ByVal AssetType As clsAssetType) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spUpdateAssetType", con)
            con.Open()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AssetTypeID", AssetType.AssetTypeID)
            cmd.Parameters.AddWithValue("@AssetType", AssetType.AssetType)
            cmd.Parameters.AddWithValue("@EntryBy", AssetType.EntryBy)
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
    Public Function fnGetAssetType() As DataSet
        Dim sp As String = "spGetAssetType"
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

