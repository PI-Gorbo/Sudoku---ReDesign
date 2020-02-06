Imports System.IO

Public Class BoardHandler 'Functions related to the logic side of board handling

    Public MainBoard As Board
    Public SolvedBoard As Board
    Public BoardChosen_Long As String
    Public BoardChosen_Short As String
    Public Directories(4) As String

    Public Sub New()

        Directories(0) = "Boards\Easy"
        Directories(1) = "Boards\Medium"
        Directories(2) = "Boards\Hard"
        Directories(3) = "Boards\Evil"
        Directories(4) = "Boards\Custom"

    End Sub

    Public Sub NewGame(Blank As Boolean)

        If Blank = False Then
            Dim DirectorySelect As Integer = -1

            If IsNothing(MainBoard) Then
                MainBoard = New Board
            End If

            DirectorySelect = Form1.DropDown_Difficulty.SelectedIndex

            If DirectorySelect = -1 Then
                DirectorySelect = 1
            End If

            Dim Dr As New DirectoryInfo(Directories(DirectorySelect))
            Dim r As New Random
            Dim Filelist As New ArrayList
            For Each ele In Dr.GetFiles
                Filelist.Add(ele)
            Next
            Dim x = r.Next(0, Filelist.Count)
            BoardChosen_Short = Convert.ToString(Filelist(x))
            BoardChosen_Long = Convert.ToString(Filelist(x).Fullname)

            Using reader As New StreamReader(BoardChosen_Long)
                Dim CurrentIndex As Integer = 0
                Dim Line As String
                For Rows = 0 To 8
                    CurrentIndex = 0
                    Line = reader.ReadLine
                    For Cols = 0 To 8

                        If IsNothing(MainBoard.Cells(Rows, Cols)) Then
                            MainBoard.Cells(Rows, Cols) = New LogicCell
                        Else
                            With MainBoard.Cells(Rows, Cols)
                                .HasValueFromImport = False
                                .Value = -1
                                .Candidates.Clear()
                            End With
                        End If

                        'Clues
                        If Line(CurrentIndex) = "[" Then
                            If Line(CurrentIndex + 1) = "0" Then
                                For i = 1 To 9
                                    MainBoard.Cells(Rows, Cols).Candidates.Add(i)
                                Next
                            Else
                                MainBoard.Cells(Rows, Cols).HasValueFromImport = True
                                MainBoard.Cells(Rows, Cols).Value = Integer.Parse(Line(CurrentIndex + 1))
                            End If


                            If Line.Length <= CurrentIndex + 3 Then
                                Exit For
                            Else
                                CurrentIndex += 3
                                Continue For
                            End If
                        End If

                        'Solutions
                        If Line(CurrentIndex) = "(" Then
                            MainBoard.Cells(Rows, Cols).Value = Integer.Parse(Line(CurrentIndex + 1))

                            If Line.Length <= CurrentIndex + 3 Then
                                Exit For
                            Else
                                CurrentIndex += 3
                                Continue For
                            End If
                        End If

                        'Candidates
                        If Line(CurrentIndex) = "{" Then
                            For i = CurrentIndex + 1 To FindIndexOfNext(Line, "}", CurrentIndex) - 1
                                If IsNumeric(Line(i)) Then
                                    MainBoard.Cells(Rows, Cols).Candidates.Add(Integer.Parse(Line(i)))
                                End If
                            Next

                            If Line.Length <= CurrentIndex = FindIndexOfNext(Line, "}", CurrentIndex) + 1 Then
                                Exit For
                            Else
                                CurrentIndex = FindIndexOfNext(Line, "}", CurrentIndex) + 1
                                Continue For
                            End If
                        End If

                        MsgBox("Error in Loading Board. If the board was written manually, then make sure the formatting is correct.")
                        Exit Sub
                    Next
                Next
            End Using
        Else
            If IsNothing(MainBoard) Then
                MainBoard = New Board
            End If
            For Rows = 0 To 8
                For Cols = 0 To 8
                    If IsNothing(MainBoard.Cells(Rows, Cols)) Then
                        MainBoard.Cells(Rows, Cols) = New LogicCell
                    End If

                    With MainBoard.Cells(Rows, Cols)
                        .HasValueFromImport = False
                        .Value = -1
                        .Candidates.Clear()
                    End With
                Next
            Next
            SolvedBoard = Nothing
        End If

        If Blank = False Then
            Dim Solved, _Error As Boolean
            Solved = False
            _Error = False
            Form1.Lst_Debug.Items.Add("Attempting to solve board in the background...")
            SolvedBoard = New Board(MainBoard)
            Bruteforce(SolvedBoard, Solved, _Error)

            If _Error = True Then
                'MsgBox("Error With Current Board apparent during solving. Please load a new board")
            Else
                Form1.Lst_Debug.Items.Add("Solved Board!")
            End If
        End If

    End Sub

    'Loads a new Game according to a opened file.
    Public Sub NewGame(Filepath As String, ShortFilePath As String, _Error As Boolean)

        'KEY --> [*] * can be the values 0 - 9. 0 being no value 1-9 being a clue for the cell
        '(*) can be 1 - 9. These values are solutions
        '{*} is a list of numbers with no spaces or separation is the candidates for a cell.

        If IsNothing(MainBoard) Then
            MainBoard = New Board
        End If

        BoardChosen_Short = ShortFilePath
        BoardChosen_Long = Filepath

        Using reader As New StreamReader(Filepath)

            Dim Line As String
            Dim CurrentIndex As Integer
            Try


                For Rows = 0 To 8
                    Line = reader.ReadLine
                    CurrentIndex = 0
                    For Cols = 0 To 8

                        If IsNothing(MainBoard.Cells(Rows, Cols)) Then
                            MainBoard.Cells(Rows, Cols) = New LogicCell
                        Else
                            With MainBoard.Cells(Rows, Cols)
                                .HasValueFromImport = False
                                .Value = -1
                                .Candidates.Clear()
                            End With
                        End If

                        'Clues
                        If Line(CurrentIndex) = "[" Then
                            If Line(CurrentIndex + 1) = "0" Then
                                For i = 1 To 9
                                    MainBoard.Cells(Rows, Cols).Candidates.Add(i)
                                Next
                            Else
                                MainBoard.Cells(Rows, Cols).HasValueFromImport = True
                                MainBoard.Cells(Rows, Cols).Value = Integer.Parse(Line(CurrentIndex + 1))
                            End If


                            If Line.Length <= CurrentIndex + 3 Then
                                Exit For
                            Else
                                CurrentIndex += 3
                                Continue For
                            End If
                        End If

                        'Solutions
                        If Line(CurrentIndex) = "(" Then
                            MainBoard.Cells(Rows, Cols).Value = Integer.Parse(Line(CurrentIndex + 1))

                            If Line.Length <= CurrentIndex + 3 Then
                                Exit For
                            Else
                                CurrentIndex += 3
                                Continue For
                            End If
                        End If

                        'Candidates
                        If Line(CurrentIndex) = "{" Then
                            For i = CurrentIndex + 1 To FindIndexOfNext(Line, "}", CurrentIndex) - 1
                                If IsNumeric(Line(i)) Then
                                    MainBoard.Cells(Rows, Cols).Candidates.Add(Integer.Parse(Line(i)))
                                End If
                            Next

                            If Line.Length <= CurrentIndex = FindIndexOfNext(Line, "}", CurrentIndex) + 1 Then
                                Exit For
                            Else
                                CurrentIndex = FindIndexOfNext(Line, "}", CurrentIndex) + 1
                                Continue For
                            End If
                        End If

                        _Error = True
                        MsgBox("Error in Loading Board. If the board was written manually, then make sure the formatting is correct.")
                        Exit Sub
                    Next
                Next

            Catch ex As Exception

                MsgBox("Error with loading board. Please select another.")
                reader.Close()
                Exit Sub
            End Try

            Dim Solved, _TError As Boolean
            Solved = False
            _Error = False
            Form1.Lst_Debug.Items.Add("Attempting to solve board in the background...")
            SolvedBoard = New Board(MainBoard)
            Bruteforce(SolvedBoard, Solved, _TError)

            If _Error = True Then
                'MsgBox("Error With Current Board apparent during solving. Please load a new board")
            Else
                Form1.Lst_Debug.Items.Add("Solved Board!")
            End If

        End Using

    End Sub

    'Resets the board without solving it again
    Public Sub ResetGame(Filepath As String)

        Using reader As New StreamReader(Filepath)

            Try


                Dim Line As String
                Dim CurrentIndex As Integer

                For Rows = 0 To 8
                    Line = reader.ReadLine
                    CurrentIndex = 0
                    For Cols = 0 To 8

                        If IsNothing(MainBoard.Cells(Rows, Cols)) Then
                            MainBoard.Cells(Rows, Cols) = New LogicCell
                        Else
                            With MainBoard.Cells(Rows, Cols)
                                .HasValueFromImport = False
                                .Value = -1
                                .Candidates.Clear()
                            End With
                        End If

                        'Clues
                        If Line(CurrentIndex) = "[" Then
                            If Line(CurrentIndex + 1) = "0" Then
                                For i = 1 To 9
                                    MainBoard.Cells(Rows, Cols).Candidates.Add(i)
                                Next
                            Else
                                MainBoard.Cells(Rows, Cols).HasValueFromImport = True
                                MainBoard.Cells(Rows, Cols).Value = Integer.Parse(Line(CurrentIndex + 1))
                            End If


                            If Line.Length <= CurrentIndex + 3 Then
                                Exit For
                            Else
                                CurrentIndex += 3
                                Continue For
                            End If
                        End If

                        'Solutions
                        If Line(CurrentIndex) = "(" Then
                            MainBoard.Cells(Rows, Cols).Value = Integer.Parse(Line(CurrentIndex + 1))

                            If Line.Length <= CurrentIndex + 3 Then
                                Exit For
                            Else
                                CurrentIndex += 3
                                Continue For
                            End If
                        End If

                        'Candidates
                        If Line(CurrentIndex) = "{" Then
                            For i = CurrentIndex + 1 To FindIndexOfNext(Line, "}", CurrentIndex) - 1
                                If IsNumeric(Line(i)) Then
                                    MainBoard.Cells(Rows, Cols).Candidates.Add(Integer.Parse(Line(i)))
                                End If
                            Next

                            If Line.Length <= CurrentIndex = FindIndexOfNext(Line, "}", CurrentIndex) + 1 Then
                                Exit For
                            Else
                                CurrentIndex = FindIndexOfNext(Line, "}", CurrentIndex) + 1
                                Continue For
                            End If
                        End If
                    Next
                Next

            Catch ex As Exception
                MsgBox("Cannot reset board, make sure last board loaded is valid")
                reader.Close()
                Exit Sub
            End Try
        End Using

    End Sub

    'Hanldes the Dialogue for loading a new game.
    Public Sub LoadNewGame_Dialogue(ByRef _Error As Boolean, ByRef Cancel As Boolean)

        Dim OFD As New OpenFileDialog

        OFD.Filter = "Text Files (*.txt)|*.txt"
        Cancel = False
        If OFD.ShowDialog() = DialogResult.OK Then
            NewGame(OFD.FileName, OFD.SafeFileName, _Error)
            If _Error = True Then
                MsgBox("Error with selected board. Please Choose a new One.")
            End If
        Else
            Cancel = True
        End If

    End Sub

    Public Sub SaveGame()

        Dim SFD As New SaveFileDialog

        SFD.RestoreDirectory = True
        SFD.FileName = "CustomBoard.txt"
        SFD.DefaultExt = "txt"
        SFD.Filter = "Text Files (*.txt)|*.txt"

        If SFD.ShowDialog = DialogResult.OK Then

            Dim line As String
            Dim templine As String
            Using file As New StreamWriter(SFD.OpenFile)

                For i = 0 To 8
                    line = ""
                    For Each ele In MainBoard.Board_Rows(i)

                        If ele.HasValueFromImport = True And ele.Value <> -1 And ele.Candidates.Count = 0 Then
                            line += "[" + CStr(ele.Value) + "]"

                        ElseIf ele.HasValueFromImport = False And ele.Value <> -1 And ele.Candidates.Count = 0 Then

                            line += "(" + CStr(ele.Value) + ")"

                        ElseIf ele.HasValueFromImport = False And ele.Value = -1 And ele.Candidates.Count > 0 Then

                            templine = ""
                            For Each num In ele.Candidates
                                templine += CStr(num)
                            Next
                            line += "{" + templine + "}"

                        Else
                            line += "[0]"
                        End If

                    Next
                    file.WriteLine(line)
                Next
            End Using

        End If

    End Sub

    'Finds the next occurance of a character in a string
    Function FindIndexOfNext(s As String, c As String, StartIndex As Integer)

        If s.Length = 1 Then
            Return -1
        ElseIf s.Contains(c) = False Then
            Return -1
        ElseIf StartIndex > s.Length - 1 Then
            Return -1
        Else
            For i = StartIndex To s.Length - 1
                If s(i) = c Then
                    Return i
                End If
            Next
        End If

        Return -1

    End Function

    'A function that loops, using the Calc Candidates function and Isolated candidates function to make progress on the board.
    Public Sub PrelimSolve(ByRef Board As Board, ByRef Board_Solved As Boolean, ByRef Error_Detected As Boolean)

        Board_Solved = False
        Error_Detected = False

        Dim _continue As Boolean
        Do
            _continue = False

            CalculateCandidates(Board, Error_Detected, _continue)
            Convert_To_Values(Board)
            FindIsolatedValues(Board, Error_Detected, _continue)
            Convert_To_Values(Board)

            If Error_Detected = True Then
                'MsgBox("Error Detected with current board. Please Load a new Board")
                Exit Sub
            End If

            If Board_Solved = False Then
                Board_Solved = IsBoardSolved(Board)
            End If

        Loop While _continue = True And Board_Solved = False



    End Sub

    'An overload of the above function that only loops for a given about of times.
    Public Sub PrelimSolve_Single(ByRef Board As Board, ByRef Board_Solved As Boolean, ByRef Error_Detected As Boolean)

        Board_Solved = False
        Error_Detected = False
        Dim loopcount = 1

        Dim _continue As Boolean

        _continue = False

        CalculateCandidates(Board, Error_Detected, _continue)
        Convert_To_Values(Board)
        FindIsolatedValues(Board, Error_Detected, _continue)
        Convert_To_Values(Board)

        If Error_Detected = True Then
            'MsgBox("Error Detected with current board. Please Load a new Board")
            Exit Sub
        End If

        If Board_Solved = False Then
            Board_Solved = IsBoardSolved(Board)
        End If
    End Sub

    'Removes candidates by subtraction
    Public Sub CalculateCandidates(ByRef Board As Board, ByRef Error_Dectected As Boolean, ByRef _Continue As Boolean)

        Dim Val As Integer = -1
        Error_Dectected = False

        For Rows = 0 To 8
            For Cols = 0 To 8

                If Board.Cells(Rows, Cols).Value <> -1 Then
                    Val = Board.Cells(Rows, Cols).Value

                    For Each ele In Board.Cells(Rows, Cols).Row
                        ele.Candidates.Remove(Val)

                        If ele.Candidates.Count = 1 Then
                            _Continue = True
                        End If

                        If ele.Candidates.Count = 0 And ele.Value = -1 Then
                            Error_Dectected = True
                        End If
                    Next
                End If

                If Board.Cells(Rows, Cols).Value <> -1 Then
                    Val = Board.Cells(Rows, Cols).Value

                    For Each ele In Board.Cells(Rows, Cols).Column
                        ele.Candidates.Remove(Val)

                        If ele.Candidates.Count = 1 Then
                            _Continue = True
                        End If

                        If ele.Candidates.Count = 0 And ele.Value = -1 Then
                            Error_Dectected = True
                        End If
                    Next
                End If

                If Board.Cells(Rows, Cols).Value <> -1 Then
                    Val = Board.Cells(Rows, Cols).Value

                    For Each ele In Board.Cells(Rows, Cols).Box
                        ele.Candidates.Remove(Val)

                        If ele.Candidates.Count = 1 Then
                            _Continue = True
                        End If

                        If ele.Candidates.Count = 0 And ele.Value = -1 Then

                            Error_Dectected = True
                        End If
                    Next
                End If

            Next
        Next

    End Sub

    'Finds isolated candidates
    Public Sub FindIsolatedValues(ByRef Board As Board, ByRef Error_Detected As Boolean, ByRef _Continue As Boolean)

        Dim flag As Boolean = False

        For Rowcount = 0 To 8

            For Num = 1 To 9
                flag = False
                For Each ele In Board.Board_Rows(Rowcount)
                    If ele.Value = Num Then
                        flag = True
                    End If
                Next
                If flag = False Then
                    Dim tempcount As Integer = 0
                    Dim Tempcell As LogicCell

                    For Each ele In Board.Board_Rows(Rowcount)

                        If tempcount > 1 Then
                            Tempcell = Nothing
                            Exit For
                        ElseIf ele.Candidates.Contains(Num) Then
                            Tempcell = ele
                            tempcount += 1
                        End If

                    Next

                    If tempcount = 1 Then
                        Tempcell.Candidates.Clear()
                        Tempcell.Candidates.Add(Num)
                        _Continue = True
                    End If
                End If
            Next
        Next

        flag = False
        For colcount = 0 To 8
            For Num = 1 To 9
                flag = False
                For Each ele In Board.Board_Columns(colcount)
                    If ele.Value = Num Then
                        flag = True
                    End If
                Next
                If flag = False Then
                    Dim tempcount As Integer = 0
                    Dim Tempcell As LogicCell

                    For Each ele In Board.Board_Columns(colcount)

                        If tempcount > 1 Then
                            Tempcell = Nothing
                            Exit For
                        ElseIf ele.Candidates.Contains(Num) Then
                            Tempcell = ele
                            tempcount += 1
                        End If

                    Next

                    If tempcount = 1 And IsNothing(Tempcell) = False Then
                        Tempcell.Candidates.Clear()
                        Tempcell.Candidates.Add(Num)
                        _Continue = True
                    End If
                End If
            Next
        Next

        flag = False
        For BoxRows = 0 To 2
            For BoxCols = 0 To 2
                For Num = 1 To 9
                    flag = False

                    For Each ele In Board.Board_Boxes(BoxRows, BoxCols)
                        If ele.Value = Num Then
                            flag = True
                        End If
                    Next

                    If flag = False Then
                        Dim tempcount As Integer = 0
                        Dim Tempcell As LogicCell

                        For Each ele In Board.Board_Boxes(BoxRows, BoxCols)

                            If tempcount > 1 Then
                                Tempcell = Nothing
                                Exit For
                            ElseIf ele.Candidates.Contains(Num) Then
                                Tempcell = ele
                                tempcount += 1
                            End If

                        Next

                        If tempcount = 1 Then
                            Tempcell.Candidates.Clear()
                            Tempcell.Candidates.Add(Num)
                            _Continue = True
                        End If
                    End If
                Next
            Next
        Next


    End Sub

    'Converts cells wih a single candidate to the value of the cell.
    Public Sub Convert_To_Values(ByRef Board As Board)

        For Rows = 0 To 8
            For Cols = 0 To 8

                If Board.Cells(Rows, Cols).Candidates.Count = 1 Then
                    Board.Cells(Rows, Cols).Value = Board.Cells(Rows, Cols).Candidates(0)
                    Board.Cells(Rows, Cols).Candidates.Clear()
                End If
            Next
        Next

    End Sub

    'Checks if the board is solved. Checks for empty cells and cells that have conficting values
    Public Function IsBoardSolved(ByRef Board As Board)

        For Rows = 0 To 8
            For Cols = 0 To 8

                For Each ele In Board.Cells(Rows, Cols).Row

                    If ele.Equals(Board.Cells(Rows, Cols)) Then
                        Continue For
                    End If

                    If ele.Value = Board.Cells(Rows, Cols).Value Or ele.Value = -1 Then
                        Return False
                    End If
                Next

                For Each ele In Board.Cells(Rows, Cols).Column

                    If ele.Equals(Board.Cells(Rows, Cols)) Then
                        Continue For
                    End If

                    If ele.Value = Board.Cells(Rows, Cols).Value Or ele.Value = -1 Then
                        Return False
                    End If
                Next

                For Each ele In Board.Cells(Rows, Cols).Box

                    If ele.Equals(Board.Cells(Rows, Cols)) Then
                        Continue For
                    End If

                    If ele.Value = Board.Cells(Rows, Cols).Value Or ele.Value = -1 Then
                        Return False
                    End If
                Next

            Next
        Next
        Return True

    End Function

    'Does the preliminary checks for if a board is valid or not
    Public Function Prelim_IsBoardValid(ByRef Board As Board)

        Dim No_OfClues As Integer = 0

        For Rows = 0 To 8
            For Cols = 0 To 8

                'If the cell has a value, add it to the count of clues
                If Board.Cells(Rows, Cols).Value <> -1 Then
                    No_OfClues += 1
                End If

                'IF the Cell has no value, and no candidates, then there is something wrong. Return False
                If Board.Cells(Rows, Cols).Candidates.Count = 0 And Board.Cells(Rows, Cols).Value = -1 Then
                    Return False
                End If

                'Iderate through the row, column and box that the cell is in. 
                'If there is any cell that has the same value, then return false
                For Each ele In Board.Cells(Rows, Cols).Row
                    If ele.Equals(Board.Cells(Rows, Cols)) = False And ele.Value = Board.Cells(Rows, Cols).Value And Board.Cells(Rows, Cols).Value <> -1 Then
                        Return False
                    End If
                Next

                For Each ele In Board.Cells(Rows, Cols).Column
                    If ele.Equals(Board.Cells(Rows, Cols)) = False And ele.Value = Board.Cells(Rows, Cols).Value And Board.Cells(Rows, Cols).Value <> -1 Then
                        Return False
                    End If
                Next

                For Each ele In Board.Cells(Rows, Cols).Box
                    If ele.Equals(Board.Cells(Rows, Cols)) = False And ele.Value = Board.Cells(Rows, Cols).Value And Board.Cells(Rows, Cols).Value <> -1 Then
                        Return False
                    End If
                Next
            Next
        Next

        If No_OfClues <= 16 Then
            Return False
        End If

        Return True
    End Function

    'Bruteforce function. Takes a Board, and recursively bruteforce solves it while also using the PrelimSolve method
    Public Sub Bruteforce(ByRef OrigBoard As Board, ByRef Solved As Boolean, ByRef _Error As Boolean)

        Solved = False
        _Error = False

        'Checks if the board entered is initally valid
        If Prelim_IsBoardValid(OrigBoard) = False Then
            Exit Sub
        End If

        'Checks if the board is already solved
        If IsBoardSolved(OrigBoard) Then
            Solved = True
            Exit Sub
        End If

        'Tries to solve the board using subtraction and isolated candidates,
        'then returns if there is an error or the board is solved
        PrelimSolve(OrigBoard, Solved, _Error)

        If _Error = True Or Solved = True Then
            Exit Sub
        End If

        '______________________________________________'
        'Beyound this point, the board is assumed to be valid and not solved

        If Not Solved Then

            Dim TempSolved As Boolean = False
            Dim TempError As Boolean = False
            Dim SC As New Point(-1, -1) 'SC means Selected Cell
            Dim Tempboard As Board
            Dim MaxCandidateIndex As Integer = -1
            Dim CurrentIndex As Integer = 0

            'Finds a no-value cell and works out how many candidates it has.
            Dim exitbool As Boolean = False
            For Rows = 0 To 8
                For Cols = 0 To 8

                    If OrigBoard.Cells(Rows, Cols).Value = -1 Then
                        SC.X = Cols
                        SC.Y = Rows
                        exitbool = True
                    End If
                    If exitbool = True Then
                        Exit For
                    End If
                Next
                If exitbool = True Then
                    Exit For
                End If
            Next
            If SC.X = -1 Or SC.Y = -1 Then
                Solved = False
                _Error = True
                Exit Sub
            End If

            MaxCandidateIndex = OrigBoard.Cells(SC.Y, SC.X).Candidates.Count - 1

            'Loops through the board, and bruteforces different permutations, trying to find a solution that works.
            Do
                TempSolved = False
                TempError = False

                Tempboard = New Board(OrigBoard)

                Tempboard.Cells(SC.Y, SC.X).Value = Tempboard.Cells(SC.Y, SC.X).Candidates(CurrentIndex)
                Tempboard.Cells(SC.Y, SC.X).Candidates.Clear()

                'Calls bruteforce
                Bruteforce(Tempboard, TempSolved, TempError)

                If TempError = True Then
                    CurrentIndex += 1
                    Continue Do
                End If

                If TempSolved = True Then
                    Exit Do
                End If

                CurrentIndex += 1
            Loop While CurrentIndex <= MaxCandidateIndex

            OrigBoard = New Board(Tempboard)

            If TempSolved = True Then
                Solved = True
                _Error = False
                Exit Sub
            End If

            If TempError = False Then
                Solved = False
                _Error = False
                Exit Sub
            End If
        End If


    End Sub

End Class

Public Class Board

    Public Cells(8, 8) As LogicCell
    Public Board_Rows(8) As List(Of LogicCell)
    Public Board_Columns(8) As List(Of LogicCell)
    Public Board_Boxes(2, 2) As List(Of LogicCell)

    Public Sub New()

        Dim BoxLocRow As Integer = -1
        Dim BoxLocCol As Integer = -1

        For _Rows = 0 To 8
            For _Cols = 0 To 8

                Cells(_Rows, _Cols) = New LogicCell

                If IsNothing(Board_Rows(_Rows)) Then
                    Board_Rows(_Rows) = New List(Of LogicCell)
                End If
                Board_Rows(_Rows).Add(Cells(_Rows, _Cols))
                Cells(_Rows, _Cols).Row = Board_Rows(_Rows)

                If IsNothing(Board_Columns(_Cols)) Then
                    Board_Columns(_Cols) = New List(Of LogicCell)
                End If
                Board_Columns(_Cols).Add(Cells(_Rows, _Cols))
                Cells(_Rows, _Cols).Column = Board_Columns(_Cols)

                If _Rows <= 2 Then

                    BoxLocRow = 0

                ElseIf _Rows >= 3 And _Rows <= 5 Then

                    BoxLocRow = 1

                ElseIf _Rows >= 6 Then

                    BoxLocRow = 2

                End If

                If _Cols <= 2 Then

                    BoxLocCol = 0

                ElseIf _Cols >= 3 And _Cols <= 5 Then

                    BoxLocCol = 1

                ElseIf _Cols >= 6 Then

                    BoxLocCol = 2

                End If

                If IsNothing(Board_Boxes(BoxLocRow, BoxLocCol)) Then
                    Board_Boxes(BoxLocRow, BoxLocCol) = New List(Of LogicCell)
                End If
                Board_Boxes(BoxLocRow, BoxLocCol).Add(Cells(_Rows, _Cols))
                Cells(_Rows, _Cols).Box = Board_Boxes(BoxLocRow, BoxLocCol)

                Cells(_Rows, _Cols).CellLocation = New Point(_Cols, _Rows)

            Next
        Next

    End Sub

    Public Sub New(OrigBoard As Board)

        Dim BoxLocRow As Integer = -1
        Dim BoxLocCol As Integer = -1

        For _Rows = 0 To 8
            For _Cols = 0 To 8

                Cells(_Rows, _Cols) = New LogicCell
                Cells(_Rows, _Cols).Value = OrigBoard.Cells(_Rows, _Cols).Value
                Cells(_Rows, _Cols).HasValueFromImport = OrigBoard.Cells(_Rows, _Cols).HasValueFromImport

                For Each ele In OrigBoard.Cells(_Rows, _Cols).Candidates
                    Cells(_Rows, _Cols).Candidates.Add(ele)
                Next

                Cells(_Rows, _Cols).CellLocation.X = OrigBoard.Cells(_Rows, _Cols).CellLocation.X
                Cells(_Rows, _Cols).CellLocation.Y = OrigBoard.Cells(_Rows, _Cols).CellLocation.Y

                If IsNothing(Board_Rows(_Rows)) Then
                    Board_Rows(_Rows) = New List(Of LogicCell)
                End If

                'Adds the cell to the right row
                Board_Rows(_Rows).Add(Cells(_Rows, _Cols))
                Cells(_Rows, _Cols).Row = Board_Rows(_Rows)

                If IsNothing(Board_Columns(_Cols)) Then
                    Board_Columns(_Cols) = New List(Of LogicCell)
                End If

                'Adds the cell to the right column
                Board_Columns(_Cols).Add(Cells(_Rows, _Cols))
                Cells(_Rows, _Cols).Column = Board_Columns(_Cols)

                If _Rows <= 2 Then

                    BoxLocRow = 0

                ElseIf _Rows >= 3 And _Rows <= 5 Then

                    BoxLocRow = 1

                ElseIf _Rows >= 6 Then

                    BoxLocRow = 2

                End If

                If _Cols <= 2 Then

                    BoxLocCol = 0

                ElseIf _Cols >= 3 And _Cols <= 5 Then

                    BoxLocCol = 1

                ElseIf _Cols >= 6 Then

                    BoxLocCol = 2

                End If

                If IsNothing(Board_Boxes(BoxLocRow, BoxLocCol)) Then

                    Board_Boxes(BoxLocRow, BoxLocCol) = New List(Of LogicCell)

                End If

                'Adds the cell to the correct box.
                Board_Boxes(BoxLocRow, BoxLocCol).Add(Cells(_Rows, _Cols))
                Cells(_Rows, _Cols).Box = Board_Boxes(BoxLocRow, BoxLocCol)
                Cells(_Rows, _Cols).CellLocation = New Point(_Rows, _Cols)
            Next
        Next

    End Sub

    Public Sub Clear()
        For Rows = 0 To 8
            For Cols = 0 To 8
                Cells(Rows, Cols).Value = -1
                Cells(Rows, Cols).Candidates.Clear()
                Cells(Rows, Cols).HasValueFromImport = False
            Next
        Next
    End Sub

    Public Sub Clone(OrigBoard As Board)
        For Rows = 0 To 8
            For Cols = 0 To 8
                Cells(Rows, Cols).Value = OrigBoard.Cells(Rows, Cols).Value
                For Each ele In OrigBoard.Cells(Rows, Cols).Candidates
                    Cells(Rows, Cols).Candidates.Add(ele)
                Next
                Cells(Rows, Cols).HasValueFromImport = OrigBoard.Cells(Rows, Cols).HasValueFromImport
            Next
        Next
    End Sub

End Class

Public Class LogicCell

    Public Value As Integer
    Public HasValueFromImport As Boolean
    Public Candidates As List(Of Integer)
    Public Row As List(Of LogicCell)
    Public Column As List(Of LogicCell)
    Public Box As List(Of LogicCell)
    Public CellLocation As Point

    Public Sub New()
        Value = -1
        HasValueFromImport = False

        Candidates = New List(Of Integer)
        Candidates.Clear()
        Candidates.Capacity = 9

        CellLocation = New Point(-1, -1)
    End Sub

End Class
