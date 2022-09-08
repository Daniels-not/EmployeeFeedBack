Imports System.Data.SqlClient
Imports System.EnterpriseServices
Imports System.Security.Cryptography
Imports System.Data
Imports EmployeeFeedBack.View
Public Class About
    Inherits Page
    Dim methods = New View()
    Dim connectionString As String = "Data Source=192.168.3.103\SENNA2019;Initial Catalog=Testing_Ramy;Persist Security Info=True;User ID=rcampusano;Password=Soporte-1"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            Me.DataBind()
            listFeedBacks()
            deleteReq()
        End If

    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        payrollView.PageIndex = e.NewPageIndex
        Me.DataBind()
        listFeedBacks()
    End Sub

    Protected Sub payrollView_SelectedIndexChanged(sender As Object, e As EventArgs)
        txtId.Text = payrollView.SelectedRow.Cells.Item("id").ToString
    End Sub

    Public Sub listFeedBacks()
        Dim connection As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("EXEC payroll_complains_read", connection)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As New DataTable

        adapter.Fill(dt)
        payrollView.DataSource = dt
        payrollView.DataBind()
        'Me.DataBind()
    End Sub

    Protected Sub GetId(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Edittt" Then
            'Determine the RowIndex of the Row whose Button was clicked.
            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

            'Reference the GridView Row.
            Dim row As GridViewRow = payrollView.Rows(rowIndex)

            'Fetch value of Name.
            'Dim id As String = TryCast(row.FindControl("txtName"), TextBox).Text
            Dim id As String = row.Cells(2).Text
            methods.setSpecificId(id)
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('id: " & id + "');", True)
        End If
        Server.Transfer("Contact.aspx", True)
    End Sub

    Public Sub deleteReq()

        'database connection 

        If txtId.Text = "" Then
            delete.Enabled = False
        Else
            delete.Enabled = True
            Dim connection As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("payroll_complains_delete", connection)
            cmd.CommandType = CommandType.StoredProcedure


            'adding params to the procedure

            cmd.Parameters.AddWithValue("@id", txtId.Text)

            connection.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Successfully deleted", MsgBoxStyle.Information, "Messange")
            connection.Close()
            txtId.Text = ""
        End If

    End Sub

    Protected Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        Dim confirmValue As String = Request.Form("confirm_value")

        If confirmValue = "Yes" Then
            deleteReq()
            listFeedBacks()
            payrollView.DataBind()
            txtId.Text = ""
            delete.Enabled = True
        End If
        listFeedBacks()
        Me.DataBind()
        txtId.Text = ""
    End Sub

    Protected Sub add_Click(sender As Object, e As EventArgs) Handles add.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub payrollView_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Select" Then
            'Determine the RowIndex of the Row whose Button was clicked.
            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

            'Reference the GridView Row.
            Dim row As GridViewRow = payrollView.Rows(rowIndex)

            'Fetch value of Name.
            'Dim id As String = TryCast(row.FindControl("txtName"), TextBox).Text
            Dim id As String = row.Cells(2).Text
            txtId.Text = id
            delete.Enabled = True
            'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('id: " & id + "');", True)
        Else
            If e.CommandName = "Edittt" Then

                'Determine the RowIndex of the Row whose Button was clicked.
                Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

                'Reference the GridView Row.
                Dim row As GridViewRow = payrollView.Rows(rowIndex)

                'Fetch value of Name.
                'Dim id As String = TryCast(row.FindControl("txtName"), TextBox).Text

                Dim id As String = row.Cells(2).Text
                Dim branch_office As String = row.Cells(3).Text
                Dim employee_name As String = row.Cells(4).Text
                Dim income As String = row.Cells(5).Text

                Dim routing_number As String = row.Cells(8).Text
                Dim account_number As String = row.Cells(9).Text
                Dim comments As String = row.Cells(10).Text

                methods.setSpecificId(id)
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('id: " & methods.id + "');", True)
                'Server.Transfer("Contact.aspx", True) server transfer reset the methods.is when passing the value

                Session("val") = methods.id
                Session("branch_office") = branch_office
                Session("employee_name") = employee_name

                Session("income") = income
                Session("routing_number") = routing_number
                Session("account_number") = account_number

                Session("comments") = comments

                Response.Redirect("Contact.aspx")
            End If
        End If
    End Sub

End Class