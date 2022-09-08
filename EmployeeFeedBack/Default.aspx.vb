Imports System.Data.SqlClient
Imports System.Security.Cryptography.X509Certificates

Public Class _Default
    Inherits Page
    Dim connectionString As String = "Data Source=192.168.3.103\SENNA2019;Initial Catalog=Testing_Ramy;Persist Security Info=True;User ID=rcampusano;Password=Soporte-1"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click()

    End Sub

    Protected Sub register_Click(sender As Object, e As EventArgs) Handles register.Click

        'variables
        Dim branch_office As String = DropStore.Text
        Dim employee_name As String = DropEmp.Text
        Dim income As String = txtincome.Text
        Dim payment_date_month As String = RadioPayment_date_month.Text
        Dim payment_date_week As String = RadioPayment_date_week.Text
        Dim routing_number As String = txtrouting_number.Text
        Dim account_number As String = txtaccount_number.Text
        Dim comments As String = txtdesc.Text

        'database connection 

        Dim connection As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("payroll_complains_create", connection)
        cmd.CommandType = CommandType.StoredProcedure


        'adding params to the procedure
        cmd.Parameters.AddWithValue("@branch_office", branch_office)
        cmd.Parameters.AddWithValue("@employee_name", employee_name)
        cmd.Parameters.AddWithValue("@income", income)
        cmd.Parameters.AddWithValue("@payment_date_month", payment_date_month)
        cmd.Parameters.AddWithValue("@payment_date_week", payment_date_week)
        cmd.Parameters.AddWithValue("@routing_number", routing_number)
        cmd.Parameters.AddWithValue("@account_number", account_number)
        cmd.Parameters.AddWithValue("@comments", comments)

        connection.Open()
        cmd.ExecuteNonQuery()
        MsgBox("Successfully inserted", MsgBoxStyle.Information, "Messange")
        connection.Close()
        Server.Transfer("About.aspx", True)
    End Sub
End Class