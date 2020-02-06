Imports System.IO


Public Class Login_Form


    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim user, pass As String
        user = Txt_Username.Text
        pass = Txt_Pass.Text

        If user = "" Or pass = "" Then
            MsgBox("One of the boxes are empty. Fill em up!")
        End If

        Using reader = New StreamReader("Users.txt")

            While Not reader.EndOfStream

                If reader.ReadLine = user Then
                    If Not reader.EndOfStream Then
                        If reader.ReadLine = pass Then
                            Form1.Activate()
                            Form1.Show()
                            MsgBox("Login Successful!")
                            Me.Close()
                            Exit Sub
                        End If
                    End If
                End If

            End While
            MsgBox("Username or Password incorrect")
        End Using

    End Sub

    Private Sub SignUp_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim user, pass As String
        user = Txt_Username.Text
        pass = Txt_Pass.Text
        If user = "" Or pass = "" Then
            MsgBox("One of the boxes are empty. Fill em up!")
        End If

        Using writer = New StreamWriter("Users.txt", True)

            writer.WriteLine(user)
            writer.WriteLine(pass)
            Form1.Activate()
            Form1.Show()
            Me.Close()
        End Using

    End Sub


End Class