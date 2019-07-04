Public Class Sodoku 'General Functions 

    Public Cells(8, 8) As DisplayCell

    Public Sub New()
        NewGame()
    End Sub

    Public Sub NewGame()

    End Sub

    Public Sub PrimeNewBoard()

    End Sub

    Public Sub InitiateManualEntry()

    End Sub

    Public Sub FinaliseManualEntry()

    End Sub

    Public Sub LabelClick()
        HandleLabelInput()
    End Sub

    Public Sub HandleLabelInput()

    End Sub

    Public Sub KeypadButtonClick()
        HandleKeypadInput()
    End Sub

    Public Sub HandleKeypadInput()

    End Sub

    Public Sub UpdateKeypads()

    End Sub

End Class

Public Class DisplayCell

    Dim DataCell As LogicCell
    Dim Labels_Grid(2, 2) As Label
    Dim Labels_Array As List(Of Label)
    Dim ValueLabel As Label
    Dim SelectedLabel As Label
    Dim Candidates As List(Of Integer)
    Dim HasValueLabel As Boolean

    Public Sub New()

        Candidates.Capacity = 9

    End Sub

End Class
