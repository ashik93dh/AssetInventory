Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class clsAsset
    Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AIDBConnectionString").ConnectionString)
    Dim _AssetID, _BrandID, _ModelID, _AssetTypeID, _InvoiceID, _EntryBy As String
    Dim _UnitAmount As Double
    Dim _isActive As Boolean
    Public Property AssetID() As String
        Get
            Return _AssetID
        End Get
        Set(ByVal value As String)
            _AssetID = value
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
    Public Property ModelID() As String
        Get
            Return _ModelID
        End Get
        Set(ByVal value As String)
            _ModelID = value
        End Set
    End Property
    Public Property AssetTypeID() As String
        Get
            Return _AssetTypeID
        End Get
        Set(ByVal value As String)
            _AssetTypeID = value
        End Set
    End Property
    Public Property InvoiceID() As String
        Get
            Return _InvoiceID
        End Get
        Set(ByVal value As String)
            _InvoiceID = value
        End Set
    End Property
    Public Property UnitAmount() As Double
        Get
            Return _UnitAmount
        End Get
        Set(ByVal value As Double)
            _UnitAmount = value
        End Set
    End Property
    Public Property isActive() As Boolean
        Get
            Return _isActive
        End Get
        Set(ByVal value As Boolean)
            _AssetID = value
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
    Public Function fnInsertAsset(ByVal Asset As clsAsset) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spInsertAsset", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BrandID", Asset.BrandID)
            cmd.Parameters.AddWithValue("@ModelID", Asset.ModelID)
            cmd.Parameters.AddWithValue("@AssetTypeID", Asset.AssetTypeID)
            cmd.Parameters.AddWithValue("@InvoiceID", Asset.InvoiceID)
            cmd.Parameters.AddWithValue("@UnitAmount", Asset.UnitAmount)
            cmd.Parameters.AddWithValue("@EntryBy", Asset.EntryBy)
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
    Public Function fnUpdateAsset(ByVal Asset As clsAsset) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spUpdateAsset", con)
            con.Open()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AssetID", Asset.AssetID)
            cmd.Parameters.AddWithValue("@BrandID", Asset.BrandID)
            cmd.Parameters.AddWithValue("@ModelID", Asset.ModelID)
            cmd.Parameters.AddWithValue("@AssetTypeID", Asset.AssetTypeID)
            cmd.Parameters.AddWithValue("@InvoiceID", Asset.InvoiceID)
            cmd.Parameters.AddWithValue("@UnitAmount", Asset.UnitAmount)
            cmd.Parameters.AddWithValue("@isActive", Asset.isActive)
            cmd.Parameters.AddWithValue("@EntryBy", Asset.EntryBy)
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
    Public Function fnGetAsset() As DataSet
        Dim sp As String = "spGetAsset"
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
