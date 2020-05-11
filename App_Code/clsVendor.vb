Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class clsVendor
    Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AIDBConnectionString").ConnectionString)
    Dim _VendorID, _VendorName, _VendorAddress, _ContactPerson, _ContactNo, _EntryBy As String
    Public Property VendorID() As String
        Get
            Return _VendorID
        End Get
        Set(ByVal value As String)
            _VendorID = value
        End Set
    End Property
    Public Property VendorName() As String
        Get
            Return _VendorName
        End Get
        Set(ByVal value As String)
            _VendorName = value
        End Set
    End Property
    Public Property VendorAddress() As String
        Get
            Return _VendorAddress
        End Get
        Set(ByVal value As String)
            _VendorAddress = value
        End Set
    End Property
    Public Property ContactPerson() As String
        Get
            Return _ContactPerson
        End Get
        Set(ByVal value As String)
            _ContactPerson = value
        End Set
    End Property
    Public Property ContactNo() As String
        Get
            Return _ContactNo
        End Get
        Set(ByVal value As String)
            _ContactNo = value
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
    Public Function fnInsertVendor(ByVal Vendor As clsVendor) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spInsertVendor", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@VendorName", Vendor.VendorName)
            cmd.Parameters.AddWithValue("@VendorAddress", Vendor.VendorAddress)
            cmd.Parameters.AddWithValue("@ContactPerson", Vendor.ContactPerson)
            cmd.Parameters.AddWithValue("@ContactNo", Vendor.ContactNo)
            cmd.Parameters.AddWithValue("@EntryBy", Vendor.EntryBy)
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
    Public Function fnUpdateVendor(ByVal Vendor As clsVendor) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spUpdateVendor", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@VendorID", Vendor.VendorID)
            cmd.Parameters.AddWithValue("@VendorName", Vendor.VendorName)
            cmd.Parameters.AddWithValue("@VendorAddress", Vendor.VendorAddress)
            cmd.Parameters.AddWithValue("@ContactPerson", Vendor.ContactPerson)
            cmd.Parameters.AddWithValue("@ContactNo", Vendor.ContactNo)
            cmd.Parameters.AddWithValue("@EntryBy", Vendor.EntryBy)
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
    Public Function fnGetVendor() As DataSet
        Dim sp As String = "spGetVendor"
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