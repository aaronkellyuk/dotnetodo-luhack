Imports LoginLogic

Public Class LoginWindow
    Private txtUsername As Object
    Private txtPassword As Object

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim isValid As Boolean = LoginLogic.ValidateLogin(txtUsername.Text, txtPassword.Text)

        If isValid Then
            MessageBox.Show("Logged in as ", txtUsername.Text, " with Password ", txtPassword.Text)

            Dim mainWindow As New MainWindow()
            mainWindow.Show()
            Me.Hide()
        Else
            Dim messageBoxResult = MessageBox.Show("Invalid Username or Password")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
