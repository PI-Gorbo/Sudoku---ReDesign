Public Class BoardLandler 'Functions related to the logic side of board handling

    Public MainBoard As Board
    Public SolvedBoard As Board
    Public BoardChosen As String




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
