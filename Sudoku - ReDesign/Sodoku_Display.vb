Partial Class Sudoku 'Functions related to the display of the sudoku board

    Public Const UP As Integer = 15
    Public Const CANDIDATE_SIZEpx As Integer = 18
    Public Const CANDIDATE_PADDINGpx As Integer = 0
    Public Const TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
    Public Const CELL_PADDINGpx As Integer = 3
    Public Const TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
    Public Const BOX_PADDINGpx As Integer = 6

    'Creates the visual appearance of the board. Labels
    Public Sub CreateBoard()

        For Rows = 0 To 8
            For Cols = 0 To 8

                If IsNothing(Cells(Rows, Cols)) Then
                    Cells(Rows, Cols) = New DisplayCell
                End If
                Cells(Rows, Cols).Labels_Array = New List(Of Label)


                Cells(Rows, Cols).Location = New Point(Cols, Rows)
                Cells(Rows, Cols).Candidates = New List(Of Integer)

                'This section creates the labels
                For lbl_Rows = 0 To 2
                    For lbl_Cols = 0 To 2

                        If IsNothing(Cells(Rows, Cols).Labels_Grid(lbl_Rows, lbl_Cols)) Then
                            Cells(Rows, Cols).Labels_Grid(lbl_Rows, lbl_Cols) = New Label
                            Cells(Rows, Cols).Labels_Array.Add(Cells(Rows, Cols).Labels_Grid(lbl_Rows, lbl_Cols))
                        End If

                        With Cells(Rows, Cols).Labels_Grid(lbl_Rows, lbl_Cols)
                            .Tag = Cells(Rows, Cols)
                            .Text = ""
                            .BackColor = Color.GhostWhite
                            .Size = New Size(CANDIDATE_SIZEpx, CANDIDATE_SIZEpx)
                            .Location = New Point(UP - 3 + (Math.Floor(Cols / 3) * BOX_PADDINGpx) + (Cols * (TOTAL_CELL_SIZEpx + CELL_PADDINGpx)) + (lbl_Cols * (CANDIDATE_SIZEpx + CANDIDATE_PADDINGpx)), UP - 3 + (Math.Floor(Rows / 3) * BOX_PADDINGpx) + (Rows * (TOTAL_CELL_SIZEpx + CELL_PADDINGpx)) + (lbl_Rows * (CANDIDATE_PADDINGpx + CANDIDATE_SIZEpx)))
                            .Font = New Font("Roboto", CANDIDATE_SIZEpx * 0.65, FontStyle.Regular)
                            .TextAlign = ContentAlignment.TopCenter
                            .ForeColor = Color.Black
                        End With

                        AddHandler Cells(Rows, Cols).Labels_Grid(lbl_Rows, lbl_Cols).Click, AddressOf LabelClick
                        Form1.Group_Board.Controls.Add(Cells(Rows, Cols).Labels_Grid(lbl_Rows, lbl_Cols))

                    Next
                Next

                'This section creates the Value Label
                Cells(Rows, Cols).ValueLabel = New Label

                With Cells(Rows, Cols).ValueLabel
                    .Tag = Cells(Rows, Cols)
                    .Location = New Point(Cells(Rows, Cols).Labels_Grid(0, 0).Location.X, Cells(Rows, Cols).Labels_Grid(0, 0).Location.Y)
                    .Size = New Size(TOTAL_CELL_SIZEpx, TOTAL_CELL_SIZEpx)
                    .BackColor = Color.GhostWhite
                    .Font = New Font("Roboto", CANDIDATE_SIZEpx * 1.5, FontStyle.Bold)
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Visible = False
                    .Enabled = False
                    .BringToFront()
                End With

                AddHandler Cells(Rows, Cols).ValueLabel.Click, AddressOf LabelClick
                Form1.Group_Board.Controls.Add(Cells(Rows, Cols).ValueLabel)

                Cells(Rows, Cols).BorderLabel = New Label

                With Cells(Rows, Cols).BorderLabel
                    .Tag = Cells(Rows, Cols)
                    .Size = New Size(TOTAL_CELL_SIZEpx + 6, TOTAL_CELL_SIZEpx + 6)
                    .Location = New Point(Cells(Rows, Cols).Labels_Grid(0, 0).Location.X - 3, Cells(Rows, Cols).Labels_Grid(0, 0).Location.Y - 3)
                    .BackColor = Color.DarkSalmon
                    .Enabled = False
                    .Visible = False
                    .SendToBack()
                End With

                Form1.Group_Board.Controls.Add(Cells(Rows, Cols).BorderLabel)

            Next
        Next

    End Sub

    'Changes the text on the labes appropirate to a select board
    Public Sub PrimeBoard(Board As Board)

        Dim SaveState As Boolean = False
        ClearDisplay()

        For Rows = 0 To 8
            For Cols = 0 To 8

                If Board.Cells(Rows, Cols).Value <> -1 Then
                    UpdateToValueLabel(Cells(Rows, Cols), Board.Cells(Rows, Cols).Value)
                End If

                If Board.Cells(Rows, Cols).Candidates.Count < 9 And Board.Cells(Rows, Cols).Candidates.Count >= 1 Then
                    For Each ele In Board.Cells(Rows, Cols).Candidates
                        Cells(Rows, Cols).Candidates.Add(ele)
                    Next
                End If
                UpdateCandidates(Cells(Rows, Cols))

            Next
        Next
        If Not IsNothing(BoardHandler.BoardChosen_Short) Then
            Form1.lbl_boardname.Text = BoardHandler.BoardChosen_Short.Replace(".txt", "")
        End If
        UpdateKeypads()
    End Sub

    'Makes the large label that displays the value of the cell visible, with a specific value
    Public Sub UpdateToValueLabel(Cell As DisplayCell, Val As Integer)

        Cell.HasValueLabel = True

        With Cell.ValueLabel
            .Text = CStr(Val)
            .Enabled = True
            .Visible = True
            If BoardHandler.MainBoard.Cells(Cell.Location.Y, Cell.Location.X).HasValueFromImport = True Then
                .ForeColor = Color.SlateBlue
            Else
                .ForeColor = Color.Black
            End If

            If IsNothing(CurrentCell) = False Then
                If CurrentCell.Equals(Cell) Then
                    .BackColor = Color.DarkSalmon
                End If
            End If

            .BringToFront()
        End With

        If IsNothing(CurrentCell) = False Then
            If CurrentCell.Equals(Cell) Then
                CellBoarder(Cell, False)
            End If
        End If

    End Sub

    'Undos above function
    Public Sub RemoveValueLabel(Cell As DisplayCell)

        Cell.HasValueLabel = False

        With Cell.ValueLabel
            .Text = ""
            .Enabled = False
            .Visible = False
            .ForeColor = Color.Black
            .BackColor = Color.GhostWhite
            .BringToFront()
        End With

        If CurrentCell.Equals(Cell) Then
            CellBoarder(Cell, True)
        End If

    End Sub

    'Updates the visual appearance of the candidates of a cell according to the cell's candidates
    Public Sub UpdateCandidates(Cell As DisplayCell)

        If Cell.HasValueLabel = False Then
            Dim count As Integer = 1
            For Each ele In Cell.Labels_Array
                ele.Text = ""
                If Cell.Candidates.Contains(count) Then
                    ele.Text = CStr(count)
                End If
                count += 1
            Next
        End If

    End Sub

    'Updates the logic side board from the display of the cells. Essentially bridges the display and logic sides
    Public Sub UpdateBoardFromDisplay(TrustDisplayCandidates As Boolean)

        'Iderate through the board.
        For Rows = 0 To 8
            For Cols = 0 To 8

                'If we know that the board already had a value from import, 
                'we know this value cannot change And therefore skip for
                If BoardHandler.MainBoard.Cells(Rows, Cols).HasValueFromImport = True Then
                    Continue For
                Else
                    BoardHandler.MainBoard.Cells(Rows, Cols).Value = -1
                    BoardHandler.MainBoard.Cells(Rows, Cols).Candidates.Clear()
                End If

                'If the cell has a value label, set that value in the original board.
                If Cells(Rows, Cols).HasValueLabel = True Then
                    BoardHandler.MainBoard.Cells(Rows, Cols).Value = Integer.Parse(Cells(Rows, Cols).ValueLabel.Text)
                Else 'Else, add the candidates that the cell has
                    If TrustDisplayCandidates = False Or Cells(Rows, Cols).Candidates.Count = 0 Then

                        For i = 1 To 9
                            BoardHandler.MainBoard.Cells(Rows, Cols).Candidates.Add(i)
                        Next

                    Else
                        For Each ele In Cells(Rows, Cols).Candidates
                            BoardHandler.MainBoard.Cells(Rows, Cols).Candidates.Add(ele)
                        Next
                    End If
                End If
            Next
        Next

    End Sub

    'Clears the diplay with default values.
    Public Sub ClearDisplay()

        For Rows = 0 To 8
            For Cols = 0 To 8

                For Each ele In Cells(Rows, Cols).Labels_Array
                    ele.Visible = True
                    ele.Enabled = True
                    ele.Text = ""
                    ele.BackColor = Color.GhostWhite
                Next

                With Cells(Rows, Cols).ValueLabel
                    .BackColor = Color.GhostWhite
                    .Visible = False
                    .Enabled = False

                End With

                Cells(Rows, Cols).Candidates.Clear()
                Cells(Rows, Cols).HasValueLabel = False
                Cells(Rows, Cols).BorderLabel.Visible = False


            Next
        Next

    End Sub


End Class
