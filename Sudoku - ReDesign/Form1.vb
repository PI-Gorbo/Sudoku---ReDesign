Imports System.IO

Public Class Form1

    Dim Game As Sudoku
    Public LastClicked As CheckBox


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
        LastClicked = Nothing
        Form_BeginningState()
        KeyPreview = True
        DropDown_Medusa.SelectedIndex = 0
    End Sub

    'Drop Down changes
    Private Sub DropDown_Difficulty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDown_Difficulty.SelectedIndexChanged
        Game.NewGame()
        Form_NormalPlayState()
        Me.ActiveControl = Nothing
    End Sub

    'Check button that reveals the saving stuff and dialogue box
    Private Sub ShowExtraOptions(sender As Object, e As EventArgs) Handles Check_Options.CheckedChanged

        If Check_Options.Checked = True Then

            Me.Size = New Size(Group_ExtraOptions.Location.X + Group_ExtraOptions.Width + 30, Me.Height)

        Else
            Me.Size = New Size(Group_Controls.Location.X + Group_Controls.Size.Width + 20, Me.Height)
        End If

    End Sub

    'Handles "Pen" Radio button changes
    Private Sub Rad_Pencil_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_Pencil.CheckedChanged
        Game.UpdateKeypads()
    End Sub

    'Handles when ppl press the solve board buttn
    Private Sub Btn_SolveBoard_Click(sender As Object, e As EventArgs) Handles Btn_SolveBoard.Click
        Game.PrimeBoard(Game.BoardHandler.SolvedBoard)
    End Sub

    'Single cell button
    Private Sub Btn_SolveSingleCell_Click(sender As Object, e As EventArgs) Handles Btn_SolveSingleCell.Click
        Game.SolveSingleCell()
        Game.UpdateKeypads()
    End Sub

    'Next button click / Staged Solve
    Private Sub Btn_Next_Click(sender As Object, e As EventArgs) Handles Btn_StagedSolving.Click

        If Btn_StagedSolving.Text = "Calc Candidates" Then
            'Stage 1 of solving a board
            Game.UpdateBoardFromDisplay(False)
            Game.BoardHandler.CalculateCandidates(Game.BoardHandler.MainBoard, vbNull, vbNull)
            Game.PrimeBoard(Game.BoardHandler.MainBoard)
            Game.ShowCandidates()
            Btn_StagedSolving.Text = "Next Step"
            Btn_PrelimSolve.Enabled = True

        ElseIf Btn_StagedSolving.Text = "Next Step" Then
            'Stage 2 of solving board. A loop 
            Game.UpdateBoardFromDisplay(True)
            Game.BoardHandler.PrelimSolve_Single(Game.BoardHandler.MainBoard, vbNull, vbNull)
            Game.PrimeBoard(Game.BoardHandler.MainBoard)
            Game.ShowCandidates()

        End If
        Game.UpdateKeypads()
        Game.RefreshHighlight(False)

    End Sub

    'Check Validity click
    Private Sub Btn_CheckValidity_Click(sender As Object, e As EventArgs) Handles Btn_CheckValidity.Click

        Game.UpdateBoardFromDisplay(True)
        Dim v = Game.BoardHandler.Prelim_IsBoardValid(Game.BoardHandler.MainBoard)

        MsgBox("Board Validity: " + v.ToString())

    End Sub

    'Reset board click
    Private Sub Btn_ResetBoard_Click(sender As Object, e As EventArgs) Handles Btn_ResetBoard.Click
        Game.ResetBoard()
    End Sub

    'New game click
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
        Check_Options.Checked = True
        Check_Can_Removal.Checked = True
        Check_EnableHighlighting.Checked = False
        Drop_HighlightSelect.Enabled = False
        Drop_HighlightSelect.SelectedIndex = 0
        DropDown_Medusa.Enabled = False
        DropDown_Medusa.Visible = False
        Rad_MedusaC1.Enabled = False
        Rad_MedusaC1.Visible = False
        Rad_MedusaC1.Enabled = False
        Rad_MedusaC2.Visible = False
        Check_Overlay2.Enabled = False
        Check_Overlay2.Visible = False
        Check_Overlay1.Enabled = False
        Check_Overlay1.Visible = False
        Check_EnableHighlighting.Enabled = False
        SubGroup_Solving.Enabled = False
        SubGroup_Misc.Enabled = False
        Btn_LoadGame.Enabled = True
        Btn_SaveGame.Enabled = False
        Btn_PrelimSolve.Enabled = False
        DropDown_Medusa.Enabled = False
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
        Check_EnableHighlighting.Enabled = True
        Check_EnableHighlighting.Checked = False
        SubGroup_Solving.Enabled = True
        SubGroup_Misc.Enabled = True
        Btn_StagedSolving.Text = "Calc Candidates"
        Btn_LoadGame.Enabled = True
        Btn_SaveGame.Enabled = True
        Btn_PrelimSolve.Enabled = False
        DropDown_Medusa.Enabled = False

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
        Check_EnableHighlighting.Enabled = False
        Check_EnableHighlighting.Checked = False
        Drop_HighlightSelect.Enabled = False
        Drop_HighlightSelect.SelectedIndex = 0
        DropDown_Medusa.Enabled = False
        DropDown_Medusa.Visible = False
        Rad_MedusaC1.Enabled = False
        Rad_MedusaC1.Visible = False
        Rad_MedusaC1.Enabled = False
        Rad_MedusaC2.Visible = False
        Check_Overlay2.Enabled = False
        Check_Overlay2.Visible = False
        Check_Overlay1.Enabled = False
        Check_Overlay1.Visible = False
        Check_EnableHighlighting.Enabled = False
        Check_EnableHighlighting.Checked = False
        SubGroup_Solving.Enabled = False
        SubGroup_Misc.Enabled = False
        Btn_LoadGame.Enabled = False
        Btn_SaveGame.Enabled = False
        DropDown_Medusa.Enabled = False

    End Sub

    'Manual Entry Click
    Private Sub Btn_ManualEntry_Click(sender As Object, e As EventArgs) Handles Btn_ManualEntry.Click

        If Btn_ManualEntry.Text <> "Finish" Then
            Form_ManualEntryState()
            Game.InitiateManualEntry()
        Else
            Game.FinaliseManualEntry()
            Form_NormalPlayState()
        End If
    End Sub

    'Handles Keypresses
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Me.ActiveControl = Nothing

        If IsNothing(Game.CurrentCell) = False Then

            If e.KeyCode >= 49 And e.KeyCode <= 57 Then

                Dim val As Integer

                If e.KeyCode = 49 Then 'Keyboard press 1
                    val = 1
                ElseIf e.KeyCode = 50 Then 'Keyboard press 2
                    val = 2
                ElseIf e.KeyCode = 51 Then 'Keyboard press 3
                    val = 3
                ElseIf e.KeyCode = 52 Then 'Keyboard press 4
                    val = 4
                ElseIf e.KeyCode = 53 Then 'Keyboard press 5
                    val = 5
                ElseIf e.KeyCode = 54 Then 'Keyboard press 6
                    val = 6
                ElseIf e.KeyCode = 55 Then 'Keyboard press 7
                    val = 7
                ElseIf e.KeyCode = 56 Then 'Keyboard press 8
                    val = 8
                ElseIf e.KeyCode = 57 Then 'Keyboard press 9
                    val = 9
                End If

                Game.SimulateKeypadInput(val)
                Exit Sub
            End If
        End If

        If IsNothing(Game.CurrentCell) = False Then
            If e.KeyCode = Keys.Right Then

                If Game.CurrentCell.Location.X + 1 > 8 Then
                    Game.HandleLabelClick(Game.Cells(Game.CurrentCell.Location.Y, 0))
                Else
                    Game.HandleLabelClick(Game.Cells(Game.CurrentCell.Location.Y, Game.CurrentCell.Location.X + 1))
                End If

            ElseIf e.KeyCode = Keys.Left Then

                If Game.CurrentCell.Location.X - 1 < 0 Then
                    Game.HandleLabelClick(Game.Cells(Game.CurrentCell.Location.Y, 8))
                Else
                    Game.HandleLabelClick(Game.Cells(Game.CurrentCell.Location.Y, Game.CurrentCell.Location.X - 1))
                End If

            ElseIf e.KeyCode = Keys.Up Then

                If Game.CurrentCell.Location.Y - 1 < 0 Then
                    Game.HandleLabelClick(Game.Cells(8, Game.CurrentCell.Location.X))
                Else
                    Game.HandleLabelClick(Game.Cells(Game.CurrentCell.Location.Y - 1, Game.CurrentCell.Location.X))
                End If

            ElseIf e.KeyCode = Keys.Down Then

                If Game.CurrentCell.Location.Y + 1 > 8 Then
                    Game.HandleLabelClick(Game.Cells(0, Game.CurrentCell.Location.X))
                Else
                    Game.HandleLabelClick(Game.Cells(Game.CurrentCell.Location.Y + 1, Game.CurrentCell.Location.X))
                End If

            End If
        End If
    End Sub

    'LoadGame click
    Private Sub Btn_LoadGame_Click(sender As Object, e As EventArgs) Handles Btn_LoadGame.Click

        Dim _err As Boolean = False
        Dim cancel As Boolean = False

        Game.BoardHandler.LoadNewGame_Dialogue(_err, cancel)
        If _err = False And cancel = False Then

            Game.PrimeBoard(Game.BoardHandler.MainBoard)
            Form_NormalPlayState()

        End If

    End Sub

    Private Sub Btn_SaveGame_Click(sender As Object, e As EventArgs) Handles Btn_SaveGame.Click

        Game.UpdateBoardFromDisplay(True)
        Game.BoardHandler.SaveGame()

    End Sub

    Private Sub Btn_ClearHighlight_Click(sender As Object, e As EventArgs) Handles Btn_ClearHighlight.Click


        If Check_EnableHighlighting.Checked = False Then 'If highlighting is not selected
            Game.RefreshHighlight(False)
            Game.UpdateKeypads()
        ElseIf Drop_HighlightSelect.SelectedIndex = 0 Then 'If highlighted candidates selected
            Game.RefreshHighlight(True)
            Game.UpdateKeypads()
        ElseIf Drop_HighlightSelect.SelectedIndex = 1 Then 'If medusa selected

            If DropDown_Medusa.SelectedIndex = 0 Then
                If IsNothing(Game.Medusa0(0)) = False Then
                    Game.Medusa0(0).Clear()
                End If
                If IsNothing(Game.Medusa0(1)) = False Then
                    Game.Medusa0(1).Clear()
                End If
                Game.RefreshHighlight(False)

            ElseIf DropDown_Medusa.SelectedIndex = 1 Then
                If IsNothing(Game.Medusa1(0)) = False Then
                    Game.Medusa1(0).Clear()
                End If
                If IsNothing(Game.Medusa1(1)) = False Then
                    Game.Medusa1(1).Clear()
                End If
                Game.RefreshHighlight(False)

            Else
                If IsNothing(Game.Medusa2(0)) = False Then
                    Game.Medusa2(0).Clear()
                End If
                If IsNothing(Game.Medusa2(1)) = False Then
                    Game.Medusa2(1).Clear()
                End If
                Game.RefreshHighlight(False)

            End If

        End If



    End Sub

    Private Sub Btn_PrelimSolve_Click(sender As Object, e As EventArgs) Handles Btn_PrelimSolve.Click

        Game.UpdateBoardFromDisplay(True)
        Game.BoardHandler.PrelimSolve(Game.BoardHandler.MainBoard, vbNull, vbNull)
        Game.PrimeBoard(Game.BoardHandler.MainBoard)
        Game.ShowCandidates()

    End Sub

    'Handles when the dropdown medusa changes
    Private Sub DropDown_Medusa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDown_Medusa.SelectedIndexChanged

        Check_Overlay1.Checked = False
        Check_Overlay2.Checked = False

        'Red + Blue = Index 0
        'Green +Purple = Index 1
        'Yellow +Pink = Index 2

        If DropDown_Medusa.SelectedIndex = 0 Then

            Rad_MedusaC1.Text = "Blue"
            Rad_MedusaC2.Text = "Red"
            Check_Overlay1.Text = "Overlay Green & Purple"
            Check_Overlay2.Text = "Overlay Yellow & Pink"

        ElseIf DropDown_Medusa.SelectedIndex = 1 Then

            Rad_MedusaC1.Text = "Green"
            Rad_MedusaC2.Text = "Purple"
            Check_Overlay1.Text = "Overlay Red & Blue"
            Check_Overlay2.Text = "Overlay Yellow & Pink"

        ElseIf DropDown_Medusa.SelectedIndex = 2 Then

            Rad_MedusaC1.Text = "Yellow"
            Rad_MedusaC2.Text = "Pink"
            Check_Overlay1.Text = "Overlay Red & Blue"
            Check_Overlay2.Text = "Overlay Green & Purple"

        End If
        Game.MedusaChanged()
    End Sub

    Private Sub Check_EnableHighlighting_CheckedChanged(sender As Object, e As EventArgs) Handles Check_EnableHighlighting.CheckedChanged

        If Check_EnableHighlighting.Checked = True Then
            Drop_HighlightSelect.Enabled = True
            If Drop_HighlightSelect.SelectedIndex = 1 Then
                DropDown_Medusa.Enabled = True
                Rad_MedusaC1.Enabled = True
                Rad_MedusaC1.Enabled = True
            End If
        Else
                Drop_HighlightSelect.Enabled = False
            DropDown_Medusa.Enabled = False
            Rad_MedusaC1.Enabled = False
            Rad_MedusaC1.Enabled = False
        End If

    End Sub

    Private Sub Drop_HighlightSelect_SelectedIndexChanged(sender As ComboBox, e As EventArgs) Handles Drop_HighlightSelect.SelectedIndexChanged

        DropDown_Medusa.Enabled = False
        DropDown_Medusa.Visible = False
        Rad_MedusaC1.Enabled = False
        Rad_MedusaC1.Visible = False
        Rad_MedusaC1.Enabled = False
        Rad_MedusaC2.Visible = False
        Check_Overlay2.Enabled = False
        Check_Overlay2.Visible = False
        Check_Overlay1.Enabled = False
        Check_Overlay1.Visible = False


        If sender.SelectedIndex = 0 Then 'Highlighting

            If IsNothing(Game.CurrentCell) = False Then
                Game.CellBoarder(Game.CurrentCell, False)
                Game.CurrentCell.ValueLabel.BackColor = Color.GhostWhite
                Game.CurrentCell = Nothing
            End If

        ElseIf sender.SelectedIndex = 1 Then 'Medusa

            DropDown_Medusa.Enabled = True
            DropDown_Medusa.Visible = True
            Rad_MedusaC1.Enabled = True
            Rad_MedusaC1.Visible = True
            Rad_MedusaC2.Enabled = True
            Rad_MedusaC2.Visible = True
            Rad_MedusaC1.Checked = True
            Check_Overlay1.Enabled = True
            Check_Overlay1.Visible = True
            Check_Overlay2.Enabled = True
            Check_Overlay2.Visible = True
            Game.MedusaChanged()

        ElseIf sender.SelectedIndex = 2 Then 'Linking


        ElseIf sender.SelectedIndex = 3 Then 'Locked Sets


        End If

        Game.RefreshHighlight(False)
        Game.UpdateKeypads()

    End Sub

    Private Sub Check_Overlay1_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Overlay1.CheckedChanged
        Game.MedusaChanged()
    End Sub

    Private Sub Check_Overlay2_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Overlay2.CheckedChanged
        Game.MedusaChanged()
    End Sub

End Class
