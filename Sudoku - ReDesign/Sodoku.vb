Public Class Sudoku 'General Functions 

    Public Cells(8, 8) As DisplayCell
    Public BoardHandler As New BoardHandler
    Public CurrentCell As DisplayCell
    Public Keypads As List(Of Button)

    'When a new sudoku is created, create all the labels that the board is going to use to display
    Public Sub New()
        CreateBoard()
        CurrentCell = Nothing
        Keypads = New List(Of Button)
    End Sub

    'When newgame is called, call a new board according to the difficulty and display it
    Public Sub NewGame()
        Form1.Form.Items.Clear()
        ResetHighlight()
        CurrentCell = Nothing
        BoardHandler.NewGame(False)
        PrimeBoard(BoardHandler.MainBoard)
    End Sub

    'TODO
    Public Sub InitiateManualEntry()

        Form1.Btn_ManualEntry.Text = "Finish"
        BoardHandler.BoardChosen_Short = ""
        BoardHandler.NewGame(True)
        PrimeBoard(BoardHandler.MainBoard)

    End Sub

    'TODO
    Public Sub FinaliseManualEntry()

        Form1.Btn_ManualEntry.Text = "Manual Entry"
        UpdateBoardFromManualEntry()
        BoardHandler.SolvedBoard = New Board(BoardHandler.MainBoard)
        BoardHandler.Bruteforce(BoardHandler.SolvedBoard, vbNull, vbNull)
        PrimeBoard(BoardHandler.MainBoard)

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

        If Form1.Check_Highlighting.Checked = True Then
            CurrentCell = Nothing
            Exit Sub
        ElseIf Form1.Check_Medusa.Checked = True Then
            CurrentCell = Nothing
            Exit Sub
        Else

            If IsNothing(CurrentCell) Then
                CurrentCell = Cell
            Else
                CellBoarder(CurrentCell, False)
                CurrentCell.ValueLabel.BackColor = Color.GhostWhite
                CurrentCell = Cell
            End If

            If CurrentCell.HasValueLabel = True Then
                CurrentCell.ValueLabel.BackColor = Color.DarkSalmon
            Else
                CellBoarder(CurrentCell, True)

            End If
            UpdateKeypads()
        End If
    End Sub

    'Takes event calls from keypad clicks
    Public Sub KeypadButtonClick(ByVal sender As Button, e As System.EventArgs)
        HandleKeypadInput(Integer.Parse(sender.Tag))
    End Sub

    'Handles informatuion from keypad clicks
    Public Sub HandleKeypadInput(ClickedVal As Integer)

        If Form1.Check_Highlighting.Checked = True Then
            'DO SOMETHING
            Exit Sub
        ElseIf Form1.Check_Medusa.Checked = True Then
            'DO SOMETHING
            Exit Sub
        Else
            If BoardHandler.MainBoard.Cells(CurrentCell.Location.Y, CurrentCell.Location.X).HasValueFromImport = False Then

                If Form1.Rad_Pen.Checked = True And CurrentCell.HasValueLabel Then

                    RemoveValueLabel(CurrentCell)
                    UpdateCandidates(CurrentCell)

                ElseIf Form1.Rad_Pen.Checked = True And CurrentCell.HasValueLabel = False Then

                    UpdateToValueLabel(CurrentCell, ClickedVal)

                ElseIf Form1.Rad_Pencil.Checked = True And CurrentCell.Candidates.Contains(ClickedVal) Then

                    CurrentCell.Candidates.Remove(ClickedVal)
                    UpdateCandidates(CurrentCell)

                ElseIf Form1.Rad_Pencil.Checked = True And CurrentCell.Candidates.Contains(ClickedVal) = False Then

                    CurrentCell.Candidates.Add(ClickedVal)
                    UpdateCandidates(CurrentCell)

                End If
                UpdateKeypads()
            End If
        End If

    End Sub

    'Updates the colouring of the keypads to reflect the current mode or selection
    Public Sub UpdateKeypads()

        If Form1.Check_Highlighting.Checked = True Then
            'Do Something
            Exit Sub
        ElseIf Form1.Check_Medusa.Checked = True Then
            'Do Something
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

    'TODO
    Public Sub ResetHighlight()
        If Not IsNothing(CurrentCell) Then
            CellBoarder(CurrentCell, False)
            CurrentCell.ValueLabel.BackColor = Color.GhostWhite
        End If
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

        BoardHandler.ResetLogicBoard(BoardHandler.BoardChosen_Long)
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
