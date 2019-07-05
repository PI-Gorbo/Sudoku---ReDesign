Public Class Form

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Check_ShowDebug.Checked = True
    End Sub

    Private Sub DropDown_Difficulty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDown_Difficulty.SelectedIndexChanged

    End Sub


    Private Sub Check_ShowDebug_CheckedChanged(sender As Object, e As EventArgs) Handles Check_ShowDebug.CheckedChanged

        If Check_ShowDebug.Checked = True Then

            Me.Size = New Size(Lst_Debug.Location.X + Lst_Debug.Width + 30, Me.Height)

        Else
            Me.Size = New Size(Group_Controls.Location.X + Group_Controls.Size.Width + 20, Me.Height)
        End If

    End Sub
End Class
