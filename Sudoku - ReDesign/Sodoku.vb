﻿Public Class Sudoku 'General Functions 

    Public Cells(8, 8) As DisplayCell
    Public BoardHandler As New BoardHandler
    Public CurrentCell As DisplayCell
    Public Keypads As List(Of Button)
    Public HighlightedCandidates As New List(Of Integer)
    Public Colours(11) As Color
    Public StandardFont, UnderlineFont As Font


    'When a new sudoku is created, create all the labels that the board is going to use to display
    Public Sub New()

        StandardFont = New Font("Roboto", CANDIDATE_SIZEpx * 1.5, FontStyle.Bold)
        UnderlineFont = New Font("Roboto", CANDIDATE_SIZEpx * 1.5, FontStyle.Underline)

        CreateBoard()
        HighlightedCandidates.Clear()
        CurrentCell = Nothing
        Keypads = New List(Of Button)

        Colours(1) = Color.FromArgb(255, 205, 91, 3)
        Colours(2) = Color.FromArgb(255, 110, 29, 115)
        Colours(3) = Color.FromArgb(255, 106, 139, 35)
        Colours(4) = Color.FromArgb(210, 39, 51, 107)
        Colours(5) = Color.FromArgb(255, 0, 171, 113)
        Colours(6) = Color.FromArgb(100, 58, 35, 104)
        Colours(7) = Color.FromArgb(255, 2, 144, 148)
        Colours(8) = Color.FromArgb(255, 112, 199, 21)
        Colours(9) = Color.FromArgb(255, 190, 129, 11)
        Colours(10) = Color.FromArgb(255, 106, 139, 35)
        Colours(11) = Color.FromArgb(210, 39, 51, 107)

    End Sub

    'When newgame is called, call a new board according to the difficulty and display it
    Public Sub NewGame()
        Form1.LastClicked = Nothing
        Form1.Lst_Debug.Items.Clear()
        RefreshHighlight(True)
        CurrentCell = Nothing
        BoardHandler.NewGame(False)
        PrimeBoard(BoardHandler.MainBoard)
    End Sub

    Public Sub InitiateManualEntry()
        Form1.LastClicked = Nothing
        Form1.Btn_ManualEntry.Text = "Finish"
        BoardHandler.BoardChosen_Short = ""
        BoardHandler.NewGame(True)
        PrimeBoard(BoardHandler.MainBoard)

    End Sub

    'Creates the dialogue for finishing the manual entry
    Public Sub FinaliseManualEntry()

        Dim result As DialogResult
        Dim BoardValid As Boolean

        result = MessageBox.Show("Are you sure you are finished with manual entry? Yes will initialise the check for the validiity of the board. Cancel with stop manual entry", "", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then

            Exit Sub

        ElseIf result = DialogResult.Cancel Then

            BoardHandler.NewGame(False)
            PrimeBoard(BoardHandler.MainBoard)
            Form1.Form_NormalPlayState()
            Form1.Btn_ManualEntry.Text = "Manual Entry"

            Exit Sub
        End If

        UpdateBoardFromManualEntry()
        BoardValid = BoardHandler.Prelim_IsBoardValid(BoardHandler.MainBoard)
        If BoardValid = False Then

            result = MessageBox.Show("Inputted Board is invalid. Would you like to change values and check again? Click no to cancel manual entry.", "", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                BoardHandler.NewGame(True)
                Exit Sub
            ElseIf result = DialogResult.No Then
                BoardHandler.NewGame(False)
                PrimeBoard(BoardHandler.MainBoard)
                Form1.Form_NormalPlayState()
                Form1.Btn_ManualEntry.Text = "Manual Entry"
                Exit Sub
            End If

        Else

            result = MessageBox.Show("Inputted Board Valid. Do you want to save the board?.", "", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim successful As Boolean
                BoardHandler.SaveGame()
                If successful = True Then
                    MsgBox("Board Saved!")
                End If

            End If

        End If
        BoardHandler.SolvedBoard = New Board(BoardHandler.MainBoard)
        BoardHandler.Bruteforce(BoardHandler.SolvedBoard, vbNull, vbNull)
        PrimeBoard(BoardHandler.MainBoard)
        Form1.Btn_ManualEntry.Text = "Manual Entry"

    End Sub

    Public Sub UpdateBoardFromManualEntry()

        'Iderate through the board.
        For Rows = 0 To 8
            For Cols = 0 To 8

                'If the cell has a value label, set that value in the original board.
                If Cells(Rows, Cols).HasValueLabel = True Then
                    BoardHandler.MainBoard.Cells(Rows, Cols).Value = Integer.Parse(Cells(Rows, Cols).ValueLabel.Text)
                    BoardHandler.MainBoard.Cells(Rows, Cols).HasValueFromImport = True
                Else 'Else, add the candidates that the cell has

                    For i = 1 To 9
                        BoardHandler.MainBoard.Cells(Rows, Cols).Candidates.Add(i)
                    Next

                End If
            Next
        Next

    End Sub

    'takes events from label clicks
    Public Sub LabelClick(ByVal sender As Label, e As System.EventArgs)
        HandleLabelInput(sender.Tag)
    End Sub

    'Handles information from label clicks
    Public Sub HandleLabelInput(Cell As DisplayCell)


        If Form1.Check_Highlighting.Checked = True Then 'Stops any input when doing highlighted candidiates
            CurrentCell = Nothing
            Exit Sub
        Else

            If IsNothing(CurrentCell) Then
                CurrentCell = Cell
            Else
                CellBoarder(CurrentCell, False)
                CurrentCell.ValueLabel.BackColor = Color.GhostWhite
                For Each ele In CurrentCell.Labels_Array
                    ele.ForeColor = Color.Black
                Next
                CurrentCell = Cell
            End If

            If CurrentCell.HasValueLabel = True Then
                CurrentCell.ValueLabel.BackColor = Color.DarkSalmon
            Else
                CellBoarder(CurrentCell, True)

            End If
            UpdateKeypads()
            CheckForSolutionConflicts()
        End If
    End Sub

    'Takes event calls from keypad clicks
    Public Sub KeypadButtonClick(ByVal sender As Button, e As System.EventArgs)
        HandleKeypadInput(Integer.Parse(sender.Tag))
    End Sub

    'Handles informatuion from keypad clicks
    Public Sub HandleKeypadInput(ClickedVal As Integer)

        If Form1.Check_Highlighting.Checked = True Then

            If HighlightedCandidates.Contains(ClickedVal) Then
                HighlightedCandidates.Remove(ClickedVal)
            Else
                HighlightedCandidates.Add(ClickedVal)
            End If
            RefreshHighlight(False)
            UpdateKeypads()

            Exit Sub
        ElseIf Form1.Check_Medusa.Checked = True Then

            If Form1.Rad_MedusaBlue.Checked = True Then

                If CurrentCell.Candidates.Contains(ClickedVal) = False Then
                    Exit Sub
                End If

                If CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(10) Then
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                Else
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(10)
                End If

            ElseIf Form1.Rad_MedusaRed.Checked = True Then

                If CurrentCell.Candidates.Contains(ClickedVal) = False Then
                    Exit Sub
                End If

                If CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(11) Then
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                Else
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(11)
                End If

            End If
            UpdateKeypads()
            Exit Sub
        Else
            If IsNothing(CurrentCell) Then
                Exit Sub
            End If

            If BoardHandler.MainBoard.Cells(CurrentCell.Location.Y, CurrentCell.Location.X).HasValueFromImport = False Then


                If Form1.Rad_Pen.Checked = True And CurrentCell.HasValueLabel Then 'Pen

                    RemoveValueLabel(CurrentCell)
                    UpdateCandidates(CurrentCell)
                    CheckForSolutionConflicts()

                ElseIf Form1.Rad_Pen.Checked = True And CurrentCell.HasValueLabel = False Then 'Pen

                    UpdateToValueLabel(CurrentCell, ClickedVal)
                    CheckForSolutionConflicts()

                ElseIf Form1.Rad_Pencil.Checked = True And CurrentCell.Candidates.Contains(ClickedVal) Then 'Pencil

                    If ClickedVal = BoardHandler.SolvedBoard.Cells(CurrentCell.Location.Y, CurrentCell.Location.X).Value And Form1.Check_Can_Removal.Checked = True Then
                        CurrentCell.Labels_Array(ClickedVal - 1).ForeColor = Color.Red
                    Else
                        CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                        CurrentCell.Candidates.Remove(ClickedVal)
                        UpdateCandidates(CurrentCell)
                    End If



                ElseIf Form1.Rad_Pencil.Checked = True And CurrentCell.Candidates.Contains(ClickedVal) = False Then 'Pencil

                        CurrentCell.Candidates.Add(ClickedVal)
                    UpdateCandidates(CurrentCell)

                End If
                UpdateKeypads()
            End If
        End If

    End Sub

    'Checks for obvious conflicts between cells and then if the check button is ticked, checks for a value conflcit with the solutions
    Public Sub CheckForSolutionConflicts()

        For Rows = 0 To 8
            For Cols = 0 To 8
                If Cells(Rows, Cols).HasValueLabel = True Then
                    Cells(Rows, Cols).ValueLabel.BackColor = Color.GhostWhite
                End If
            Next
        Next

        Dim TempRowMin, TempRowMax, TempColMin, TempColMax As Integer

        For Rows = 0 To 8
            For Cols = 0 To 8

                If Cells(Rows, Cols).HasValueLabel = True Then

                    For TempRows = 0 To 8
                        If Cells(TempRows, Cols).HasValueLabel = True Then

                            If Cells(TempRows, Cols).ValueLabel.Text = Cells(Rows, Cols).ValueLabel.Text And Cells(TempRows, Cols).Equals(Cells(Rows, Cols)) = False Then
                                Cells(TempRows, Cols).ValueLabel.BackColor = Color.IndianRed
                            End If
                        End If
                    Next

                    For TempCols = 0 To 8
                        If Cells(Rows, TempCols).HasValueLabel = True Then

                            If Cells(Rows, TempCols).ValueLabel.Text = Cells(Rows, Cols).ValueLabel.Text And Cells(Rows, TempCols).Equals(Cells(Rows, Cols)) = False Then
                                Cells(Rows, TempCols).ValueLabel.BackColor = Color.IndianRed
                            End If
                        End If
                    Next

                    If Rows <= 2 Then
                        TempRowMin = 0
                        TempRowMax = 2
                    ElseIf Rows >= 3 And Rows <= 5 Then
                        TempRowMin = 3
                        TempRowMax = 5
                    ElseIf Rows >= 6 Then
                        TempRowMin = 6
                        TempRowMax = 8
                    End If

                    If Cols <= 2 Then
                        TempColMin = 0
                        TempColMax = 2
                    ElseIf Cols >= 3 And Cols <= 5 Then
                        TempColMin = 3
                        TempColMax = 5
                    ElseIf Cols >= 6 Then
                        TempColMin = 6
                        TempColMax = 8
                    End If

                    For TempRows = TempRowMin To TempRowMax
                        For TempCols = TempColMin To TempColMax

                            If Cells(TempRows, TempCols).HasValueLabel = True Then

                                If Cells(TempRows, TempCols).ValueLabel.Text = Cells(Rows, Cols).ValueLabel.Text And Cells(TempRows, TempCols).Equals(Cells(Rows, Cols)) = False Then
                                    Cells(TempRows, TempCols).ValueLabel.BackColor = Color.IndianRed
                                End If
                            End If

                        Next
                    Next

                    If Cells(Rows, Cols).ValueLabel.Font.Equals(UnderlineFont) Then
                        Cells(Rows, Cols).ValueLabel.Font = StandardFont
                    End If

                    If Form1.Check_Can_Removal.Checked = True Then

                        If Integer.Parse(Cells(Rows, Cols).ValueLabel.Text) <> BoardHandler.SolvedBoard.Cells(Rows, Cols).Value Then
                            Cells(Rows, Cols).ValueLabel.Font = UnderlineFont
                        End If

                    End If
                End If
            Next
        Next

        If IsNothing(CurrentCell) = False Then
            If CurrentCell.HasValueLabel = True Then
                CurrentCell.ValueLabel.BackColor = Color.DarkSalmon
            End If
        End If



    End Sub

    'Updates the colouring of the keypads to reflect the current mode or selection
    Public Sub UpdateKeypads()

        If Form1.Check_Highlighting.Checked = True Then
            'Do Something

            For Each ele In Keypads
                ele.BackColor = Color.GhostWhite
                If HighlightedCandidates.Contains(Integer.Parse(ele.Tag)) Then
                    ele.BackColor = Colours(Integer.Parse(ele.Tag))
                End If
            Next

            Exit Sub
        ElseIf Form1.Check_Medusa.Checked = True Then
            'Do Something

            If Not IsNothing(CurrentCell) Then
                Dim count = 1
                For Each ele In CurrentCell.Labels_Array
                    Keypads(count - 1).BackColor = ele.BackColor
                    count += 1
                Next

            End If

            Exit Sub
        Else

            For Each ele In Keypads
                ele.BackColor = Color.GhostWhite
            Next

            If IsNothing(CurrentCell) = False Then

                If CurrentCell.HasValueLabel And Form1.Rad_Pen.Checked = True Then
                    Keypads(Integer.Parse(CurrentCell.ValueLabel.Text) - 1).BackColor = Color.DarkSalmon

                ElseIf CurrentCell.HasValueLabel = False And Form1.Rad_Pencil.Checked = True Then

                    Dim count As Integer = 1
                    For Each ele In Keypads
                        If CurrentCell.Candidates.Contains(count) Then
                            Keypads(count - 1).BackColor = Color.DarkSalmon
                        End If
                        count += 1
                    Next

                End If
            End If
        End If

    End Sub

    'Changes the boarder of the cell to be visible or not. 
    'This Is a separate function because the method in which the border Is changed may change
    Public Sub CellBoarder(Cell As DisplayCell, Enabled As Boolean)

        If Enabled = True Then
            Cell.BorderLabel.Visible = True
        Else
            Cell.BorderLabel.Visible = False
        End If

    End Sub

    'Shows the calculated candidates of the current board.
    Public Sub ShowCandidates()

        For Rows = 0 To 8
            For Cols = 0 To 8

                Cells(Rows, Cols).Candidates.Clear()
                For Each ele In BoardHandler.MainBoard.Cells(Rows, Cols).Candidates
                    Cells(Rows, Cols).Candidates.Add(ele)
                Next
                UpdateCandidates(Cells(Rows, Cols))
            Next
        Next

    End Sub

    'Iderates through each cell and highlights which cells needs to be highlighted
    Public Sub RefreshHighlight(ClearHighlighting As Boolean)

        If ClearHighlighting = True Then
            HighlightedCandidates.Clear()
        End If

        Dim count As Integer

        For Rows = 0 To 8
            For Cols = 0 To 8

                count = 1
                For Each ele In Cells(Rows, Cols).Labels_Array
                    ele.BackColor = Color.GhostWhite
                    If HighlightedCandidates.Contains(count) And Cells(Rows, Cols).Candidates.Contains(count) Then
                        ele.BackColor = Colours(count)
                    End If
                    count += 1
                Next

            Next
        Next


    End Sub

    'Displays the value for the current selected cell
    Public Sub SolveSingleCell()

        'if the currentcell does not exist or already has a value, then exit sub
        If IsNothing(CurrentCell) Then
            Exit Sub
        End If

        If CurrentCell.HasValueLabel Then
            If Integer.Parse(CurrentCell.ValueLabel.Text) = BoardHandler.SolvedBoard.Cells(CurrentCell.Location.Y, CurrentCell.Location.X).Value Then
                Exit Sub
            End If
        End If

        Dim Value = BoardHandler.SolvedBoard.Cells(CurrentCell.Location.Y, CurrentCell.Location.X).Value

        UpdateToValueLabel(CurrentCell, Value)


    End Sub

    'Resets the board to its beginning state
    Public Sub ResetBoard()

        BoardHandler.ResetGame(BoardHandler.BoardChosen_Long)
        PrimeBoard(BoardHandler.MainBoard)

    End Sub

    'To Do
    Public Sub Hint()

    End Sub

End Class

Public Class DisplayCell

    Public Location As Point
    Public Labels_Grid(2, 2) As Label
    Public Labels_Array As List(Of Label)
    Public ValueLabel, BorderLabel As Label
    Public SelectedLabel As Label
    Public Candidates As List(Of Integer)
    Public HasValueLabel As Boolean


End Class
