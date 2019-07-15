Public Class Sudoku 'General Functions 

    Public Cells(8, 8) As DisplayCell
    Public BoardHandler As New BoardHandler
    Public CurrentCell As DisplayCell
    Public Keypads As List(Of Button)
    Public HighlightedCandidates As New List(Of Integer)

    Public Medusa0(1) As List(Of Tuple(Of DisplayCell, Integer))
    Public Medusa1(1) As List(Of Tuple(Of DisplayCell, Integer))
    Public Medusa2(1) As List(Of Tuple(Of DisplayCell, Integer))

    Public Colours(15) As Color
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
        Colours(10) = Color.LightBlue 'Medusa Blue
        Colours(11) = Color.LightCoral 'Medusa Red
        Colours(12) = Color.LightGreen 'Medusa Green
        Colours(13) = Color.MediumPurple 'Medusa Purple
        Colours(14) = Color.Yellow 'Medusa Yellow
        Colours(15) = Color.LightPink 'Medusa Pink


    End Sub

    'When newgame is called, call a new board according to the difficulty and display it
    Public Sub NewGame()

        If IsNothing(Medusa0(0)) = False Then
            Medusa0(0).Clear()
        End If

        If IsNothing(Medusa0(1)) = False Then
            Medusa0(1).Clear()
        End If

        If IsNothing(Medusa1(0)) = False Then
            Medusa1(0).Clear()
        End If

        If IsNothing(Medusa1(1)) = False Then
            Medusa1(1).Clear()
        End If

        If IsNothing(Medusa2(0)) = False Then
            Medusa2(0).Clear()
        End If

        If IsNothing(Medusa2(1)) = False Then
            Medusa2(1).Clear()
        End If

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

        HandleLabelClick(sender.Tag.Item1)
        SC_SimKeypadInput(sender.Tag)

    End Sub

    'Handles information from label clicks
    Public Sub HandleLabelClick(Cell As DisplayCell)

        Form1.ActiveControl = Nothing
        If Form1.Drop_HighlightSelect.SelectedIndex = 0 And Form1.Check_EnableHighlighting.Checked = True Then 'Stops any input when doing highlighted candidiates
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
        If Form1.Drop_HighlightSelect.SelectedIndex = 0 And Form1.Check_EnableHighlighting.Checked = True Then 'When highlighting is checked

            HandleHighlighting(Integer.Parse(sender.Tag))

        ElseIf Form1.Drop_HighlightSelect.SelectedIndex = 1 And Form1.Check_EnableHighlighting.Checked = True Then 'When Medusa is checked

            HandleMedusa(Integer.Parse(sender.Tag))

        Else

            HandleNormalKeypadInput(Integer.Parse(sender.Tag)) 'Handles normal keybard input
        End If
    End Sub

    'Allows for a value to be passed in as if there was a keypad input
    Public Sub SimulateKeypadInput(ClickedVal As Integer)
        If Form1.Drop_HighlightSelect.SelectedIndex = 0 And Form1.Check_EnableHighlighting.Checked = True Then 'When highlighting is checked

            HandleHighlighting(ClickedVal)

        ElseIf Form1.Drop_HighlightSelect.SelectedIndex = 1 And Form1.Check_EnableHighlighting.Checked = True = True Then 'When Medusa is checked

            HandleMedusa(ClickedVal)

        Else

            HandleNormalKeypadInput(ClickedVal) 'Handles normal keybard input
        End If
    End Sub

    Public Sub SC_SimKeypadInput(Cell_Val As Tuple(Of DisplayCell, Integer))

        If Form1.Drop_HighlightSelect.SelectedIndex = 0 And Form1.Check_EnableHighlighting.Checked = True Then '0 = Candidate Highlighting. EG: When CHing is chosen
            Exit Sub
        ElseIf Form1.Drop_HighlightSelect.SelectedIndex = 1 And Form1.Check_EnableHighlighting.Checked = True = True Then
            HandleMedusa(Cell_Val.Item2)

        ElseIf Form1.Rad_Pen.Checked = True Then

            If Cell_Val.Item2 = BoardHandler.SolvedBoard.Cells(CurrentCell.Location.Y, CurrentCell.Location.X).Value And Form1.Check_Can_Removal.Checked = True Then
                CurrentCell.Labels_Array(Cell_Val.Item2 - 1).ForeColor = Color.Red
            Else
                CurrentCell.Labels_Array(Cell_Val.Item2 - 1).BackColor = Color.GhostWhite
                CurrentCell.Candidates.Remove(Cell_Val.Item2)
                UpdateCandidates(CurrentCell)
            End If

        End If

    End Sub

    'Handles normal keypad input when any highlighting options are not checked 
    Public Sub HandleNormalKeypadInput(ClickedVal As Integer)

        If IsNothing(CurrentCell) Then
            Exit Sub
        End If

        If IsNothing(BoardHandler.MainBoard) Then
            Exit Sub
        End If

        'If the cell has a value from import, then that value cannot change
        If BoardHandler.MainBoard.Cells(CurrentCell.Location.Y, CurrentCell.Location.X).HasValueFromImport = False Then

            If Form1.Rad_Pen.Checked = True And CurrentCell.HasValueLabel Then 'Pen

                If ClickedVal.ToString <> CurrentCell.ValueLabel.Text Then
                    'If the value inputted is not the same as the value of the label, then simply change the value or the label to the inputted val
                    CurrentCell.ValueLabel.Text = ClickedVal.ToString
                Else
                    'Else remove that value and show the candidates instead.
                    RemoveValueLabel(CurrentCell)
                    UpdateCandidates(CurrentCell)
                End If
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


    End Sub

    'handles the highlighting for general candidate highlighting
    Public Sub HandleHighlighting(ClickedVal As Integer)
        'If it is in the highlighted list, then remove else add it
        If HighlightedCandidates.Contains(ClickedVal) Then
            HighlightedCandidates.Remove(ClickedVal)
        Else
            HighlightedCandidates.Add(ClickedVal)
        End If

        RefreshHighlight(False) 'Redo the highlighting with the updated list
        UpdateKeypads()

    End Sub

    Public Sub OverlayMedusa()

    End Sub

    'handles the highlighting for medusas.
    Public Sub HandleMedusa(ClickedVal As Integer)

        'If somehow there is no selected index, then set it to 1
        If Form1.DropDown_Medusa.SelectedIndex = -1 Then
            Form1.DropDown_Medusa.SelectedIndex = 0
        End If
        'Find the correct colours to use.
        Dim State As Integer = Form1.DropDown_Medusa.SelectedIndex

        If Form1.Rad_MedusaC1.Checked = True Then 'When colour 1 is checked

            If CurrentCell.Candidates.Contains(ClickedVal) = False Then
                Exit Sub
            End If

            If State = 0 Then 'Allocates the correct colours according to what state the dropdown is in

                If IsNothing(Medusa0(0)) Then
                    Medusa0(0) = New List(Of Tuple(Of DisplayCell, Integer))
                End If

                If CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(10) Then
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                    Medusa0(0).Remove(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                Else
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(10)
                    Medusa0(0).Add(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                End If

            ElseIf State = 1 Then

                If IsNothing(Medusa1(0)) Then
                    Medusa1(0) = New List(Of Tuple(Of DisplayCell, Integer))
                End If

                If CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(12) Then
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                    Medusa1(0).Remove(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples

                Else
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(12)
                    Medusa1(0).Add(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples

                End If

            Else State = 2

                If IsNothing(Medusa2(0)) Then
                    Medusa2(0) = New List(Of Tuple(Of DisplayCell, Integer))
                End If

                If CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(14) Then
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                    Medusa2(0).Remove(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                Else
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(14)
                    Medusa2(0).Add(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                End If

            End If

        Else 'When colour 2 is checked

            If CurrentCell.Candidates.Contains(ClickedVal) = False Then
                Exit Sub
            End If

            If State = 0 Then 'Allocates the correct colours according to what state the dropdown is in

                If IsNothing(Medusa0(1)) Then
                    Medusa0(1) = New List(Of Tuple(Of DisplayCell, Integer))
                End If

                If CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(11) Then
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                    Medusa0(1).Remove(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                Else
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(11)
                    Medusa0(1).Add(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                End If

            ElseIf State = 1 Then

                If IsNothing(Medusa1(1)) Then
                    Medusa1(1) = New List(Of Tuple(Of DisplayCell, Integer))
                End If

                If CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(13) Then
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                    Medusa1(1).Remove(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                Else
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(13)
                    Medusa1(1).Add(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                End If

            Else State = 2

                If IsNothing(Medusa2(1)) Then
                    Medusa2(1) = New List(Of Tuple(Of DisplayCell, Integer))
                End If

                If CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(15) Then
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Color.GhostWhite
                    Medusa2(1).Remove(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                Else
                    CurrentCell.Labels_Array(ClickedVal - 1).BackColor = Colours(15)
                    Medusa2(1).Add(Tuple.Create(CurrentCell, ClickedVal)) 'Remove that value from the list of tuples
                End If

            End If

        End If

        UpdateKeypads()
        Exit Sub

    End Sub

    'Checks for obvious conflicts between cells and then if the check button is ticked, checks for a value conflcit with the solutions
    Public Sub CheckForSolutionConflicts()

        'Change every cell's color to white that has a value label
        For Rows = 0 To 8
            For Cols = 0 To 8
                If Cells(Rows, Cols).HasValueLabel = True Then
                    Cells(Rows, Cols).ValueLabel.BackColor = Color.GhostWhite
                End If
            Next
        Next

        Dim TempRowMin, TempRowMax, TempColMin, TempColMax As Integer

        'Check through each row, col and box for conflicts in value. 
        For Rows = 0 To 8
            For Cols = 0 To 8

                If Cells(Rows, Cols).HasValueLabel = True Then

                    For TempRows = 0 To 8
                        If Cells(TempRows, Cols).HasValueLabel = True Then 'Col

                            If Cells(TempRows, Cols).ValueLabel.Text = Cells(Rows, Cols).ValueLabel.Text And Cells(TempRows, Cols).Equals(Cells(Rows, Cols)) = False Then
                                Cells(TempRows, Cols).ValueLabel.BackColor = Color.IndianRed
                            End If
                        End If
                    Next

                    For TempCols = 0 To 8
                        If Cells(Rows, TempCols).HasValueLabel = True Then 'Row

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

                            If Cells(TempRows, TempCols).HasValueLabel = True Then 'Box

                                If Cells(TempRows, TempCols).ValueLabel.Text = Cells(Rows, Cols).ValueLabel.Text And Cells(TempRows, TempCols).Equals(Cells(Rows, Cols)) = False Then
                                    Cells(TempRows, TempCols).ValueLabel.BackColor = Color.IndianRed
                                End If
                            End If

                        Next
                    Next

                    If Cells(Rows, Cols).ValueLabel.Font.Equals(UnderlineFont) Then
                        Cells(Rows, Cols).ValueLabel.Font = StandardFont
                    End If

                    If Form1.Check_Can_Removal.Checked = True Then 'If the "Altert to incorrect values function is ticked"

                        'If the cell conflcits with the solved board, then underline it.
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

    'Called when medusa changed, in order to update for the current selection
    Public Sub MedusaChanged()

        'If the medusa button is unchecked, then do nothing
        If Form1.Check_EnableHighlighting.Checked = False Then
            Exit Sub

        ElseIf Form1.DropDown_Medusa.SelectedIndex = 0 Then 'If in state 0, then display the cells that have been previosuly shown in state 0
            RefreshHighlight(True)
            If IsNothing(Medusa0(0)) = False Then
                For Each ele In Medusa0(0)
                    If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                        ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(10)
                    End If
                Next
            End If

            If IsNothing(Medusa0(1)) = False Then
                For Each ele In Medusa0(1)
                    If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                        ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(11)
                    End If
                Next
            End If

        ElseIf Form1.DropDown_Medusa.SelectedIndex = 1 Then 'if in state 1, then display all cells that are highlighted in State 1
            RefreshHighlight(True)

            If IsNothing(Medusa1(0)) = False Then
                For Each ele In Medusa1(0)
                    If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                        ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(12)
                    End If
                Next
            End If

            If IsNothing(Medusa1(1)) = False Then
                For Each ele In Medusa1(1)
                    If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                        ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(13)
                    End If
                Next
            End If

        Else Form1.DropDown_Medusa.SelectedIndex = 2  'if in state 2, then display all cells that are highlighted in State 2
            RefreshHighlight(True)

            If IsNothing(Medusa2(0)) = False Then
                For Each ele In Medusa2(0)
                    If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                        ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(14)
                    End If
                Next
            End If

            If IsNothing(Medusa2(1)) = False Then

                For Each ele In Medusa2(1)
                    If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                        ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(15)
                    End If
                Next
            End If
        End If

        'If overlay 1 is checked, then display the other medusa set selected on display
        If Form1.Check_Overlay1.Checked = True Then

            If Form1.DropDown_Medusa.SelectedIndex = 1 Or Form1.DropDown_Medusa.SelectedIndex = 2 Then

                If IsNothing(Medusa0(0)) = False Then
                    For Each ele In Medusa0(0)
                        If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                            ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(10)
                        End If
                    Next
                End If

                If IsNothing(Medusa0(1)) = False Then
                    For Each ele In Medusa0(1)
                        If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                            ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(11)
                        End If
                    Next
                End If
            Else

                If IsNothing(Medusa1(0)) = False Then
                    For Each ele In Medusa1(0)
                        If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                            ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(12)
                        End If
                    Next
                End If

                If IsNothing(Medusa1(1)) = False Then
                    For Each ele In Medusa1(1)
                        If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                            ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(13)
                        End If
                    Next
                End If

            End If

        Else

            If Form1.DropDown_Medusa.SelectedIndex = 0 Or Form1.DropDown_Medusa.SelectedIndex = 1 Then

                If IsNothing(Medusa2(0)) = False Then
                    For Each ele In Medusa2(0)
                        If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                            ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(14)
                        End If
                    Next
                End If

                If IsNothing(Medusa2(1)) = False Then

                    For Each ele In Medusa2(1)
                        If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                            ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(15)
                        End If
                    Next
                End If

            Else

                If IsNothing(Medusa1(0)) = False Then
                    For Each ele In Medusa1(0)
                        If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                            ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(12)
                        End If
                    Next
                End If

                If IsNothing(Medusa1(1)) = False Then
                    For Each ele In Medusa1(1)
                        If ele.Item1.HasValueLabel = False Then 'If the Cell does not have a value, 
                            ele.Item1.Labels_Array(ele.Item2 - 1).BackColor = Colours(13)
                        End If
                    Next
                End If

            End If

        End If

            If Form1.Check_Overlay2.Checked = True Then

        End If

        UpdateKeypads()
    End Sub

    'Updates the colouring of the keypads to reflect the current mode or selection
    Public Sub UpdateKeypads()

        If Form1.Drop_HighlightSelect.SelectedIndex = 0 And Form1.Check_EnableHighlighting.Checked = True Then
            'Do Something

            For Each ele In Keypads
                ele.BackColor = Color.GhostWhite
                If HighlightedCandidates.Contains(Integer.Parse(ele.Tag)) Then
                    ele.BackColor = Colours(Integer.Parse(ele.Tag))
                End If
            Next

            Exit Sub
        ElseIf Form1.Drop_HighlightSelect.SelectedIndex = 1 And Form1.Check_EnableHighlighting.Checked = True = True Then
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
