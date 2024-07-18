<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mail
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.entry = New System.Windows.Forms.Label()
        Me.update = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtentry = New System.Windows.Forms.TextBox()
        Me.txtupdate = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcomment = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtacccount = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1296, 95)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(88, 47)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(8, 8)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(30, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 39)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'entry
        '
        Me.entry.AutoSize = True
        Me.entry.Location = New System.Drawing.Point(37, 266)
        Me.entry.Name = "entry"
        Me.entry.Size = New System.Drawing.Size(71, 17)
        Me.entry.TabIndex = 2
        Me.entry.Text = "EntryDate"
        '
        'update
        '
        Me.update.AutoSize = True
        Me.update.Location = New System.Drawing.Point(37, 310)
        Me.update.Name = "update"
        Me.update.Size = New System.Drawing.Size(84, 17)
        Me.update.TabIndex = 3
        Me.update.Text = "UpdateDate"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.ComboBox1.Location = New System.Drawing.Point(227, 216)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Catogaties"
        '
        'txtentry
        '
        Me.txtentry.Location = New System.Drawing.Point(227, 266)
        Me.txtentry.Name = "txtentry"
        Me.txtentry.Size = New System.Drawing.Size(121, 22)
        Me.txtentry.TabIndex = 8
        '
        'txtupdate
        '
        Me.txtupdate.Location = New System.Drawing.Point(227, 310)
        Me.txtupdate.Name = "txtupdate"
        Me.txtupdate.Size = New System.Drawing.Size(121, 22)
        Me.txtupdate.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PictureBox1.Location = New System.Drawing.Point(227, 415)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(126, 114)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 361)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Comment"
        '
        'txtcomment
        '
        Me.txtcomment.Location = New System.Drawing.Point(227, 361)
        Me.txtcomment.Name = "txtcomment"
        Me.txtcomment.Size = New System.Drawing.Size(121, 22)
        Me.txtcomment.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Acccount Number"
        '
        'txtacccount
        '
        Me.txtacccount.Location = New System.Drawing.Point(227, 172)
        Me.txtacccount.Name = "txtacccount"
        Me.txtacccount.Size = New System.Drawing.Size(121, 22)
        Me.txtacccount.TabIndex = 15
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(403, 126)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(885, 413)
        Me.DataGridView1.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(37, 448)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 23)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "Save Document"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(40, 599)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(98, 36)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "save"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'mail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 701)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtacccount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtcomment)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtupdate)
        Me.Controls.Add(Me.txtentry)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.update)
        Me.Controls.Add(Me.entry)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "mail"
        Me.Text = "mail"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents entry As Label
    Friend WithEvents update As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtentry As TextBox
    Friend WithEvents txtupdate As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtcomment As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtacccount As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
