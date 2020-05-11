Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class clsInvoice
    Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("AIDBConnectionString").ConnectionString)
    Dim _InvoiceID, _InvoiceNumber, _InvoiceFile, _VendorID, _EntryBy, _Remarks, _InvoiceDate, _Action, _ActionTime As String
    Dim _isApproved As Boolean
    Dim _InvoiceAmount As Double
    Public Property InvoiceID() As String
        Get
            Return _InvoiceID
        End Get
        Set(ByVal value As String)
            _InvoiceID = value
        End Set
    End Property
    Public Property InvoiceNumber() As String
        Get
            Return _InvoiceNumber
        End Get
        Set(ByVal value As String)
            _InvoiceNumber = value
        End Set
    End Property
    Public Property InvoiceAmount() As Double
        Get
            Return _InvoiceAmount
        End Get
        Set(ByVal value As Double)
            _InvoiceAmount = value
        End Set
    End Property
    Public Property InvoiceDate() As String
        Get
            Return _InvoiceDate
        End Get
        Set(ByVal value As String)
            _InvoiceDate = value
        End Set
    End Property
    Public Property InvoiceFile() As String
        Get
            Return _InvoiceFile
        End Get
        Set(ByVal value As String)
            _InvoiceFile = value
        End Set
    End Property
    Public Property VendorID() As String
        Get
            Return _VendorID
        End Get
        Set(ByVal value As String)
            _VendorID = value
        End Set
    End Property
    Public Property isApproved() As Boolean
        Get
            Return _isApproved
        End Get
        Set(ByVal value As Boolean)
            _isApproved = value
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
    Public Property ActionTime() As String
        Get
            Return _ActionTime
        End Get
        Set(ByVal value As String)
            _ActionTime = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Property Action() As String
        Get
            Return _Action
        End Get
        Set(ByVal value As String)
            _Action = value
        End Set
    End Property
#Region "Insert"
    Public Function fnInsertInvoice(ByVal Invoice As clsInvoice) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spInsertInvoice", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@InvoiceNumber", Invoice.InvoiceNumber)
            cmd.Parameters.AddWithValue("@InvoiceAmount", Invoice.InvoiceAmount)
            cmd.Parameters.AddWithValue("@InvoiceDate", Invoice.InvoiceDate)
            cmd.Parameters.AddWithValue("@InvoiceFile", Invoice.InvoiceFile)
            cmd.Parameters.AddWithValue("@VendorID", Invoice.VendorID)
            cmd.Parameters.AddWithValue("@EntryBy", Invoice.EntryBy)
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
    Public Function fnUpdateInvoice(ByVal Invoice As clsInvoice) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spUpdateInvoice", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@InvoiceID", Invoice.InvoiceID)
            cmd.Parameters.AddWithValue("@InvoiceNumber", Invoice.InvoiceNumber)
            cmd.Parameters.AddWithValue("@InvoiceAmount", Invoice.InvoiceAmount)
            cmd.Parameters.AddWithValue("@InvoiceDate", Invoice.InvoiceDate)
            cmd.Parameters.AddWithValue("@InvoiceFile", Invoice.InvoiceFile)
            cmd.Parameters.AddWithValue("@VendorID", Invoice.VendorID)
            cmd.Parameters.AddWithValue("@isApproved", Invoice.isApproved)
            cmd.Parameters.AddWithValue("@EntryBy", Invoice.EntryBy)
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
    Public Function fnProcessInvoice(ByVal Invoice As clsInvoice) As clsResult
        Dim result As New clsResult()
        Try
            Dim cmd As SqlCommand = New SqlCommand("spProcessInvoice", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@InvoiceID", Invoice.InvoiceID)
            cmd.Parameters.AddWithValue("@Remarks", Invoice.Remarks)
            cmd.Parameters.AddWithValue("@Action", Invoice.Action)
            cmd.Parameters.AddWithValue("@EntryBy", Invoice.EntryBy)
            cmd.ExecuteNonQuery()
            result.Success = True
            result.Message = "Successfully Processed"
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
    Public Function fnGetInvoice() As DataSet
        Dim sp As String = "spGetInvoice"
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
#Region "Fetch"
    Public Function fnGetAssetByInvoice(ByVal Invoice As clsInvoice) As DataSet
        Dim sp As String = "spGetAssetByInvoice"
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet()
        Try
            con.Open()
            Using cmd = New SqlCommand(sp, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@InvoiceID", Invoice.InvoiceID)
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
    Public Function fnGetAssetByInvoiceNumber(ByVal Invoice As clsInvoice) As DataSet
        Dim sp As String = "spGetAssetByInvoiceNumber"
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet()
        Try
            con.Open()
            Using cmd = New SqlCommand(sp, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@InvoiceNumber", Invoice.InvoiceNumber)
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
    Public Function fnGetWaitingInvoice() As DataSet
        Dim sp As String = "spGetWaitingInvoice"
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
    Public Function fnGetUnapprovedInvoice() As DataSet
        Dim sp As String = "spGetUnapprovedInvoice"
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
    Public Function fnGetApprovedInvoice() As DataSet
        Dim sp As String = "spGetApprovedInvoice"
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
    Public Function fnGetRejectedInvoice() As DataSet
        Dim sp As String = "spGetRejectedInvoice"
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
