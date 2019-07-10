<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Btn_NewGame = New System.Windows.Forms.Button()
        Me.Group_Board = New System.Windows.Forms.Panel()
        Me.Group_Controls = New System.Windows.Forms.Panel()
        Me.SubGroup_Misc = New System.Windows.Forms.Panel()
        Me.Btn_CheckValidity = New System.Windows.Forms.Button()
        Me.Btn_ResetBoard = New System.Windows.Forms.Button()
        Me.Btn_Hint = New System.Windows.Forms.Button()
        Me.SubGroup_Solving = New System.Windows.Forms.Panel()
        Me.Btn_PartialSolve = New System.Windows.Forms.Button()
        Me.Btn_SolveBoard = New System.Windows.Forms.Button()
        Me.Btn_Next = New System.Windows.Forms.Button()
        Me.Btn_SolveSingleCell = New System.Windows.Forms.Button()
        Me.SubGroup_Highlight = New System.Windows.Forms.Panel()
        Me.Rad_MedusaRed = New System.Windows.Forms.RadioButton()
        Me.Rad_MedusaBlue = New System.Windows.Forms.RadioButton()
        Me.Check_Medusa = New System.Windows.Forms.CheckBox()
        Me.Check_Highlighting = New System.Windows.Forms.CheckBox()
        Me.SubGroup_Keypad = New System.Windows.Forms.Panel()
        Me.Rad_Pencil = New System.Windows.Forms.RadioButton()
        Me.Rad_Pen = New System.Windows.Forms.RadioButton()
        Me.Check_Can_Removal = New System.Windows.Forms.CheckBox()
        Me.Check_ShowDebug = New System.Windows.Forms.CheckBox()
        Me.Keypad_9 = New System.Windows.Forms.Button()
        Me.Keypad_8 = New System.Windows.Forms.Button()
        Me.Keypad_7 = New System.Windows.Forms.Button()
        Me.Keypad_6 = New System.Windows.Forms.Button()
        Me.KeyPad_5 = New System.Windows.Forms.Button()
        Me.KeyPad_4 = New System.Windows.Forms.Button()
        Me.Keypad_3 = New System.Windows.Forms.Button()
        Me.KeyPad_2 = New System.Windows.Forms.Button()
        Me.KeyPad_1 = New System.Windows.Forms.Button()
        Me.SubGroup_Menu = New System.Windows.Forms.Panel()
        Me.lbl_ManualEntryAlert = New System.Windows.Forms.Label()
        Me.Btn_ManualEntry = New System.Windows.Forms.Button()
        Me.lbl_Difficulty = New System.Windows.Forms.Label()
        Me.DropDown_Difficulty = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Form = New System.Windows.Forms.ListBox()
        Me.lbl_boardname = New System.Windows.Forms.Label()
        Me.Group_Controls.SuspendLayout()
        Me.SubGroup_Misc.SuspendLayout()
        Me.SubGroup_Solving.SuspendLayout()
        Me.SubGroup_Highlight.SuspendLayout()
        Me.SubGroup_Keypad.SuspendLayout()
        Me.SubGroup_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_NewGame
        '
        Me.Btn_NewGame.Location = New System.Drawing.Point(5, 3)
        Me.Btn_NewGame.Name = "Btn_NewGame"
        Me.Btn_NewGame.Size = New System.Drawing.Size(152, 33)
        Me.Btn_NewGame.TabIndex = 0
        Me.Btn_NewGame.Text = "New Game"
        Me.Btn_NewGame.UseVisualStyleBackColor = True
        '
        'Group_Board
        '
        Me.Group_Board.BackColor = System.Drawing.Color.Silver
        Me.Group_Board.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Group_Board.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Board.Location = New System.Drawing.Point(45, 27)
        Me.Group_Board.Name = "Group_Board"
        Me.Group_Board.Size = New System.Drawing.Size(559, 553)
        Me.Group_Board.TabIndex = 1
        '
        'Group_Controls
        '
        Me.Group_Controls.BackColor = System.Drawing.Color.Silver
        Me.Group_Controls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Group_Controls.Controls.Add(Me.SubGroup_Misc)
        Me.Group_Controls.Controls.Add(Me.SubGroup_Solving)
        Me.Group_Controls.Controls.Add(Me.SubGroup_Highlight)
        Me.Group_Controls.Controls.Add(Me.SubGroup_Keypad)
        Me.Group_Controls.Controls.Add(Me.SubGroup_Menu)
        Me.Group_Controls.Controls.Add(Me.Button2)
        Me.Group_Controls.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Controls.Location = New System.Drawing.Point(614, 26)
        Me.Group_Controls.Name = "Group_Controls"
        Me.Group_Controls.Size = New System.Drawing.Size(322, 553)
        Me.Group_Controls.TabIndex = 2
        '
        'SubGroup_Misc
        '
        Me.SubGroup_Misc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SubGroup_Misc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SubGroup_Misc.Controls.Add(Me.Btn_CheckValidity)
        Me.SubGroup_Misc.Controls.Add(Me.Btn_ResetBoard)
        Me.SubGroup_Misc.Controls.Add(Me.Btn_Hint)
        Me.SubGroup_Misc.Location = New System.Drawing.Point(11, 449)
        Me.SubGroup_Misc.Name = "SubGroup_Misc"
        Me.SubGroup_Misc.Size = New System.Drawing.Size(301, 93)
        Me.SubGroup_Misc.TabIndex = 12
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
        Me.Btn_Hint.Enabled = False
        Me.Btn_Hint.Location = New System.Drawing.Point(79, 47)
        Me.Btn_Hint.Name = "Btn_Hint"
        Me.Btn_Hint.Size = New System.Drawing.Size(140, 37)
        Me.Btn_Hint.TabIndex = 9
        Me.Btn_Hint.Text = "Hint"
        Me.Btn_Hint.UseVisualStyleBackColor = True
        '
        'SubGroup_Solving
        '
        Me.SubGroup_Solving.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SubGroup_Solving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SubGroup_Solving.Controls.Add(Me.Btn_PartialSolve)
        Me.SubGroup_Solving.Controls.Add(Me.Btn_SolveBoard)
        Me.SubGroup_Solving.Controls.Add(Me.Btn_Next)
        Me.SubGroup_Solving.Controls.Add(Me.Btn_SolveSingleCell)
        Me.SubGroup_Solving.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubGroup_Solving.Location = New System.Drawing.Point(11, 341)
        Me.SubGroup_Solving.Name = "SubGroup_Solving"
        Me.SubGroup_Solving.Size = New System.Drawing.Size(301, 102)
        Me.SubGroup_Solving.TabIndex = 24
        '
        'Btn_PartialSolve
        '
        Me.Btn_PartialSolve.Location = New System.Drawing.Point(152, 52)
        Me.Btn_PartialSolve.Name = "Btn_PartialSolve"
        Me.Btn_PartialSolve.Size = New System.Drawing.Size(140, 37)
        Me.Btn_PartialSolve.TabIndex = 12
        Me.Btn_PartialSolve.Text = "Partial Solve"
        Me.Btn_PartialSolve.UseVisualStyleBackColor = True
        '
        'Btn_SolveBoard
        '
        Me.Btn_SolveBoard.Location = New System.Drawing.Point(6, 52)
        Me.Btn_SolveBoard.Name = "Btn_SolveBoard"
        Me.Btn_SolveBoard.Size = New System.Drawing.Size(140, 37)
        Me.Btn_SolveBoard.TabIndex = 11
        Me.Btn_SolveBoard.Text = "Solve Board"
        Me.Btn_SolveBoard.UseVisualStyleBackColor = True
        '
        'Btn_Next
        '
        Me.Btn_Next.Location = New System.Drawing.Point(152, 9)
        Me.Btn_Next.Name = "Btn_Next"
        Me.Btn_Next.Size = New System.Drawing.Size(140, 37)
        Me.Btn_Next.TabIndex = 10
        Me.Btn_Next.Text = "Next Step"
        Me.Btn_Next.UseVisualStyleBackColor = True
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
        'SubGroup_Highlight
        '
        Me.SubGroup_Highlight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SubGroup_Highlight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SubGroup_Highlight.Controls.Add(Me.Rad_MedusaRed)
        Me.SubGroup_Highlight.Controls.Add(Me.Rad_MedusaBlue)
        Me.SubGroup_Highlight.Controls.Add(Me.Check_Medusa)
        Me.SubGroup_Highlight.Controls.Add(Me.Check_Highlighting)
        Me.SubGroup_Highlight.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubGroup_Highlight.Location = New System.Drawing.Point(11, 266)
        Me.SubGroup_Highlight.Name = "SubGroup_Highlight"
        Me.SubGroup_Highlight.Size = New System.Drawing.Size(301, 69)
        Me.SubGroup_Highlight.TabIndex = 21
        '
        'Rad_MedusaRed
        '
        Me.Rad_MedusaRed.AutoSize = True
        Me.Rad_MedusaRed.Enabled = False
        Me.Rad_MedusaRed.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_MedusaRed.Location = New System.Drawing.Point(171, 37)
        Me.Rad_MedusaRed.Name = "Rad_MedusaRed"
        Me.Rad_MedusaRed.Size = New System.Drawing.Size(124, 24)
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
        Me.Rad_MedusaBlue.Size = New System.Drawing.Size(128, 24)
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
        Me.Check_Medusa.Size = New System.Drawing.Size(92, 24)
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
        Me.Check_Highlighting.Size = New System.Drawing.Size(203, 24)
        Me.Check_Highlighting.TabIndex = 0
        Me.Check_Highlighting.Text = "Candidate Highlighting"
        Me.Check_Highlighting.UseVisualStyleBackColor = True
        '
        'SubGroup_Keypad
        '
        Me.SubGroup_Keypad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SubGroup_Keypad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SubGroup_Keypad.Controls.Add(Me.Rad_Pencil)
        Me.SubGroup_Keypad.Controls.Add(Me.Rad_Pen)
        Me.SubGroup_Keypad.Controls.Add(Me.Check_Can_Removal)
        Me.SubGroup_Keypad.Controls.Add(Me.Check_ShowDebug)
        Me.SubGroup_Keypad.Controls.Add(Me.Keypad_9)
        Me.SubGroup_Keypad.Controls.Add(Me.Keypad_8)
        Me.SubGroup_Keypad.Controls.Add(Me.Keypad_7)
        Me.SubGroup_Keypad.Controls.Add(Me.Keypad_6)
        Me.SubGroup_Keypad.Controls.Add(Me.KeyPad_5)
        Me.SubGroup_Keypad.Controls.Add(Me.KeyPad_4)
        Me.SubGroup_Keypad.Controls.Add(Me.Keypad_3)
        Me.SubGroup_Keypad.Controls.Add(Me.KeyPad_2)
        Me.SubGroup_Keypad.Controls.Add(Me.KeyPad_1)
        Me.SubGroup_Keypad.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubGroup_Keypad.Location = New System.Drawing.Point(11, 89)
        Me.SubGroup_Keypad.Name = "SubGroup_Keypad"
        Me.SubGroup_Keypad.Size = New System.Drawing.Size(301, 171)
        Me.SubGroup_Keypad.TabIndex = 6
        '
        'Rad_Pencil
        '
        Me.Rad_Pencil.AutoSize = True
        Me.Rad_Pencil.Font = New System.Drawing.Font("Roboto", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Pencil.Location = New System.Drawing.Point(171, 44)
        Me.Rad_Pencil.Name = "Rad_Pencil"
        Me.Rad_Pencil.Size = New System.Drawing.Size(76, 24)
        Me.Rad_Pencil.TabIndex = 24
        Me.Rad_Pencil.TabStop = True
        Me.Rad_Pencil.Text = "Pencil"
        Me.Rad_Pencil.UseVisualStyleBackColor = True
        '
        'Rad_Pen
        '
        Me.Rad_Pen.AutoSize = True
        Me.Rad_Pen.Checked = True
        Me.Rad_Pen.Font = New System.Drawing.Font("Roboto", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Pen.Location = New System.Drawing.Point(171, 11)
        Me.Rad_Pen.Name = "Rad_Pen"
        Me.Rad_Pen.Size = New System.Drawing.Size(59, 24)
        Me.Rad_Pen.TabIndex = 23
        Me.Rad_Pen.TabStop = True
        Me.Rad_Pen.Text = "Pen"
        Me.Rad_Pen.UseVisualStyleBackColor = True
        '
        'Check_Can_Removal
        '
        Me.Check_Can_Removal.AutoSize = True
        Me.Check_Can_Removal.Checked = True
        Me.Check_Can_Removal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_Can_Removal.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_Can_Removal.Location = New System.Drawing.Point(171, 109)
        Me.Check_Can_Removal.Name = "Check_Can_Removal"
        Me.Check_Can_Removal.Size = New System.Drawing.Size(146, 24)
        Me.Check_Can_Removal.TabIndex = 22
        Me.Check_Can_Removal.Text = "Can Remv Alert"
        Me.Check_Can_Removal.UseVisualStyleBackColor = True
        '
        'Check_ShowDebug
        '
        Me.Check_ShowDebug.AutoSize = True
        Me.Check_ShowDebug.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_ShowDebug.Location = New System.Drawing.Point(171, 139)
        Me.Check_ShowDebug.Name = "Check_ShowDebug"
        Me.Check_ShowDebug.Size = New System.Drawing.Size(130, 24)
        Me.Check_ShowDebug.TabIndex = 3
        Me.Check_ShowDebug.Text = "Show Debug "
        Me.Check_ShowDebug.UseVisualStyleBackColor = True
        '
        'Keypad_9
        '
        Me.Keypad_9.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_9.Location = New System.Drawing.Point(114, 113)
        Me.Keypad_9.Name = "Keypad_9"
        Me.Keypad_9.Size = New System.Drawing.Size(45, 45)
        Me.Keypad_9.TabIndex = 20
        Me.Keypad_9.Tag = "9"
        Me.Keypad_9.Text = "9"
        Me.Keypad_9.UseVisualStyleBackColor = True
        '
        'Keypad_8
        '
        Me.Keypad_8.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_8.Location = New System.Drawing.Point(63, 113)
        Me.Keypad_8.Name = "Keypad_8"
        Me.Keypad_8.Size = New System.Drawing.Size(45, 45)
        Me.Keypad_8.TabIndex = 19
        Me.Keypad_8.Tag = "8"
        Me.Keypad_8.Text = "8"
        Me.Keypad_8.UseVisualStyleBackColor = True
        '
        'Keypad_7
        '
        Me.Keypad_7.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_7.Location = New System.Drawing.Point(12, 113)
        Me.Keypad_7.Name = "Keypad_7"
        Me.Keypad_7.Size = New System.Drawing.Size(45, 45)
        Me.Keypad_7.TabIndex = 18
        Me.Keypad_7.Tag = "7"
        Me.Keypad_7.Text = "7"
        Me.Keypad_7.UseVisualStyleBackColor = True
        '
        'Keypad_6
        '
        Me.Keypad_6.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_6.Location = New System.Drawing.Point(114, 62)
        Me.Keypad_6.Name = "Keypad_6"
        Me.Keypad_6.Size = New System.Drawing.Size(45, 45)
        Me.Keypad_6.TabIndex = 17
        Me.Keypad_6.Tag = "6"
        Me.Keypad_6.Text = "6"
        Me.Keypad_6.UseVisualStyleBackColor = True
        '
        'KeyPad_5
        '
        Me.KeyPad_5.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad_5.Location = New System.Drawing.Point(63, 62)
        Me.KeyPad_5.Name = "KeyPad_5"
        Me.KeyPad_5.Size = New System.Drawing.Size(45, 45)
        Me.KeyPad_5.TabIndex = 16
        Me.KeyPad_5.Tag = "5"
        Me.KeyPad_5.Text = "5"
        Me.KeyPad_5.UseVisualStyleBackColor = True
        '
        'KeyPad_4
        '
        Me.KeyPad_4.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad_4.Location = New System.Drawing.Point(12, 62)
        Me.KeyPad_4.Name = "KeyPad_4"
        Me.KeyPad_4.Size = New System.Drawing.Size(45, 45)
        Me.KeyPad_4.TabIndex = 15
        Me.KeyPad_4.Tag = "4"
        Me.KeyPad_4.Text = "4"
        Me.KeyPad_4.UseVisualStyleBackColor = True
        '
        'Keypad_3
        '
        Me.Keypad_3.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_3.Location = New System.Drawing.Point(114, 11)
        Me.Keypad_3.Name = "Keypad_3"
        Me.Keypad_3.Size = New System.Drawing.Size(45, 45)
        Me.Keypad_3.TabIndex = 14
        Me.Keypad_3.Tag = "3"
        Me.Keypad_3.Text = "3"
        Me.Keypad_3.UseVisualStyleBackColor = True
        '
        'KeyPad_2
        '
        Me.KeyPad_2.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad_2.Location = New System.Drawing.Point(63, 11)
        Me.KeyPad_2.Name = "KeyPad_2"
        Me.KeyPad_2.Size = New System.Drawing.Size(45, 45)
        Me.KeyPad_2.TabIndex = 13
        Me.KeyPad_2.Tag = "2"
        Me.KeyPad_2.Text = "2"
        Me.KeyPad_2.UseVisualStyleBackColor = True
        '
        'KeyPad_1
        '
        Me.KeyPad_1.Font = New System.Drawing.Font("Roboto", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPad_1.Location = New System.Drawing.Point(12, 11)
        Me.KeyPad_1.Name = "KeyPad_1"
        Me.KeyPad_1.Size = New System.Drawing.Size(45, 45)
        Me.KeyPad_1.TabIndex = 12
        Me.KeyPad_1.Tag = "1"
        Me.KeyPad_1.Text = "1"
        Me.KeyPad_1.UseVisualStyleBackColor = True
        '
        'SubGroup_Menu
        '
        Me.SubGroup_Menu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SubGroup_Menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SubGroup_Menu.Controls.Add(Me.lbl_ManualEntryAlert)
        Me.SubGroup_Menu.Controls.Add(Me.Btn_ManualEntry)
        Me.SubGroup_Menu.Controls.Add(Me.lbl_Difficulty)
        Me.SubGroup_Menu.Controls.Add(Me.DropDown_Difficulty)
        Me.SubGroup_Menu.Controls.Add(Me.Btn_NewGame)
        Me.SubGroup_Menu.Font = New System.Drawing.Font("Roboto", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubGroup_Menu.Location = New System.Drawing.Point(11, 9)
        Me.SubGroup_Menu.Name = "SubGroup_Menu"
        Me.SubGroup_Menu.Size = New System.Drawing.Size(301, 74)
        Me.SubGroup_Menu.TabIndex = 1
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
        Me.lbl_ManualEntryAlert.Size = New System.Drawing.Size(157, 22)
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
        Me.lbl_Difficulty.Size = New System.Drawing.Size(79, 20)
        Me.lbl_Difficulty.TabIndex = 4
        Me.lbl_Difficulty.Text = "Difficulty:"
        '
        'DropDown_Difficulty
        '
        Me.DropDown_Difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDown_Difficulty.FormattingEnabled = True
        Me.DropDown_Difficulty.Items.AddRange(New Object() {"Easy", "Medium", "Hard", "Expert", "Custom"})
        Me.DropDown_Difficulty.Location = New System.Drawing.Point(67, 42)
        Me.DropDown_Difficulty.Name = "DropDown_Difficulty"
        Me.DropDown_Difficulty.Size = New System.Drawing.Size(88, 31)
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
        'Form
        '
        Me.Form.BackColor = System.Drawing.Color.Silver
        Me.Form.Font = New System.Drawing.Font("Roboto", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Form.FormattingEnabled = True
        Me.Form.ItemHeight = 15
        Me.Form.Location = New System.Drawing.Point(947, 27)
        Me.Form.Name = "Form"
        Me.Form.Size = New System.Drawing.Size(246, 544)
        Me.Form.TabIndex = 3
        '
        'lbl_boardname
        '
        Me.lbl_boardname.AutoSize = True
        Me.lbl_boardname.Font = New System.Drawing.Font("Roboto", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_boardname.ForeColor = System.Drawing.Color.White
        Me.lbl_boardname.Location = New System.Drawing.Point(298, 4)
        Me.lbl_boardname.Name = "lbl_boardname"
        Me.lbl_boardname.Size = New System.Drawing.Size(0, 20)
        Me.lbl_boardname.TabIndex = 4
        Me.lbl_boardname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(16, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1246, 607)
        Me.Controls.Add(Me.lbl_boardname)
        Me.Controls.Add(Me.Form)
        Me.Controls.Add(Me.Group_Controls)
        Me.Controls.Add(Me.Group_Board)
        Me.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Group_Controls.ResumeLayout(False)
        Me.SubGroup_Misc.ResumeLayout(False)
        Me.SubGroup_Solving.ResumeLayout(False)
        Me.SubGroup_Highlight.ResumeLayout(False)
        Me.SubGroup_Highlight.PerformLayout()
        Me.SubGroup_Keypad.ResumeLayout(False)
        Me.SubGroup_Keypad.PerformLayout()
        Me.SubGroup_Menu.ResumeLayout(False)
        Me.SubGroup_Menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_NewGame As Button
    Friend WithEvents Group_Board As Panel
    Friend WithEvents Group_Controls As Panel
    Friend WithEvents SubGroup_Menu As Panel
    Friend WithEvents lbl_ManualEntryAlert As Label
    Friend WithEvents Btn_ManualEntry As Button
    Friend WithEvents lbl_Difficulty As Label
    Friend WithEvents DropDown_Difficulty As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents SubGroup_Keypad As Panel
    Friend WithEvents SubGroup_Solving As Panel
    Friend WithEvents SubGroup_Highlight As Panel
    Friend WithEvents Rad_MedusaRed As RadioButton
    Friend WithEvents Rad_MedusaBlue As RadioButton
    Friend WithEvents Check_Medusa As CheckBox
    Friend WithEvents Check_Highlighting As CheckBox
    Friend WithEvents Keypad_9 As Button
    Friend WithEvents Keypad_8 As Button
    Friend WithEvents Keypad_7 As Button
    Friend WithEvents Keypad_6 As Button
    Friend WithEvents KeyPad_5 As Button
    Friend WithEvents KeyPad_4 As Button
    Friend WithEvents Keypad_3 As Button
    Friend WithEvents KeyPad_2 As Button
    Friend WithEvents KeyPad_1 As Button
    Friend WithEvents SubGroup_Misc As Panel
    Friend WithEvents Btn_CheckValidity As Button
    Friend WithEvents Btn_ResetBoard As Button
    Friend WithEvents Btn_Hint As Button
    Friend WithEvents Btn_SolveBoard As Button
    Friend WithEvents Btn_Next As Button
    Friend WithEvents Btn_SolveSingleCell As Button
    Friend WithEvents Check_ShowDebug As CheckBox
    Friend WithEvents Form As ListBox
    Friend WithEvents Check_Can_Removal As CheckBox
    Friend WithEvents Rad_Pencil As RadioButton
    Friend WithEvents Rad_Pen As RadioButton
    Friend WithEvents Btn_PartialSolve As Button
    Friend WithEvents lbl_boardname As Label
End Class
