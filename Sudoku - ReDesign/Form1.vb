Imports System.IO

Public Class Form1

    Dim Game As Sudoku

    'Most functions below handle the events called by the controls on the form. 
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Game = New Sudoku

        Game.Keypads.Add(KeyPad_1)
        Game.Keypads.Add(KeyPad_2)
        Game.Keypads.Add(Keypad_3)
        Game.Keypads.Add(KeyPad_4)
        Game.Keypads.Add(KeyPad_5)
        Game.Keypads.Add(Keypad_6)
        Game.Keypads.Add(Keypad_7)
        Game.Keypads.Add(Keypad_8)
        Game.Keypads.Add(Keypad_9)

        For Each ele In Game.Keypads
            AddHandler ele.Click, AddressOf Game.KeypadButtonClick
        Next

        Form_BeginningState()
        KeyPreview = True
    End Sub

    Private Sub DropDown_Difficulty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDown_Difficulty.SelectedIndexChanged
        Game.NewGame()
        Form_NormalPlayState()
    End Sub

    Private Sub Check_ShowDebug_CheckedChanged(sender As Object, e As EventArgs) Handles Check_ShowDebug.CheckedChanged

        If Check_ShowDebug.Checked = True Then

            Me.Size = New Size(Form.Location.X + Form.Width + 30, Me.Height)

        Else
            Me.Size = New Size(Group_Controls.Location.X + Group_Controls.Size.Width + 20, Me.Height)
        End If

    End Sub

    Private Sub Rad_Pencil_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_Pencil.CheckedChanged
        Game.UpdateKeypads()
    End Sub

    Private Sub Btn_SolveBoard_Click(sender As Object, e As EventArgs) Handles Btn_SolveBoard.Click
        Game.PrimeBoard(Game.BoardHandler.SolvedBoard)
    End Sub

    Private Sub Btn_SolveSingleCell_Click(sender As Object, e As EventArgs) Handles Btn_SolveSingleCell.Click
        Game.SolveSingleCell()
        Game.UpdateKeypads()
    End Sub

    Private Sub Btn_Next_Click(sender As Object, e As EventArgs) Handles Btn_Next.Click

        Game.UpdateBoardFromDisplay()
        Game.BoardHandler.PrelimSolve_Single(Game.BoardHandler.MainBoard, vbNull, vbNull)
        Game.PrimeBoard(Game.BoardHandler.MainBoard)
        Game.ShowCandidates()


    End Sub

    Private Sub Btn_PartialSolve_Click(sender As Object, e As EventArgs) Handles Btn_PartialSolve.Click
        Game.UpdateBoardFromDisplay()
        Game.BoardHandler.PrelimSolve(Game.BoardHandler.MainBoard, vbNull, vbNull)
        Game.PrimeBoard(Game.BoardHandler.MainBoard)
        Game.ShowCandidates()
    End Sub

    Private Sub Btn_CheckValidity_Click(sender As Object, e As EventArgs) Handles Btn_CheckValidity.Click

        Game.UpdateBoardFromDisplay()
        Dim v = Game.BoardHandler.Prelim_IsBoardValid(Game.BoardHandler.MainBoard)

        MsgBox("Board Validity: " + v.ToString())

    End Sub

    Private Sub Btn_ResetBoard_Click(sender As Object, e As EventArgs) Handles Btn_ResetBoard.Click
        Game.ResetBoard()
    End Sub

    Private Sub Btn_NewGame_Click(sender As Object, e As EventArgs) Handles Btn_NewGame.Click
        Game.NewGame()
        Form_NormalPlayState()
    End Sub

    'Below are a series of states that the form can be in during the duration of the play.
    'This limits the user's input during certain times.
    Public Sub Form_BeginningState()
        Btn_NewGame.Enabled = False
        DropDown_Difficulty.Visible = True
        Btn_ManualEntry.Enabled = True
        lbl_ManualEntryAlert.Enabled = False
        SubGroup_Keypad.Enabled = False
        Check_ShowDebug.Checked = True
        Check_Can_Removal.Checked = True
        Check_Highlighting.Enabled = False
        Check_Highlighting.Checked = False
        Check_Medusa.Enabled = False
        Check_Medusa.Checked = False
        Rad_MedusaBlue.Checked = True
        Rad_MedusaBlue.Enabled = False
        Rad_MedusaRed.Enabled = False
        SubGroup_Solving.Enabled = False
        SubGroup_Misc.Enabled = False
    End Sub

    Public Sub Form_NormalPlayState()

        Btn_NewGame.Enabled = True
        DropDown_Difficulty.Enabled = True
        Btn_ManualEntry.Enabled = True
        lbl_ManualEntryAlert.Visible = False
        SubGroup_Keypad.Enabled = True
        Rad_Pencil.Enabled = True
        Rad_Pen.Enabled = True
        Check_Can_Removal.Checked = True
        Check_Highlighting.Enabled = True
        Check_Highlighting.Checked = False
        Check_Medusa.Enabled = True
        Check_Medusa.Checked = False
        Rad_MedusaBlue.Checked = True
        Rad_MedusaBlue.Enabled = False
        Rad_MedusaRed.Enabled = False
        SubGroup_Solving.Enabled = True
        SubGroup_Misc.Enabled = True

    End Sub

    Public Sub Form_ManualEntryState()
        Btn_NewGame.Enabled = False
        DropDown_Difficulty.Enabled = False
        Btn_ManualEntry.Enabled = True
        lbl_ManualEntryAlert.Visible = True
        SubGroup_Keypad.Enabled = True
        Rad_Pencil.Enabled = False
        Rad_Pen.Checked = True
        Check_Can_Removal.Checked = False
        Check_Highlighting.Enabled = False
        Check_Highlighting.Checked = False
        Check_Medusa.Enabled = False
        Check_Medusa.Checked = False
        Rad_MedusaBlue.Checked = True
        Rad_MedusaBlue.Enabled = False
        Rad_MedusaRed.Enabled = False
        SubGroup_Solving.Enabled = False
        SubGroup_Misc.Enabled = False
    End Sub

    Private Sub Btn_ManualEntry_Click(sender As Object, e As EventArgs) Handles Btn_ManualEntry.Click

        If Btn_ManualEntry.Text <> "Finish" Then
            Form_ManualEntryState()
            Game.InitiateManualEntry()
        Else
            Game.FinaliseManualEntry()
            Form_NormalPlayState()
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If IsNothing(Game.CurrentCell) = False Then


            If e.KeyCode >= 49 And e.KeyCode <= 57 Then

                Dim val As Integer

                If e.KeyCode = 49 Then
                    val = 1
                ElseIf e.KeyCode = 50 Then
                    val = 2
                ElseIf e.KeyCode = 51 Then
                    val = 3
                ElseIf e.KeyCode = 52 Then
                    val = 4
                ElseIf e.KeyCode = 53 Then
                    val = 5
                ElseIf e.KeyCode = 54 Then
                    val = 6
                ElseIf e.KeyCode = 55 Then
                    val = 7
                ElseIf e.KeyCode = 56 Then
                    val = 8
                ElseIf e.KeyCode = 57 Then
                    val = 9

                End If

                Game.HandleKeypadInput(val)

            End If
        End If

    End Sub
End Class
