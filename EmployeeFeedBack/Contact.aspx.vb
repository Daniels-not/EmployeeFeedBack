Imports EmployeeFeedBack.View
Imports System.Data.SqlClient
Imports System.EnterpriseServices
Imports System.Security.Cryptography
Imports System.Data

Public Class Contact
    Inherits Page
    Dim gen = New View()
    Dim connectionString As String = "Data Source=192.168.3.103\SENNA2019;Initial Catalog=Testing_Ramy;Persist Security Info=True;User ID=rcampusano;Password=Soporte-1"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'resiving the value id from About.aspx
        Dim strVal As String = DirectCast(Session("val"), String)
        Dim id As String = DirectCast(Session("val"), String)

        Dim branch_office As String = DirectCast(Session("branch_office"), String)
        Dim employee_name As String = DirectCast(Session("employee_name"), String)
        Dim income As String = DirectCast(Session("income"), String)

        Dim routing_number As String = DirectCast(Session("routing_number"), String)
        Dim account_number As String = DirectCast(Session("account_number"), String)
        Dim comments As String = DirectCast(Session("comments"), String)

        'asigning data from About.aspx to textbox
        txtId.Text = strVal
        DropStore.Text = branch_office
        DropEmp.Text = employee_name

        txtincome.Text = income
        txtrouting_number.Text = routing_number
        txtaccount_number.Text = account_number
        txtdesc.Text = comments
        'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('id: " & strVal + "');", True)
    End Sub

    Protected Sub update_Click(sender As Object, e As EventArgs) Handles update.Click


        'variables
        Dim branch_office As String = DropStore.Text
        Dim employee_name As String = DropEmp.Text
        Dim income As String = txtincome.Text
        Dim payment_date_month As String = RadioPayment_date_month.Text
        Dim payment_date_week As String = RadioPayment_date_week.Text
        Dim routing_number As String = txtrouting_number.Text
        Dim account_number As String = txtaccount_number.Text
        Dim comments As String = txtdesc.Text
        Dim ID As String = txtId.Text

        'database connection 

        Dim connection As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("payroll_complains_update", connection)
        cmd.CommandType = CommandType.StoredProcedure


        'adding params to the procedure
        cmd.Parameters.AddWithValue("@id", ID)
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
        MsgBox("Successfully updated", MsgBoxStyle.Information, "Messange")
        connection.Close()
        Response.Redirect("About.aspx")
    End Sub
End Class