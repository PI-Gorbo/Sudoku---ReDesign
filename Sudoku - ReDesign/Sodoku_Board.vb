Imports System.IO

Public Class BoardLandler 'Functions related to the logic side of board handling

    Public MainBoard As Board
    Public SolvedBoard As Board
    Public BoardChosen As String
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

            DirectorySelect = Form.DropDown_Difficulty.SelectedIndex

            If DirectorySelect = -1 Then
                DirectorySelect = 1
            End If

            Dim Dr As New DirectoryInfo(Directories(Form.DropDown_Difficulty.SelectedIndex))
            Dim r As New Random
            Dim Filelist As New ArrayList
            Dim x = r.Next(0, Filelist.Count - 1)
            For Each ele In Dr.GetFiles
                Filelist.Add(ele)
            Next


            Using reader As New StreamReader(Convert.ToString(Filelist(x).Fullname))



                Dim Line As String
                For Rows = 0 To 8
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

                        With MainBoard.Cells(Rows, Cols)
                            If Line(Cols) = "0" Then
                                For i = 1 To 9
                                    .Candidates.Add(i)
                                    .Value = -1
                                Next
                            Else
                                .Value = Integer.Parse(Line(Cols))
                                .HasValueFromImport = True
                            End If
                        End With
                    Next
                Next
            End Using
        Else
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
        End If

        Dim Solved, _Error As Boolean
        Solved = False
        _Error = False

        SolvedBoard = New Board(MainBoard)
        Bruteforce(SolvedBoard, Solved, _Error)

        If _Error = True Then
            MsgBox("Error With Current Board apparent during solving. Please load a new board")
        End If

    End Sub

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
                MsgBox("Error Detected with current board. Please Load a new Board")
            End If

            If Board_Solved = False Then
                Board_Solved = IsBoardSolved(Board)
            End If

        Loop While _continue = True And Board_Solved = False



    End Sub

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

                        If ele.Candidates.Count = 0 Then
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

                        If ele.Candidates.Count = 0 Then
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

                        If ele.Candidates.Count = 0 Then
                            Error_Dectected = True
                        End If
                    Next
                End If

            Next
        Next

        Form.Lst_Debug.Items.Add("Removing candidates by subtraction")

    End Sub

    Public Sub FindIsolatedValues(ByRef Board As Board, ByRef Error_Detected As Boolean, ByRef _Continue As Boolean)

        For Rowcount = 0 To 8

            For Num = 1 To 9

                For Each ele In Board.Board_Rows(Rowcount)
                    If ele.Value = Num Then
                        GoTo SkipNumLine_1
                    End If
                Next

                Dim tempcount As Integer = 0
                Dim Tempcell As LogicCell

                For Each ele In Board.Board_Rows(Rowcount)

                    If tempcount > 1 Then
                        Tempcell = Nothing
                        Exit For
                    Else
                        Tempcell = ele
                        tempcount += 1
                    End If

                Next

                If tempcount = 1 Then
                    Tempcell.Candidates.Clear()
                    Tempcell.Candidates.Add(Num)
                    _Continue = True
                End If
SkipNumLine_1:
            Next
        Next

        For colcount = 0 To 8

            For Num = 1 To 9

                For Each ele In Board.Board_Columns(colcount)
                    If ele.Value = Num Then
                        GoTo SkipNumLine_2
                    End If
                Next

                Dim tempcount As Integer = 0
                Dim Tempcell As LogicCell

                For Each ele In Board.Board_Columns(colcount)

                    If tempcount > 1 Then
                        Tempcell = Nothing
                        Exit For
                    Else
                        Tempcell = ele
                        tempcount += 1
                    End If

                Next

                If tempcount = 1 Then
                    Tempcell.Candidates.Clear()
                    Tempcell.Candidates.Add(Num)
                    _Continue = True
                End If
SkipNumLine_2:
            Next
        Next

        For BoxRows = 0 To 2
            For BoxCols = 0 To 2

                For Num = 1 To 9

                    For Each ele In Board.Board_Boxes(BoxRows, BoxCols)
                        If ele.Value = Num Then
                            GoTo SkipNumLine_3
                        End If
                    Next

                    Dim tempcount As Integer = 0
                    Dim Tempcell As LogicCell

                    For Each ele In Board.Board_Boxes(BoxRows, BoxCols)

                        If tempcount > 1 Then
                            Tempcell = Nothing
                            Exit For
                        Else
                            Tempcell = ele
                            tempcount += 1
                        End If

                    Next

                    If tempcount = 1 Then
                        Tempcell.Candidates.Clear()
                        Tempcell.Candidates.Add(Num)
                        _Continue = True
                    End If
SkipNumLine_3:
                Next
            Next
        Next

        Form.Lst_Debug.Items.Add("Removing candidates by Isolation")

    End Sub

    Public Sub Convert_To_Values(ByRef Board As Board)

        For Rows = 0 To 8
            For Cols = 0 To 8

                If Board.Cells(Rows, Cols).Candidates.Count = 1 Then
                    Board.Cells(Rows, Cols).Value = Board.Cells(Rows, Cols).Candidates(0)
                    Board.Cells(Rows, Cols).Candidates.Clear()
                End If
            Next
        Next

        Form.Lst_Debug.Items.Add("Converting candidates to values...")

    End Sub

    Public Function IsBoardSolved(ByRef Board As Board)

        Form.Lst_Debug.Items.Add("Checking is board is solved")

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

        Form.Lst_Debug.Items.Add("")
        Form.Lst_Debug.Items.Add("Board Solved!")
        Return True

    End Function

    Public Sub IsBoardValid()

    End Sub

    Public Sub Bruteforce(ByRef mOrigBoard As Board, ByRef Solved As Boolean, ByRef _Error As Boolean)

    End Sub

    Public Sub SaveCurrentBoard()

    End Sub

    Public Sub DebugCandidates()

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
