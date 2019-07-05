<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btn_NewGame = New System.Windows.Forms.Button()
        Me.Group_Board = New System.Windows.Forms.Panel()
        Me.Group_Controls = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Btn_CheckValidity = New System.Windows.Forms.Button()
        Me.Btn_ResetBoard = New System.Windows.Forms.Button()
        Me.Btn_Hint = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Btn_SolveBoard = New System.Windows.Forms.Button()
        Me.Btn_PartialSolve = New System.Windows.Forms.Button()
        Me.Btn_SolveSingleCell = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Rad_MedusaRed = New System.Windows.Forms.RadioButton()
        Me.Rad_MedusaBlue = New System.Windows.Forms.RadioButton()
        Me.Check_Medusa = New System.Windows.Forms.CheckBox()
        Me.Check_Highlighting = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Rad_Pen = New System.Windows.Forms.RadioButton()
        Me.Rad_Pencil = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_ManualEntryAlert = New System.Windows.Forms.Label()
        Me.Btn_ManualEntry = New System.Windows.Forms.Button()
        Me.lbl_Difficulty = New System.Windows.Forms.Label()
        Me.DropDown_Difficulty = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Check_ShowDebug = New System.Windows.Forms.CheckBox()
        Me.Lst_Debug = New System.Windows.Forms.ListBox()
        Me.Group_Controls.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_NewGame
        '
        Me.Btn_NewGame.Location = New System.Drawing.Point(3, 3)
        Me.Btn_NewGame.Name = "Btn_NewGame"
        Me.Btn_NewGame.Size = New System.Drawing.Size(149, 33)
        Me.Btn_NewGame.TabIndex = 0
        Me.Btn_NewGame.Text = "New Game"
        Me.Btn_NewGame.UseVisualStyleBackColor = True
        '
        'Group_Board
        '
        Me.Group_Board.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Group_Board.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Group_Board.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Board.Location = New System.Drawing.Point(29, 27)
        Me.Group_Board.Name = "Group_Board"
        Me.Group_Board.Size = New System.Drawing.Size(661, 553)
        Me.Group_Board.TabIndex = 1
        '
        'Group_Controls
        '
        Me.Group_Controls.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Group_Controls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Group_Controls.Controls.Add(Me.Panel5)
        Me.Group_Controls.Controls.Add(Me.Panel4)
        Me.Group_Controls.Controls.Add(Me.Panel3)
        Me.Group_Controls.Controls.Add(Me.Panel2)
        Me.Group_Controls.Controls.Add(Me.Panel1)
        Me.Group_Controls.Controls.Add(Me.Button2)
        Me.Group_Controls.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Controls.Location = New System.Drawing.Point(701, 27)
        Me.Group_Controls.Name = "Group_Controls"
        Me.Group_Controls.Size = New System.Drawing.Size(322, 553)
        Me.Group_Controls.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Btn_CheckValidity)
        Me.Panel5.Controls.Add(Me.Btn_ResetBoard)
        Me.Panel5.Controls.Add(Me.Btn_Hint)
        Me.Panel5.Location = New System.Drawing.Point(11, 449)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(301, 93)
        Me.Panel5.TabIndex = 12
        '
        'Btn_CheckValidity
        '
        Me.Btn_CheckValidity.Location = New System.Drawing.Point(9, 4)
        Me.Btn_CheckValidity.Name = "Btn_CheckValidity"
        Me.Btn_CheckValidity.Size = New System.Drawing.Size(140, 37)
        Me.Btn_CheckValidity.TabIndex = 11
        Me.Btn_CheckValidity.Text = "Check Validity"
        Me.Btn_CheckValidity.UseVisualStyleBackColor = True
        '
        'Btn_ResetBoard
        '
        Me.Btn_ResetBoard.Location = New System.Drawing.Point(155, 4)
        Me.Btn_ResetBoard.Name = "Btn_ResetBoard"
        Me.Btn_ResetBoard.Size = New System.Drawing.Size(136, 37)
        Me.Btn_ResetBoard.TabIndex = 10
        Me.Btn_ResetBoard.Text = "Reset Board"
        Me.Btn_ResetBoard.UseVisualStyleBackColor = True
        '
        'Btn_Hint
        '
        Me.Btn_Hint.Location = New System.Drawing.Point(79, 47)
        Me.Btn_Hint.Name = "Btn_Hint"
        Me.Btn_Hint.Size = New System.Drawing.Size(140, 37)
        Me.Btn_Hint.TabIndex = 9
        Me.Btn_Hint.Text = "Hint"
        Me.Btn_Hint.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Btn_SolveBoard)
        Me.Panel4.Controls.Add(Me.Btn_PartialSolve)
        Me.Panel4.Controls.Add(Me.Btn_SolveSingleCell)
        Me.Panel4.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(11, 341)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(301, 102)
        Me.Panel4.TabIndex = 24
        '
        'Btn_SolveBoard
        '
        Me.Btn_SolveBoard.Location = New System.Drawing.Point(78, 52)
        Me.Btn_SolveBoard.Name = "Btn_SolveBoard"
        Me.Btn_SolveBoard.Size = New System.Drawing.Size(140, 37)
        Me.Btn_SolveBoard.TabIndex = 11
        Me.Btn_SolveBoard.Text = "Solve Board"
        Me.Btn_SolveBoard.UseVisualStyleBackColor = True
        '
        'Btn_PartialSolve
        '
        Me.Btn_PartialSolve.Location = New System.Drawing.Point(152, 9)
        Me.Btn_PartialSolve.Name = "Btn_PartialSolve"
        Me.Btn_PartialSolve.Size = New System.Drawing.Size(140, 37)
        Me.Btn_PartialSolve.TabIndex = 10
        Me.Btn_PartialSolve.Text = "Partial Solve"
        Me.Btn_PartialSolve.UseVisualStyleBackColor = True
        '
        'Btn_SolveSingleCell
        '
        Me.Btn_SolveSingleCell.Location = New System.Drawing.Point(6, 9)
        Me.Btn_SolveSingleCell.Name = "Btn_SolveSingleCell"
        Me.Btn_SolveSingleCell.Size = New System.Drawing.Size(140, 37)
        Me.Btn_SolveSingleCell.TabIndex = 9
        Me.Btn_SolveSingleCell.Text = "Solve Cell"
        Me.Btn_SolveSingleCell.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Rad_MedusaRed)
        Me.Panel3.Controls.Add(Me.Rad_MedusaBlue)
        Me.Panel3.Controls.Add(Me.Check_Medusa)
        Me.Panel3.Controls.Add(Me.Check_Highlighting)
        Me.Panel3.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(11, 266)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(301, 69)
        Me.Panel3.TabIndex = 21
        '
        'Rad_MedusaRed
        '
        Me.Rad_MedusaRed.AutoSize = True
        Me.Rad_MedusaRed.Enabled = False
        Me.Rad_MedusaRed.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_MedusaRed.Location = New System.Drawing.Point(171, 37)
        Me.Rad_MedusaRed.Name = "Rad_MedusaRed"
        Me.Rad_MedusaRed.Size = New System.Drawing.Size(96, 19)
        Me.Rad_MedusaRed.TabIndex = 23
        Me.Rad_MedusaRed.Text = "Medusa Red"
        Me.Rad_MedusaRed.UseVisualStyleBackColor = True
        '
        'Rad_MedusaBlue
        '
        Me.Rad_MedusaBlue.AutoSize = True
        Me.Rad_MedusaBlue.Checked = True
        Me.Rad_MedusaBlue.Enabled = False
        Me.Rad_MedusaBlue.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_MedusaBlue.Location = New System.Drawing.Point(171, 12)
        Me.Rad_MedusaBlue.Name = "Rad_MedusaBlue"
        Me.Rad_MedusaBlue.Size = New System.Drawing.Size(99, 19)
        Me.Rad_MedusaBlue.TabIndex = 22
        Me.Rad_MedusaBlue.TabStop = True
        Me.Rad_MedusaBlue.Text = "Medusa Blue"
        Me.Rad_MedusaBlue.UseVisualStyleBackColor = True
        '
        'Check_Medusa
        '
        Me.Check_Medusa.AutoSize = True
        Me.Check_Medusa.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_Medusa.Location = New System.Drawing.Point(6, 37)
        Me.Check_Medusa.Name = "Check_Medusa"
        Me.Check_Medusa.Size = New System.Drawing.Size(72, 19)
        Me.Check_Medusa.TabIndex = 1
        Me.Check_Medusa.Text = "Medusa"
        Me.Check_Medusa.UseVisualStyleBackColor = True
        '
        'Check_Highlighting
        '
        Me.Check_Highlighting.AutoSize = True
        Me.Check_Highlighting.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_Highlighting.Location = New System.Drawing.Point(6, 12)
        Me.Check_Highlighting.Name = "Check_Highlighting"
        Me.Check_Highlighting.Size = New System.Drawing.Size(153, 19)
        Me.Check_Highlighting.TabIndex = 0
        Me.Check_Highlighting.Text = "Candidate Highlighting"
        Me.Check_Highlighting.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Check_ShowDebug)
        Me.Panel2.Controls.Add(Me.Button9)
        Me.Panel2.Controls.Add(Me.Button8)
        Me.Panel2.Controls.Add(Me.Button7)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.Rad_Pen)
        Me.Panel2.Controls.Add(Me.Rad_Pencil)
        Me.Panel2.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(11, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(301, 171)
        Me.Panel2.TabIndex = 6
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(114, 113)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(45, 45)
        Me.Button9.TabIndex = 20
        Me.Button9.Text = "9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(63, 113)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(45, 45)
        Me.Button8.TabIndex = 19
        Me.Button8.Text = "8"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(12, 113)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(45, 45)
        Me.Button7.TabIndex = 18
        Me.Button7.Text = "7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(114, 62)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(45, 45)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(63, 62)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(45, 45)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(12, 62)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(45, 45)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(114, 11)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(45, 45)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(63, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 45)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "2"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(12, 11)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(45, 45)
        Me.Button10.TabIndex = 12
        Me.Button10.Text = "1"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Rad_Pen
        '
        Me.Rad_Pen.AutoSize = True
        Me.Rad_Pen.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Pen.Location = New System.Drawing.Point(171, 37)
        Me.Rad_Pen.Name = "Rad_Pen"
        Me.Rad_Pen.Size = New System.Drawing.Size(47, 19)
        Me.Rad_Pen.TabIndex = 4
        Me.Rad_Pen.Text = "Pen"
        Me.Rad_Pen.UseVisualStyleBackColor = True
        '
        'Rad_Pencil
        '
        Me.Rad_Pencil.AutoSize = True
        Me.Rad_Pencil.Checked = True
        Me.Rad_Pencil.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Pencil.Location = New System.Drawing.Point(171, 11)
        Me.Rad_Pencil.Name = "Rad_Pencil"
        Me.Rad_Pencil.Size = New System.Drawing.Size(60, 19)
        Me.Rad_Pencil.TabIndex = 3
        Me.Rad_Pencil.TabStop = True
        Me.Rad_Pencil.Text = "Pencil"
        Me.Rad_Pencil.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbl_ManualEntryAlert)
        Me.Panel1.Controls.Add(Me.Btn_ManualEntry)
        Me.Panel1.Controls.Add(Me.lbl_Difficulty)
        Me.Panel1.Controls.Add(Me.DropDown_Difficulty)
        Me.Panel1.Controls.Add(Me.Btn_NewGame)
        Me.Panel1.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(11, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(301, 74)
        Me.Panel1.TabIndex = 1
        '
        'lbl_ManualEntryAlert
        '
        Me.lbl_ManualEntryAlert.AutoSize = True
        Me.lbl_ManualEntryAlert.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.lbl_ManualEntryAlert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_ManualEntryAlert.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ManualEntryAlert.ForeColor = System.Drawing.Color.Black
        Me.lbl_ManualEntryAlert.Location = New System.Drawing.Point(171, 46)
        Me.lbl_ManualEntryAlert.Name = "lbl_ManualEntryAlert"
        Me.lbl_ManualEntryAlert.Size = New System.Drawing.Size(117, 17)
        Me.lbl_ManualEntryAlert.TabIndex = 5
        Me.lbl_ManualEntryAlert.Text = "Manual Entry Mode"
        Me.lbl_ManualEntryAlert.Visible = False
        '
        'Btn_ManualEntry
        '
        Me.Btn_ManualEntry.Location = New System.Drawing.Point(162, 3)
        Me.Btn_ManualEntry.Name = "Btn_ManualEntry"
        Me.Btn_ManualEntry.Size = New System.Drawing.Size(134, 33)
        Me.Btn_ManualEntry.TabIndex = 2
        Me.Btn_ManualEntry.Text = "Manual Entry"
        Me.Btn_ManualEntry.UseVisualStyleBackColor = True
        '
        'lbl_Difficulty
        '
        Me.lbl_Difficulty.AutoSize = True
        Me.lbl_Difficulty.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Difficulty.Location = New System.Drawing.Point(3, 48)
        Me.lbl_Difficulty.Name = "lbl_Difficulty"
        Me.lbl_Difficulty.Size = New System.Drawing.Size(60, 15)
        Me.lbl_Difficulty.TabIndex = 4
        Me.lbl_Difficulty.Text = "Difficulty:"
        '
        'DropDown_Difficulty
        '
        Me.DropDown_Difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDown_Difficulty.FormattingEnabled = True
        Me.DropDown_Difficulty.Items.AddRange(New Object() {"Easy", "Medium", "Hard", "Impossible", "Custom"})
        Me.DropDown_Difficulty.Location = New System.Drawing.Point(66, 42)
        Me.DropDown_Difficulty.Name = "DropDown_Difficulty"
        Me.DropDown_Difficulty.Size = New System.Drawing.Size(86, 26)
        Me.DropDown_Difficulty.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(444, 65)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Check_ShowDebug
        '
        Me.Check_ShowDebug.AutoSize = True
        Me.Check_ShowDebug.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ShowDebug.Location = New System.Drawing.Point(171, 139)
        Me.Check_ShowDebug.Name = "Check_ShowDebug"
        Me.Check_ShowDebug.Size = New System.Drawing.Size(101, 19)
        Me.Check_ShowDebug.TabIndex = 3
        Me.Check_ShowDebug.Text = "Show Debug "
        Me.Check_ShowDebug.UseVisualStyleBackColor = True
        '
        'Lst_Debug
        '
        Me.Lst_Debug.FormattingEnabled = True
        Me.Lst_Debug.ItemHeight = 14
        Me.Lst_Debug.Location = New System.Drawing.Point(1034, 28)
        Me.Lst_Debug.Name = "Lst_Debug"
        Me.Lst_Debug.Size = New System.Drawing.Size(246, 550)
        Me.Lst_Debug.TabIndex = 3
        '
        'Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1292, 607)
        Me.Controls.Add(Me.Lst_Debug)
        Me.Controls.Add(Me.Group_Controls)
        Me.Controls.Add(Me.Group_Board)
        Me.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Form"
        Me.Text = "Form1"
        Me.Group_Controls.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_NewGame As Button
    Friend WithEvents Group_Board As Panel
    Friend WithEvents Group_Controls As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_ManualEntryAlert As Label
    Friend WithEvents Btn_ManualEntry As Button
    Friend WithEvents lbl_Difficulty As Label
    Friend WithEvents DropDown_Difficulty As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Rad_MedusaRed As RadioButton
    Friend WithEvents Rad_MedusaBlue As RadioButton
    Friend WithEvents Check_Medusa As CheckBox
    Friend WithEvents Check_Highlighting As CheckBox
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Rad_Pen As RadioButton
    Friend WithEvents Rad_Pencil As RadioButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Btn_CheckValidity As Button
    Friend WithEvents Btn_ResetBoard As Button
    Friend WithEvents Btn_Hint As Button
    Friend WithEvents Btn_SolveBoard As Button
    Friend WithEvents Btn_PartialSolve As Button
    Friend WithEvents Btn_SolveSingleCell As Button
    Friend WithEvents Check_ShowDebug As CheckBox
    Friend WithEvents Lst_Debug As ListBox
End Class
