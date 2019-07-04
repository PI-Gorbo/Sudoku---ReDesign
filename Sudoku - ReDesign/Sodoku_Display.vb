Partial Class Sodoku 'Functions related to the display of the sudoku board

    Public Const CANDIDATE_SIZEpx As Integer = 18
    Public Const CANDIDATE_PADDINGpx As Integer = 0
    Public Const TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
    Public Const CELL_PADDINGpx As Integer = 3
    Public Const TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
    Public Const BOX_PADDINGpx As Integer = 8

    Public Sub CreateBoard()

        For Rows = 0 To 8
            For Cols = 0 To 8

                If Not IsNothing(Cells(Rows, Cols)) Then
                    Cells(Rows, Cols) = New DisplayCell

                End If

                For lbl_Rows = 0 To 2
                    For lbl_Cols = 0 To 8

                    Next
                Next

            Next
        Next

    End Sub

    Public Sub UpdateToValueLabel()

    End Sub

    Public Sub UpdateDisplayFromBoard()

    End Sub

    Public Sub UpdateBoardFromDisplay()

    End Sub

    Public Sub ClearDisplay()

    End Sub

End Class
